using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitmentParametricCurve : AGEPRO.GUI.ControlRecruitmentParametricBase
    {
        public ControlRecruitmentParametricCurve()
        {
            InitializeComponent();
            this.typeOfParmetric = ParametricType.Curve;
            
            this.textBoxAlpha.Text = "0";
            this.textBoxBeta.Text = "0";
            this.textBoxKParm.Text = "0";
            this.textBoxVariance.Text = "0";
            this.textBoxPhi.Text = "0";
            this.textBoxLastResidual.Text = "0";

            //By default, K-Parm is invisible
            this.labelKparm.Visible = false;
            this.textBoxKParm.Visible = false;

            //By Default, autocorrected vaules is seen as disabled
            this.labelPhi.Enabled = false;
            this.labelLastResidual.Enabled = false;
            this.textBoxPhi.Enabled = false;
            this.textBoxLastResidual.Enabled = false;
        }

        public override void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            ParametricCurve currentParametricCurveRecruit = (ParametricCurve)currentRecruit;
            this.textBoxAlpha.DataBindings.Add("Text", currentParametricCurveRecruit, "alpha");
            this.textBoxBeta.DataBindings.Add("Text", currentParametricCurveRecruit, "beta");
            this.textBoxVariance.DataBindings.Add("Text", currentParametricCurveRecruit, "variance");

            if(currentParametricCurveRecruit.IsThisAShepherdCurve())
            {
                this.labelKparm.Visible = true;
                this.textBoxKParm.Visible = true;
                this.textBoxKParm.DataBindings.Add("Text", currentParametricCurveRecruit, "kParm", true,
                    DataSourceUpdateMode.OnPropertyChanged);
            }

            if (currentParametricCurveRecruit.autocorrelated)
            {
                this.labelPhi.Enabled = true;
                this.labelLastResidual.Enabled = true;
                this.textBoxPhi.Enabled = true;
                this.textBoxLastResidual.Enabled = true;

                this.textBoxPhi.DataBindings.Add("Text", currentParametricCurveRecruit, "phi", true, 
                    DataSourceUpdateMode.OnPropertyChanged);
                this.textBoxLastResidual.DataBindings.Add("Text", currentParametricCurveRecruit, "lastResidual", true,
                    DataSourceUpdateMode.OnPropertyChanged);
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }
    }
}
