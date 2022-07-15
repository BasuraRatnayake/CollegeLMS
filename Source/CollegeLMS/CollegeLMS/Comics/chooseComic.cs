using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Comics{
    public partial class chooseComic:Form{

        public chooseComic(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String resourceCode = "";//Resource Code

        private void btnPrintCard_Click(object sender, EventArgs e){
            resourceCode = txtUsername.Text;

            if(server.resouceValid(resourceCode, "Comic")){

                String jsonData = server.showComics(resourceCode, "coId");//Data from the database server

                var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
                String[] result = new String[] {
                    json[0].coId, json[0].title, json[0].genre, json[0].published,
                    json[0].lang, json[0].pic, json[0].publisher, json[0].volume
                };

                showComic showB = new showComic(result);

                effects.showDialog(showB);
                this.Hide();
                showB.BringToFront();

            } else 
                effects.showError(picUsername, lblU, "Invalid Resource Code");
        }
    }
}
