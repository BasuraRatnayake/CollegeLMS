using System;
using System.Windows.Forms;

namespace CollegeLMS.IssueResources {
    public partial class issuedResource:Form{
        private String[] resDetails;//Resource and Member Details

        public issuedResource(String[] data) {
            InitializeComponent();

            setData(data);
        }

        private void setData(String[] resDetails){
            lblName.Text = resDetails[0];
            lblRName.Text = resDetails[1];

            if(resDetails[1].Split(' ').Length > 0) {
                lblIDate.Text = resDetails[2].Split(' ')[0];
                lblRDate.Text = resDetails[3].Split(' ')[0];
            }else {
                lblIDate.Text = resDetails[2];
                lblRDate.Text = resDetails[3];
            }

            if(resDetails[4] == "returned = 'Y'") 
                lblRemainData.Text = "Resource Already Returned";
            else{
                int day,month,year;
                DateTime Idate = DateTime.Now.Date;

                day = Convert.ToInt16(lblRDate.Text.Split('/')[0]);
                month = Convert.ToInt16(lblRDate.Text.Split('/')[1]);
                year = Convert.ToInt16(lblRDate.Text.Split('/')[2]);
                DateTime Rdate = new DateTime(year, month, day);

                double rem = Rdate.Subtract(Idate).TotalDays;                
                lblRemaning.Text = "0" + rem.ToString();
            }
        }
    }
}
