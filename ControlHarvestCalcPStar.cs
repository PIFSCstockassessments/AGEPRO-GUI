using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
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
        
        public void SetHarvestCalcPStarControls(Nmfs.Agepro.CoreLib.PStarCalculation pstar, Panel panelHarvestCalcParam) 
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

        /// <summary>
        /// Resizes the PStar Levels Data Grid View Table when the spinBoxNumPStarLevels value has been
        /// changed by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spinBoxNumPStarLevels_ValueChanged(object sender, EventArgs e)
        {
            if (setControlValues == false)
            {
                NumericUpDown newPStarLevel = sender as NumericUpDown;
                ControlRecruitment.ResizeDataGridTable(
                    (DataTable)this.dataGridPStarLevelValues.DataSource, 1, Convert.ToInt32(newPStarLevel.Value));

                //Rename Columns
                for (int colNum=0; colNum < this.dataGridPStarLevelValues.Columns.Count ; colNum++)
                {
                    this.dataGridPStarLevelValues.Columns[colNum].HeaderText = "Level " + (colNum + 1);

                    //Set blank cells to 0
                    if(string.IsNullOrEmpty(this.dataGridPStarLevelValues.Rows[0].Cells[colNum].Value.ToString()))
                    {
                        this.dataGridPStarLevelValues.Rows[0].Cells[colNum].Value = 0;
                    }
                }
            }
        }//end spinBoxNumPStarLevels_ValueChanged

    }
}
