using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;

namespace CollegeLMS.Video
{
    public partial class showVideos:Form {
        public showVideos() {
            InitializeComponent();
            this.Height = 191;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building

        int resultCount;//Number of Search Results
        String searchType = "title";
        String jsonData;
        
        private void ShowBooks_Click(object sender, EventArgs e, int count) {//Execute Button Operation
            var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            String[] data = new String[] {
                json[count].vdId, json[count].title, json[count].genre, json[count].lang,
                json[count].fname, json[count].lname, json[count].duration, json[count].pic, json[count].vdType
            };
            effects.showDialog(new Video.showVideo(data));
        }

        private int getData() {//Get Data and Set to Controls
            String searchTerm = txtSearch.Text;
            if(searchTerm.Length < 4)
                return -1;

            jsonData = server.showVidDoc(txtSearch.Text, searchType);//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            resultCount = Convert.ToInt16(jsonData.Split('|')[1]);//Number of results

            int[] count = new int[] { 0, 0 };//0 - Newspaper, 1 - Magazine

            effects.initResults(resultCount, pnlResults);//Initialize the Result Holder

            for(int i = 0;i < resultCount;i++) {
                int direction = i;

                String file = "";
                if(data[i].vdType == "D") {
                    count[0]++;
                    file = "DocVid/";
                } else {
                    count[1]++;
                    file = "TutVid/";
                }
                file += data[i].pic;

                effects.setResultData(i, new String[] { data[i].title, data[i].fname + " " + data[i].lname }, (sender, e) => ShowBooks_Click(sender, e, direction), fileHandle.buildImage("Files/" + file));//Set data to result
            }

            lblRes.Text = "Found " + count[0] + " Documentries and " + count[1] + " Tutorials";

            this.Height = 214;
            if(resultCount >= 1)
                this.Height = 649;
            else
                lblRes.Text = "No Documentries or Tutorials Found";

            this.CenterToScreen();
            return 1;
        }

        private void btnPrintCard_Click(object sender, EventArgs e) {
            getData();
        }

        private void panel2_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel2_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void rbTitle_Click(object sender, EventArgs e) {
            searchType = "title";
        }
        private void rdGen_CheckedChanged(object sender, EventArgs e) {
            searchType = "genre";
        }
        private void rbLan_CheckedChanged(object sender, EventArgs e) {
            searchType = "lang";
        }
        private void rbAuth_CheckedChanged(object sender, EventArgs e) {
            searchType = "fname";
        }
    }
}
