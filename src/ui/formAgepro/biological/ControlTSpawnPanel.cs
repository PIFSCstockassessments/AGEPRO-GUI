using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlTSpawnPanel : UserControl
  {

    
    public string[] SeqYears { get; set; }
    public bool TimeVarying { get; set; }
    public double DefaultCellValue { get; set; }

    public ControlTSpawnPanel()
    {
      InitializeComponent();
      CreateTSpawnColumns();
    }


    public DataTable TSpawnTable
    {
      get => (DataTable)dataGridTSpawn.DataSource;
      set => dataGridTSpawn.DataSource = value;
    }
    public bool TSpawnTableTimeVarying
    {
      get => checkBoxTSpawnTimeVarying.Checked;
      set => checkBoxTSpawnTimeVarying.Checked = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bioTSpawn"></param>
    /// <param name="seqYrs"></param>
    public void LoadTSpawnTableData(AgeproBioTSpawn bioTSpawn, string[] seqYrs)
    {
      if (bioTSpawn is null)
      {
        throw new ArgumentNullException(nameof(bioTSpawn));
      }
      SeqYears = seqYrs ?? throw new ArgumentNullException(nameof(seqYrs));
      TSpawnTable = bioTSpawn.TSpawn;
      TSpawnTableTimeVarying = bioTSpawn.TimeVarying;
    }


    //BindTSpawnData
    public void BindTSpawnData(AgeproBioTSpawn inp)
    {
      if (inp is null)
      {
        throw new ArgumentNullException(nameof(inp));
      }

      inp.TimeVarying = TimeVarying;
      inp.TSpawn = TSpawnTable;

    }
    //Use CoreLib CreateTSpawnFallbackTable

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridTSpawn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridTSpawn.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        dataGridTSpawn.Rows[0].HeaderCell.Value = "Fraction F Prior to Spawn";
        dataGridTSpawn.Rows[1].HeaderCell.Value = "Fraction M Prior to Spawn";
      }
    }


    /// <summary>
    /// Creates Columns for TSpawn (Fraction Mortality) Data Grid
    /// </summary>
    public void CreateTSpawnColumns()
    {
      if(SeqYears == null)
      {
        SeqYears = new string[] { "1" };
      }

      if (TSpawnTable != null)
      {
        TSpawnTable.Columns.Clear(); //Clear all Columns
      }
      else
      {
        //If null, instantiate a empty Data Table /w two Rows
        TSpawnTable = new DataTable();
        _ = TSpawnTable.Rows.Add();
        _ = TSpawnTable.Rows.Add();
      }

      if (checkBoxTSpawnTimeVarying.Checked)
      {
        //Time Varying Fraction Mortality Data Table share the same time horizion as the
        //Maturity Data Table (since it is coming from the General Options parameters)
        for (int iyear = 0; iyear < SeqYears.Count(); iyear++)
        {
          string colNameYear = SeqYears[iyear];
          _ = TSpawnTable.Columns.Add(colNameYear);
          foreach (DataRow irow in TSpawnTable.Rows)
          {
            irow[colNameYear] = DefaultCellValue;
          }
        }

        TSpawnTableTimeVarying = true;
      }
      else
      {
        string colNameYear = "All Years";
        _ = TSpawnTable.Columns.Add(colNameYear);

        foreach (DataRow irow in TSpawnTable.Rows)
        {
          irow["All Years"] = DefaultCellValue;
        }

        TSpawnTableTimeVarying = false;
      }
    }


    /// <summary>
    /// Checks is the Fraction Mortality Data Grid has any blank or null cells. 
    /// </summary>
    /// <returns></returns>
    public bool ValidateTSpawnDataGrid()
    {
      if (dataGridTSpawn.HasBlankOrNullCells())
      {
        _ = MessageBox.Show("Data Fraction Mortality Prior to Spawning Data Table has blank or missing values.",
            "AGEPRO Biological", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    /// <summary>
    /// Event that calls CreateTSpawnColumns whenever the Time Varying check 
    /// box gets checked or unchecked. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CheckBoxTSpawnTimeVarying_CheckedChanged(object sender, EventArgs e)
    {      

      CreateTSpawnColumns();
    }

  }
}
