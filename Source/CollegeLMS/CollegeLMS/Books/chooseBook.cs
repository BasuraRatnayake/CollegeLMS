using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Books{
    public partial class chooseBook:Form{

        public chooseBook(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String resourceCode = "";//Resource Code

        private void btnPrintCard_Click(object sender, EventArgs e){
            resourceCode = txtUsername.Text;
            String rType = "Book_N";
            if(cbBook.Checked)
                rType = "Book_E";

            if(server.resouceValid(resourceCode, rType)){

                String jsonData = server.showBook(resourceCode, "isbn");//Data from the database server

                var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
                String[] result = new String[] {
                    json[0].isbn, json[0].title, json[0].fname+" "+json[0].lname, json[0].lang,
                    json[0].genre, json[0].publisher, json[0].published, json[0].btype, json[0].pic
                };

                showBook showB = new showBook(result);

                effects.showDialog(showB);
                this.Hide();
                showB.BringToFront();

            } else 
                effects.showError(picUsername, lblU, "Invalid ISBN");
        }
    }
}
