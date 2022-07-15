using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.DashBoard{
    public partial class chooseUser:Form{

        private Form direction = null;//Direction of the operation
        private String path = null;

        public chooseUser(String Direction){
            InitializeComponent();
            path = Direction;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        protected String nic = "";//National NIC

        private void btnPrintCard_Click(object sender, EventArgs e){
            nic = txtUsername.Text;
            if(validate.NationalID(nic)){
                if(server.validNIC(nic)) {
                    switch(path) {
                        case "generateCard":
                            direction = new LibraryCard.generateCard(nic);
                            break;
                        case "changePass":
                            direction = new SignIn.newPassword(nic);
                            break;
                        case "changeEmail":
                            direction = new SignIn.newEmail(nic);
                            break;
                        case "changeCon":
                            direction = new Members.newContact(nic);
                            break;
                        case "changeAdd":
                            direction = new Members.newAddress(nic);
                            break;
                    }
                    effects.showDialog(direction);
                    this.Hide();
                    direction.BringToFront();
                }else
                    effects.showError(picUsername, lblU, "Invalid NIC Number");
            }else 
                effects.showError(picUsername, lblU, "Invalid NIC Number");
        }
    }
}
