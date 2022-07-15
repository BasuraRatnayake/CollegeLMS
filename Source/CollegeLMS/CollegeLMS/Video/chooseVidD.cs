using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Video{
    public partial class chooseVidD:Form{

        public chooseVidD(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String resourceCode = "";//Resource Code

        private void btnPrintCard_Click(object sender, EventArgs e){
            resourceCode = txtUsername.Text;
            String rType = "VidD_D";
            if(cbBook.Checked)
                rType = "VidD_T";

            if(server.resouceValid(resourceCode, rType)){

                String jsonData = server.showVidDoc(resourceCode, "vdId");//Data from the database server

                var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
                String[] result = new String[] {
                    json[0].vdId, json[0].title, json[0].genre, json[0].lang,
                    json[0].fname, json[0].lname, json[0].duration, json[0].pic, json[0].vdType
                };

                showVideo showB = new showVideo(result);

                effects.showDialog(showB);
                this.Hide();
                showB.BringToFront();

            }else 
                effects.showError(picUsername, lblU, "Invalid Resource Code");
        }
    }
}
