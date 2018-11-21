using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            comboBoxOutputViewerProgram.SelectedIndex = 0;

            //Set Bounds defaults
            miscOptionsBoundsMaxWeight = "10.0";
            miscOptionsBoundsNaturalMortality = "1.0";
        }

        public bool miscOptionsEnableSummaryReport
        {
            get { return checkBoxEnableSummaryReport.Checked; }
            set { checkBoxEnableSummaryReport.Checked = value; }
        }
        public bool miscOptionsEnableAuxStochasticFiles
        {
            get { return checkBoxEnableAuxStochasticFiles.Checked; }
            set { checkBoxEnableAuxStochasticFiles.Checked = value; }
        }
        public bool miscOptionsEnableExportR
        {
            get { return checkBoxEnableExportR.Checked; }
            set { checkBoxEnableExportR.Checked = value; }
        }
        public bool miscOptionsEnablePercentileReport
        {
            get { return checkBoxEnablePercentileReport.Checked; }
            set { checkBoxEnablePercentileReport.Checked = value;  }
        }
        public double miscOptionsReportPercentile
        {
            get { return Convert.ToDouble(spinBoxReportPercentile.Value); }
            set { spinBoxReportPercentile.Value = Convert.ToDecimal(value); }
        }
        public bool miscOptionsEnableRefpointsReport
        {
            get { return checkBoxEnableRefpoints.Checked; }
            set { checkBoxEnableRefpoints.Checked = value; }
        }
        public string miscOptionsRefSpawnBiomass
        {
            get { return textBoxRefSpawnBiomass.Text; }
            set { textBoxRefSpawnBiomass.Text = value; }
        }
        public string miscOptionsRefJan1Biomass
        {
            get { return textBoxRefJan1Biomass.Text; }
            set { textBoxRefJan1Biomass.Text = value; }
        }
        public string miscOptionsRefMeanBiomass
        {
            get { return textBoxRefMeanBiomass.Text; }
            set { textBoxRefMeanBiomass.Text = value; }
        }
        public string miscOptionsRefFishingMortality
        {
            get { return textBoxRefFishMortality.Text; }
            set { textBoxRefFishMortality.Text = value; }
        }
        public bool miscOptionsEnableScaleFactors
        {
            get { return checkBoxEnableScaleFactors.Checked; }
            set { checkBoxEnableScaleFactors.Checked = value; }
        }
        public string miscOptionsScaleFactorBiomass
        {
            get { return textBoxScaleFactorBiomass.Text; }
            set { textBoxScaleFactorBiomass.Text = value; }
        }
        public string miscOptionsScaleFactorRecruits
        {
            get { return textBoxScaleFactorRecruits.Text; }
            set { textBoxScaleFactorRecruits.Text = value; }
        }
        public string miscOptionsScaleFactorStockNumbers
        {
            get { return textBoxScaleFactorsStockNum.Text; }
            set { textBoxScaleFactorsStockNum.Text = value; }
        }
        public bool miscOptionsBounds
        {
            get { return checkBoxBounds.Checked; }
            set { checkBoxBounds.Checked = value; }
        }
        public string miscOptionsBoundsMaxWeight
        {
            get { return textBoxBoundsMaxWeight.Text; }
            set { textBoxBoundsMaxWeight.Text = value; }
        }
        public string miscOptionsBoundsNaturalMortality
        {
            get { return textBoxBoundsNatMortality.Text; }
            set { textBoxBoundsNatMortality.Text = value; }
        }
        public bool miscOptionsEnableRetroAdjustmentFactors
        {
            get { return checkBoxEnableRetroAdjustment.Checked; }
            set { checkBoxEnableRetroAdjustment.Checked = value; }
        }
        public DataTable miscOptionsRetroAdjustmentFactorTable
        {
            get { return (DataTable)dataGridRetroAdjustment.DataSource; }
            set { dataGridRetroAdjustment.DataSource = value; }
        }
        public string ageproOutputViewer
        {
            get { return comboBoxOutputViewerProgram.SelectedItem.ToString(); }
        }

        public void SetRetroAdjustmentFactorRowHeaders()
        {
            this.dataGridRetroAdjustment.RowHeadersVisible = true;
            for (int iage = 0; iage < this.miscOptionsNAges; iage++)
            {
                //Accomidate 0-based or 1-based First Age Models
                int iageForHeader = iage + this.miscOptionsFirstAge;
                this.dataGridRetroAdjustment.Rows[iage].HeaderCell.Value = ("Age " + iageForHeader);
            }
        }
        
        /// <summary>
        /// Data Binding setup for Reference Point Options Controls
        /// </summary>
        /// <param name="miscOpt">AGEPRO CoreLib Misc Options Object</param>
        public void SetupRefpointDataBindings(Nmfs.Agepro.CoreLib.MiscOptionsParameter miscOpt)
        {
            SetControlDataBindings(this.textBoxRefSpawnBiomass, miscOpt, "refSpawnBio");
            SetControlDataBindings(this.textBoxRefJan1Biomass, miscOpt, "refJan1Bio");
            SetControlDataBindings(this.textBoxRefMeanBiomass, miscOpt, "refMeanBio");
            SetControlDataBindings(this.textBoxRefFishMortality, miscOpt, "refFMort");
        }

        /// <summary>
        /// Data Binding setup for Scale Factor Controls
        /// </summary>
        /// <param name="miscOpt">AGEPRO CoreLib Misc Options Object</param>
        public void SetupScaleFactorsDataBindings(Nmfs.Agepro.CoreLib.ScaleFactors miscOpt)
        {
            SetControlDataBindings(this.textBoxScaleFactorBiomass, miscOpt, "scaleBio");
            SetControlDataBindings(this.textBoxScaleFactorRecruits, miscOpt, "scaleRec");
            SetControlDataBindings(this.textBoxScaleFactorsStockNum, miscOpt, "scaleStockNum");
        }

        /// <summary>
        /// Data Binding setup for Bounds Controls
        /// </summary>
        /// <param name="miscOpt">AGEPRO CoreLib Misc Options Object</param>
        public void SetupBoundsDataBindings(Nmfs.Agepro.CoreLib.Bounds miscOpt)
        {
            SetControlDataBindings(this.textBoxBoundsMaxWeight, miscOpt, "maxWeight", true);
            SetControlDataBindings(this.textBoxBoundsNatMortality, miscOpt, "maxNatMort", true);
        }

        private void SetControlDataBindings(NftTextBox ctl, 
            Nmfs.Agepro.CoreLib.MiscOptionsParameter miscOptSrc, string miscOptField,
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


        private void DoubleToString(object sender, ConvertEventArgs sevent)
        {
            // The method converts only to string type. Test this using the DesiredType.
            if (sevent.DesiredType != typeof(string)) return;

            // Use the ToString method to format the value.
            sevent.Value = ((double)sevent.Value).ToString("#.0");
        }

        private void StringToDouble(object sender, ConvertEventArgs sevent)
        {
            // ' The method converts only to decimal type. 
            if (sevent.DesiredType != typeof(double)) return;

            // Converts the string back to decimal using the static ToDouble method.
            sevent.Value = Convert.ToDouble(sevent.Value.ToString());
        }

        
        private void checkBoxPercentileReport_CheckStateChanged(object sender, EventArgs e)
        {
            bool enabledPercentileReport = this.checkBoxEnablePercentileReport.Checked;
            Console.WriteLine(enabledPercentileReport);
            this.labelReportPercentile.Enabled = enabledPercentileReport;
            this.spinBoxReportPercentile.Enabled = enabledPercentileReport;
        }
        
        private void checkBoxPercentileReport_CheckedChanged(object sender, EventArgs e)
        {
            this.labelReportPercentile.Enabled = this.checkBoxEnablePercentileReport.Checked;
            this.spinBoxReportPercentile.Enabled = this.checkBoxEnablePercentileReport.Checked;
        }

        private void checkBoxRefpoints_CheckedChanged(object sender, EventArgs e)
        {
            this.labelSpawnBiomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.textBoxRefSpawnBiomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.labelJan1Biomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.textBoxRefJan1Biomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.labelMeanBiomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.textBoxRefMeanBiomass.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.labelFishMortality.Enabled = this.checkBoxEnableRefpoints.Checked;
            this.textBoxRefFishMortality.Enabled = this.checkBoxEnableRefpoints.Checked;
        }

        private void checkBoxScaleFactors_CheckedChanged(object sender, EventArgs e)
        {
            this.labelScaleFactorBiomass.Enabled = this.checkBoxEnableScaleFactors.Checked;
            this.textBoxScaleFactorBiomass.Enabled = this.checkBoxEnableScaleFactors.Checked;
            this.labelScaleFactorRecruits.Enabled = this.checkBoxEnableScaleFactors.Checked;
            this.textBoxScaleFactorRecruits.Enabled = this.checkBoxEnableScaleFactors.Checked;
            this.labelScaleFactorStockNum.Enabled = this.checkBoxEnableScaleFactors.Checked;
            this.textBoxScaleFactorsStockNum.Enabled = this.checkBoxEnableScaleFactors.Checked;

        }

        private void checkBoxBounds_CheckedChanged(object sender, EventArgs e)
        {
            this.labelBoundsMaxWeight.Enabled = this.checkBoxBounds.Checked;
            this.textBoxBoundsMaxWeight.Enabled = this.checkBoxBounds.Checked;
            this.labelBoundsNatMortality.Enabled = this.checkBoxBounds.Checked;
            this.textBoxBoundsNatMortality.Enabled = this.checkBoxBounds.Checked;
        }

        private void checkBoxRetroAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            //this.dataGridRetroAdjustment.Enabled = this.checkBoxEnableRetroAdjustment.Checked;
            
            if (this.checkBoxEnableRetroAdjustment.Checked == false)
            {
                this.dataGridRetroAdjustment.DataSource = null;
            }
            else
            {
                this.dataGridRetroAdjustment.DataSource = GetRetroAdjustmentFallbackTable(this.miscOptionsNAges);

                SetRetroAdjustmentFactorRowHeaders();
               
            }
        }

        public bool ValidateMiscOptions()
        {
            List<string> errorMsgList = new List<string>();
            //Reference Points
            if (this.miscOptionsEnableRefpointsReport)
            {
                if (string.IsNullOrWhiteSpace(this.miscOptionsRefJan1Biomass))
                {
                    this.miscOptionsRefJan1Biomass = "0.0";
                }
                if (string.IsNullOrWhiteSpace(this.miscOptionsRefMeanBiomass))
                {
                    this.miscOptionsRefMeanBiomass = "0.0";
                }
                if (string.IsNullOrWhiteSpace(this.miscOptionsRefSpawnBiomass))
                {
                    this.miscOptionsRefSpawnBiomass = "0.0";
                }
                if (string.IsNullOrWhiteSpace(this.miscOptionsRefFishingMortality))
                {
                    this.miscOptionsRefFishingMortality = "0.0";
                }
            }
            //Retrospective Adjustment Factors
            if (this.dataGridRetroAdjustment.HasBlankOrNullCells())
            {
                errorMsgList.Add("Retro Adjustment Factors data grid has missing data.");
            }

            //Report Percentile
            if (this.miscOptionsEnablePercentileReport)
            {
                //todo: spinbox text issue
                if (string.IsNullOrWhiteSpace(this.miscOptionsReportPercentile.ToString()))
                {
                    errorMsgList.Add("Missing Report Percentile");
                }

                if (this.miscOptionsReportPercentile < 0.0 || this.miscOptionsReportPercentile > 100)
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
        /// 
        /// </summary>
        /// <param name="auxFileRowSize"></param>
        /// <param name="largeFileRowCount">Defaul to 1000000 </param>
        /// <returns></returns>
        public bool CheckOutputFileRowSize(int auxFileRowSize, int largeFileRowCount = 1000000)
        {
            if (auxFileRowSize > largeFileRowCount)
            {
                DialogResult outputFileSizePrompt;

                if (this.miscOptionsEnableSummaryReport || this.miscOptionsEnableAuxStochasticFiles)
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
        /// Creates a fallback Data Table source that the Retro Adjustment Factors Data Grid 
        /// can use.
        /// </summary>
        /// <param name="numAges">Number of age rows. Each row represents an age.</param>
        /// <returns>Returns a single column Data Table populated with 0.</returns>
        public DataTable GetRetroAdjustmentFallbackTable(int numAges)
        {
            //Create a Single Column Table for the data grid view. Each row represents an age.
            DataTable fallbackTable = new DataTable();
            fallbackTable.Columns.Add("factor");
            for (int i = 0; i < numAges; i++)
            {
                fallbackTable.Rows.Add(0);
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
        private void dataGridRetroAdjustment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //header value is null
            if(e.ColumnIndex == 0)
            {  
                SetRetroAdjustmentFactorRowHeaders();
            }
        }


    }
}
