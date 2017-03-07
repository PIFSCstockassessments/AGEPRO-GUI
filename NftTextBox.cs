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

        public string prevValidValue { get; set; }   
        public string paramName { get; set; }

        public NftTextBox()
        {
            this.prevValidValue = string.Empty;
            this.CausesValidation = true;
        }



        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                if (!string.IsNullOrWhiteSpace(this.prevValidValue))
                {
                    this.Text = this.prevValidValue;
                }
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
