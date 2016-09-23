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
            
            this.alpha = 0;
            this.beta = 0;
            this.kParm = 0;
            this.variance = 0;
            this.phi = 0;
            this.lastResidual = 0;

            //By default, K-Parm is invisible
            this.labelKparm.Visible = false;
            this.textBoxKParm.Visible = false;

            //By Default, autocorrected vaules is seen as disabled
            this.labelPhi.Enabled = false;
            this.labelLastResidual.Enabled = false;
            this.textBoxPhi.Enabled = false;
            this.textBoxLastResidual.Enabled = false;
        }

        public double alpha 
        {
            get { return Convert.ToDouble(textBoxAlpha.Text); }
            set { textBoxAlpha.Text = value.ToString(); }
        }
        public double beta
        {
            get { return Convert.ToDouble(textBoxBeta.Text); }
            set { textBoxBeta.Text = value.ToString(); }
        }
        public double kParm
        {
            get { return Convert.ToDouble(textBoxKParm.Text); }
            set { textBoxKParm.Text = value.ToString(); }
        }
        public double variance
        {
            get { return Convert.ToDouble(textBoxVariance.Text); }
            set { textBoxVariance.Text = value.ToString(); }
        }
        public double phi
        {
            get { return Convert.ToDouble(textBoxPhi.Text); }
            set { textBoxPhi.Text = value.ToString(); }
        }
        public double lastResidual
        {
            get { return Convert.ToDouble(textBoxLastResidual.Text); }
            set { textBoxLastResidual.Text = value.ToString(); }
        }

        public override void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            ParametricCurve currentParametricCurveRecruit = (ParametricCurve)currentRecruit;
            this.alpha = currentParametricCurveRecruit.alpha;
            this.beta = currentParametricCurveRecruit.beta;
            if(currentParametricCurveRecruit.IsThisAShepherdCurve())
            {
                this.kParm = currentParametricCurveRecruit.kParm.Value;
                this.labelKparm.Visible = true;
                this.textBoxKParm.Visible = true;
            }

            if (currentParametricCurveRecruit.autocorrelated)
            {
                this.labelPhi.Enabled = true;
                this.labelLastResidual.Enabled = true;
                this.textBoxPhi.Enabled = true;
                this.textBoxLastResidual.Enabled = true;

                this.phi = currentParametricCurveRecruit.phi.Value;
                this.lastResidual = currentParametricCurveRecruit.lastResidual.Value;
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }
    }
}
