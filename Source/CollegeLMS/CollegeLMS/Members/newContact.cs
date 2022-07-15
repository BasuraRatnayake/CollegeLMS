using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Members{
    public partial class newContact:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String passOld;
        protected String mobile;
        protected String home;
        protected String NIC;
        protected String regCode;
        protected String username;

        public newContact(String nic){
            InitializeComponent();
            NIC = nic;

            passOld = server.getMemberPass(NIC);//Get Password from Server
            regCode = passOld.Split('|')[1];
            passOld = passOld.Split('|')[0];

            username = server.getMemberUsername(regCode);
        }

        private void ValidateContact(){
            if(txtPassOld.Text == passOld){//Check Old Password
                effects.showOkay(picPassOld, lblPassOld, "Password is Okay");
                mobile = txtPass.Text;
                home = txtPassConfirm.Text;

                if(validate.PhoneNumber(mobile) && validate.PhoneNumber(home)){
                    effects.showOkay(picPass, lblPass, "Mobile is Okay");
                    effects.showOkay(picPassConfirm, lblPassConfirm, "Home Number is Okay");
                    if(server.changeMemberContact(username, mobile, home)){
                        MessageBox.Show("Contact Details Changed", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }else{
                    if(validate.PhoneNumber(mobile))
                        effects.showOkay(picPass, lblPass, "Mobile is Okay");
                    else
                        effects.showError(picPass, lblPass, "Mobile is Invalid");

                    if(validate.PhoneNumber(home))
                        effects.showOkay(picPassConfirm, lblPassConfirm, "Home Number is Okay");
                    else
                        effects.showError(picPassConfirm, lblPassConfirm, "Home Number is Invalid");
                }
            }else
                effects.showError(picPassOld, lblPassOld, "Incorrect Password");
        }

        private void btnSave_Click(object sender, EventArgs e){
            ValidateContact();
        }
    }
}
