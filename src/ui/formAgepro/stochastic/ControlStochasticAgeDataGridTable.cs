using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlStochasticAgeDataGridTable : UserControl
  {
    public bool MultiFleetTable { get; set; }
    public string[] SeqYears { get; set; }
    public int NumFleets { get; set; }
    public double DefaultCellValue { get; set; }
    public bool ReadInputFileState { get; set; }
    public event EventHandler TimeVaryingCheckedChangedEvent;
    public StochasticAgeFleetDependency FleetDependent { get; set; }

    public ControlStochasticAgeDataGridTable()
    {
      InitializeComponent();
      ReadInputFileState = false;
      DefaultCellValue = 0;
    }
    public string StochasticParamAgeDataGridLabel
    {
      get => labelStochasticAgeTable.Text;
      set => labelStochasticAgeTable.Text = value;
    }
    public bool TimeVarying
    {
      get => checkBoxTimeVarying.Checked;
      set => checkBoxTimeVarying.Checked = value;
    }
    public DataTable StochasticAgeTable
    {
      get => (DataTable)dataGridStochasticAgeTable.DataSource;
      set => dataGridStochasticAgeTable.DataSource = value;
    }
    public DataTable StochasticCV
    {
      get => (DataTable)dataGridCVTable.DataSource;
      set => dataGridCVTable.DataSource = value;
    }
    public bool EnableTimeVaryingCheckBox
    {
      get => checkBoxTimeVarying.Enabled;
      set => checkBoxTimeVarying.Enabled = value;
    }

    /// <summary>
    /// Creates Row Headers for the stochastic parameter's by age DataTable. 
    /// </summary>
    /// <param name="yearArray">String array year sequence from first to last year of projection</param>
    /// <param name="nfleets">Number of Fleets</param>
    private void SetStochasticAgeTableRowHeaders(string[] yearArray, int nfleets)
    {

      if (MultiFleetTable)
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
            stochasticRowHeaders[irowHeader] = TimeVarying ? $"Fleet-{jfleet + 1}-{yearArray[kyear]}" : $"Fleet-{jfleet + 1}";
            irowHeader++;
          }
        }
        int iyear = 0;
        foreach (DataGridViewRow stochasticRow in dataGridStochasticAgeTable.Rows)
        {
          stochasticRow.HeaderCell.Value = stochasticRowHeaders[iyear];
          iyear++;
        }
      }
      else
      {
        if (TimeVarying)
        {
          int iyear = 0;
          foreach (DataGridViewRow stochasticRow in dataGridStochasticAgeTable.Rows)
          {
            stochasticRow.HeaderCell.Value = yearArray[iyear];
            iyear++;
          }
        }
        else
        {
          foreach (DataGridViewRow stochasticRow in dataGridStochasticAgeTable.Rows)
          {
            stochasticRow.HeaderCell.Value = "All Years";
          }
        }

      }
    }

    /// <summary>
    /// Creates row headers for the stochastic parameter's CV DataTable.
    /// </summary>
    private void setCVTableRowHeaders()
    {
      if (MultiFleetTable)
      {
        int ifleet = 1;
        foreach (DataGridViewRow CVTableRow in dataGridCVTable.Rows)
        {
          CVTableRow.HeaderCell.Value = "Fleet-" + ifleet;
          ifleet++;
        }
      }
      else
      {
        if (dataGridCVTable.Rows.Count > 1)
        {
          throw new InvalidAgeproGuiParameterException("Single-Fleet or Fleet-Indpendent CV Table has more than one row.");
        }
        foreach (DataGridViewRow CVTableRow in dataGridCVTable.Rows)
        {
          CVTableRow.HeaderCell.Value = "All Years";
        }

      }

    }

    /// <summary>
    /// When the 'Checked' value of the Time Varying Check Box changes, the program will clear all rows and then
    /// draw the rows of the stochastic age DataTable. The number of rows drawn will be determined on the boolean 
    /// value of the changed "Time Varying" checked state. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxTimeVarying_CheckedChanged(object sender, EventArgs e)
    {

      if (ReadInputFileState != false)
      {
        return;
      }// end if readInputFileState is false

      //Bubble this event for ControlStochasticAgeFromFile to read
      TimeVaryingCheckedChangedEvent?.Invoke(sender, e);

      //TODO: Handle cases where stochasticAgeTable is Null    
      //Clear all rows and draw a new stochasatic data table
      StochasticAgeTable.Clear();
      if (checkBoxTimeVarying.Checked)
      {
        int countFleetYears = FleetDependent == StochasticAgeFleetDependency.dependent ? SeqYears.Count() * NumFleets : SeqYears.Count();
        for (int i = 0; i < countFleetYears; i++)
        {
          _ = StochasticAgeTable.Rows.Add();
        }

      }
      else
      {
        if (FleetDependent == StochasticAgeFleetDependency.dependent)
        {
          for (int i = 0; i < NumFleets; i++)
          {
            _ = StochasticAgeTable.Rows.Add();
            dataGridStochasticAgeTable.Rows[i].HeaderCell.Value = "Fleet-" + (i + 1);
          }

        }
        else
        {
          _ = StochasticAgeTable.Rows.Add();
          dataGridStochasticAgeTable.Rows[0].HeaderCell.Value = "All Years";
        }

      }

      //Fills in blank cells with the defalutCellValue
      string[] rowDefaults =
          Enumerable.Repeat(DefaultCellValue.ToString(), StochasticAgeTable.Columns.Count).ToArray();

      foreach (DataRow dr in StochasticAgeTable.Rows)
      {
        dr.ItemArray = rowDefaults;
      }
    }

    /// <summary>
    /// Stochastic Age Data Grid View Cell Formattin Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridStochasticAgeTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridStochasticAgeTable.Rows[e.RowIndex].HeaderCell;

      if (header.Value != null)
      {
        return;
      }

      if (TimeVarying)
      {
        string[] stochasticAgeTableRowHeaders = SeqYears;
        SetStochasticAgeTableRowHeaders(stochasticAgeTableRowHeaders, NumFleets);
      }
      else
      {

        if (MultiFleetTable)
        {
          //Pass in one empty string since setStochasticAgeTableRowHeaders sets the header string
          string[] stochasticAgeTableRowHeaders = { string.Empty };
          SetStochasticAgeTableRowHeaders(stochasticAgeTableRowHeaders, NumFleets);
        }
        else
        {
          string[] stochasticAgeTableRowHeaders = { "All Years" };
          SetStochasticAgeTableRowHeaders(stochasticAgeTableRowHeaders, 1);
        }

      }


    }

    /// <summary>
    /// Stochastic CV Data Grid View Cell Formatting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridCVTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    public bool StochasticAgeDataGridTableContainMissingData()
    {
      return dataGridStochasticAgeTable.HasBlankOrNullCells();
    }
    /// <summary>
    /// Checks if this Coefficient of Variation Data Grid has Blank or Null Cells
    /// </summary>
    /// <returns></returns>
    public bool StochasticCVDataGridTableContainMissingData()
    {
      return dataGridCVTable.HasBlankOrNullCells();
    }

  }
}
