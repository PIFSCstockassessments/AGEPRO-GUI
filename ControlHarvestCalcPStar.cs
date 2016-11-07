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

            //Set up new Data Bindings 

            panelHarvestCalcParam.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelHarvestCalcParam.Controls.Add(this);
 
        }
    }
}
