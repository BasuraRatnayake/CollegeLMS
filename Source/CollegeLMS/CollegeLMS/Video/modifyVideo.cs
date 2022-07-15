using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;
using Newtonsoft.Json;

namespace CollegeLMS.Video{
    public partial class modifyVideo:Form{
        private String ISBN = "";

        public modifyVideo(String isbn){
            InitializeComponent();
            ISBN = isbn;

            getData();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        private String[] inputs;//Store Inputs

        private void getData(){
            String jsonData = server.showVidDoc(ISBN, "vdId");//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON

            txtCode.Text = data[0].vdId;
            txtTitle.Text = data[0].title;
            txtDuration.Text = data[0].duration;
            txtBFname.Text = data[0].fname;
            txtBLname.Text = data[0].lname;
            cmbGenre.Text = data[0].genre;
            cmbLan.Text = data[0].lang;

            if(data[0].vdType == "D")
                txtType.Text = "Documentry";
            else
                txtType.Text = "Video Tutorial";
        }


        private Boolean getInputs(){//Get Text Based Inputs and Validate
            inputs = new String[]{ 
                txtCode.Text, txtTitle.Text, cmbGenre.Text, cmbLan.Text, txtBFname.Text, txtBLname.Text, txtDuration.Text
            };

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 1)
                    count++;

            return (count == 7);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                if(server.modifyVidDoc(inputs)) {//To Database server
                    MessageBox.Show(txtType.Text + " Added", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                } else
                    MessageBox.Show("Unable to Connect to Server", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Fill all the fields", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddB_Click(object sender, EventArgs e){
            postInputs();
        }        
    }
}
