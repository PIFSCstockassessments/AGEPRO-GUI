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
    public partial class ControlRecruitmentFixed : UserControl
    {
        public List<RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }
        public int collectionSelectedIndex { get; set; }
        public string[] seqYears { get; set; }

        public ControlRecruitmentFixed()
        {
            InitializeComponent();
        }

        public DataTable fixedRecruitTable
        {
            get { return (DataTable)dataGridFixedRecruitment.DataSource; }
            set { dataGridFixedRecruitment.DataSource = value; }
        }

        public void SetFixedRecruitmentControls(EmpiricalRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            //create empty obsTable if null
            if (!(currentRecruit.obsTable != null))
            {
                if (!(seqYears != null))
                {
                    currentRecruit.obsTable = currentRecruit.SetNewObsTable(0);
                }
                else
                {
                    currentRecruit.obsTable = currentRecruit.SetNewObsTable(seqYears.Count());
                }
            }

            this.fixedRecruitTable = currentRecruit.obsTable;
            
            panelRecruitModelParameter.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelRecruitModelParameter.Controls.Add(this);

        }

        private void dataGridFixedRecruitment_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridFixedRecruitment.Rows[e.RowIndex].HeaderCell;

            if (!(header.Value != null))
            {
                for (int i = 0; i < seqYears.Count(); i++)
                {
                    dataGridFixedRecruitment.Rows[i].HeaderCell.Value = seqYears[i];
                }
            }

        }
    }
}
