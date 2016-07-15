using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    
    public partial class ControlGeneral : UserControl
    {
        public ControlGeneral()
        {
            InitializeComponent();
        }

        public event EventHandler SetGeneral;
        

        private void buttonSetGeneral_Click(object sender, EventArgs e)
        {
            //Transfer general option values to input file class

            if (this.SetGeneral != null)
            {
                this.SetGeneral(sender, e);
            }
            
        }
    }
}
