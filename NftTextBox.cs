using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
    public class NftTextBox : TextBox
    {

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                return;
            }
            base.OnValidating(e);
        }
    }
}
