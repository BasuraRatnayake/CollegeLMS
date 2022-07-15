using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CollegeLMS.Newspaper{
    public partial class showQR:Form{

        Camera camera = new Camera();//Camera

        public showQR(String type, String code, String Title){
            InitializeComponent();

            if(type == "NEWSPAPER")
                type = "NewM_N";
            else
                type = "NewM_M";


            picCode.Image = camera.generateQR(Title + "|" + code + "|" + type);

            this.Text = "QR Code for "+ Title;
        }

        PrintDocument printDocument1 = new PrintDocument();
        private void btnPrintCard_Click(object sender, EventArgs e) {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawImage(picCode.Image, 0, 0);
        }
    }
}
