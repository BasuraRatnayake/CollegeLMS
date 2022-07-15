using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS.LibraryCard{
    public partial class scanCard:Form{
        public scanCard(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validateD = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        Camera camera = null;//Camera

        private void scanCode(){//Scan Library Card
            picUsername.Visible = true;
            label3.Visible = true;

            ofdPicture.FileName = "cameraImage.jpeg";
            txtUsername.Text = camera.decodeQR();

            pnlUsername.Visible = false;
            effects.showError(picUsername, new Label(), "Invalid");

            if(txtUsername.Text != ""){
                String[] licData = txtUsername.Text.Split('|');//Split QR Code
                if(licData.Length == 3)
                    if(checkWithServer(licData[2], licData[1])){//Check with Server
                        camera.stopCamera();
                        effects.showOkay(picUsername, new Label(), "Valid");

                        txtNic.Text = licData[1];
                        txtUid.Text = licData[2];

                        schedule.Stop();

                        pnlUsername.Visible = true;
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
            pnlUsername.Visible = false;
            picBook.Image = null;
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e){
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void txtUsername_MouseLeave(object sender, EventArgs e){
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void scanCard_FormClosing(object sender, FormClosingEventArgs e) {
            camera.stopCamera();
            schedule.Stop();
        }
    }
}
