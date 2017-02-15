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
    public partial class ControlRecruitmentParametricCurve : Nmfs.Agepro.Gui.ControlRecruitmentParametricBase
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
            DataBindTextBox(this.textBoxAlpha, currentParametricCurveRecruit, "alpha");
            DataBindTextBox(this.textBoxBeta, currentParametricCurveRecruit, "beta");
            DataBindTextBox(this.textBoxVariance, currentParametricCurveRecruit, "variance");

            if(currentParametricCurveRecruit.GetType() == typeof(ParametricShepherdCurve))
            {
                this.labelKparm.Visible = true;
                this.textBoxKParm.Visible = true;
                DataBindTextBox(this.textBoxKParm, currentParametricCurveRecruit, "kParm");
            }
            
            if (currentParametricCurveRecruit.autocorrelated)
            {
                this.labelPhi.Enabled = true;
                this.labelLastResidual.Enabled = true;
                this.textBoxPhi.Enabled = true;
                this.textBoxLastResidual.Enabled = true;

                DataBindTextBox(this.textBoxPhi, currentParametricCurveRecruit, "phi");
                DataBindTextBox(this.textBoxLastResidual, currentParametricCurveRecruit, "lastResidual");
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }


    }
}
