using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS.DashBoard{
    public partial class scanItem:Form{
        public scanItem() {
            InitializeComponent();
            camera = new Camera(picBook);
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validateD = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        Camera camera = null;//Camera

        private void scanCode(){//Scan Resource
            picUsername.Visible = true;
            label3.Visible = true;

            ofdPicture.FileName = "cameraImage.jpeg";
            txtUsername.Text = camera.decodeQR();

            pnlUsername.Visible = false;
            effects.showError(picUsername, new Label(), "Invalid");

            if(txtUsername.Text != ""){
                String[] licData = txtUsername.Text.Split('|');//Split QR Code
                if(licData.Length == 3)
                    if(server.resouceValid(licData[1], licData[2])) {//Check with Server
                        camera.stopCamera();

                        txtType.Text = licData[2];
                        txtRCode.Text = licData[1];

                        String tableName = "";
                        String searchTerm = "";
                        if(licData[2].Contains("_"))
                            tableName = licData[2].Split('_')[0].ToLower();
                        else
                            tableName = licData[2].ToLower();

                        switch(tableName) {
                            case "book":
                                tableName = "books";
                                searchTerm = "isbn = '" + txtRCode.Text + "'";

                                txtType.Text = "E Book";
                                if(licData[2].Split('_')[1].ToLower() == "n") 
                                    txtType.Text = "Book";
                                break;
                            case "comic":
                                tableName = "comics";
                                searchTerm = "coId = " + txtRCode.Text;

                                txtType.Text = "Comic";
                                break;
                            case "vidd":
                                tableName = "vidDoc";
                                searchTerm = "vdId = " + txtRCode.Text;

                                txtType.Text = "Documentry";
                                if(licData[2].Split('_')[1].ToLower() == "t")
                                    txtType.Text = "Video Tutorial";
                                break;
                            case "pastp":
                                tableName = "pastPapers";
                                searchTerm = "ppID = " + txtRCode.Text;

                                txtType.Text = "Past Papers";
                                break;
                            case "newm":
                                tableName = "newspapersMags";
                                searchTerm = "nmId = " + txtRCode.Text;

                                txtType.Text = "Newspaper";
                                if(licData[2].Split('_')[1].ToLower() == "m")
                                    txtType.Text = "Magazine";
                                break;
                        }

                        txtTitle.Text = server.getTitle(tableName, searchTerm);

                        schedule.Stop();

                        btnStop.Enabled = false;
                        btnStart.Enabled = true;

                        effects.showOkay(picUsername, new Label(), "Valid");

                        btnStop.Enabled = false;
                        btnStart.Enabled = true;
                        picUsername.Visible = true;
                        pnlUsername.Visible = true;
                        label3.Visible = true;
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
            picUsername.Visible = false;
            pnlUsername.Visible = false;
            label3.Visible = false;
            picBook.Image = null;
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e){
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void txtUsername_MouseLeave(object sender, EventArgs e){
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void scanItem_FormClosing(object sender, FormClosingEventArgs e){
            camera.stopCamera();
            schedule.Stop();
        }
    }
}
