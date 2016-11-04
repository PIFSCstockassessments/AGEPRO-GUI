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
        public string[] seqYears { get; set; }

        public ControlHarvestScenario()
        {
            InitializeComponent();
            
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

        public void SetHarvestSpecificationColumn()
        {

            columnHarvestSpecification = new DataGridViewComboBoxColumn();
            columnHarvestSpecification.HeaderText = "Harvest Specfication";
            //'DataPropertyName' references harvest spec column in input data's Harvest Scenario DataTable 
            columnHarvestSpecification.DataPropertyName = "Harvest Spec";
            columnHarvestSpecification.Width = 100;
            //Get Data Source from List<HarvestSpecification> Class
            columnHarvestSpecification.DataSource = HarvestSpecification.GetHarvestSpec();
            //Do not need 'ValueMember', because 'DataPropertyNameInstead' is referenced 
            columnHarvestSpecification.DisplayMember = "HarvestScenario";
            dataGridHarvestScenarioTable.Columns.Add(columnHarvestSpecification);
            dataGridHarvestScenarioTable.RowHeadersWidth = 70;
            

        }

        public void SetHarvestScenarioInputDataTable(DataTable inpFileTable)
        {
            if (this.HarvestScenarioTable != null)
            {
                this.HarvestScenarioTable.Reset();
            }
            SetHarvestSpecificationColumn();
            
            this.HarvestScenarioTable = inpFileTable;
            
        } 

        private void dataGridHarvestScenarioTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridHarvestScenarioTable.Rows[e.RowIndex].HeaderCell;
            
            if (!(header.Value != null))
            {
                //set HarvestScenarioTable RowHeaders
                int iyear = 0;
                foreach (DataGridViewRow yearRow in dataGridHarvestScenarioTable.Rows)
                {
                    yearRow.HeaderCell.Value = seqYears[iyear];
                    iyear++;
                }

            }
        }
    }
}
