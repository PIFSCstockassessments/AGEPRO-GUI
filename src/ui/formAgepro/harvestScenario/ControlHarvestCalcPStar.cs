using System;
using System.Data;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlHarvestCalcPStar : UserControl
  {
    private bool setControlValues;
    public DataTable PstarLevelsTable { get; set; }

    public ControlHarvestCalcPStar()
    {
      InitializeComponent();
      setControlValues = false;
    }

    public int PstarLevels
    {
      get => decimal.ToInt32(spinBoxNumPStarLevels.Value);
      set => spinBoxNumPStarLevels.Value = value;
    }
    public string TargetYear
    {
      get => textBoxPStarTargetYear.Text;
      set => textBoxPStarTargetYear.Text = value;
    }
    public string OverfishingF
    {
      get => textBoxOverfishingF.Text;
      set => textBoxOverfishingF.Text = value;
    }


    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      //Ensure setControlValues bool flag to false after controls is setup.
      setControlValues = false;
    }

    public void SetHarvestCalcPStarControls(CoreLib.PStarCalculation pstar, Panel panelHarvestCalcParam)
    {
      setControlValues = true;

      //Clear any previous Data Bindings
      spinBoxNumPStarLevels.DataBindings.Clear();
      textBoxOverfishingF.DataBindings.Clear();
      textBoxPStarTargetYear.DataBindings.Clear();
      dataGridPStarLevelValues.DataBindings.Clear();
      //Set up new Data Bindings
      _ = spinBoxNumPStarLevels.DataBindings.Add("value", pstar, "pStarLevels", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxOverfishingF.DataBindings.Add("text", pstar, "pStarF", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxPStarTargetYear.DataBindings.Add("text", pstar, "targetYear", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = dataGridPStarLevelValues.DataBindings.Add("dataSource", pstar, "pStarTable", true, DataSourceUpdateMode.OnPropertyChanged);

      panelHarvestCalcParam.Controls.Clear();
      Dock = DockStyle.Fill;
      panelHarvestCalcParam.Controls.Add(this);

      //If the PStar controls did not load for the first time, do not set setControlsValues to false.
      //Otherwise, allow it. 
      if (Created)
      {
        setControlValues = false;
      }
    }

    /// <summary>
    /// Resizes the PStar Levels Data Grid View Table when the spinBoxNumPStarLevels value has been
    /// changed by the user.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void spinBoxNumPStarLevels_ValueChanged(object sender, EventArgs e)
    {
      if (setControlValues == false)
      {
        NumericUpDown newPStarLevel = sender as NumericUpDown;
        ControlRecruitment.ResizeDataGridTable(
            (DataTable)dataGridPStarLevelValues.DataSource, 1, Convert.ToInt32(newPStarLevel.Value));

        //Rename Columns
        for (int colNum = 0; colNum < dataGridPStarLevelValues.Columns.Count; colNum++)
        {
          dataGridPStarLevelValues.Columns[colNum].HeaderText = "Level " + (colNum + 1);

          //Set blank cells to 0
          if (string.IsNullOrEmpty(dataGridPStarLevelValues.Rows[0].Cells[colNum].Value.ToString()))
          {
            dataGridPStarLevelValues.Rows[0].Cells[colNum].Value = 0;
          }
        }
      }
    }//end spinBoxNumPStarLevels_ValueChanged

  }
}
