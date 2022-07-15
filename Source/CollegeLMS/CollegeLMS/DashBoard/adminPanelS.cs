using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.DashBoard{
    public partial class adminPanelS:Form{
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building
        GUIEffects effects = new GUIEffects();//GUI Effects

        String username;

        public adminPanelS(String username) {
            InitializeComponent();

            this.username = username;

            label50.Text = server.getMemberName(username);
            pictureBox4.Image = System.Drawing.Image.FromFile("Files/" + "User/Profiles/" + server.getMemberPic(username));
        }

        private void btnResources_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanel(username));
        }
        private void btnMembers_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelM(username));
        }
        private void btnIssue_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelI(username));
        }
    }
}
