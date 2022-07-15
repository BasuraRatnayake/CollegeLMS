using System;
using System.Windows.Forms;
using CollegeLMS.DatabaseServer;

namespace CollegeLMS.Register {
    public partial class register:Form {

        protected String uRegCode = "";//Registration Code
        public register(String regCode) {
            InitializeComponent();
            uRegCode = regCode;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        private String[] personal = new String[3];
        private String[] contact = new String[1];
        private String[] login = new String[1];

        private void setInputs(){//Set Inputs to the arrays
            personal = new String[] {//Set Personal Details
                txtFirst.Text, txtLast.Text, txtStreet.Text, txtCity.Text
            };
            contact = new String[] {//Set Contact Details
                txtMobile.Text, txtHome.Text
            };
            login = new String[] {//Set Login Details
                txtUsername.Text, txtEmail.Text, txtPassword.Text, txtConP.Text
            };
        }

        private void setValidateMarker(Boolean status, PictureBox pic, Label label, String[] msg) {//Input Validation Function
            if(status)
                effects.showOkay(pic, label, msg[0]);
            else
                effects.showError(pic, label, msg[1]);
        }
        private Boolean validateInputs() {//Validate All Inputs
            PictureBox[] pics = new PictureBox[] {//Picture Boxes to Show Statuses
                picFirst, picStreet, picCity, picMobile, picHome, picUsername, picEmail, picPassword, picConP
            };

            Label[] labels = new Label[] {//Labels to Show the Messages
                lblFirst, lblStreet, lblCity, lblMobile, lblHome, lblUsername, lblEmail, lblPassword, lblConP
            };

            String[,] msgs = new String[,] { //Messages
                { "Your Name is Okay", "Enter Your Real Name" }, 
                { "Your Street is Okay", "Enter Your Real Street" }, 
                { "Your City is Okay", "Enter Your Real City" }, 
                { "Your Mobile Number is Okay", "Enter Your Real Mobile Number" },
                { "Your Home Number is Okay", "Enter Your Real Home Number" },
                { "Your Username is Okay", "Username must be 10-20 Characters(A-Z,0-9,_)" },
                { "Your Email is Okay", "Enter Your Real Valid Email Address" },
                { "Your Password is Okay", "Password must be 10-60 Characters(A-Z,0-9,_,.)"},
                { "Password Confirmation is Okay", "Password Doesn't Match" }
            };
            Boolean[] allOkay = new Boolean[9];//Status of Validated Inputs

            Boolean[] conditions = new Boolean[] {//Conditions to Match Against the Inputs
                (validate.FirstLastName(personal[0]) && validate.FirstLastName(personal[1])),
                validate.StreetName(personal[2]),
                validate.FirstLastName(personal[3]),
                validate.PhoneNumber(contact[0]),
                validate.PhoneNumber(contact[1]),
                validate.Username(login[0]),
                validate.Email(login[1]),
                validate.Password(login[2]),
                (validate.Password(login[2]) && (login[2] == login[3]))
            };

            int count = 0;//Count the Number of Valid Inputs
            for(int i = 0; i < 9; i++) { //Validate Inputs
                setValidateMarker(conditions[i], pics[i], labels[i], new String[] { msgs[i, 0], msgs[i, 1] });
                allOkay[i] = conditions[i];
                if(allOkay[i])//Count Number of Valid Inputs
                    count++;
            }

            return (count==9);//Return the count as statement
        }

        private void registerStudent() {//Register Student
            setInputs();//Set Data
            if(validateInputs()) {//Result of Validated Inputs
                Boolean status = server.registerUser(uRegCode, personal, contact, login);//Send data to server
                if(status) {
                    Register.success s = new success(personal[0], personal[1]);
                    this.Hide();
                    s.Show();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            registerStudent();
        }

        #region EL_Mouse
        private void txtFirst_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlFirst);
        }
        private void txtFirst_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlFirst);
        }

        private void panel3_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlLast);
        }
        private void panel3_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlLast);
        }

        private void panel4_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlStreet);
        }
        private void panel4_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlStreet);
        }

        private void panel6_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlCity);
        }
        private void panel6_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlCity);
        }

        private void panel10_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlMobile);
        }
        private void panel10_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlMobile);
        }

        private void panel8_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlHome);
        }
        private void panel8_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlHome);
        }

        private void panel14_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlUsername);
        }
        private void panel14_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlUsername);
        }

        private void panel12_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlEmail);
        }
        private void panel12_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlEmail);
        }

        private void panel18_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlPassword);
        }
        private void panel18_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlPassword);
        }

        private void panel16_MouseEnter(object sender, EventArgs e) {
            effects.changeTextBorder_MO(pnlConP);
        }
        private void panel16_MouseLeave(object sender, EventArgs e) {
            effects.changeTextBorder_ML(pnlConP);
        }
        #endregion

        
        private void txtPassword_Enter(object sender, EventArgs e) {
            txtPassword.PasswordChar = '=';
        }
        private void txtConP_Enter(object sender, EventArgs e) {
            txtConP.PasswordChar = '=';
        }
    }
}
