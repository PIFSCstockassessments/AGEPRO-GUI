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

        private string prevValidValue = string.Empty;
        private string paramName { get; set; }

        public NftTextBox()
        {
            this.CausesValidation = true;
        }



        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                e.Cancel = true;
                return;
            }
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            this.prevValidValue = this.Text;
            base.OnValidated(e);
        }
          
    }
}
