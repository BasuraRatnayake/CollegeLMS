using CollegeLMS.DatabaseServer;
using System;
using System.Windows.Forms;

namespace CollegeLMS.Members{
    public partial class revokeMember:Form{

        GUIEffects effects = new GUIEffects();//GUI Effects
        Validation validate = new Validation();//Validations
        DatabaseServerClient server = new DatabaseServerClient();//Server Connection

        public revokeMember(){
            InitializeComponent();            
        }

        protected String nic = "";//National NIC
        private void revokeMembership(){
            nic = txtPassOld.Text;
            if(validate.NationalID(nic)){
                if(server.validNIC(nic)){
                    DialogResult result = MessageBox.Show("Are you sure want to revoke the membership of this NIC: "+ nic, "CLMS Control Panel", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                        if(server.revokeMembership(nic)){
                            MessageBox.Show("Membership of "+ nic+" is now revoked", "CLMS Control Panel", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.Close();
                        }
                }else
                    effects.showError(picPassOld, lblPassOld, "Invalid NIC Number");
            }else
                effects.showError(picPassOld, lblPassOld, "Invalid NIC Number");
        }

        private void btnSave_Click(object sender, EventArgs e){
            revokeMembership();
        }
    }
}
