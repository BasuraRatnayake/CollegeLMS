using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.DashBoard{
    public partial class adminPanelM:Form{
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building
        GUIEffects effects = new GUIEffects();//GUI Effects

        String username;

        public adminPanelM(String username) {
            InitializeComponent();

            this.username = username;

            label50.Text = server.getMemberName(username);
            pictureBox4.Image = System.Drawing.Image.FromFile("Files/" + "User/Profiles/" + server.getMemberPic(username));
        }

        private void button1_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanel(username));
        }
        private void btnIssue_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelI(username));
        }
        private void btnSupplier_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelS(username));
        }

        private void btnPrintCard_Click(object sender, EventArgs e){
            effects.showDialog(new chooseUser("generateCard"));
        }

        private void btnGenCode_Click(object sender, EventArgs e){
            effects.showDialog(new Register.generate());
        }

        private void button4_Click(object sender, EventArgs e){
            effects.showDialog(new Register.validate());
        }

        private void btnScanc_Click(object sender, EventArgs e){
            effects.showDialog(new LibraryCard.scanCard());

        }

        private void btnCP_Click(object sender, EventArgs e){
            effects.showDialog(new chooseUser("changePass"));
        }

        private void btnCE_Click(object sender, EventArgs e){
            effects.showDialog(new chooseUser("changeEmail"));
        }

        private void btnLV_Click(object sender, EventArgs e){
            effects.showDialog(new Members.showLoginD());
        }

        private void btnCA_Click(object sender, EventArgs e){
            effects.showDialog(new chooseUser("changeAdd"));
        }

        private void button9_Click(object sender, EventArgs e){
            effects.showDialog(new chooseUser("changeCon"));
        }

        private void btnRM_Click(object sender, EventArgs e){
            effects.showDialog(new DashBoard.authorize("revokeMember"));
        }
    }
}
