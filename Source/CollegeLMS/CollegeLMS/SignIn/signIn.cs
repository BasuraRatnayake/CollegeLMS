using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS{
    public partial class signIn : Form{
        public signIn(){
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String username;
        protected String password;

        private void validateLogin(){//Validate Login Credentials
            this.Cursor = Cursors.WaitCursor;
            username = txtUsername.Text;
            password = txtPassword.Text;

            if(server.validLogin(username, password)){//If Both are K
                effects.showOkay(picUsername, lblU, "Username is Okay");
                effects.showOkay(picPassword, lblP, "Password is Okay");
                if(username.ToLower().Contains("xoxo"))//Admins
                    effects.showThisHide(this, new DashBoard.adminPanel(username));
                else
                    effects.showThisHide(this, new DashBoard.memberLogin(username));

            }else{
                effects.showOkay(picUsername, lblU, "Username is Okay");
                if(server.userRegistered(username))//If username k
                    effects.showError(picPassword, lblP, "Password is Incorrect");
                else{
                    effects.showError(picUsername, lblU, "Username is Not Registered");
                    effects.showError(picPassword, lblP, "No Password for Un-Registered Account");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void btnSignin_Click(object sender, EventArgs e) {
            validateLogin();
        }


        private void panel2_MouseHover(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel2_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void pnlPassword_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlPassword);
        }
        private void pnlPassword_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlPassword);
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e) {

        }

        private void lblRegister_Click(object sender, EventArgs e) {
            effects.showThisHide(this, new Register.validate());
        }
    }
}
