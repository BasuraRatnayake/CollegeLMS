using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS.Register {
    public partial class validate:Form {
        public validate() {
            InitializeComponent();
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validateD = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        Encryptions encryption = new Encryptions();

        protected String regCode = "";
        public void setRegCode() {//Initialize the Reg Code Variable
            regCode = txtUsername.Text;
        }

        private void validateCode() {//Validate RegCode and Forward User to Register Screen
            setRegCode();

            if(validateD.RegCode(regCode)) {
                this.Cursor = Cursors.WaitCursor;
                Boolean codeK = server.regCodeAvailable(regCode);//Check whether code already in db
                this.Cursor = Cursors.Default;
                if(!codeK) {
                    effects.showOkay(picUsername, lblU, "Registration Code is Okay");
                    register r = new register(regCode);
                    this.Hide();
                    r.Show();
                }else
                    effects.showError(picUsername, lblU, "Invalid Registration Code");
            }else
                effects.showError(picUsername, lblU, "Invalid Registration Code");
        }

        private void btnValidate_Click(object sender, EventArgs e) {
            validateCode();
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void txtUsername_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlUsername);
        }
    }
}
