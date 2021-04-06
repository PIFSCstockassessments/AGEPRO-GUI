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
    public partial class ControlRecruitmentMarkovMatrix : UserControl
    {

        public List<RecruitmentModelProperty> collectionAgeproRecruitModels { get; set; }
        public int collectionSelectedIndex { get; set; }

        public ControlRecruitmentMarkovMatrix()
        {
            InitializeComponent();
        }
        public DataTable recruitLevelTable
        {
            get { return (DataTable)dataGridRecruitTable.DataSource; }
            set { dataGridRecruitTable.DataSource = value; }
        }
        public DataTable SSBLevelTable
        {
            get { return (DataTable)dataGridSSBTable.DataSource; }
            set { dataGridSSBTable.DataSource = value; }
        }
        public DataTable probabilityTable
        {
            get { return (DataTable)dataGridProbabilityTable.DataSource; }
            set { dataGridProbabilityTable.DataSource = value; }
        }
        protected override void OnLoad(EventArgs e)
        {
            dataGridSSBTable.Columns[0].Width = 120;
            base.OnLoad(e);
        }

        public void SetRecruitmentControls(MarkovMatrixRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            //defaults
            int defaultRecruitLvl = 1;
            int defaultSSBLvl = 1;

            //Assign Recruit/SSB levels to Default if they are (less than or) equal to zero
            if (currentRecruit.numRecruitLevels <= 0)
            {
                currentRecruit.numRecruitLevels = defaultRecruitLvl;
            }
            if (currentRecruit.numSSBLevels <= 0)
            {
                currentRecruit.numSSBLevels = defaultSSBLvl;
            }

            if (!(currentRecruit.markovRecruitment != null))
            {
                currentRecruit.markovRecruitment = new DataSet("markovRecruitmentTables");

                DataTable markovRecruit = currentRecruit.NewRecruitLevelTable(defaultRecruitLvl);
                DataTable markovSSBLevel = currentRecruit.NewSSBLevelTable(defaultSSBLvl);
                DataTable markovProbability = currentRecruit.NewProbabilityTable(defaultSSBLvl, defaultRecruitLvl);
                
                currentRecruit.markovRecruitment.Tables.Add(markovRecruit);
                currentRecruit.markovRecruitment.Tables.Add(markovSSBLevel);
                currentRecruit.markovRecruitment.Tables.Add(markovProbability);
            }
            else
            {
                
                //Create Data Table if null
                if (!(currentRecruit.markovRecruitment.Tables["Recruitment"] != null))
                {
                    currentRecruit.markovRecruitment.Tables.Add(
                        currentRecruit.NewRecruitLevelTable(currentRecruit.numRecruitLevels));
                }

                if (!(currentRecruit.markovRecruitment.Tables["SSB"] != null))
                {
                    currentRecruit.markovRecruitment.Tables.Add(currentRecruit.NewSSBLevelTable(currentRecruit.numSSBLevels));
                }

                if (!(currentRecruit.markovRecruitment.Tables["Probability"] != null))
                {
                    currentRecruit.markovRecruitment.Tables.Add(
                        currentRecruit.NewProbabilityTable(currentRecruit.numSSBLevels, currentRecruit.numRecruitLevels));
                }
            }
            //Set data bindings
            this.spinBoxNumRecruitLevels.DataBindings.Add("Value", currentRecruit, "numRecruitLevels", 
                true, DataSourceUpdateMode.OnPropertyChanged);
            this.spinBoxNumSSBLevels.DataBindings.Add("Value", currentRecruit, "numSSBlevels", true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.recruitLevelTable = currentRecruit.markovRecruitment.Tables["Recruitment"];
            this.SSBLevelTable = currentRecruit.markovRecruitment.Tables["SSB"];
            this.probabilityTable = currentRecruit.markovRecruitment.Tables["Probability"];

            panelRecruitModelParameter.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelRecruitModelParameter.Controls.Add(this);
        }

        private void buttonSetParameters_Click(object sender, EventArgs e)
        {
            try
            {
                int newNumRecruitLevelsValue = Convert.ToInt32(spinBoxNumRecruitLevels.Value);
                int newNumSSBLevelsValue = Convert.ToInt32(spinBoxNumSSBLevels.Value);
                bool renameProbTableCols = newNumRecruitLevelsValue > probabilityTable.Columns.Count;

                recruitLevelTable = ControlRecruitment.ResizeDataGridTable(recruitLevelTable, newNumRecruitLevelsValue);
                SSBLevelTable = ControlRecruitment.ResizeDataGridTable(SSBLevelTable, newNumSSBLevelsValue);

                probabilityTable = ControlRecruitment.ResizeDataGridTable(probabilityTable, newNumSSBLevelsValue, 
                    newNumRecruitLevelsValue);
                
                if (renameProbTableCols)
                {
                    int ncol = 1;
                    foreach (DataColumn dcol in probabilityTable.Columns)
                    {
                        dcol.ColumnName = "PR(" + ncol + ")";
                        ncol++;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not readjust markov matrix level(s)." + Environment.NewLine + ex.Message,
                   "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridProbabilityTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridProbabilityTable.Rows[e.RowIndex].HeaderCell;

            if (!(header.Value != null))
            {
                for (int i = 0; i < dataGridProbabilityTable.Rows.Count; i++)
                {
                    dataGridProbabilityTable.Rows[i].HeaderCell.Value = "SSB Level-" + (i + 1);
                }
            }
        }

        private void dataGridRecruitTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridRecruitTable.Rows[e.RowIndex].HeaderCell;

            if (!(header.Value != null))
            {
                for (int i = 0; i < dataGridRecruitTable.Rows.Count; i++)
                {
                    dataGridRecruitTable.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
        }

        private void dataGridSSBTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridSSBTable.Rows[e.RowIndex].HeaderCell;

            if (!(header.Value != null))
            {
                for (int i = 0; i < dataGridSSBTable.Rows.Count; i++)
                {
                    dataGridSSBTable.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
        }
    }
}