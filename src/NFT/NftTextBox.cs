using System;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  /// <summary>
  /// This is an extension class of the System.Windows.Forms.TextBox. 
  /// This includes basic validation and previous valid value. 
  /// </summary>
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
