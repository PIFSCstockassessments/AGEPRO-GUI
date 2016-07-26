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
    public partial class ControlStochasticAgeDataGridTable : UserControl
    {
        public bool multiFleetTable { get; set; }
        public string[] seqYears { get; set; }
        public int numFleets { get; set; }

        public ControlStochasticAgeDataGridTable()
        {
            InitializeComponent();

            
        }
        public string stochasticParamAgeDataGridLabel
        {
            get { return labelStochasticAgeTable.Text; }
            set { labelStochasticAgeTable.Text = value; }
        }
        public bool timeVarying
        {
            get { return checkBoxTimeVarying.Checked; }
            set { checkBoxTimeVarying.Checked = value; }
        }
        public DataTable stochasticAgeTable
        {
            get { return (DataTable)dataGridStochasticAgeTable.DataSource; }
            set { dataGridStochasticAgeTable.DataSource = value;  }
        }
        public DataTable stochasticCV
        {
            get { return (DataTable)dataGridCVTable.DataSource; }
            set { dataGridCVTable.DataSource = value; }
        }

        private void setStochasticAgeTableRowHeaders(string[] yearArray, int nfleets)
        {
            
            int countFleetYears = yearArray.Count() * nfleets;
            if (countFleetYears != dataGridStochasticAgeTable.RowCount)
            {
                throw new InvalidOperationException("Amount of Fleet-Years does not equal to Data Table rows");
            }
            
            if (multiFleetTable == true)
            {
                string[] stochasticRowHeaders = new string[countFleetYears];
                int irowHeader = 0;
                for (int jfleet = 0; jfleet < nfleets; jfleet++)
                {
                    for (int kyear = 0; kyear < yearArray.Count(); kyear++)
                    {
                        stochasticRowHeaders[irowHeader] = "Fleet-" + (jfleet + 1) + "-" + yearArray[kyear];
                        irowHeader = irowHeader + 1;
                    }
                }
                int iyear = 0;
                foreach (DataGridViewRow stochasticRow in dataGridStochasticAgeTable.Rows)
                {
                    stochasticRow.HeaderCell.Value = stochasticRowHeaders[iyear];
                    iyear = iyear + 1;
                }              
            }
            else
            {
                int iyear = 0;
                foreach (DataGridViewRow stochasticRow in dataGridStochasticAgeTable.Rows)
                {
                    stochasticRow.HeaderCell.Value = yearArray[iyear];
                    iyear = iyear + 1;
                }
            }
        }

        private void setCVTableRowHeaders()
        {

            int ifleet = 1;
            foreach (DataGridViewRow CVTableRow in dataGridCVTable.Rows)
            {
                if (multiFleetTable)
                {
                    CVTableRow.HeaderCell.Value = "Fleet-" + ifleet;
                }
                else
                {
                    CVTableRow.HeaderCell.Value = "All Years";
                }
                ifleet = ifleet + 1;
            }
      
            
        }


        private void checkBoxTimeVarying_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeVarying.Checked)
            {
                
            }
        }

        private void dataGridStochasticAgeTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //header value is null
            if (e.ColumnIndex == 0)
            {
                setStochasticAgeTableRowHeaders(seqYears,numFleets);
            }
        }

        private void dataGridCVTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //header value is null
            if (e.ColumnIndex == 0)
            {
                setCVTableRowHeaders();
            }
        }   
    }
}
