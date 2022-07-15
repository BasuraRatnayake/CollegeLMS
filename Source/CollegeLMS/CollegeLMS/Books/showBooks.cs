using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;

namespace CollegeLMS.Books{
    public partial class showBooks:Form{
        public showBooks(){
            InitializeComponent();
            this.Height = 191;
        }
        
        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building

        int resultCount;//Number of Search Results
        String searchType="title";
        String jsonData;
       
        private void ShowBooks_Click(object sender, EventArgs e, int count){//Execute Button Operation
            var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            String[] data = new String[] {
                json[count].isbn, json[count].title, json[count].fname+" "+json[count].lname, json[count].lang,
                json[count].genre, json[count].publisher, json[count].published, json[count].btype, json[count].pic
            };
            effects.showDialog(new showBook(data));
        }

        private int getData(){//Get Data and Set to Controls
            String searchTerm = txtSearch.Text;
            if(searchTerm.Length < 4)
                return -1;

            jsonData = server.showBook(txtSearch.Text, searchType);//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            resultCount = Convert.ToInt16(jsonData.Split('|')[1]);//Number of results

            int[] count = new int[] { 0, 0 };//0 - Books, 1 - Ebooks

            effects.initResults(resultCount, pnlResults);//Initialize the Result Holder

            for(int i = 0;i < resultCount;i++){
                int direction = i;

                String file = "";
                if(data[i].btype == "E"){
                    count[1]++;
                    file = "Ebooks/";
                }else{
                    count[0]++;
                    file = "Books/";
                }
                file += data[i].pic;

                effects.setResultData(i, new String[] { data[i].title, data[i].fname + " " + data[i].lname }, (sender, e) => ShowBooks_Click(sender, e, direction), fileHandle.buildImage("Files/" + file));//Set data to result
            }

            lblRes.Text = "Found " + count[0] + " Books and " + count[1] + " EBooks";

            this.Height = 214;
            if(resultCount >= 1)
                this.Height = 649;
            else
                lblRes.Text = "No Books or EBooks Found";

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
        private void rdGen_Click(object sender, EventArgs e){
            searchType = "genre";
        }
        private void rbLan_Enter(object sender, EventArgs e){
            searchType = "lang";
        }
        private void rbAuth_DragEnter(object sender, DragEventArgs e){
            searchType = "fname";
        }
        private void rbISBN_Click(object sender, EventArgs e){
            searchType = "isbn";
        }
    }
}
