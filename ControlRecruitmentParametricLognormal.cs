using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlRecruitmentParametricLognormal : Nmfs.Agepro.Gui.ControlRecruitmentParametricBase
    {
        public ControlRecruitmentParametricLognormal()
        {
            InitializeComponent();
            this.typeOfParmetric = ParametricType.Lognormal;

            this.textBoxMean.Text = "0";
            this.textBoxStdDeviation.Text = "0";
            this.textBoxPhi.Text = "0";
            this.textBoxLastResidual.Text = "0";

            this.textBoxMean.PrevValidValue = this.textBoxMean.Text;
            this.textBoxStdDeviation.PrevValidValue = this.textBoxStdDeviation.Text;
            this.textBoxPhi.PrevValidValue = this.textBoxPhi.Text;
            this.textBoxLastResidual.PrevValidValue = this.textBoxLastResidual.Text;

            //By Default, autocorrected vaules is seen as disabled
            this.labelPhi.Enabled = false;
            this.labelLastResidual.Enabled = false;
            this.textBoxPhi.Enabled = false;
            this.textBoxLastResidual.Enabled = false;
        }

        public override void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            ParametricLognormal currentLognormalRecruit = (ParametricLognormal)currentRecruit;

            DataBindTextBox(this.textBoxMean, currentLognormalRecruit, "mean");
            DataBindTextBox(this.textBoxStdDeviation, currentLognormalRecruit, "stdDev");

            this.textBoxMean.PrevValidValue = currentLognormalRecruit.mean.ToString();
            this.textBoxStdDeviation.PrevValidValue = currentLognormalRecruit.mean.ToString();

            if (currentLognormalRecruit.autocorrelated)
            {
                this.labelPhi.Enabled = true;
                this.labelLastResidual.Enabled = true;
                this.textBoxPhi.Enabled = true;
                this.textBoxLastResidual.Enabled = true;

                DataBindTextBox(this.textBoxPhi, currentLognormalRecruit, "phi");
                DataBindTextBox(this.textBoxLastResidual, currentLognormalRecruit, "lastResidual");
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }

        private void textBoxMean_Validating(object sender, CancelEventArgs e)
        {
            ValidateParamerticParameter(sender as NftTextBox, e);
        }

        private void textBoxStdDeviation_Validating(object sender, CancelEventArgs e)
        {
            ValidateParamerticParameter(sender as NftTextBox, e);
        }

        private void textBoxPhi_Validating(object sender, CancelEventArgs e)
        {
            ValidateParamerticParameter(sender as NftTextBox, e);
        }

        private void textBoxLastResidual_Validating(object sender, CancelEventArgs e)
        {
            ValidateParamerticParameter(sender as NftTextBox, e);
        }
    }
}
