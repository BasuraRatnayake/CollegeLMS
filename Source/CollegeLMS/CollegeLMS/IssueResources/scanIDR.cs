using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.TransactionServer;

namespace CollegeLMS.IssueResources{
    public partial class scanIDR:Form{
        private String operationType;//Type of Operation to be performed
        public scanIDR(String operationType){
            InitializeComponent();
            camera = new Camera(picBook);

            this.operationType=operationType;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        TransactionsClient transaction = new TransactionsClient();//Transaction Server Connection
        Camera camera = null;//Camera

        private String[] resDetails;//Store Resource code and type
        private String[] memDetails;//Store member nic and uid
        private Boolean IDScanner = false;//ID Scanner false

        private String tableName;//Resource Table

        private void scanCode(){//Scan Resource
            if(IDScanner){
                ofdPicture.FileName = "cameraImage.jpeg";
                txtUsername.Text = camera.decodeQR();

                effects.showError(picCard, new Label(), "Invalid");

                if(txtUsername.Text != "") {
                    String[] licData = txtUsername.Text.Split('|');//Split QR Code
                    if(licData.Length == 3)                        
                        if(!server.regIDsAvailable(licData[2], licData[1])) {//Check with Server
                            camera.stopCamera();

                            memDetails = new string[] { licData[1], licData[2] };
                            schedule.Stop();

                            String regCode = server.getMemberPass(licData[1]).Split('|')[1];//Get member registration code
                            if(operationType == "IssueResource") {
                                if(transaction.unReturnedCount(regCode)<2) {
                                    IDScanner=false;

                                    issueR showB = new issueR(resDetails, memDetails);

                                    lblScanner.Text="RESOURCE SCANNER";
                                    effects.showOkay(picCard, new Label(), "Valid");
                                    btnStop.Text="SCAN RESOURCE";

                                    this.Hide();
                                    effects.showDialog(showB);
                                    showB.BringToFront();
                                }else{
                                    label4.Text="Member Borrow Resource Limit Reached.";
                                    label4.Visible=true;
                                }
                            }else if(operationType == "ReturnResource"){
                                if(transaction.returnResource(regCode, resDetails[0], tableName)){
                                    MessageBox.Show("Resource Returned", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }

                            btnStop.Enabled = false;
                            btnStart.Enabled = true;
                        }
                }
            }else{
                ofdPicture.FileName = "cameraImage.jpeg";
                txtUsername.Text = camera.decodeQR();

                effects.showError(picUsername, new Label(), "Invalid");

                if(txtUsername.Text != "") {
                    String[] licData = txtUsername.Text.Split('|');//Split QR Code
                    if(licData.Length == 3)
                        if(server.resouceValid(licData[1], licData[2])) {//Check with Server
                            camera.stopCamera();

                            resDetails = new string[] { licData[1], licData[2] };

                            schedule.Stop();

                            tableName = licData[2];
                            if(tableName.Contains("_"))
                                tableName = tableName.Split('_')[0].ToLower();
                            else
                                tableName = tableName.ToLower();

                            switch(tableName) {
                                case "book":
                                    tableName = "issueBook";
                                    break;
                                case "newm":
                                    tableName = "issueNewM";
                                    break;
                                case "vidd":
                                    tableName = "issueVidD";
                                    break;
                                case "comic":
                                    tableName = "issueComic";
                                    break;
                                case "pastp":
                                    tableName = "issuePastP";
                                    break;
                            }

                            if(operationType == "IssueResource"){
                                if(transaction.resourcedIssued(tableName, licData[1])){
                                    IDScanner=true;
                                    lblScanner.Text="ID CARD SCANNER";
                                    effects.showOkay(picUsername, new Label(), "Valid");
                                    btnStop.Text="SCAN ID CARD";
                                }else{
                                    label4.Text="This Is An Issued Resource.";
                                    label4.Visible=true;
                                }
                            }else if(operationType == "ReturnResource"){
                                IDScanner=true;
                                lblScanner.Text="ID CARD SCANNER";
                                effects.showOkay(picUsername, new Label(), "Valid");
                                btnStop.Text="SCAN ID CARD";
                            }                            

                            btnStop.Enabled = false;
                            btnStart.Enabled = true;
                        }
                }
            }
        }
        
        private void btnStop_Click(object sender, EventArgs e){
            schedule.Tick += Schedule_Tick;
            schedule.Start();            
        }

        private void Schedule_Tick(object sender, EventArgs e){
            scanCode();
        }

        private void btnStart_Click(object sender, EventArgs e){
            camera = new Camera(picBook);
            camera.startCamera();

            ofdPicture.FileName = "cameraImage.jpeg";

            btnStop.Enabled = true;
            btnStart.Enabled = false;
            label4.Visible = false;
            picBook.Image = null;
        }

        private void scanItem_FormClosing(object sender, FormClosingEventArgs e){
            camera.stopCamera();
            schedule.Stop();
        }
    }
}
