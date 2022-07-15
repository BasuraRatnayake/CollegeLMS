using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeLMS.Register {
    public partial class generateSuccess:Form {
        public generateSuccess(String code) {
            InitializeComponent();
            lblCode.Text = code;
        }
    }
}
