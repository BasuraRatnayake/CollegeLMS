using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;
using Newtonsoft.Json;

namespace CollegeLMS.Comics{
    public partial class modifyComic:Form{
        private String ISBN = "";

        public modifyComic(String isbn){
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
            String jsonData = server.showComics(ISBN, "coId");//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON

            txtISBN.Text = data[0].coId;
            txtBTitle.Text = data[0].title;
            cmbGenre.Text = data[0].genre;
            dtpPublished.Value = data[0].published;
            txtbPublish.Text = data[0].publisher;
            cmbLan.Text = data[0].volume;
            cmbLang.Text = data[0].lang;
        }

        private Boolean getInputs(){//Get Text Based Inputs and Validate
            inputs = new String[]{
                txtISBN.Text, txtBTitle.Text, cmbGenre.Text, dtpPublished.Value.ToString().Split(' ')[0], cmbLang.Text, txtbPublish.Text, cmbLan.Text
            };

            String[] date = inputs[3].Split('/');
            inputs[3] = date[2] + "-" + date[1] + "-" + date[0];

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 1)
                    count++;

            return (count == 7);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                if(server.modifyComic(inputs)){//To Database server
                    MessageBox.Show("Comic Modified", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }else
                    MessageBox.Show("Unable to Connect to Server", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Fill all the fields", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddB_Click(object sender, EventArgs e){
            postInputs();
        }

    }
}
