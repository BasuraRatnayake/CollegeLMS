using System;
using System.Windows.Forms;
using System.Drawing;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;

namespace CollegeLMS.Newspaper{
    public partial class showNewspaper:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        String[] details;//Book Details from Server
        //0 - ISBN, 1- title, 2 - Author, 3 - Lan
        String file = "Files/";

        public showNewspaper(String[] data){
            InitializeComponent();
            details = data;//Data from Server
            initDetails();
        }

        private void initDetails(){//Set Data to the Controls
            lblCode.Text = details[0];
            lblBTitle.Text = details[1];
            lblLang.Text = details[4];
            lblGen.Text = details[2];
            lblPublisher.Text = details[6];
            lblPublished.Text = details[3].Split(' ')[0];
            
            if(details[7] == "M"){
                details[7] = "MAGAZINE";
                file += "Magazines/";
            } else{
                details[7] = "NEWSPAPER";
                file += "Newspapers/";
            }
            file += details[5];
            lblType.Text = details[7];

            label15.Text = details[7] + " DETAILS";

            picBook.Image = Image.FromFile(file);//Get Image
        }
        private void removeBook(){//Remove Book from database server
            DialogResult result = MessageBox.Show("Are you sure want to remove the "+ details[7] + " from the system ?", "CLMS Control Panel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                if(server.removeNewspaper(details[0])) //Delete database record
                    //if(fileServer.deleteFile(file)) //Delete the file from server
                        MessageBox.Show(details[7] + " Successfully Deleted from the System", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowQR_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.showQR(lblType.Text, details[0], lblBTitle.Text));
        }

        private void btnRemove_Click(object sender, EventArgs e){
            removeBook();
        }

        private void btnModify_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.modifyNewspaper(details[0]));
        }
    }
}
