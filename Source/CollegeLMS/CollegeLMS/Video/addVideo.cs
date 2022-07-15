using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using System.IO;
using CollegeLMS.FileServer;

namespace CollegeLMS.Video{
    public partial class addVideo:Form{
        public addVideo(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection
        Camera camera = null;//Camera

        private String[] inputs;//Store Inputs

        private Boolean getInputs(){//Get Text Based Inputs and Validate
            if(picBook.Image == null)
                getImage();

            inputs = new String[]{
                txtTitle.Text, cmbGenre.Text, cmbLan.Text, txtBFname.Text, txtBLname.Text, txtDuration.Text, encryption.generateCode5() + "." + ofdPicture.SafeFileName.Split('.')[1], cmbType.Text
            };

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 3)
                    count++;

            return (count == 8);
        }

        private void getImage(){//Get Image of Book from User PC
            ofdPicture.Title = "Select Picture of Video";
            ofdPicture.ShowDialog();
            if(ofdPicture.FileName != "")
                picBook.Image = System.Drawing.Image.FromFile(ofdPicture.FileName);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                FileStream file = new FileStream(ofdPicture.FileName, FileMode.Open, FileAccess.Read);
                String bType = "TutVid";
                if(inputs[7] == "Documentry")
                    bType = "DocVid";

                if(server.addDocVid(inputs)){//To Database server
                    fileServer.UploadFile(bType, inputs[6], file.Length, 0, file);//Send File to Server
                    MessageBox.Show(inputs[7] + " Added", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }else
                    MessageBox.Show("Unable to Connect to Server", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Fill all the fields", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddB_Click(object sender, EventArgs e){
            postInputs();
        }

        private void btnChoose_Click(object sender, EventArgs e){
            getImage();
        }

        private void btnCamera_Click(object sender, EventArgs e){
            camera = new Camera(picBook);
            camera.startCamera();

            btnTakePicture.Visible = true;
            btnChoose.Visible = false;
            btnCamera.Visible = false;
        }       

        private void btnTakePicture_Click(object sender, EventArgs e){
            camera.CaptureImage();

            ofdPicture.FileName = "cameraImage.jpeg";

            btnTakePicture.Visible = false;
            btnCamera.Visible = true;
            btnChoose.Visible = true;
        }
    }
}
