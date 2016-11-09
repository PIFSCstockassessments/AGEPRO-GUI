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
    public partial class ControlHarvestCalcPStar : UserControl
    {
        private bool setControlValues;
        public ControlHarvestCalcPStar()
        {
            InitializeComponent();
            setControlValues = false;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Ensure setControlValues bool flag to false after controls is setup.
            setControlValues = false; 
        }
        
        public void SetHarvestCalcPStarControls(AGEPRO.CoreLib.PStarCalculation pstar, Panel panelHarvestCalcParam) 
        {
            setControlValues = true;
            //Clear any previous Data Bindings
            this.spinBoxNumPStarLevels.DataBindings.Clear();
            this.textBoxOverfishingF.DataBindings.Clear();
            this.textBoxPStarTargetYear.DataBindings.Clear();
            this.dataGridPStarLevelValues.DataBindings.Clear();
            //Set up new Data Bindings
            this.spinBoxNumPStarLevels.DataBindings.Add("value", pstar, "pStarLevels");
            this.textBoxOverfishingF.DataBindings.Add("text", pstar, "pStarF");
            this.textBoxPStarTargetYear.DataBindings.Add("text", pstar, "targetYear");
            this.dataGridPStarLevelValues.DataBindings.Add("dataSource", pstar, "pStarTable");

            panelHarvestCalcParam.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelHarvestCalcParam.Controls.Add(this);
            
            //If the PStar controls did not load for the first time, do not set setControlsValues to false.
            //Otherwise, allow it. 
            if (this.Created)
            {
                setControlValues = false;
            }
        }

        private void spinBoxNumPStarLevels_ValueChanged(object sender, EventArgs e)
        {
            if (setControlValues == false)
            {
                Console.WriteLine("Debug");
            }
        }
    }
}
