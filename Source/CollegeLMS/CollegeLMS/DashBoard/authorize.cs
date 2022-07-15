using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS.DashBoard{
    public partial class authorize:Form{
        private Form direction = null;
        private String toForm = "";

        public authorize(String form){
            InitializeComponent();

            toForm = form;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validateD = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        Camera camera = null;//Camera

        private void scanCode() {//Scan Library CardpicUsername.Visible = true;
            label3.Visible = true;

            ofdPicture.FileName = "cameraImage.jpeg";
            txtUsername.Text = camera.decodeQR();

            effects.showError(picUsername, new Label(), "Invalid");

            if(txtUsername.Text != "") {
                String[] licData = txtUsername.Text.Split('|');//Split QR Code
                if(licData.Length == 3)
                    if(checkWithServer(licData[2], licData[1])) {//Check with Server
                        camera.stopCamera();
                        schedule.Stop();
                        String username = server.getMemberPass(licData[1]);
                        username = username.Split('|')[1];

                        username = server.getMemberUsername(username).ToLower();
                        if(username.Contains("xoxo")) {
                            effects.showOkay(picUsername, new Label(), "Valid");
                            switch(toForm) {
                                case "revokeMember":
                                    direction = new Members.revokeMember();
                                    this.Hide();
                                    effects.showDialog(direction);
                                    direction.BringToFront();
                                    break;
                            }
                        }else
                            label4.Visible = true;

                        btnStop.Enabled = false;
                        btnStart.Enabled = true;
                    }
            }
        }

        private Boolean checkWithServer(String nic, String uid){//Check NIC, UID with Server
            return server.regIDsAvailable(uid, nic);
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
            label3.Visible = false;
            label4.Visible = false;
            picBook.Image = null;
        }

        private void authorize_FormClosing(object sender, FormClosingEventArgs e) {
            camera.stopCamera();
            schedule.Stop();
        }
    }
}
