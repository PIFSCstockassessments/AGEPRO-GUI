using Nmfs.Agepro.CoreLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  /// <summary>
  /// Settings for AGEPRO output and optional parameters.
  /// </summary>
  public partial class ControlMiscOptions : UserControl
  {
    public int miscOptionsNAges { get; set; }
    public int miscOptionsFirstAge { get; set; }

    public ControlMiscOptions()
    {
      InitializeComponent();

      //AGEPRO Ouptput Viewer Program
      comboBoxOutputViewerProgram.SelectedIndex = 0;

      //Set Bounds defaults
      MiscOptionsBoundsMaxWeight = "10.0";
      MiscOptionsBoundsNaturalMortality = "1.0";

      //Refpoints
      MiscOptionsRefJan1Biomass = "0.0";
      MiscOptionsRefMeanBiomass = "0.0";
      MiscOptionsRefSpawnBiomass = "0.0";
      MiscOptionsRefFishingMortality = "0.0";

      //Scale Factors
      MiscOptionsScaleFactorBiomass = "0.0";
      MiscOptionsScaleFactorRecruits = "0.0";
      MiscOptionsScaleFactorStockNumbers = "0.0";

      //Report Percentile
      MiscOptionsReportPercentile = 0;
    }

    public bool MiscOptionsEnableSummaryReport
    {
      get => checkBoxEnableSummaryReport.Checked;
      set => checkBoxEnableSummaryReport.Checked = value;
    }
    public bool MiscOptionsEnableAuxStochasticFiles
    {
      get => checkBoxEnableAuxStochasticFiles.Checked;
      set => checkBoxEnableAuxStochasticFiles.Checked = value;
    }
    public bool MiscOptionsEnableExportR
    {
      get => checkBoxEnableExportR.Checked;
      set => checkBoxEnableExportR.Checked = value;
    }
    public bool MiscOptionsEnablePercentileReport
    {
      get => checkBoxEnablePercentileReport.Checked;
      set => checkBoxEnablePercentileReport.Checked = value;
    }
    public double MiscOptionsReportPercentile
    {
      get => Convert.ToDouble(spinBoxReportPercentile.Value);
      set => spinBoxReportPercentile.Value = Convert.ToDecimal(value);
    }
    public bool MiscOptionsEnableRefpointsReport
    {
      get => checkBoxEnableRefpoints.Checked;
      set => checkBoxEnableRefpoints.Checked = value;
    }
    public string MiscOptionsRefSpawnBiomass
    {
      get => textBoxRefSpawnBiomass.Text;
      set => textBoxRefSpawnBiomass.Text = value;
    }
    public string MiscOptionsRefJan1Biomass
    {
      get => textBoxRefJan1Biomass.Text;
      set => textBoxRefJan1Biomass.Text = value;
    }
    public string MiscOptionsRefMeanBiomass
    {
      get => textBoxRefMeanBiomass.Text;
      set => textBoxRefMeanBiomass.Text = value;
    }
    public string MiscOptionsRefFishingMortality
    {
      get => textBoxRefFishMortality.Text;
      set => textBoxRefFishMortality.Text = value;
    }
    public bool MiscOptionsEnableScaleFactors
    {
      get => checkBoxEnableScaleFactors.Checked;
      set => checkBoxEnableScaleFactors.Checked = value;
    }
    public string MiscOptionsScaleFactorBiomass
    {
      get => textBoxScaleFactorBiomass.Text;
      set => textBoxScaleFactorBiomass.Text = value;
    }
    public string MiscOptionsScaleFactorRecruits
    {
      get => textBoxScaleFactorRecruits.Text;
      set => textBoxScaleFactorRecruits.Text = value;
    }
    public string MiscOptionsScaleFactorStockNumbers
    {
      get => textBoxScaleFactorsStockNum.Text;
      set => textBoxScaleFactorsStockNum.Text = value;
    }
    public bool MiscOptionsBounds
    {
      get => checkBoxBounds.Checked;
      set => checkBoxBounds.Checked = value;
    }
    public string MiscOptionsBoundsMaxWeight
    {
      get => textBoxBoundsMaxWeight.Text;
      set => textBoxBoundsMaxWeight.Text = value;
    }
    public string MiscOptionsBoundsNaturalMortality
    {
      get => textBoxBoundsNatMortality.Text;
      set => textBoxBoundsNatMortality.Text = value;
    }
    public bool MiscOptionsEnableRetroAdjustmentFactors
    {
      get => checkBoxEnableRetroAdjustment.Checked;
      set => checkBoxEnableRetroAdjustment.Checked = value;
    }
    public DataTable MiscOptionsRetroAdjustmentFactorTable
    {
      get => (DataTable)dataGridRetroAdjustment.DataSource;
      set => dataGridRetroAdjustment.DataSource = value;
    }
    public string AgeproOutputViewer => comboBoxOutputViewerProgram.SelectedItem.ToString();

    public void SetRetroAdjustmentFactorRowHeaders()
    {
      dataGridRetroAdjustment.RowHeadersVisible = true;
      for (int iage = 0; iage < miscOptionsNAges; iage++)
      {
        //Accomidate 0-based or 1-based First Age Models
        int iageForHeader = iage + miscOptionsFirstAge;
        dataGridRetroAdjustment.Rows[iage].HeaderCell.Value = "Age " + iageForHeader;
      }
    }

    /// <summary>
    /// Data Binding setup for Reference Point Options Controls
    /// </summary>
    /// <param name="miscOpt">Refrerence Points Option Object</param>
    public void SetupRefpointDataBindings(CoreLib.Refpoint miscOpt)
    {
      SetControlDataBindings(textBoxRefSpawnBiomass, miscOpt, "refSpawnBio");
      SetControlDataBindings(textBoxRefJan1Biomass, miscOpt, "refJan1Bio");
      SetControlDataBindings(textBoxRefMeanBiomass, miscOpt, "refMeanBio");
      SetControlDataBindings(textBoxRefFishMortality, miscOpt, "refFMort");
    }

    /// <summary>
    /// Data Binding setup for Scale Factor Controls
    /// </summary>
    /// <param name="miscOpt">AGEPRO CoreLib Misc Options Object</param>
    public void SetupScaleFactorsDataBindings(CoreLib.ScaleFactors miscOpt)
    {
      SetControlDataBindings(textBoxScaleFactorBiomass, miscOpt, "scaleBio");
      SetControlDataBindings(textBoxScaleFactorRecruits, miscOpt, "scaleRec");
      SetControlDataBindings(textBoxScaleFactorsStockNum, miscOpt, "scaleStockNum");
    }

    /// <summary>
    /// Data Binding setup for Bounds Controls
    /// </summary>
    /// <param name="miscOpt">AGEPRO CoreLib Misc Options Object</param>
    public void SetupBoundsDataBindings(CoreLib.Bounds miscOpt)
    {
      SetControlDataBindings(textBoxBoundsMaxWeight, miscOpt, "maxWeight", true);
      SetControlDataBindings(textBoxBoundsNatMortality, miscOpt, "maxNatMort", true);
    }

    /// <summary>
    /// Textbox data bindings
    /// </summary>
    /// <param name="ctl"> <see cref="NftTextBox"/> Control </param>
    /// <param name="miscOptSrc"> Generalized class that encapsulates AGEPRO's <see cref="CoreLib.AgeproOptionsProperty"/> Classes </param>
    /// <param name="miscOptField"> Field names of specfic <see cref="AgeproOptionsProperty"/> class.</param>
    /// <param name="decimalZeroFormat">Boolean flag to format to include point-decimal values.  </param>
    private void SetControlDataBindings(NftTextBox ctl, CoreLib.AgeproOptionsProperty miscOptSrc, string miscOptField,
      bool decimalZeroFormat = false)
    {
      //Clear any existing (if any) bindings before creating new ones.
      ctl.DataBindings.Clear();

      Binding b = new Binding("Text", miscOptSrc, miscOptField, true, DataSourceUpdateMode.OnPropertyChanged);
      if (decimalZeroFormat)
      {
        b.Format += new ConvertEventHandler(DoubleToString);
        b.Parse += new ConvertEventHandler(StringToDouble);
        ctl.DataBindings.Add(b);
      }
      else
      {
        ctl.DataBindings.Add(b);
      }

    }

    /// <summary>
    /// Double to String
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="sevent"></param>
    private void DoubleToString(object sender, ConvertEventArgs sevent)
    {
      // The method converts only to string type. Test this using the DesiredType.
      if (sevent.DesiredType != typeof(string))
      {
        return;
      }

      // Use the ToString method to format the value.
      sevent.Value = ((double)sevent.Value).ToString("#.0");
    }

    /// <summary>
    /// String to Double
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="sevent"></param>
    private void StringToDouble(object sender, ConvertEventArgs sevent)
    {
      // ' The method converts only to decimal type. 
      if (sevent.DesiredType != typeof(double)) return;

      // Converts the string back to decimal using the static ToDouble method.
      sevent.Value = Convert.ToDouble(sevent.Value.ToString());
    }

    /// <summary>
    /// Actions when "Request Percentile Report" check Box is changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxPercentileReport_CheckStateChanged(object sender, EventArgs e)
    {
      bool enabledPercentileReport = checkBoxEnablePercentileReport.Checked;
      Console.WriteLine(enabledPercentileReport);
      labelReportPercentile.Enabled = enabledPercentileReport;
      spinBoxReportPercentile.Enabled = enabledPercentileReport;
    }

    /// <summary>
    /// Enable or Disable the Report Percentile UI elements by determining the 
    /// "Request Perecentile Report" check box "checked" value it was was changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxPercentileReport_CheckedChanged(object sender, EventArgs e)
    {
      labelReportPercentile.Enabled = checkBoxEnablePercentileReport.Checked;
      spinBoxReportPercentile.Enabled = checkBoxEnablePercentileReport.Checked;
    }

    /// <summary>
    /// Actions when "Enable Reference Point Threshold Report" check Box is changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxRefpoints_CheckedChanged(object sender, EventArgs e)
    {
      labelSpawnBiomass.Enabled = checkBoxEnableRefpoints.Checked;
      textBoxRefSpawnBiomass.Enabled = checkBoxEnableRefpoints.Checked;
      labelJan1Biomass.Enabled = checkBoxEnableRefpoints.Checked;
      textBoxRefJan1Biomass.Enabled = checkBoxEnableRefpoints.Checked;
      labelMeanBiomass.Enabled = checkBoxEnableRefpoints.Checked;
      textBoxRefMeanBiomass.Enabled = checkBoxEnableRefpoints.Checked;
      labelFishMortality.Enabled = checkBoxEnableRefpoints.Checked;
      textBoxRefFishMortality.Enabled = checkBoxEnableRefpoints.Checked;
    }

    /// <summary>
    /// Actions when "Specify Scale Factors for Output Report" check Box is changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxScaleFactors_CheckedChanged(object sender, EventArgs e)
    {
      labelScaleFactorBiomass.Enabled = checkBoxEnableScaleFactors.Checked;
      textBoxScaleFactorBiomass.Enabled = checkBoxEnableScaleFactors.Checked;
      labelScaleFactorRecruits.Enabled = checkBoxEnableScaleFactors.Checked;
      textBoxScaleFactorRecruits.Enabled = checkBoxEnableScaleFactors.Checked;
      labelScaleFactorStockNum.Enabled = checkBoxEnableScaleFactors.Checked;
      textBoxScaleFactorsStockNum.Enabled = checkBoxEnableScaleFactors.Checked;

    }

    /// <summary>
    /// Actions when "Specify Bounds" check Box is changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxBounds_CheckedChanged(object sender, EventArgs e)
    {
      labelBoundsMaxWeight.Enabled = checkBoxBounds.Checked;
      textBoxBoundsMaxWeight.Enabled = checkBoxBounds.Checked;
      labelBoundsNatMortality.Enabled = checkBoxBounds.Checked;
      textBoxBoundsNatMortality.Enabled = checkBoxBounds.Checked;
    }

    /// <summary>
    /// Actions when "Specify Retro Adjustment Factors" check Box is changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxRetroAdjustment_CheckedChanged(object sender, EventArgs e)
    {

      if (checkBoxEnableRetroAdjustment.Checked == false)
      {
        dataGridRetroAdjustment.DataSource = null;
      }
      else
      {
        //If Checked, create fallback defualt data table.
        dataGridRetroAdjustment.DataSource = GetRetroAdjustmentFallbackTable(miscOptionsNAges);

        SetRetroAdjustmentFactorRowHeaders();

      }
    }

    /// <summary>
    /// Input Validation
    /// </summary>
    /// <returns></returns>
    public bool ValidateMiscOptions()
    {
      List<string> errorMsgList = new List<string>();
      //Reference Points
      if (MiscOptionsEnableRefpointsReport)
      {
        if (string.IsNullOrWhiteSpace(MiscOptionsRefJan1Biomass))
        {
          MiscOptionsRefJan1Biomass = "0.0";
        }
        if (string.IsNullOrWhiteSpace(MiscOptionsRefMeanBiomass))
        {
          MiscOptionsRefMeanBiomass = "0.0";
        }
        if (string.IsNullOrWhiteSpace(MiscOptionsRefSpawnBiomass))
        {
          MiscOptionsRefSpawnBiomass = "0.0";
        }
        if (string.IsNullOrWhiteSpace(MiscOptionsRefFishingMortality))
        {
          MiscOptionsRefFishingMortality = "0.0";
        }
      }
      //Retrospective Adjustment Factors
      if (dataGridRetroAdjustment.HasBlankOrNullCells())
      {
        errorMsgList.Add("Retro Adjustment Factors data grid has missing data.");
      }

      //Report Percentile
      if (MiscOptionsEnablePercentileReport)
      {
        //todo: spinbox text issue
        if (string.IsNullOrWhiteSpace(MiscOptionsReportPercentile.ToString()))
        {
          errorMsgList.Add("Missing Report Percentile");
        }

        if (MiscOptionsReportPercentile < 0.0 || MiscOptionsReportPercentile > 100)
        {
          errorMsgList.Add("Invalid Report Percent value.");
        }

      }

      if (errorMsgList.Any())
      {
        MessageBox.Show("Invalid values found in Misc. Options: " + Environment.NewLine +
            string.Join(Environment.NewLine, errorMsgList),
            "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        return false;
      }

      return true;
    }

    /// <summary>
    /// Row-count based auxilary stochastic file checker. Throws an warning dialog if row count is over the
    /// large file aize row count. 
    /// </summary>
    /// <param name="auxFileRowSize">Auxilary file row count.  
    /// Size equals timeHorizon * numRealizations, which numRealizations is numBootstraps * numSims</param>
    /// <param name="largeFileRowCount">Default to 1000000 </param>
    /// <returns></returns>
    public bool CheckOutputFileRowSize(int auxFileRowSize, int largeFileRowCount = 1000000)
    {
      if (auxFileRowSize > largeFileRowCount)
      {
        DialogResult outputFileSizePrompt;

        if (MiscOptionsEnableSummaryReport || MiscOptionsEnableAuxStochasticFiles)
        {
          outputFileSizePrompt = MessageBox.Show(
            "The number of realizations times the number of projected years is greater than " +
            largeFileRowCount + ". This will produce large auxiliary output files. " +
            "This will affect the performance of calculation engine." +
            Environment.NewLine + Environment.NewLine + "Do you wish to procced?",
            "AGEPRO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

          if (outputFileSizePrompt == DialogResult.No)
          {
            return false;
          }
        }
      }
      return true;
    }

    /// <summary>
    /// Helper Function to Load The Retro Adjustments Data Grid from AGEPRO Input File
    /// </summary>
    /// <param name="inputFile">AGEPRO Input File Object</param>
    public void LoadRetroAdjustmentsFactorTable(AgeproInputFile inputFile)
    {
      if (MiscOptionsRetroAdjustmentFactorTable != null)
      {
        MiscOptionsRetroAdjustmentFactorTable.Reset();
      }
      MiscOptionsRetroAdjustmentFactorTable = inputFile.RetroAdjustments.RetroAdjust;
    }

    /// <summary>
    /// Creates a fallback Data Table source that the Retro Adjustment Factors Data Grid 
    /// can use.
    /// </summary>
    /// <param name="numAges">Number of age rows. Each row represents an age.</param>
    /// <returns>Returns a single column Data Table populated with 0.</returns>
    public DataTable GetRetroAdjustmentFallbackTable(int numAges)
    {
      //Create a Single Column Table for the data grid view. Each row represents an age.
      DataTable fallbackTable = new DataTable();
      _ = fallbackTable.Columns.Add("factor");
      for (int i = 0; i < numAges; i++)
      {
        _ = fallbackTable.Rows.Add(0);
      }
      return fallbackTable;
    }

    /// <summary>
    /// Use this event handler to load Row Headers if the MiscOptions control wasn't active (another 
    /// AGEPRO parameter control was visible instead) when RetroAdjustmentFactor DataGridView was 
    /// instantiated.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridRetroAdjustment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      //header value is null
      if (e.ColumnIndex == 0)
      {
        SetRetroAdjustmentFactorRowHeaders();
      }
    }


  }
}
