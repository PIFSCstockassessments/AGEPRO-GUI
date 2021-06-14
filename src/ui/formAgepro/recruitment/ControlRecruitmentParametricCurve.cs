using System.ComponentModel;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentParametricCurve : ControlRecruitmentParametricBase
  {
    public ControlRecruitmentParametricCurve()
    {
      InitializeComponent();
      ParametricCategory = ParametricType.Curve;

      textBoxAlpha.Text = "0";
      textBoxBeta.Text = "0";
      textBoxKParm.Text = "0";
      textBoxVariance.Text = "0";
      textBoxPhi.Text = "0";
      textBoxLastResidual.Text = "0";

      textBoxAlpha.PrevValidValue = textBoxAlpha.Text;
      textBoxBeta.PrevValidValue = textBoxBeta.Text;
      textBoxKParm.PrevValidValue = textBoxKParm.Text;
      textBoxVariance.PrevValidValue = textBoxVariance.Text;
      textBoxPhi.PrevValidValue = textBoxPhi.Text;
      textBoxLastResidual.PrevValidValue = textBoxLastResidual.Text;

      //By default, K-Parm is invisible
      labelKparm.Visible = false;
      textBoxKParm.Visible = false;

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
      ParametricCurve currentParametricCurveRecruit = (ParametricCurve)currentRecruit;
      DataBindTextBox(textBoxAlpha, currentParametricCurveRecruit, "alpha");
      DataBindTextBox(textBoxBeta, currentParametricCurveRecruit, "beta");
      DataBindTextBox(textBoxVariance, currentParametricCurveRecruit, "variance");

      textBoxAlpha.PrevValidValue = currentParametricCurveRecruit.Alpha.ToString();
      textBoxBeta.PrevValidValue = currentParametricCurveRecruit.Beta.ToString();
      textBoxVariance.PrevValidValue = currentParametricCurveRecruit.Variance.ToString();

      if (currentParametricCurveRecruit.GetType() == typeof(ParametricShepherdCurve))
      {
        labelKparm.Visible = true;
        textBoxKParm.Visible = true;
        DataBindTextBox(textBoxKParm, currentParametricCurveRecruit, "kParm");
        textBoxKParm.PrevValidValue = ((ParametricShepherdCurve)currentParametricCurveRecruit).KParm.ToString();
      }

      if (currentParametricCurveRecruit.Autocorrelated)
      {
        labelPhi.Enabled = true;
        labelLastResidual.Enabled = true;
        textBoxPhi.Enabled = true;
        textBoxLastResidual.Enabled = true;

        DataBindTextBox(textBoxPhi, currentParametricCurveRecruit, "phi");
        DataBindTextBox(textBoxLastResidual, currentParametricCurveRecruit, "lastResidual");
        textBoxPhi.PrevValidValue = currentParametricCurveRecruit.Phi.Value.ToString();
        textBoxLastResidual.PrevValidValue = currentParametricCurveRecruit.LastResidual.Value.ToString();
      }

      base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
    }

    /// <summary>
    /// Validate Alpha Curve text boc value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxAlpha_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate Beta Curve text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxBeta_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate Variance text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxVariance_Validating(object sender, CancelEventArgs e)
    {
      ValidateParamerticParameter(sender as NftTextBox, e);
    }

    /// <summary>
    /// Validate KParm text box value as numeric. See also:
    /// <seealso cref="ControlRecruitmentParametricBase.ValidateParamerticParameter(NftTextBox, CancelEventArgs)"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxKParm_Validating(object sender, CancelEventArgs e)
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
