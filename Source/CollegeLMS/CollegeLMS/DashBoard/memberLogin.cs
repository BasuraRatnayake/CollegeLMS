using CollegeLMS.DatabaseServer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CollegeLMS.DashBoard{
    public partial class memberLogin:Form{

        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileHandle fileHandle = new FileHandle();//File Download and Building
        GUIEffects effects = new GUIEffects();//GUI Effects

        String username;

        public memberLogin(String username){
            InitializeComponent();

            this.username = username;

            label50.Text = server.getMemberName(username);
            pictureBox4.Image = fileHandle.buildImage("Files/" + "User/Profiles/" + server.getMemberPic(username));
        }

        private void btnMembers_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelM(username));
        }
        private void btnIssue_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelI(username));
        }
        private void btnSupplier_Click(object sender, EventArgs e){
            effects.showThisHide(this, new adminPanelS(username));
        }

        #region Book
        private void btnABook_Click(object sender, EventArgs e){
            effects.showDialog(new Books.addBook());
        }
        private void btnMBook_Click(object sender, EventArgs e){
            effects.showDialog(new Books.chooseBook());
        }
        private void btnVBook_Click(object sender, EventArgs e){
            effects.showDialog(new Books.showBooks());
        }       
        private void btnRBook_Click(object sender, EventArgs e){
            effects.showDialog(new Books.chooseBook());
        }
        #endregion

        private void btnAMagazine_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.addNewspaper());
        }
        private void btnMNewspaper_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.chooseNewM());
        }
        private void btnVNewspaper_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.showNewspapers());
        }
        private void btnRNewspaper_Click(object sender, EventArgs e){
            effects.showDialog(new Newspaper.chooseNewM());
        }


        private void btnAComic_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.addComic());
        }
        private void btnVComics_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.showComics());
        }
        private void btnMComic_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.chooseComic());
        }
        private void btnRComic_Click(object sender, EventArgs e){
            effects.showDialog(new Comics.chooseComic());
        }

        private void btnAVidDoc_Click(object sender, EventArgs e){
            effects.showDialog(new Video.addVideo());
        }
        private void btnMVideo_Click(object sender, EventArgs e){
            effects.showDialog(new Video.chooseVidD());
        }
        private void btnVVideo_Click(object sender, EventArgs e){
            effects.showDialog(new Video.showVideos());
        }
        private void btnRVideo_Click(object sender, EventArgs e){
            effects.showDialog(new Video.chooseVidD());
        }

        private void btnAPast_Click(object sender, EventArgs e){
            effects.showDialog(new Pastpapers.addPastpapers());
        }
        private void btnVPastPapers_Click(object sender, EventArgs e){
            effects.showDialog(new Pastpapers.showPastpapers());
        }
        private void btnMPastPaper_Click(object sender, EventArgs e){
            effects.showDialog(new Pastpapers.choosePastpaper());
        }
        private void btnRPastPaper_Click(object sender, EventArgs e){
            effects.showDialog(new Pastpapers.choosePastpaper());
        }

        private void label49_Click(object sender, EventArgs e) {
            effects.showThisHide(this, new signIn());
        }

        private void btnCP_Click(object sender, EventArgs e) {
            effects.showDialog(new chooseUser("changePass"));
        }

        private void btnCE_Click(object sender, EventArgs e) {
            effects.showDialog(new chooseUser("changeEmail"));
        }

        private void btnCA_Click(object sender, EventArgs e) {
            effects.showDialog(new chooseUser("changeAdd"));
        }

        private void button9_Click(object sender, EventArgs e) {
            effects.showDialog(new chooseUser("changeCon"));
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {

        }
    }
}
