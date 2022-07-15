using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;
using System.IO;

namespace CollegeLMS.Register {
    public partial class generate:Form {
        public generate() {
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection
        Camera camera = new Camera();//Camera

        protected String sid;//Student ID
        protected String nic;//National ID
        protected String regCode;//Registration Code

        protected void setUID_NIC() {//Set SID and NIC
            sid = txtUID.Text;
            nic = txtNIC.Text;
        }

        private Boolean ValidateCode(){//Validate Inputs and Show Statuses
            setUID_NIC();

            if (!validate.NationalID(nic))
                effects.showError(picPassword, lblP, "NIC Number is Invalid");
            else
                effects.showOkay(picPassword, lblP, "NIC Number is Okay");

            if (!validate.UniversityID(sid))
                effects.showError(picUsername, lblU, "University ID is Invalid");
            else
                effects.showOkay(picUsername, lblU, "University ID is Okay");

            if(validate.NationalID(nic) && validate.UniversityID(sid)) //If both NIC and SID Okay
                return true;

            return false;
        }

        private void getImage() {//Get Image of Book from User PC
            ofdPicture.Title = "Select Picture of Book";
            ofdPicture.ShowDialog();
            if(ofdPicture.FileName != "")
                picBook.Image = System.Drawing.Image.FromFile(ofdPicture.FileName);
        }

        private void generateCode() {//Generate Code
            lblWarning.Visible = false;
            if(ValidateCode()) {
                String fileName = encryption.generateCode5() + "." + ofdPicture.SafeFileName.Split('.')[1];

                this.Cursor = Cursors.WaitCursor;
                Boolean status = server.regIDsAvailable(sid, nic);
                this.Cursor = Cursors.Default;
                if(status) {
                    regCode = encryption.generateRegCode(sid, nic);

                    server.insertRegCode(sid, nic, regCode, fileName);//Insert Data to DB

                    FileStream file = new FileStream(ofdPicture.FileName, FileMode.Open, FileAccess.Read);
                    fileServer.UploadFile("User/Profiles", fileName, file.Length, 0, file);//Send File to Server

                    effects.showDialog(new generateSuccess(regCode));
                    this.Hide();

                } else {
                    effects.showError(picPassword, lblP, "NIC Number Already Registered");
                    effects.showError(picUsername, lblU, "University ID Already Registered");
                    lblWarning.Visible = true;
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            generateCode();
        }

        private void moveSelection(String chars) {//Move cursor to the last of the text
            txtUID.Text = chars + "-";
            txtUID.SelectionStart = txtUID.Text.Length;
            txtUID.SelectionLength = 0;
        }
        private void txtUID_KeyDown(object sender, KeyEventArgs e) {//When key pressed
            String chars = txtUID.Text;
            switch(txtUID.Text.Length) {
                case 5:
                    moveSelection(chars);
                    break;
                case 9:
                    moveSelection(chars);
                    break;
                case 13:
                    moveSelection(chars);
                    break;
            }
        }

        private void panel2_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel2_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void panel3_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlPassword);
        }
        private void panel3_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlPassword);
        }

        private void btnCamera_Click(object sender, EventArgs e) {
            camera = new Camera(picBook);
            camera.startCamera();

            btnTakePicture.Visible = true;
            btnChoose.Visible = false;
            btnCamera.Visible = false;
        }

        private void btnChoose_Click(object sender, EventArgs e) {
            getImage();
        }

        private void btnTakePicture_Click(object sender, EventArgs e) {
            camera.CaptureImage();

            ofdPicture.FileName = "cameraImage.jpeg";

            btnTakePicture.Visible = false;
            btnCamera.Visible = true;
            btnChoose.Visible = true;
        }
    }
}