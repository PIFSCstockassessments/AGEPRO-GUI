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
        public ControlHarvestCalcPStar()
        {
            InitializeComponent();
        }


        public void SetHarvestCalcPStarControls(AGEPRO.CoreLib.PStarCalculation pstar, Panel panelHarvestCalcParam) 
        {

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
 
        }
    }
}
