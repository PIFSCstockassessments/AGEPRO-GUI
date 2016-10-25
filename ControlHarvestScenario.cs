using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{
    public partial class ControlHarvestScenario : UserControl
    {
        private DataGridViewComboBoxColumn columnHarvestSpecification;

        public ControlHarvestScenario()
        {
            InitializeComponent();

            columnHarvestSpecification = new DataGridViewComboBoxColumn();
            columnHarvestSpecification.HeaderText = "Harvest Specfication";
            columnHarvestSpecification.Width = 100;

            columnHarvestSpecification.DataSource = HarvestSpecification.GetHarvestSpec();
            columnHarvestSpecification.ValueMember = "Index";
            columnHarvestSpecification.DisplayMember = "HarvestScenario";
            dataGridHarvestScenarioTable.Columns.Add(columnHarvestSpecification);
            dataGridHarvestScenarioTable.RowHeadersWidth = 90;
            

        }

        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioPStar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioRebuilderTarget_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
