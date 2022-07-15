using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.LibraryCard{
    public partial class generateCard:Form{

        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        Encryptions encryption = new Encryptions();//Encryptions and Codes
        Camera camera = new Camera();//Camera
        FileHandle fileHandle = new FileHandle();//File Download and Building

        private object[] data;//Data from the server
        // nic, uid, name, registered

        public generateCard(){}
        public generateCard(String id){
            InitializeComponent();
            data = server.getLICDetails(id);

            buildCard();
        }       

        private void buildCard(){
            lblNic.Text = data[0].ToString();
            lblUid.Text = data[1].ToString();
            lblRegD.Text = data[3].ToString();
            lblJoined.Text = data[3].ToString().Split(' ')[0].Replace('-', '/');

            int year = Convert.ToInt16(lblJoined.Text.Split('/')[2])+1;

            lblValid.Text = lblJoined.Text.Substring(0, lblJoined.Text.Length - 4)+ year;

            data[4] = "Files/User/Profiles/"+ data[4];//Set Path to File
            picUser.Image = fileHandle.buildImage(data[4].ToString());//Download and set profile image

            picCode.Image = camera.generateQR(data[2].ToString()+"|"+ data[0].ToString()+"|"+ data[1].ToString());

            lblFName.Text = data[5].ToString();
            lblName.Text = data[5].ToString();

            lblSex.Text = encryption.exploreNIC(data[0].ToString())[1];
            lblDob.Text = encryption.exploreNIC(data[0].ToString())[0];
        }
       

        private void btnPrintCard_Click(object sender, EventArgs e){
        }
    }
}
