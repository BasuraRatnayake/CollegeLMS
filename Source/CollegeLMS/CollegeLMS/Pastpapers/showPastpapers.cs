using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;

namespace CollegeLMS.Pastpapers{
    public partial class showPastpapers:Form{
        public showPastpapers(){
            InitializeComponent();
            this.Height = 191;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building

        int resultCount;//Number of Search Results
        String searchType = "title";
        String jsonData;

        
        private void ShowBooks_Click(object sender, EventArgs e, int count){//Execute Button Operation
            var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            String[] data = new String[] {
                json[count].ppID, json[count].title, json[count].programme, json[count].eyear,
                json[count].semester, json[count].fname, json[count].lname, json[count].eDate, json[count].pic
            };
            effects.showDialog(new Pastpapers.showPastpaper(data));
        }

        private int getData(){//Get Data and Set to Controls
            this.Cursor = Cursors.WaitCursor;
            String searchTerm = txtSearch.Text;
            if(searchTerm.Length < 4)
                return -1;

            jsonData = server.showPastPapers(txtSearch.Text, searchType);//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            resultCount = Convert.ToInt16(jsonData.Split('|')[1]);//Number of results

            this.Cursor = Cursors.Default;

            int[] count = new int[] { 0, 0 };//0 - Newspaper, 1 - Magazine

            effects.initResults(resultCount, pnlResults);//Initialize the Result Holder

            for(int i = 0;i < resultCount;i++){
                int direction = i;

                String file = "PastPapers/" + data[i].pic;
                count[0]++;

                effects.setResultData(i, new String[] { data[i].title, "Semester: "+data[i].semester+", Year: "+ data[i].eyear }, (sender, e) => ShowBooks_Click(sender, e, direction), fileHandle.buildImage("Files/" + file));//Set data to result
            }

            lblRes.Text = "Found " + count[0] + " Past Paper(s)";

            this.Height = 214;
            if(resultCount >= 1)
                this.Height = 649;
            else
                lblRes.Text = "No Past Papers Found";

            this.CenterToScreen();
            return 1;
        }

        private void btnPrintCard_Click(object sender, EventArgs e){
            getData();
        }

        private void panel2_MouseEnter(object sender, EventArgs e){
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel2_MouseLeave(object sender, EventArgs e){
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void rbTitle_Click(object sender, EventArgs e){
            searchType = "title";
        }
        private void rdGen_CheckedChanged(object sender, EventArgs e){
            searchType = "genre";
        }
        private void rbLan_CheckedChanged(object sender, EventArgs e){
            searchType = "eyear";
        }
        private void rbAuth_CheckedChanged(object sender, EventArgs e){
            searchType = "fname";
        }
    }
}
