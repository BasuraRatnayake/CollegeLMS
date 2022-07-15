using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Pastpapers{
    public partial class choosePastpaper:Form{

        public choosePastpaper(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String resourceCode = "";//Resource Code

        private void btnPrintCard_Click(object sender, EventArgs e){
            resourceCode = txtUsername.Text;

            if(server.resouceValid(resourceCode, "PastP")){

                String jsonData = server.showPastPapers(resourceCode, "ppID");//Data from the database server

                var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
                String[] result = new String[] {
                    json[0].ppID, json[0].title, json[0].programme, json[0].eyear,
                    json[0].semester, json[0].fname, json[0].lname, json[0].eDate, json[0].pic
                };

                showPastpaper showB = new showPastpaper(result);

                effects.showDialog(showB);
                this.Hide();
                showB.BringToFront();

            }else 
                effects.showError(picUsername, lblU, "Invalid Resource Code");
        }
    }
}
