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
            //'DataPropertyName' references harvest spec column in input data's Harvest Scenario DataTable 
            columnHarvestSpecification.DataPropertyName = "Harvest Spec";
            columnHarvestSpecification.Width = 100;

            columnHarvestSpecification.DataSource = HarvestSpecification.GetHarvestSpec();
            //Do not need 'ValueMember', because 'DataPropertyNameInstead' is referenced 
            columnHarvestSpecification.DisplayMember = "HarvestScenario";
            dataGridHarvestScenarioTable.Columns.Add(columnHarvestSpecification);
            dataGridHarvestScenarioTable.RowHeadersWidth = 90;
            

        }

        public DataTable HarvestScenarioTable
        {
            get { return (DataTable)dataGridHarvestScenarioTable.DataSource; }
            set { dataGridHarvestScenarioTable.DataSource = value; }
        }

        /// <summary>
        /// Action that When the 'None' radio buttion is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioPStar_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioRebuilderTarget_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
