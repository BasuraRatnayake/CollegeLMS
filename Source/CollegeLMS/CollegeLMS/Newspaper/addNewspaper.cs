using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using System.IO;
using CollegeLMS.FileServer;

namespace CollegeLMS.Newspaper{
    public partial class addNewspaper:Form{
        public addNewspaper(){
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
                txtNTitle.Text, cmbGenre.Text, dtpPublished.Value.ToString().Split(' ')[0], txtbPublish.Text,
                 encryption.generateCode5() + "." + ofdPicture.SafeFileName.Split('.')[1], cmbLang.Text, cbBook.Checked.ToString()
            };

            String[] date = inputs[2].Split('/');
            inputs[2] = date[2] + "-" + date[1] + "-" + date[0];

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 4)
                    count++;

            return (count == 7);
        }

        private void getImage(){//Get Image of Book from User PC
            ofdPicture.Title = "Select Picture of Newspaper";
            ofdPicture.ShowDialog();
            if(ofdPicture.FileName != "")
                picBook.Image = System.Drawing.Image.FromFile(ofdPicture.FileName);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                FileStream file = new FileStream(ofdPicture.FileName, FileMode.Open, FileAccess.Read);
                String bType = "Magazines";
                if(inputs[6].ToLower() == "false")
                    bType = "Newspapers";

                if(server.addNewspaper(inputs)){//To Database server
                    fileServer.UploadFile(bType, inputs[4], file.Length, 0, file);//Send File to Server
                    MessageBox.Show(bType + " Added", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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