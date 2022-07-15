using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.Drawing;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;

namespace CollegeLMS.Video {
    public partial class showVideo:Form {

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        String[] details;//Book Details from Server
        //0 - ISBN, 1- title, 2 - Author, 3 - Lan
        String file = "Files/";

        public showVideo(String[] data) {
            InitializeComponent();
            details = data;//Data from Server
            initDetails();
        }

        private void initDetails() {//Set Data to the Controls
            lblCode.Text = details[0];
            lblBTitle.Text = details[1];
            lblGen.Text = details[2];
            lblLang.Text = details[3];
            lblPublisher.Text = details[4] + " " + details[5];
            lblPublished.Text = details[6];
            
            if(details[8] == "D") {
                details[8] = "DOCUMENTRY";
                file += "DocVid/";
            } else{
                details[8] = "VIDEO Tutorial";
                file += "TutVid/";
            }
            file += details[7];
            lblType.Text = details[8];

            label15.Text = details[8] + " DETAILS";

            picBook.Image = Image.FromFile(file);//Get Image
        }
        private void removeBook(){//Remove Book from database server
            DialogResult result = MessageBox.Show("Are you sure want to remove the "+ details[8] + " from the system ?", "CLMS Control Panel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                if(server.removeNewspaper(details[0])) //Delete database record
                    //if(fileServer.deleteFile(file)) //Delete the file from server
                        MessageBox.Show(details[8] + " Successfully Deleted from the System", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowQR_Click(object sender, EventArgs e) {
            effects.showDialog(new Video.showQR(lblType.Text, details[0], lblBTitle.Text));
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            removeBook();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            effects.showDialog(new Video.modifyVideo(details[0]));
        }
    }
}
