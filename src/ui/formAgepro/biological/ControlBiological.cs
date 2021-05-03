using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlBiological : UserControl
  {
    public bool readFractionMortalityState;
    public ControlStochasticAge maturityAge;

    public double DefaultCellValue { get; set; }
    public ControlBiological()
    {
      InitializeComponent();

      maturityAge = new ControlStochasticAge
      {
        StochasticParameterLabel = "Maturity",
        IsMultiFleet = false,
        Dock = DockStyle.Fill
      };

      tabMaturity.Controls.Add(maturityAge);
      DefaultCellValue = 0;


    }
    public DataTable FractionMortality
    {
      get => (DataTable)dataGridFractionMortality.DataSource;
      set => dataGridFractionMortality.DataSource = value;
    }
    public bool FractionMortalityTimeVarying
    {
      get => checkBoxFractionMortalityTimeVarying.Checked;
      set => checkBoxFractionMortalityTimeVarying.Checked = value;
    }

    private void DataGridFractionMortality_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridFractionMortality.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        dataGridFractionMortality.Rows[0].HeaderCell.Value = "Fraction F Prior to Spawn";
        dataGridFractionMortality.Rows[1].HeaderCell.Value = "Fraction M Prior to Spawn";
      }
    }

    /// <summary>
    /// Creates Columns for the Fraction Mortality Data Grid
    /// </summary>
    public void CreateFractionMortalityColumns()
    {

      if (FractionMortality != null)
      {
        FractionMortality.Columns.Clear(); //Clear all Columns
      }
      else
      {
        //If null, instantiate a empty Data Table /w two Rows
        FractionMortality = new DataTable();
        _ = FractionMortality.Rows.Add();
        _ = FractionMortality.Rows.Add();
      }

      if (checkBoxFractionMortalityTimeVarying.Checked)
      {
        //Time Varying Fraction Mortality Data Table share the same time horizion as the
        //Maturity Data Table (since it is coming from the General Options parameters)
        for (int iyear = 0; iyear < maturityAge.SeqYears.Count(); iyear++)
        {
          string colNameYear = maturityAge.SeqYears[iyear];
          _ = FractionMortality.Columns.Add(colNameYear);
          foreach (DataRow irow in FractionMortality.Rows)
          {
            irow[colNameYear] = DefaultCellValue;
          }
        }

      }
      else
      {
        string colNameYear = "All Years";
        _ = FractionMortality.Columns.Add(colNameYear);

        foreach (DataRow irow in FractionMortality.Rows)
        {
          irow["All Years"] = DefaultCellValue;
        }
      }
    }

    /// <summary>
    /// Checks is the Fraction Mortality Data Grid has any blank or null cells. 
    /// </summary>
    /// <returns></returns>
    public bool ValidateFractionMortalityDataGrid()
    {
      if (dataGridFractionMortality.HasBlankOrNullCells())
      {
        _ = MessageBox.Show("Data Fraction Mortality Prior to Spawning Table has blank or missing values.",
            "AGEPRO Biological", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }


    /// <summary>
    /// Event that calls CreateFractionMortalityColumns whenever the Time Varying check 
    /// box gets checked or unchecked. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkBoxFractionMortalityTimeVarying_CheckedChanged(object sender, EventArgs e)
    {
      if (readFractionMortalityState == false)
      {
        CreateFractionMortalityColumns();
      }
    }

  }
}
