using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Newspaper{
    public partial class chooseNewM:Form{

        public chooseNewM(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String resourceCode = "";//Resource Code

        private void btnPrintCard_Click(object sender, EventArgs e){
            resourceCode = txtUsername.Text;
            String rType = "NewM_N";
            if(cbBook.Checked)
                rType = "NewM_M";

            if(server.resouceValid(resourceCode, rType)){

                String jsonData = server.showNewspapers(resourceCode, "nmId");//Data from the database server

                var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
                String[] result = new String[] {
                    json[0].nmId, json[0].title, json[0].genre, json[0].published,
                    json[0].lang, json[0].pic, json[0].publisher, json[0].bType
                };

                showNewspaper showB = new showNewspaper(result);

                effects.showDialog(showB);
                this.Hide();
                showB.BringToFront();

            } else 
                effects.showError(picUsername, lblU, "Invalid Resource Code");
        }
    }
}
