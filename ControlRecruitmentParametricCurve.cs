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
            this.textBoxAlpha.DataBindings.Add("Text", currentParametricCurveRecruit, "alpha", false,
                DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxBeta.DataBindings.Add("Text", currentParametricCurveRecruit, "beta", false,
                DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxVariance.DataBindings.Add("Text", currentParametricCurveRecruit, "variance", false,
                DataSourceUpdateMode.OnPropertyChanged);

            if(currentParametricCurveRecruit.isShepherdCurve)
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

                Binding b =  new Binding("Text", currentParametricCurveRecruit, "phi", true);
                b.Format -= new ConvertEventHandler(textBoxBindingNullable_Format);
                b.Parse -= new ConvertEventHandler(textBoxBindingNullable_Parse);
                b.Format += new ConvertEventHandler(textBoxBindingNullable_Format);
                b.Parse += new ConvertEventHandler(textBoxBindingNullable_Parse);
                this.textBoxPhi.DataBindings.Add(b);
                //this.textBoxPhi.DataBindings.Add("Text", currentParametricCurveRecruit, "phi", true, 
                //    DataSourceUpdateMode.OnValidation, string.Empty);
                this.textBoxLastResidual.DataBindings.Add("Text", currentParametricCurveRecruit, "lastResidual", true,
                    DataSourceUpdateMode.OnValidation, string.Empty);
            }

            base.SetParametricRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        }

        
        /// <summary>
        /// How the nullable data object gets formatted to the control is bounded to.  Object to control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBoxBindingNullable_Format(object sender, ConvertEventArgs e)
        {
            Binding b = sender as Binding;
            if (b != null)
            {
                TextBox ctlTxt = (b.Control as TextBox);
                if (ctlTxt != null)
                {
                    if (e.Value == null)
                    {
                        e.Value = ctlTxt.Text;
                    }
                    
                }
            }
        }

        /// <summary>
        /// How the control's formatted nullable value is stored to that object its bounded to. Control to Object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBoxBindingNullable_Parse(object sender, ConvertEventArgs e)
        {
            Binding b = sender as Binding;
            if (b != null)
            {
                TextBox ctlTxt = b.Control as TextBox;
                if (ctlTxt != null)
                {
                    double val;
                    if (Double.TryParse(e.Value.ToString(), out val))
                    {
                        if (string.IsNullOrWhiteSpace(ctlTxt.Text))
                        {
                            ctlTxt.Undo();
                        }
                        else
                        {
                            e.Value = new double?(val);
                        }            
                    }
                    else
                    {
                        ctlTxt.Undo();
                    }
                }
            }
        }

    }
}
