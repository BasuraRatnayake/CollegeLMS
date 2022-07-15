using System;
using System.Windows.Forms;
using System.Drawing;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;

namespace CollegeLMS.Books {
    public partial class showBook:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection

        String[] details;//Book Details from Server
        //0 - ISBN, 1- title, 2 - Author, 3 - Lan
        String file = "Files/";

        public showBook(String[] data){
            InitializeComponent();
            details = data;//Data from Server
            initDetails();
        }

        private void initDetails(){//Set Data to the Controls
            lblISBN.Text = details[0];
            lblBTitle.Text = details[1];
            lblAuthor.Text = details[2];
            lblLang.Text = details[3];
            lblGen.Text = details[4];
            lblPublisher.Text = details[5];
            lblPublished.Text = details[6].Split(' ')[0];
            
            if(details[7] == "E"){
                details[7] = "E BOOK";
                file += "Ebooks/";
            } else{
                details[7] = "BOOK";
                file += "Books/";
            }
            file += details[8];
            lblType.Text = details[7];

            picBook.Image = Image.FromFile(file);//Get Image
        }
        private void removeBook(){//Remove Book from database server
            DialogResult result = MessageBox.Show("Are you sure want to remove the book from the system ?", "CLMS Control Panel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
                if(server.removeBook(details[0])) //Delete database record
                    //if(fileServer.deleteFile(file)) //Delete the file from server
                        MessageBox.Show("Book Successfully Deleted from the System", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowQR_Click(object sender, EventArgs e){
            effects.showDialog(new Books.showQR(lblType.Text, details[0], lblBTitle.Text));
        }

        private void btnRemove_Click(object sender, EventArgs e){
            removeBook();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            effects.showDialog(new Books.modifyBooks(details[0]));
        }
    }
}
