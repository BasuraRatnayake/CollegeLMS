using CollegeLMS.DatabaseServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeLMS.SignIn{
    public partial class newEmail:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String passOld;
        protected String emailNew;
        protected String emailConfirm;
        protected String NIC;
        protected String regCode;

        public newEmail(String nic){
            InitializeComponent();
            NIC = nic;

            passOld = server.getMemberPass(NIC);//Get Password from Server
            regCode = passOld.Split('|')[1];
            passOld = passOld.Split('|')[0];
        }

        private void validateEmail(){//Validate and Change Password
            if(txtPassOld.Text == passOld) {//Check Old Password
                effects.showOkay(picPassOld, lblPassOld, "Password is Okay");
                emailNew = txtPass.Text;
                emailConfirm = txtPassConfirm.Text;

                if(Regex.Match(emailNew, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase).Success) {
                    effects.showOkay(picPass, lblPass, "New Email is Okay");
                    if(emailNew == emailConfirm) {
                        effects.showOkay(picPassConfirm, lblPassConfirm, "Email Confirm is Okay");
                        if(server.changeMemberEmail(regCode, emailNew)) {
                            MessageBox.Show("Email Changed", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }else
                        effects.showError(picPassConfirm, lblPassConfirm, "Email Doesn't Match");
                }else
                    effects.showError(picPass, lblPass, "A Email must valid");
            }else
                effects.showError(picPassOld, lblPassOld, "Incorrect Password");
        }

        private void btnSave_Click(object sender, EventArgs e){
            validateEmail();
        }
    }
}
