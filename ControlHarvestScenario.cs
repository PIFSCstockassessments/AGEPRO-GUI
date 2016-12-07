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
        private ControlHarvestCalcPStar controlHarvestPStar;
        public string[] seqYears { get; set; }
        public AGEPRO.CoreLib.RebuilderTargetCalculation Rebuilder { get; set; }
        public AGEPRO.CoreLib.PStarCalculation PStar { get; set; }

        //Constructing Context Menu fo DataGridView
        private ContextMenuStrip strip;
        private ToolStripMenuItem menuCut = new ToolStripMenuItem();
        private ToolStripMenuItem menuCopy = new ToolStripMenuItem();
        private ToolStripMenuItem menuPaste = new ToolStripMenuItem();

        public ControlHarvestScenario()
        {
            InitializeComponent();
            controlHarvestRebuilder = new ControlHarvestCalcRebuilder();
            controlHarvestPStar = new ControlHarvestCalcPStar();

            menuCopy.Click -= new EventHandler(menuCopy_Click);
            menuPaste.Click -= new EventHandler(menuPaste_Click);
            menuCopy.Click += new EventHandler(menuCopy_Click);
            menuPaste.Click += new EventHandler(menuPaste_Click);
        }


        void menuPaste_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void menuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridHarvestScenarioTable.GetClipboardContent());
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
                        //Create PStar Table
                        PStar.pStarTable = PStar.CreateNewPStarTable();
                        PStar.pStarTable.Rows.Add();
                        AGEPRO.CoreLib.Extensions.FillDBNullCellsWithZero(PStar.pStarTable);
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
        public void SetHarvestCalcuationOptionFromInput(AGEPRO.CoreLib.AgeproInputFile inpData)
        {
            AGEPRO.CoreLib.HarvestScenarioAnalysis calcType = inpData.harvestScenario.analysisType;

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
                controlHarvestPStar.SetHarvestCalcPStarControls(this.PStar, this.panelAltCalcParameters);
            }
            else if (calcType == HarvestScenarioAnalysis.Rebuilder)
            {
                this.Rebuilder = inpData.rebuild;
                radioRebuilderTarget.Checked = true;
                controlHarvestRebuilder.SetHarvestCalcRebuilderControls(this.Rebuilder, this.panelAltCalcParameters);
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

        private void dataGridHarvestScenarioTable_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

            if (strip == null)
            {
                strip = new ContextMenuStrip();
                menuCut.Text = "Cut";
                menuCopy.Text = "Copy";
                menuPaste.Text = "Paste";
                strip.Items.Add(menuCut);
                strip.Items.Add(menuCopy);
                strip.Items.Add(new ToolStripSeparator());
                strip.Items.Add(menuPaste);
            }
            e.ContextMenuStrip = strip;

        }


    }
}
