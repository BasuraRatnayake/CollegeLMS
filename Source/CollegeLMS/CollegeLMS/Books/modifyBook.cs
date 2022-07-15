using CollegeLMS.FileServer;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Books{
    public partial class modifyBooks:Form{
        private String ISBN = "";

        public modifyBooks(String isbn){
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
            String jsonData = server.showBook(ISBN, "isbn");//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON

            txtISBN.Text = data[0].isbn;
            txtBTitle.Text = data[0].title;
            txtBFname.Text = data[0].fname;
            txtBLname.Text = data[0].lname;
            cmbGenre.Text = data[0].genre;
            dtpPublished.Value = data[0].published;
            txtbPublish.Text = data[0].publisher;
            cmbLan.Text = data[0].lang;

            if(Convert.ToString(data[0].btype) == "E") 
                cbBook.Checked = true;
        }


        private Boolean getInputs() {//Get Text Based Inputs and Validate

            inputs = new String[] {
                txtISBN.Text, txtBTitle.Text, txtBFname.Text,
                txtBLname.Text, cmbGenre.Text, dtpPublished.Value.ToString().Split(' ')[0], txtbPublish.Text,cmbLan.Text, cbBook.Checked.ToString()
            };

            String[] date = inputs[5].Split('/');
            inputs[5] = date[2] + "-" + date[1] + "-" + date[0];

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 4)
                    count++;

            return (count == 9);
        }

        private void postInputs() {//Post Data to the Server and Database
            if(getInputs()) {
                String bType = "Ebooks";
                if(inputs[8].ToLower() == "false")
                    bType = "Books";

                if(server.modifyBook(inputs)) {//To Database server
                    MessageBox.Show(bType + " Details Modified", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                } else
                    MessageBox.Show("Unable to Connect to Server", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Fill all the fields", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddB_Click(object sender, EventArgs e) {
            postInputs();
        }
    }
}
