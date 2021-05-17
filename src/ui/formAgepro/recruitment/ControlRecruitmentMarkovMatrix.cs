using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentMarkovMatrix : UserControl
  {

    public List<RecruitmentModelProperty> CollectionAgeproRecruitModels { get; set; }
    public int CollectionSelectedIndex { get; set; }

    public ControlRecruitmentMarkovMatrix()
    {
      InitializeComponent();
    }
    public DataTable RecruitLevelTable
    {
      get { return (DataTable)dataGridRecruitTable.DataSource; }
      set { dataGridRecruitTable.DataSource = value; }
    }
    public DataTable SSBLevelTable
    {
      get { return (DataTable)dataGridSSBTable.DataSource; }
      set { dataGridSSBTable.DataSource = value; }
    }
    public DataTable ProbabilityTable
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
      if (currentRecruit.NumRecruitLevels <= 0)
      {
        currentRecruit.NumRecruitLevels = defaultRecruitLvl;
      }
      if (currentRecruit.NumSSBLevels <= 0)
      {
        currentRecruit.NumSSBLevels = defaultSSBLvl;
      }

      if (currentRecruit.MarkovRecruitment == null)
      {
        currentRecruit.MarkovRecruitment = new DataSet("markovRecruitmentTables");

        DataTable markovRecruit = currentRecruit.NewRecruitLevelTable(defaultRecruitLvl);
        DataTable markovSSBLevel = currentRecruit.NewSSBLevelTable(defaultSSBLvl);
        DataTable markovProbability = currentRecruit.NewProbabilityTable(defaultSSBLvl, defaultRecruitLvl);

        currentRecruit.MarkovRecruitment.Tables.Add(markovRecruit);
        currentRecruit.MarkovRecruitment.Tables.Add(markovSSBLevel);
        currentRecruit.MarkovRecruitment.Tables.Add(markovProbability);
      }
      else
      {

        //Create Data Table if null
        if (currentRecruit.MarkovRecruitment.Tables["Recruitment"] == null)
        {
          currentRecruit.MarkovRecruitment.Tables.Add(
              currentRecruit.NewRecruitLevelTable(currentRecruit.NumRecruitLevels));
        }

        if (currentRecruit.MarkovRecruitment.Tables["SSB"] == null)
        {
          currentRecruit.MarkovRecruitment.Tables.Add(currentRecruit.NewSSBLevelTable(currentRecruit.NumSSBLevels));
        }

        if (currentRecruit.MarkovRecruitment.Tables["Probability"] == null)
        {
          currentRecruit.MarkovRecruitment.Tables.Add(
              currentRecruit.NewProbabilityTable(currentRecruit.NumSSBLevels, currentRecruit.NumRecruitLevels));
        }
      }
      //Set data bindings
      _ = spinBoxNumRecruitLevels.DataBindings.Add("Value", currentRecruit, "numRecruitLevels",
          true, DataSourceUpdateMode.OnPropertyChanged);
      _ = spinBoxNumSSBLevels.DataBindings.Add("Value", currentRecruit, "numSSBlevels", true,
          DataSourceUpdateMode.OnPropertyChanged);

      RecruitLevelTable = currentRecruit.MarkovRecruitment.Tables["Recruitment"];
      SSBLevelTable = currentRecruit.MarkovRecruitment.Tables["SSB"];
      ProbabilityTable = currentRecruit.MarkovRecruitment.Tables["Probability"];

      panelRecruitModelParameter.Controls.Clear();
      Dock = DockStyle.Fill;
      panelRecruitModelParameter.Controls.Add(this);
    }

    private void ButtonSetParameters_Click(object sender, EventArgs e)
    {
      try
      {
        int newNumRecruitLevelsValue = Convert.ToInt32(spinBoxNumRecruitLevels.Value);
        int newNumSSBLevelsValue = Convert.ToInt32(spinBoxNumSSBLevels.Value);
        bool renameProbTableCols = newNumRecruitLevelsValue > ProbabilityTable.Columns.Count;

        RecruitLevelTable = ControlRecruitment.ResizeDataGridTable(RecruitLevelTable, newNumRecruitLevelsValue);
        SSBLevelTable = ControlRecruitment.ResizeDataGridTable(SSBLevelTable, newNumSSBLevelsValue);

        ProbabilityTable = ControlRecruitment.ResizeDataGridTable(ProbabilityTable, newNumSSBLevelsValue,
            newNumRecruitLevelsValue);

        if (renameProbTableCols)
        {
          int ncol = 1;
          foreach (DataColumn dcol in ProbabilityTable.Columns)
          {
            dcol.ColumnName = "PR(" + ncol + ")";
            ncol++;
          }
        }

      }
      catch (Exception ex)
      {
        _ = MessageBox.Show("Can not readjust markov matrix level(s)." + Environment.NewLine + ex.Message,
           "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void DataGridProbabilityTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridProbabilityTable.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        for (int i = 0; i < dataGridProbabilityTable.Rows.Count; i++)
        {
          dataGridProbabilityTable.Rows[i].HeaderCell.Value = "SSB Level-" + (i + 1);
        }
      }
    }

    private void DataGridRecruitTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridRecruitTable.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        for (int i = 0; i < dataGridRecruitTable.Rows.Count; i++)
        {
          dataGridRecruitTable.Rows[i].HeaderCell.Value = (i + 1).ToString();
        }
      }
    }

    private void DataGridSSBTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridSSBTable.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        for (int i = 0; i < dataGridSSBTable.Rows.Count; i++)
        {
          dataGridSSBTable.Rows[i].HeaderCell.Value = (i + 1).ToString();
        }
      }
    }
  }
}