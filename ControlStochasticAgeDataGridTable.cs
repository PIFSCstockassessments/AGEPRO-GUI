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
                if (multiFleetTable == true)
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
                if (multiFleetTable == true)
                {

                }
                else
                {

                }
            }
            else
            {

                //
                stochasticAgeTable.Clear(); //Clear All Rows
                //dataGridStochasticAgeTable.DataSource = null; //Clear All Rows

                for (int i = 0; i < numFleets; i++)
                {
                    stochasticAgeTable.Rows.Add();
                }
                //dataGridStochasticAgeTable.Rows.Add(numFleets);
                //DataTable fallbackDataTable = new DataTable();

                //Set RowHeaders
                //setStochasticAgeTableRowHeaders(new string[] {"All Years"},this.numFleets);
            }
            //dataGridStochasticAgeTable.Refresh();
        }

        private void dataGridStochasticAgeTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridStochasticAgeTable.Rows[e.RowIndex].HeaderCell;
            
            //TODO: Limit multiple Cell_Formatting event.
            //3-4x Row Headers function is called. Figure out which event triggers cell_formatting
            //1. code 259?? 2. ... 3. changes in CellSytleFormatting

            if (header.Value == null)
            {
                Console.WriteLine("Cell Formatting Event at {0}", e.RowIndex + 1);
                setStochasticAgeTableRowHeaders(seqYears, numFleets);

   
            }
            
            
        }

        private void dataGridCVTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridCVTable.Rows[e.RowIndex].HeaderCell;
            //header value is null
            if (header.Value == null)
            {
                Console.WriteLine("Cell Formatting CV Table at {0}", e.RowIndex);
                setCVTableRowHeaders();
            }
        }


    }
}
