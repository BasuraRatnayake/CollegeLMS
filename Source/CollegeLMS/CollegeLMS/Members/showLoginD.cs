using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;

namespace CollegeLMS.Members{
    public partial class showLoginD:Form{
        public showLoginD(){
            InitializeComponent();
            this.Height = 191;
        }
        
        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building

        int resultCount;//Number of Search Results
        String searchType="nic";
        String jsonData;
       
        private void ShowBooks_Click(object sender, EventArgs e, int count){//Execute Button Operation
            var json = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            String[] data = new String[] {
                json[count].regCode, json[count].nic,json[count].sid,json[count].regDate,json[count].pic,json[count].username,
                json[count].password,json[count].email,json[count].firstName,json[count].lastName,json[count].street,json[count].city,
                json[count].mobile,json[count].home,
            };
            effects.showDialog(new showLoginDV(data));
        }

        private int getData(){//Get Data and Set to Controls
            String searchTerm = txtSearch.Text;
            if(searchTerm.Length < 4)
                return -1;

            jsonData = server.showMemberDetails(txtSearch.Text, searchType);//Data from the database server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            resultCount = Convert.ToInt16(jsonData.Split('|')[1]);//Number of results

            effects.initResults(resultCount, pnlResults);//Initialize the Result Holder

            for(int i = 0;i < resultCount;i++){
                int direction = i;

                String file = "User/Profiles/"+ data[i].pic;
                String memberType = data[i].sid;
                memberType = memberType.Split('-')[0];

                if(memberType == "STAFF")
                    memberType = "Staff Member";
                else
                    memberType = "Student";

                effects.setResultData(i, new String[] { data[i].firstName + " " + data[i].lastName, memberType }, (sender, e) => ShowBooks_Click(sender, e, direction), fileHandle.buildImage("Files/" + file));//Set data to result
            }

            lblRes.Text = "Found " + resultCount + " Member(s)";

            this.Height = 214;
            if(resultCount >= 1)
                this.Height = 649;
            else
                lblRes.Text = "No Members Found";

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
            searchType = "nic";
        }
        private void rdGen_Click(object sender, EventArgs e){
            searchType = "sid";
        }
        private void rbLan_Click(object sender, EventArgs e){
            searchType = "lastName";
        }
        private void rbAuth_Click(object sender, EventArgs e){
            searchType = "city";
        }
    }
}
