using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.SignIn{
    public partial class newPassword:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String passOld;
        protected String passNew;
        protected String pasConfirm;
        protected String NIC;
        protected String regCode;

        public newPassword(String nic){
            InitializeComponent();
            NIC = nic;

            passOld = server.getMemberPass(NIC);//Get Password from Server
            regCode = passOld.Split('|')[1];
            passOld = passOld.Split('|')[0];
        }

        private void validatePassword(){//Validate and Change Password
            if(txtPassOld.Text == passOld) {//Check Old Password
                effects.showOkay(picPassOld, lblPassOld, "Old Password is Okay");
                passNew = txtPass.Text;
                pasConfirm = txtPassConfirm.Text;

                if(validate.Password(passNew)){//Validate Password
                    effects.showOkay(picPass, lblPass, "New Password is Okay");
                    if(passNew == pasConfirm){
                        effects.showOkay(picPassConfirm, lblPassConfirm, "Password Confirm is Okay");
                        if(server.changeMemberPass(regCode, passNew)){
                            MessageBox.Show("Password Changed", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }else
                        effects.showError(picPassConfirm, lblPassConfirm, "Password Doesn't Match");
                }else
                    effects.showError(picPass, lblPass, "A password must contain atleast 10 Chars");
            }else
                effects.showError(picPassOld, lblPassOld, "Incorrect Old Password");
        }

        private void btnSave_Click(object sender, EventArgs e){
            validatePassword();
        }
    }
}
