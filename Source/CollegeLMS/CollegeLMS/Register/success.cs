using System;
using System.Windows.Forms;

namespace CollegeLMS.Register {
    public partial class success:Form {
        String name = "";
        public success(String first, String last) {
            name=first[0].ToString().ToUpper()+first.Substring(1, first.Length-1)+" ";
            name+=last[0].ToString().ToUpper()+last.Substring(1, last.Length-1);
            InitializeComponent();
            lblName.Text=name;
        }

        GUIEffects effects = new GUIEffects();//GUI Effects

        private void button1_Click(object sender, EventArgs e) {
            effects.showThisHide(this, new signIn());
        }
    }
}
