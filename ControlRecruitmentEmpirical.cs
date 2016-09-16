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
    public partial class ControlRecruitmentEmpirical : UserControl
    {
        public int maxNumObservations { get; set; }

        public ControlRecruitmentEmpirical()
        {
            InitializeComponent();
        }

        public int numObservations
        {
            get { return Convert.ToInt32(spinBoxNumObservations.Value); }
            set { spinBoxNumObservations.Value = value; }
        }
        public DataTable observationTable
        {
            get { return (DataTable)dataGridRecruitTable.DataSource; }
            set { dataGridRecruitTable.DataSource = value; }
        }

        private void buttonSetParameters_Click(object sender, EventArgs e)
        {
            
            this.dataGridRecruitTable.RowCount = this.numObservations;
        }


    }
}
