using System;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public class NftTextBox : TextBox
  {

    public string PrevValidValue { get; set; }
    public string ParamName { get; set; }

    public NftTextBox()
    {
      PrevValidValue = string.Empty;
      CausesValidation = true;
    }

    protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
    {
      base.OnValidating(e);
    }

    protected override void OnValidated(EventArgs e)
    {
      PrevValidValue = Text;
      base.OnValidated(e);
    }

  }
}
