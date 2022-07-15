using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;
using CollegeLMS.TransactionServer;

namespace CollegeLMS.IssueResources{
    public partial class issueR:Form{
        private String[] resDetails;//Resource Details
        private String[] memDetails;//Member Details
        String tableName;
        String searchTerm;
        String fileName;

        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building
        TransactionsClient transaction = new TransactionsClient();//Transaction Server Connection

        public issueR(String[] resD, String[] memD) {
            InitializeComponent();
            resDetails = resD;
            memDetails = memD;

            getData();
        }

        private void selectTable(){//Get Data from Table Name
            switch(tableName) {
                case "book":
                    tableName = "books";
                    searchTerm = "isbn = '" + txtCode.Text + "'";
                    resDetails[1] = txtType.Text.Split('_')[1];

                    txtType.Text = "E Book";
                    fileName = "Files/Ebooks/";

                    if(resDetails[1].ToLower() == "n") {
                        txtType.Text = "Book";
                        fileName = "Files/Books/";
                    }
                    break;
                case "comic":
                    tableName = "comics";
                    searchTerm = "coId = " + txtCode.Text;

                    txtType.Text = "Comic";
                    fileName = "Files/Comics/";
                    break;
                case "vidd":
                    tableName = "vidDoc";
                    searchTerm = "vdId = " + txtCode.Text;
                    resDetails[1] = txtType.Text.Split('_')[1];

                    txtType.Text = "Documentryy";
                    fileName = "Files/DocVid/";

                    if(resDetails[1].ToLower() == "t") {
                        txtType.Text = "Video Tutorial";
                        fileName = "Files/TutVid/";
                    }
                    break;
                case "pastp":
                    tableName = "pastPapers";
                    searchTerm = "ppID = " + txtCode.Text;

                    txtType.Text = "Past Papers";
                    fileName = "Files/PastPapers/";
                    break;
                case "newm":
                    tableName = "newspapersMags";
                    searchTerm = "nmId = " + txtCode.Text;
                    resDetails[1] = txtType.Text.Split('_')[1];

                    txtType.Text = "Newspaper";
                    fileName = "Files/Newspapers/";

                    if(resDetails[1].ToLower() == "m") {
                        txtType.Text = "Magazine";
                        fileName = "Files/Magazines/";
                    }
                    break;
            }
        }

        private void getData() {//Get Data from Servers
            txtRCode.Text = server.getMemberPass(memDetails[0]).Split('|')[1];
            txtNic.Text = memDetails[0];

            txtCode.Text = resDetails[0];
            txtType.Text = resDetails[1];

            if(resDetails[1].Contains("_"))
                tableName = resDetails[1].Split('_')[0].ToLower();
            else
                tableName = resDetails[1].ToLower();

            selectTable();//Get Data from Table Name

            object[] data = server.getLICDetails(memDetails[0]);
            txtName.Text = data[5].ToString();

            txtTitle.Text = server.getTitle(tableName, searchTerm);//Resource Title

            fileName += server.getResourcePic(tableName, searchTerm);//Get Resource file path
            picResource.Image = fileHandle.buildImage(fileName);//Set Resource picture

            fileName = "Files/User/Profiles/" + data[4].ToString();//Set Path to File
            picMember.Image = fileHandle.buildImage(fileName);//Download and set profile image       

            btnProceed.Text = "ISSUE " + txtType.Text.ToUpper();

            txtBBorrow.Text = transaction.unReturnedCount(txtRCode.Text).ToString()+"/2";//Get Borrowed Resource Count
        }

        private void postData() {//Issue Resouce and Post to server
            Boolean status = false;
            switch(tableName) {
                case "books":
                    if(transaction.issueBook(txtRCode.Text, resDetails[0], resDetails[1]))//Add issued book
                        status = true;
                    break;
                case "comics":
                    if(transaction.issueComic(txtRCode.Text, resDetails[0]))//Add issued Comic
                        status = true;
                    break;
                case "vidDoc":
                    if(transaction.issueVidDoc(txtRCode.Text, resDetails[0], resDetails[1]))//Add issued Video, Tutorial
                        status = true;
                    break;
                case "pastPapers":
                    if(transaction.issuePastP(txtRCode.Text, resDetails[0]))//Add issued past paper
                        status = true;
                    break;
                case "newspapersMags":
                    if(transaction.issueNewsMag(txtRCode.Text, resDetails[0], resDetails[1]))//Add issued newspaper, magazine
                        status = true;
                    break;
            }

            if(status)
                MessageBox.Show(txtType.Text+" Issued", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("An Error Occurred", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e) {
            postData();
        }
    }
}
