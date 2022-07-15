using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;
using Newtonsoft.Json;

namespace CollegeLMS.Newspaper{
    public partial class modifyNewspaper:Form{
        private String ISBN = "";

        public modifyNewspaper(String isbn){
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
            String jsonData = server.showNewspapers(ISBN, "nmId");//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON

            txtISBN.Text = data[0].nmId;
            txtNTitle.Text = data[0].title;
            cmbGenre.Text = data[0].genre;
            dtpPublished.Value = Convert.ToString(data[0].published);
            txtbPublish.Text = data[0].publisher;
            cmbLang.Text = data[0].lang;

            if(Convert.ToString(data[0].bType) == "M")
                cbBook.Checked = true;
        }

        private Boolean getInputs(){//Get Text Based Inputs and Validate
            inputs = new String[]{
                txtISBN.Text, txtNTitle.Text, cmbGenre.Text, dtpPublished.Value.ToString().Split(' ')[0], txtbPublish.Text, cmbLang.Text, cbBook.Checked.ToString()
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
                String bType = "Magazines";
                if(inputs[6].ToLower() == "false")
                    bType = "Newspapers";

                if(server.modifyNewspaper(inputs)){//To Database server
                    MessageBox.Show(bType + " Details Modified", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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