using System;
using System.Windows.Forms;
using System.Drawing;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;

namespace CollegeLMS.Comics{
    public partial class showComic:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        String[] details;//Book Details from Server
        //0 - ISBN, 1- title, 2 - Author, 3 - Lan
        String file = "Files/";

        public showComic(String[] data){
            InitializeComponent();
            details = data;//Data from Server
            initDetails();
        }

        private void initDetails(){//Set Data to the Controls
            lblCode.Text = details[0];
            lblBTitle.Text = details[1];
            lblGen.Text = details[2];
            lblPublished.Text = details[3].Split(' ')[0];
            lblLang.Text = details[4];
            lblPublisher.Text = details[6];
            lblVolume.Text = details[7];

            file += "Comics/"+ details[5];

            picBook.Image = Image.FromFile(file);//Get Image
        }
        private void removeBook(){//Remove Book from database server
            DialogResult result = MessageBox.Show("Are you sure want to remove the comic from the system ?", "CLMS Control Panel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                if(server.removeComic(details[0])) //Delete database record
                    //if(fileServer.deleteFile(file)) //Delete the file from server
                        MessageBox.Show("Comic Successfully Deleted from the System", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowQR_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.showQR("Comic", details[0], lblBTitle.Text));
        }

        private void btnRemove_Click(object sender, EventArgs e){
            removeBook();
        }

        private void btnModify_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.modifyComic(details[0]));
        }
    }
}
