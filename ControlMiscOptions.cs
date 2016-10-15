using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
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
        }

        public bool miscOptionsSummaryReport
        {
            get { return checkBoxSummayReport.Checked; }
            set { checkBoxSummayReport.Checked = value; }
        }
        public bool miscOptionsAuxStochasticFiles
        {
            get { return checkBoxAuxStochasticFiles.Checked; }
            set { checkBoxAuxStochasticFiles.Checked = value; }
        }
        public bool miscOptionsExportR
        {
            get { return checkBoxExportR.Checked; }
            set { checkBoxExportR.Checked = value; }
        }
        public bool miscOptionsPercentileReport
        {
            get { return checkBoxPercentileReport.Checked; }
            set { checkBoxPercentileReport.Checked = value;  }
        }
        public double miscOptionsReportPercentile
        {
            get { return Convert.ToDouble(spinBoxReportPercentile.Value); }
            set { spinBoxReportPercentile.Value = Convert.ToDecimal(value); }
        }
        public bool miscOptionsRefpointsReport
        {
            get { return checkBoxRefpoints.Checked; }
            set { checkBoxRefpoints.Checked = value; }
        }
        public string miscOptionsSpawnBiomass
        {
            get { return textBoxSpawnBiomass.Text; }
            set { textBoxSpawnBiomass.Text = value; }
        }
        public string miscOptionsJan1Biomass
        {
            get { return textBoxJan1Biomass.Text; }
            set { textBoxJan1Biomass.Text = value; }
        }
        public string miscOptionsMeanBiomass
        {
            get { return textBoxMeanBiomass.Text; }
            set { textBoxMeanBiomass.Text = value; }
        }
        public string miscOptionsFishingMortality
        {
            get { return textBoxFishMortality.Text; }
            set { textBoxFishMortality.Text = value; }
        }
        public bool miscOptionsScaleFactors
        {
            get { return checkBoxScaleFactors.Checked; }
            set { checkBoxScaleFactors.Checked = value; }
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
        public string miscoptionsScaleFactorStockNumbers
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
        public bool miscOptionsRetroAdjustmentFactors
        {
            get { return checkBoxRetroAdjustment.Checked; }
            set { checkBoxRetroAdjustment.Checked = value; }
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

        
        private void checkBoxPercentileReport_CheckStateChanged(object sender, EventArgs e)
        {
            bool enabledPercentileReport = this.checkBoxPercentileReport.Checked;
            Console.WriteLine(enabledPercentileReport);
            this.labelReportPercentile.Enabled = enabledPercentileReport;
            this.spinBoxReportPercentile.Enabled = enabledPercentileReport;
        }
        
        private void checkBoxPercentileReport_CheckedChanged(object sender, EventArgs e)
        {
            this.labelReportPercentile.Enabled = this.checkBoxPercentileReport.Checked;
            this.spinBoxReportPercentile.Enabled = this.checkBoxPercentileReport.Checked;
        }

        private void checkBoxRefpoints_CheckedChanged(object sender, EventArgs e)
        {
            this.labelSpawnBiomass.Enabled = this.checkBoxRefpoints.Checked;
            this.textBoxSpawnBiomass.Enabled = this.checkBoxRefpoints.Checked;
            this.labelJan1Biomass.Enabled = this.checkBoxRefpoints.Checked;
            this.textBoxJan1Biomass.Enabled = this.checkBoxRefpoints.Checked;
            this.labelMeanBiomass.Enabled = this.checkBoxRefpoints.Checked;
            this.textBoxMeanBiomass.Enabled = this.checkBoxRefpoints.Checked;
            this.labelFishMortality.Enabled = this.checkBoxRefpoints.Checked;
            this.textBoxFishMortality.Enabled = this.checkBoxRefpoints.Checked;
        }

        private void checkBoxScaleFactors_CheckedChanged(object sender, EventArgs e)
        {
            this.labelScaleFactorBiomass.Enabled = this.checkBoxScaleFactors.Checked;
            this.textBoxScaleFactorBiomass.Enabled = this.checkBoxScaleFactors.Checked;
            this.labelScaleFactorRecruits.Enabled = this.checkBoxScaleFactors.Checked;
            this.textBoxScaleFactorRecruits.Enabled = this.checkBoxScaleFactors.Checked;
            this.labelScaleFactorStockNum.Enabled = this.checkBoxScaleFactors.Checked;
            this.textBoxScaleFactorsStockNum.Enabled = this.checkBoxScaleFactors.Checked;

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
            //this.dataGridRetroAdjustment.Enabled = this.checkBoxRetroAdjustment.Checked;
            
            if (this.checkBoxRetroAdjustment.Checked == false)
            {
                this.dataGridRetroAdjustment.DataSource = null;
            }
            else
            {
                //Create a Single Column Empty Table for the data grid view. Each row represents an age.
                //DataTable retroAdjustmentFallbackTable = new DataTable();
                //retroAdjustmentFallbackTable.Columns.Add("factor", typeof(double));
                //for (int i = 0; i < this.miscOptionsNAges ; i++)
                //{
                //    retroAdjustmentFallbackTable.Rows.Add();
                //}
                //this.dataGridRetroAdjustment.DataSource = retroAdjustmentFallbackTable;
                this.dataGridRetroAdjustment.DataSource = GetRetroAdjustmentFallbackTable(this.miscOptionsNAges);

                SetRetroAdjustmentFactorRowHeaders();
               
            }
        }

        public DataTable GetRetroAdjustmentFallbackTable(int numAges)
        {
            DataTable fallbackTable = new DataTable();
            fallbackTable.Columns.Add("factor", typeof(double));
            for (int i = 0; i < numAges; i++)
            {
                fallbackTable.Rows.Add();
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
