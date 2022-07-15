using System;
using System.Windows.Forms;
using System.Drawing;
using CollegeLMS.DatabaseServer;
using CollegeLMS.FileServer;

namespace CollegeLMS.Members{
    public partial class showLoginDV:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection
        Encryptions encryption = new Encryptions();//Encryptions and Codes

        String[] details;//Book Details from Server
        String file = "Files/";

        public showLoginDV(String[] data){
            InitializeComponent();
            details = data;//Data from Server
            initDetails();
        }

        private void initDetails(){//Set Data to the Controls    
            lblReg.Text = details[0];
            lblNic.Text = details[1];
            lblSid.Text = details[2];
            lblRegD.Text = details[3];
            lblName.Text = details[8]+" "+ details[9];
            lblAdd.Text = details[10]+ ", "+ details[11];
            lblMN.Text = details[12];
            lblHN.Text = details[13];
            lblUser.Text = details[5];
            lblPass.Text = encryption.makePasswordX(details[6]);
            lblEmail.Text = details[7];

            String memberType = details[2];
            memberType = memberType.Split('-')[0];

            if(memberType == "STAFF")
                memberType = "Staff Member";
            else
                memberType = "Student";
            lblType.Text = memberType;


            String file = "Files/User/Profiles/" + details[4];
            picBook.Image = Image.FromFile(file);//Get Image
        }
        
    }
}
