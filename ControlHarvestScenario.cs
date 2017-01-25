using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlHarvestScenario : UserControl
    {
        private DataGridViewComboBoxColumn columnHarvestSpecification; 
        private ControlHarvestCalcRebuilder controlHarvestRebuilder;
        private ControlHarvestCalcPStar controlHarvestPStar;
        public string[] seqYears { get; set; }
        public Nmfs.Agepro.CoreLib.RebuilderTargetCalculation Rebuilder { get; set; }
        public Nmfs.Agepro.CoreLib.PStarCalculation PStar { get; set; }

        public ControlHarvestScenario()
        {
            InitializeComponent();
            controlHarvestRebuilder = new ControlHarvestCalcRebuilder();
            controlHarvestPStar = new ControlHarvestCalcPStar();

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
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    if (!(PStar != null))
                    {
                        PStar = new PStarCalculation();
                        PStar.pStarLevels = 1;
                        PStar.pStarF = 0;
                        PStar.targetYear = 0;
                        PStar.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
                        //Create PStar Table
                        PStar.pStarTable = PStar.CreateNewPStarTable();
                        PStar.pStarTable.Rows.Add();
                        Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(PStar.pStarTable);
                    }
                    controlHarvestPStar.SetHarvestCalcPStarControls(this.PStar, this.panelAltCalcParameters);
                }
            }
            
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
                    //If Rebuilder has no data, create an empty/default set. 
                    //Otherwise load stored 'Rebuilder' class data to GUI.
                    if (!(Rebuilder != null))
                    {
                        Rebuilder = new RebuilderTargetCalculation();
                        Rebuilder.targetYear = 0;
                        Rebuilder.targetValue = 0;
                        Rebuilder.targetType = 0;
                        Rebuilder.targetPercent = 0;
                        Rebuilder.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
                    }
                    controlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, this.panelAltCalcParameters);
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

        /// <summary>
        /// Sets up the Harvest Scenario Data Grid View Table, including the Harvest Specification combo box
        /// column.
        /// </summary>
        /// <param name="inpFileTable">Harvest Scenario Data Table Source</param>
        public void SetHarvestScenarioInputDataTable(DataTable inpFileTable)
        {
            if (this.HarvestScenarioTable != null)
            {
                this.HarvestScenarioTable.Reset();
            }
            SetHarvestSpecificationColumn();
            
            this.HarvestScenarioTable = inpFileTable;
            
        }

        
        
        /// <summary>
        /// Sets Harvest Calculation option from when setting user specifed General Options or loading a 
        /// existing AGEPRO input file. 
        /// </summary>
        /// <param name="inputData"></param>
        public void SetHarvestCalcuationOptionFromInput(Nmfs.Agepro.CoreLib.AgeproInputFile inpData)
        {
            Nmfs.Agepro.CoreLib.HarvestScenarioAnalysis calcType = inpData.harvestScenario.analysisType;

            //Clean out any previous instances of pstar and/or rebuilder. 
            if (this.PStar != null)
            {
                PStar = null;
            }
            if (this.Rebuilder != null)
            {
                Rebuilder = null; 
            }

            //SetHarvestCalculationRadioButtonOption
            if (calcType == HarvestScenarioAnalysis.HarvestScenario)
            {
                radioNone.Checked = true;
            }
            else if (calcType == HarvestScenarioAnalysis.PStar)
            {
                this.PStar = inpData.pstar;
                radioPStar.Checked = true;
                this.PStar.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
                controlHarvestPStar.SetHarvestCalcPStarControls(this.PStar, this.panelAltCalcParameters);
            }
            else if (calcType == HarvestScenarioAnalysis.Rebuilder)
            {
                this.Rebuilder = inpData.rebuild;
                radioRebuilderTarget.Checked = true;
                this.Rebuilder.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
                controlHarvestRebuilder.SetHarvestCalcRebuilderControls(this.Rebuilder, this.panelAltCalcParameters);
            }
        }

        public bool ValidateHarvestScenario()
        {
            if (this.dataGridHarvestScenarioTable.HasBlankOrNullCells())
            {
                MessageBox.Show("Harvest Scenario Data Table has blank or missing values.", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.radioRebuilderTarget.Checked == true)
            {
                ValidationResult rebuilderCheck = this.Rebuilder.ValidationCheck();
                if (rebuilderCheck.isValid == false)
                {
                    MessageBox.Show("Invalid Rebuilder target parameters: " + Environment.NewLine + 
                        rebuilderCheck.message, "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Check Harvest Scenario Table


            }
            else if (this.radioPStar.Checked == true)
            {
                ValidationResult pstarCheck = this.PStar.ValidationCheck();
                if (pstarCheck.isValid == false)
                {
                    MessageBox.Show("Ivalid P-Star parameters: " + Environment.NewLine + pstarCheck.message,
                        "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                //Check the HarvestScenario Table
            }
            

            return true;
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
