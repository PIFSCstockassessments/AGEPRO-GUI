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
    public partial class ControlMiscOptions : UserControl
    {
        public ControlMiscOptions()
        {
            InitializeComponent();
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
            this.dataGridRetroAdjustment.Enabled = this.checkBoxRetroAdjustment.Checked;
            //TODO: Implement a visual disable style on dataGridView  

        }


    }
}
