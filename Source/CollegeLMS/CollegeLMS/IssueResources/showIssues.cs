using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System.Drawing;
using CollegeLMS.TransactionServer;

namespace CollegeLMS.IssueResources{
    public partial class showIssues:Form{
        public showIssues(){
            InitializeComponent();
            this.Height = 191;
        }
        
        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        TransactionsClient transaction = new TransactionsClient();//Transaction Server Connection

        int resultCount = 0;//Number of Search Results
        String searchType="returned = 'Y'";
        String jsonData;

        private Label[,] lblBoldLabels;//0 - Resource, 1-Issued To, 2-Member,3-On
        private Label[,] lblResultLabel;//same as lblBoldLabels
        private Button[] btnViewDetails;
        private Panel[] pnlResult;

        private void createLabels(int i) {//Create Labels
            lblResultLabel[i, 0]=new Label();
            lblResultLabel[i, 1]=new Label();
            lblResultLabel[i, 2]=new Label();
            lblBoldLabels[i, 0]=new Label();
            lblBoldLabels[i, 1]=new Label();
            lblBoldLabels[i, 2]=new Label();
            lblBoldLabels[i, 3]=new Label();

            lblBoldLabels[i, 0].Font=new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, ((byte)(0)));
            lblBoldLabels[i, 1].Font=lblBoldLabels[i, 2].Font=lblBoldLabels[i, 3].Font=lblBoldLabels[i, 0].Font;

            lblResultLabel[i, 0].ForeColor=Color.Black;
            lblResultLabel[i, 1].ForeColor=lblResultLabel[i, 2].ForeColor=lblBoldLabels[i, 0].ForeColor=lblBoldLabels[i, 1].ForeColor=lblBoldLabels[i, 2].ForeColor=lblBoldLabels[i, 3].ForeColor=lblResultLabel[i, 0].ForeColor;

            lblResultLabel[i, 0].BackColor=Color.Transparent;
            lblResultLabel[i, 1].BackColor=lblResultLabel[i, 2].BackColor=lblBoldLabels[i, 0].BackColor=lblBoldLabels[i, 1].BackColor=lblBoldLabels[i, 2].BackColor=lblBoldLabels[i, 3].BackColor=lblResultLabel[i, 0].BackColor;

            lblResultLabel[i, 0].Font=lblResultLabel[i, 1].Font=lblResultLabel[i, 2].Font=new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(0)));

            lblBoldLabels[i, 0].Location=new Point(6, 6);
            lblBoldLabels[i, 0].Size=new Size(65, 15);
            lblBoldLabels[i, 0].Text="Resource:";
            pnlResult[i].Controls.Add(lblBoldLabels[i, 0]);

            lblBoldLabels[i, 1].Size=new Size(70, 15);
            lblBoldLabels[i, 1].Location=new Point(6, 21);
            lblBoldLabels[i, 1].Text="Issued To";
            pnlResult[i].Controls.Add(lblBoldLabels[i, 1]);

            lblBoldLabels[i, 2].Size=new Size(57, 15);
            lblBoldLabels[i, 2].Location=new Point(14, 36);
            lblBoldLabels[i, 2].Text="Member:";
            pnlResult[i].Controls.Add(lblBoldLabels[i, 2]);

            lblBoldLabels[i, 3].Size=new Size(26, 15);
            lblBoldLabels[i, 3].Location=new Point(45, 51);
            lblBoldLabels[i, 3].Text="On:";
            pnlResult[i].Controls.Add(lblBoldLabels[i, 3]);

            lblResultLabel[i, 0].Size=lblResultLabel[i, 0].Size=lblResultLabel[i, 0].Size=new Size(147, 10);

            lblResultLabel[i, 0].Location=new Point(70, 6);
            pnlResult[i].Controls.Add(lblResultLabel[i, 0]);

            lblResultLabel[i, 1].Location=new Point(70, 36);
            pnlResult[i].Controls.Add(lblResultLabel[i, 1]);

            lblResultLabel[i, 2].Location=new Point(70, 51);
            pnlResult[i].Controls.Add(lblResultLabel[i, 2]);

            lblResultLabel[i, 1].AutoSize=lblResultLabel[i, 2].AutoSize=lblResultLabel[i, 0].AutoSize=true;

            lblResultLabel[i, 0].Text=lblResultLabel[i, 1].Text=lblResultLabel[i, 2].Text="asd";
        }
        private void createButton(int i) {//Create Buttons
            btnViewDetails[i]=new Button();
            btnViewDetails[i].BackColor=Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(3)))), ((int)(((byte)(5)))));
            btnViewDetails[i].Font=new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel, ((byte)(0)));
            btnViewDetails[i].FlatStyle=FlatStyle.Flat;
            btnViewDetails[i].ForeColor=Color.White;
            btnViewDetails[i].Cursor=Cursors.Hand;
            btnViewDetails[i].Size=new Size(208, 24);
            btnViewDetails[i].Location=new Point(8, 72);
            btnViewDetails[i].Text="View Details";
            btnViewDetails[i].TextAlign=ContentAlignment.MiddleCenter;

            pnlResult[i].Controls.Add(btnViewDetails[i]);
        }
        private void buildResultStructure(){//Build the Structure of the Results
            lblBoldLabels = new Label[resultCount,4];
            lblResultLabel = new Label[resultCount, 3];
            btnViewDetails = new Button[resultCount];
            pnlResult = new Panel[resultCount];

            int x = 0, y = 0;
            int cont = 0;

            for(int i = 0;i<resultCount;i++) {
                pnlResult[i]=new Panel();
                pnlResult[i].BackColor=Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                pnlResult[i].Size=new Size(221,105);

                createLabels(i);
                createButton(i);

                pnlResult[i].Location=new Point(x, y);

                x=pnlResult[i].Location.X+(pnlResult[i].Width+5);//Set X of Panels

                if((i+1)%4==0) {
                    y=pnlResult[i].Location.Y+(pnlResult[i].Height+10);//Set Y of Panels
                    x-=(cont*(pnlResult[i].Width+4))+pnlResult[i].Width+8;
                }

                if(cont>=4)
                    cont=0;
                cont++;

                pnlResults.Controls.Add(pnlResult[i]);
            }
        }
        private void setData(int i, String resource, String member, String[] data) {
            lblResultLabel[i, 0].Text=resource;
            lblResultLabel[i, 1].Text=member;
            lblResultLabel[i, 2].Text= data[2];

            btnViewDetails[i].Click+=(sender, e) => ShowIssues_Click(sender, e, data);
        }

        private void ShowIssues_Click(object sender, EventArgs e, String[] data) {
            effects.showDialog(new issuedResource(data));
        }

        private int getData(){//Get Data and Set to Controls
            this.Cursor = Cursors.WaitCursor;
            pnlResults.Controls.Clear();
            jsonData = transaction.issuedResources(searchType);//Data from the transaction server
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData.Split('|')[0]);//Convert String back to JSON
            resultCount = Convert.ToInt16(jsonData.Split('|')[1]);//Number of results            

            buildResultStructure();
            String tblName, searchTerm, memberName;
            String[] issueDetails;
            for(int i = 0;i<resultCount;i++) {

                tblName = Convert.ToString(data[i].table);//Get Table Name
                searchTerm = Convert.ToString(data[i].resourceId);//Get Resource Code
                switch(tblName) {
                    case "issueBook":
                        tblName= "books";
                        searchTerm = "isbn = '"+ searchTerm + "'";
                        break;
                    case "issueComic":
                        tblName = "comics";
                        searchTerm = "coId = '" + searchTerm + "'";
                        break;
                    case "issueNewM":
                        tblName = "newspapersMags";
                        searchTerm = "nmId = '" + searchTerm + "'";
                        break;
                    case "issuePastP":
                        tblName = "pastPapers";
                        searchTerm = "ppID = '" + searchTerm + "'";
                        break;
                    case "issueVidD":
                        tblName = "vidDoc";
                        searchTerm = "vdId = '" + searchTerm + "'";
                        break;
                }
                tblName = server.getTitle(tblName, searchTerm);//Get Resource Title

                memberName = Convert.ToString(data[i].memberId);//Get Member Code
                memberName = server.getMemberUsername(memberName);//Get Member Username;
                memberName = server.getMemberName(memberName);

                issueDetails = new String[] { memberName, tblName, Convert.ToString(data[i].issueD), Convert.ToString(data[i].returnD), searchType };

                setData(i, tblName, memberName, issueDetails);
                this.Cursor = Cursors.Default;
            }

            lblRes.Text = "Found " + resultCount + " Resource(s)";

            this.Height = 214;
            if(resultCount >= 1)
                this.Height = 649;
            else
                lblRes.Text ="No Resource(s) Found";

            this.CenterToScreen();
            return 1;
        }

        private void btnPrintCard_Click(object sender, EventArgs e){
            this.Height=214;
            getData();

            if(resultCount>=1)
                this.Height=649;
            else
                lblRes.Text="No Resource(s) Found";

            this.CenterToScreen();
        }

        private void panel2_MouseEnter(object sender, EventArgs e){
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel2_MouseLeave(object sender, EventArgs e){
            effects.changeTextBorder_ML(pnlUsername);
        }       
        
        private void rbLan_Click(object sender, EventArgs e){
            searchType="issueDate LIKE '%"+txtSearch.Text+"%'";
        }
        private void rbAuth_Click(object sender, EventArgs e){
            searchType = "returned = 'Y'";
        }
        private void rdGen_Click(object sender, EventArgs e) {
            searchType = "returned = 'N'";
        }
        private void radioButton1_Click(object sender, EventArgs e) {
            searchType="returnDate LIKE '%"+txtSearch.Text+"%'";
        }
    }
}