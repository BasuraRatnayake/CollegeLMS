using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Members{
    public partial class newAddress:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String passOld;
        protected String street;
        protected String city;
        protected String NIC;
        protected String regCode;
        protected String username;

        public newAddress(String nic){
            InitializeComponent();
            NIC = nic;

            passOld = server.getMemberPass(NIC);//Get Password from Server
            regCode = passOld.Split('|')[1];
            passOld = passOld.Split('|')[0];

            username = server.getMemberUsername(regCode);
        }

        private void validateAddress(){
            if(txtPassOld.Text == passOld){//Check Old Password
                effects.showOkay(picPassOld, lblPassOld, "Password is Okay");
                street = txtPass.Text;
                city = txtPassConfirm.Text;

                if(validate.StreetName(street) && validate.StreetName(city)){
                    effects.showOkay(picPass, lblPass, "Street is Okay");
                    effects.showOkay(picPassConfirm, lblPassConfirm, "City is Okay");
                    if(server.changeMemberAddress(username, street, city)){
                        MessageBox.Show("Address Changed", "CLMS Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }else{
                    if(validate.StreetName(street))
                        effects.showOkay(picPass, lblPass, "Street is Okay");
                    else
                        effects.showError(picPass, lblPass, "Street is Invalid");

                    if(validate.StreetName(city))
                        effects.showOkay(picPassConfirm, lblPassConfirm, "City is Okay");
                    else
                        effects.showError(picPassConfirm, lblPassConfirm, "City is Invalid");
                }
            }else
                effects.showError(picPassOld, lblPassOld, "Incorrect Password");
        }

        private void btnSave_Click(object sender, EventArgs e){
            validateAddress();
        }
    }
}
