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

            //By Default, autocorrected vaules is seen as disabled
            this.labelPhi.Enabled = false;
            this.labelLastResidual.Enabled = false;
            this.textBoxPhi.Enabled = false;
            this.textBoxLastResidual.Enabled = false;
        }

        public override void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            ParametricLognormal currentLognormalRecruit = (ParametricLognormal)currentRecruit;

            this.textBoxMean.DataBindings.Add("Text", currentLognormalRecruit, "mean");
            this.textBoxStdDeviation.DataBindings.Add("Text", currentLognormalRecruit, "stdDev");

            if (currentLognormalRecruit.autocorrelated)
            {
                this.labelPhi.Enabled = true;
                this.labelLastResidual.Enabled = true;
                this.textBoxPhi.Enabled = true;
                this.textBoxLastResidual.Enabled = true;

                this.textBoxPhi.DataBindings.Add("Text", currentLognormalRecruit, "phi", true, DataSourceUpdateMode.OnPropertyChanged);
                this.textBoxLastResidual.DataBindings.Add("Text", currentLognormalRecruit, "lastResidual", true,
                    DataSourceUpdateMode.OnPropertyChanged);
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }
    }
}
