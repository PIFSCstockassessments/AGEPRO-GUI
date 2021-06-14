using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlBootstrap : UserControl
  {
    public ControlBootstrap()
    {
      InitializeComponent();

      BootstrapIterations = "0";
      BootstrapScaleFactors = "0";
    }
    public string BootstrapFilename
    {
      get => textBoxBootstrapFile.Text;
      set => textBoxBootstrapFile.Text = value;
    }
    public string BootstrapIterations
    {
      get => textBoxNumBootstrapIterations.Text;
      set => textBoxNumBootstrapIterations.Text = value;
    }
    public string BootstrapScaleFactors
    {
      get => textBoxPopScaleFactors.Text;
      set => textBoxPopScaleFactors.Text = value;
    }


    /// <summary>
    /// Intializes the control's values and data bindings to the AgeproBootstrap object
    /// </summary>
    /// <param name="bootstrapOpt">AGEPRO CoreLib Bootstrap object</param>
    public void SetBootstrapControls(AgeproBootstrap bootstrapOpt)
    {

      //Clear any existing bindings before creating new ones.
      textBoxBootstrapFile.DataBindings.Clear();
      textBoxNumBootstrapIterations.DataBindings.Clear();
      textBoxPopScaleFactors.DataBindings.Clear();

      //Data Binding
      _ = textBoxBootstrapFile.DataBindings.Add("Text", bootstrapOpt, "bootstrapFile", false,
        DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxNumBootstrapIterations.DataBindings.Add("Text", bootstrapOpt, "numBootstraps", true,
        DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxPopScaleFactors.DataBindings.Add("Text", bootstrapOpt, "popScaleFactor", true,
        DataSourceUpdateMode.OnPropertyChanged);

      textBoxNumBootstrapIterations.PrevValidValue = BootstrapIterations;
      textBoxPopScaleFactors.PrevValidValue = BootstrapScaleFactors;
    }

    /// <summary>
    /// Handles File Dialog events after user presses the "Load File".
    /// </summary>
    /// <returns></returns>
    public static OpenFileDialog SetBootstrapOpenFileDialog()
    {
      OpenFileDialog openBootstrapFileDialog = new OpenFileDialog
      {
        InitialDirectory = "~",
        Filter = "AGEPRO bootstrap files (*.BSN)|*.bsn|All Files (*.*)|*.*",
        FilterIndex = 1,
        RestoreDirectory = true,
        Title = "Open AGEPRO Bootstrap File"
      };

      return openBootstrapFileDialog;
    }



    /// <summary>
    /// Input Validation
    /// </summary>
    /// <param name="validateFilename">Check existance of bootstrap file in system</param>
    /// <returns>Returns false on the first invalid object found. Otherwise true.</returns>
    public bool ValidateBootstrapInput(bool validateFilename = false)
    {
      List<string> errorMsgList = new List<string>();
      if (string.IsNullOrWhiteSpace(BootstrapIterations))
      {
        errorMsgList.Add("Missing Number of Bootstraps.");
      }
      if (string.IsNullOrWhiteSpace(BootstrapScaleFactors))
      {
        errorMsgList.Add("Missing Number of Bootstrap Scale Factors.");
      }

      if (validateFilename)
      {
        if (System.IO.File.Exists(BootstrapFilename) == false)
        {
          errorMsgList.Add("Bootstrap File not found in system.");
        }
      }

      ValidationResult results = ValidatableExtensions.EnumerateValidationResults(errorMsgList);

      if (results.IsValid == false)
      {
        _ = MessageBox.Show("Invalid Bootstrap values found: " + Environment.NewLine
            + results.Message, "AGEPRO Bootstrap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }

      return true;
    }

    /// <summary>
    /// Handles events that occur when user clicks the "Load File" Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonLoadFile_Click(object sender, EventArgs e)
    {
      if (sender is Button)
      {
        OpenFileDialog bootstrapFileDialog = SetBootstrapOpenFileDialog();
        if (bootstrapFileDialog.ShowDialog() == DialogResult.OK)
        {
          BootstrapFilename = bootstrapFileDialog.FileName;
        }
      }
    }

    /// <summary>
    /// Pop Scale Factor Validating Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxPopScaleFactors_Validating(object sender, CancelEventArgs e)
    {
      NftTextBox txtBootFac = sender as NftTextBox;
      if (double.TryParse(txtBootFac.Text, out double scaleFactor))
      {
        if (scaleFactor < 0)
        {
          _ = MessageBox.Show("Bootsrap Population Scale Factors must be a positive number.", 
            "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          txtBootFac.Text = txtBootFac.PrevValidValue;
          e.Cancel = true;
          return;
        }
      }
      else
      {
        _ = MessageBox.Show("Bootstrap Population Scale Factors must be a numeric value.", 
          "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtBootFac.Text = txtBootFac.PrevValidValue;
        e.Cancel = true;
        return;
      }
    }//end TextBoxPopScaleFactors_Validating

  }
}
