using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using System.IO;
using CollegeLMS.FileServer;

namespace CollegeLMS.Pastpapers{
    public partial class addPastpapers:Form{
        public addPastpapers(){
            InitializeComponent();

            for(int i = DateTime.Today.Year;i > 1999;i--) 
                cmbYear.Items.Add(i);
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
                txtSub.Text, txtProgramme.Text, cmbYear.Text,
                cmbSem.Text, txtBFname.Text, txtBLname.Text,
                dtpPublished.Value.ToString().Split(' ')[0],
                encryption.generateCode5() + "." + ofdPicture.SafeFileName.Split('.')[1]
            };

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 1)
                    count++;

            return (count == 8);
        }

        private void getImage(){//Get Image of Book from User PC
            ofdPicture.Title = "Select Picture of Past Paper";
            ofdPicture.ShowDialog();
            if(ofdPicture.FileName != "")
                picBook.Image = System.Drawing.Image.FromFile(ofdPicture.FileName);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                FileStream file = new FileStream(ofdPicture.FileName, FileMode.Open, FileAccess.Read);

                if(server.addPastPaper(inputs)) {//To Database server
                    fileServer.UploadFile("PastPapers", inputs[7], file.Length, 0, file);//Send File to Server
                    MessageBox.Show("Past Paper" + " Added", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
