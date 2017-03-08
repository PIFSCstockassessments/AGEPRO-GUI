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

        public string PrevValidValue { get; set; }   
        public string ParamName { get; set; }

        public NftTextBox()
        {
            this.PrevValidValue = string.Empty;
            this.CausesValidation = true;
        }



        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            this.PrevValidValue = this.Text;
            base.OnValidated(e);
        }
          
    }
}
