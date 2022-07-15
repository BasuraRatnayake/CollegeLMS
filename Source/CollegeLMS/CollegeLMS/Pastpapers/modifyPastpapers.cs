using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using System.IO;
using CollegeLMS.FileServer;
using Newtonsoft.Json;

namespace CollegeLMS.Pastpapers{
    public partial class modifyPastpapers:Form{
        private String ISBN = "";

        public modifyPastpapers(String isbn){
            InitializeComponent();
            ISBN = isbn;

            getData();

            for(int i = DateTime.Today.Year;i > 1999;i--) 
                cmbYear.Items.Add(i);
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        private String[] inputs;//Store Inputs

        private void getData(){
            String jsonData = server.showPastPapers(ISBN, "ppID");//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON

            txtISBN.Text = data[0].ppID;
            txtSub.Text = data[0].title;
            txtBFname.Text = data[0].fname;
            txtBLname.Text = data[0].lname;

            dtpPublished.Value = data[0].eDate;
            txtProgramme.Text = data[0].programme;
            cmbYear.Text = data[0].eyear;
            cmbSem.Text = data[0].semester;
        }

        private Boolean getInputs(){//Get Text Based Inputs and Validate
            inputs = new String[] {
                txtISBN.Text, txtSub.Text, txtProgramme.Text, cmbYear.Text,
                cmbSem.Text, txtBFname.Text, txtBLname.Text,
                dtpPublished.Value.ToString().Split(' ')[0]
            };

            String[] date = inputs[7].Split('/');
            inputs[7] = date[2] + "-" + date[1] + "-" + date[0];

            int count = 0;
            for(int i = 0;i < inputs.Length;i++)
                if(inputs[i].Length >= 1)
                    count++;

            return (count == 8);
        }

        private void postInputs(){//Post Data to the Server and Database
            if(getInputs()){
                if(server.modifyPastPaper(inputs)) {//To Database server
                    MessageBox.Show("Past Paper" + " Modified", "CLMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
