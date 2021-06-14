using System;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlStochasticAgeFromFile : UserControl
  {
    public event EventHandler TimeVaryingFileChecked;
    public string stochasticParameterFileLabel;

    public ControlStochasticAgeFromFile()
    {
      InitializeComponent();
      stochasticParameterFileLabel = "Stochastic Parameter";
    }
    public string StochasticDataFile
    {
      get { return textBoxDataFile.Text; }
      set { textBoxDataFile.Text = value; }
    }

    public void CheckBoxTimeVaryingFile_CheckedChanged(object sender, EventArgs e)
    {
      TimeVaryingFileChecked?.Invoke(sender, e);

    }

    private void ButtonLoadDataFile_Click(object sender, EventArgs e)
    {
      OpenFileDialog openStochasticDataFile = new OpenFileDialog
      {
        InitialDirectory = @"~",
        Title = "Open " + stochasticParameterFileLabel + " Data File",
        Filter = "All Files (*.*)|*.*",
        FilterIndex = 1,
        RestoreDirectory = true
      };

      if (openStochasticDataFile.ShowDialog() == DialogResult.OK)
      {
        try
        {
          textBoxDataFile.Text = openStochasticDataFile.FileName;
        }
        catch (Exception ex)
        {
          _ = MessageBox.Show($"Can not load AGEPRO Stochastic Data File.{Environment.NewLine}{ex.Message}", "",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
    }
  }
}
