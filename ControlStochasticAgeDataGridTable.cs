using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlStochasticAgeDataGridTable : UserControl
    {
        public bool multiFleetTable { get; set; }
        public string[] seqYears { get; set; }
        public int numFleets { get; set; }
        public double defaultCellValue { get; set; }
        public bool readInputFileState { get; set; }
        public event EventHandler timeVaryingCheckedChangedEvent;

        public ControlStochasticAgeDataGridTable()
        {
            InitializeComponent();
            readInputFileState = false;
            defaultCellValue = 0;
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
        public bool enableTimeVaryingCheckBox
        {
            get { return checkBoxTimeVarying.Enabled; }
            set { checkBoxTimeVarying.Enabled = value; }
        }
        
        /// <summary>
        /// Creates Row Headers for the stochastic parameter's by age DataTable. 
        /// </summary>
        /// <param name="yearArray">String array year sequence from first to last year of projection</param>
        /// <param name="nfleets">Number of Fleets</param>
        private void setStochasticAgeTableRowHeaders(string[] yearArray, int nfleets)
        {
            
            if (multiFleetTable == true)
            {
                int countFleetYears = yearArray.Count() * nfleets;
                if (countFleetYears != dataGridStochasticAgeTable.RowCount)
                {
                    throw new InvalidOperationException("Amount of Fleet-Years does not equal to Data Table rows");
                }

                string[] stochasticRowHeaders = new string[countFleetYears];
                int irowHeader = 0;
                for (int jfleet = 0; jfleet < nfleets; jfleet++)
                {
                    for (int kyear = 0; kyear < yearArray.Count(); kyear++)
                    {
                        if (timeVarying)
                        {
                            stochasticRowHeaders[irowHeader] = "Fleet-" + (jfleet + 1) + "-" + yearArray[kyear];
                        }
                        else
                        {
                            stochasticRowHeaders[irowHeader] = "Fleet-" + (jfleet + 1);
                        }
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

        /// <summary>
        /// Creates row headers for the stochastic parameter's CV DataTable.
        /// </summary>
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

        /// <summary>
        /// When the 'Checked' value of the Time Varying Check Box changes, the program will clear all rows and then
        /// draw the rows of the stochastic age DataTable. The number of rows drawn will be determined on the boolean 
        /// value of the changed "Time Varying" checked state. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxTimeVarying_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.readInputFileState == false)
            {
                //Bubble this event for ControlStochasticAgeFromFile to read
                if (this.timeVaryingCheckedChangedEvent != null)
                {
                    this.timeVaryingCheckedChangedEvent(sender, e);
                }

                //TODO: Handle cases where stochasticAgeTable is Null    
                stochasticAgeTable.Clear(); //Clear All Rows
                if (checkBoxTimeVarying.Checked)
                {
                    int countFleetYears = seqYears.Count() * this.numFleets;
                    for (int i = 0; i < countFleetYears; i++)
                    {
                        stochasticAgeTable.Rows.Add();
                    }

                }
                else
                {   
                    for (int i = 0; i < numFleets; i++)
                    {
                        stochasticAgeTable.Rows.Add();
                        
                        if (multiFleetTable)
                        {
                            dataGridStochasticAgeTable.Rows[i].HeaderCell.Value = "Fleet-" + (i + 1);
                        }
                        else
                        {
                            dataGridStochasticAgeTable.Rows[i].HeaderCell.Value = "All Years";
                        }
                    }
                }

                //Fills in blank cells with the defalutCellValue
                var rowDefaults = 
                    Enumerable.Repeat(defaultCellValue.ToString(), this.stochasticAgeTable.Columns.Count).ToArray();
                foreach (DataRow dr in this.stochasticAgeTable.Rows)
                {
                    dr.ItemArray = rowDefaults;
                }        

            }// end if readInputFileState is false
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridStochasticAgeTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridStochasticAgeTable.Rows[e.RowIndex].HeaderCell;
            
            if (header.Value == null)
            {
                if(timeVarying == true)
                {
                    string[] stochasticAgeTableRowHeaders = this.seqYears;
                    setStochasticAgeTableRowHeaders(stochasticAgeTableRowHeaders, numFleets);
                }
                else
                {
                    string[] stochasticAgeTableRowHeaders = new string[numFleets];
                    if (multiFleetTable == true)
                    {
                        for (int ifleet = 0; ifleet < numFleets; ifleet++)
                        {
                            stochasticAgeTableRowHeaders[ifleet] = "Fleet-" + (ifleet+1);
                        }
                    }
                    else
                    {
                        stochasticAgeTableRowHeaders[0] = "All Years";
                    }
                    setStochasticAgeTableRowHeaders(stochasticAgeTableRowHeaders, numFleets);
                }
                
            }
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridCVTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridCVTable.Rows[e.RowIndex].HeaderCell;
            //header value is null
            if (header.Value == null)
            {
                setCVTableRowHeaders();
            }
        }

        /// <summary>
        /// Checks if this Stochastic Age Data Grid has Blank or Null Cells 
        /// </summary>
        /// <returns></returns>
        public bool ValidateStochasticAgeDataGridTable()
        {
            return this.dataGridStochasticAgeTable.HasBlankOrNullCells();
        }
        /// <summary>
        /// Checks if this Coefficient of Variation Data Grid has Blank or Null Cells
        /// </summary>
        /// <returns></returns>
        public bool ValidateStochasticCVDataGridTable()
        {
            return this.dataGridCVTable.HasBlankOrNullCells();
        }


    }
}
