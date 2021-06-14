using System.ComponentModel;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentParametricLognormal : ControlRecruitmentParametricBase
  {
    public ControlRecruitmentParametricLognormal()
    {
      InitializeComponent();
      ParametricCategory = ParametricType.Lognormal;

      textBoxMean.Text = "0";
      textBoxStdDeviation.Text = "0";
      textBoxPhi.Text = "0";
      textBoxLastResidual.Text = "0";

      textBoxMean.PrevValidValue = textBoxMean.Text;
      textBoxStdDeviation.PrevValidValue = textBoxStdDeviation.Text;
      textBoxPhi.PrevValidValue = textBoxPhi.Text;
      textBoxLastResidual.PrevValidValue = textBoxLastResidual.Text;

      //By Default, autocorrected vaules is seen as disabled
      labelPhi.Enabled = false;
      labelLastResidual.Enabled = false;
      textBoxPhi.Enabled = false;
      textBoxLastResidual.Enabled = false;
    }

    /// <summary>
    /// Sets up and data binds interface controls to ParametericRecruitent data.
    /// </summary>
    /// <param name="currentRecruit"></param>
    /// <param name="panelRecruitModelParameter"></param>
    public override void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit, Panel panelRecruitModelParameter)
    {
      ParametricLognormal currentLognormalRecruit = (ParametricLognormal)currentRecruit;

      DataBindTextBox(textBoxMean, currentLognormalRecruit, "mean");
      DataBindTextBox(textBoxStdDeviation, currentLognormalRecruit, "stdDev");

      textBoxMean.PrevValidValue = currentLognormalRecruit.Mean.ToString();
      textBoxStdDeviation.PrevValidValue = currentLognormalRecruit.Mean.ToString();

      if (currentLognormalRecruit.Autocorrelated)
      {
        labelPhi.Enabled = true;
        labelLastResidual.Enabled = true;
        textBoxPhi.Enabled = true;
        textBoxLastResidual.Enabled = true;

        DataBindTextBox(textBoxPhi, currentLognormalRecruit, "phi");
        DataBindTextBox(textBoxLastResidual, currentLognormalRecruit, "lastResidual");
      }

      base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
    }

    /// <summary>
    /// Validate Mean text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxMean_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate Standard Deviation text value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxStdDeviation_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate Phi text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxPhi_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate Last Residual text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxLastResidual_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }
  }
}
