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
        private ControlHarvestCalcRebuilder controlHarvestRebuilder;
        public string[] seqYears { get; set; }
        public AGEPRO.CoreLib.RebuilderTargetCalculation Rebuilder { get; set; }
        public AGEPRO.CoreLib.PStarCalculation PStar { get; set; }
        
        public ControlHarvestScenario()
        {
            InitializeComponent();
            controlHarvestRebuilder = new ControlHarvestCalcRebuilder();
           
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
            panelAltCalcParameters.Controls.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioPStar_CheckedChanged(object sender, EventArgs e)
        {
            panelAltCalcParameters.Controls.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioRebuilderTarget_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    if (!(Rebuilder != null))
                    {
                        Rebuilder = new RebuilderTargetCalculation();
                        Rebuilder.targetYear = 0;
                        Rebuilder.targetValue = 0;
                        Rebuilder.targetType = 0;
                        Rebuilder.targetPercent = 0;
                    }
                    else
                    {
                        controlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, this.panelAltCalcParameters);
                    }
                    
                }
            }
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

        
        
        
        public void SetHarvestCalcuationParameter(AGEPRO.CoreLib.AgeproInputFile inpFile)
        {
            AGEPRO.CoreLib.HarvestScenarioAnalysis calcType = inpFile.harvestScenario.analysisType;


            //SetHarvestCalculationRadioButtonOption
            if (calcType == HarvestScenarioAnalysis.HarvestScenario)
            {
                radioNone.Checked = true;
            }
            else if (calcType == HarvestScenarioAnalysis.PStar)
            {
                radioPStar.Checked = true;
            }
            else if (calcType == HarvestScenarioAnalysis.Rebuilder)
            {
                radioRebuilderTarget.Checked = true;
                controlHarvestRebuilder.SetHarvestCalcRebuilderControls(inpFile.rebuild, this.panelAltCalcParameters);
            }

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
