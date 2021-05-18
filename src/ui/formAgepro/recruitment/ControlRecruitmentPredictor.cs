using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentPredictor : UserControl
  {
    public List<RecruitmentModelProperty> CollectionAgeproRecruitmentModels { get; set; }
    public int CollectionSelectedIndex { get; set; }
    public string[] SeqYears { get; set; }

    private int MaxRecruitPredictors { get; set; }

    public int NumRecruitPredictors
    {
      get => Convert.ToInt32(spinBoxNumRecruitPredictors.Value);
      set => spinBoxNumRecruitPredictors.Value = value;
    }
    public double Variance
    {
      get => Convert.ToDouble(textBoxVariance.Text);
      set => textBoxVariance.Text = value.ToString();
    }
    public double Intercept
    {
      get => Convert.ToDouble(textBoxIntercept.Text);
      set => textBoxIntercept.Text = value.ToString();
    }
    public DataTable CoefficientTable
    {
      get => (DataTable)dataGridCoefficients.DataSource;
      set => dataGridCoefficients.DataSource = value;
    }
    public DataTable ObservationTable
    {
      get => (DataTable)dataGridObservations.DataSource;
      set => dataGridObservations.DataSource = value;
    }

    public ControlRecruitmentPredictor()
    {
      InitializeComponent();
      MaxRecruitPredictors = 5;
      spinBoxNumRecruitPredictors.Maximum = MaxRecruitPredictors;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSetParameters_Click(object sender, EventArgs e)
    {
      int newNumPredictors = Convert.ToInt32(spinBoxNumRecruitPredictors.Value);
      CoefficientTable = ResizePredictorDataGridTables(CoefficientTable, newNumPredictors);
      ObservationTable = ResizePredictorDataGridTables(ObservationTable, newNumPredictors);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predictorDataTable"></param>
    /// <param name="numPredictors"></param>
    /// <returns></returns>
    private DataTable ResizePredictorDataGridTables(DataTable predictorDataTable, int numPredictors)
    {
      //Catch if the number of Predictors exceed limit (in case control couldn't prevent it)
      if (numPredictors > MaxRecruitPredictors)
      {
        throw new InvalidAgeproParameterException(
          $"Number of Observations exceed maximum limit of {MaxRecruitPredictors}.");
      }

      //Delete rows if current count excceds new value
      if (predictorDataTable.Rows.Count > numPredictors)
      {
        List<DataRow> rowsToDelete = new List<DataRow>();
        for (int i = 0; i < predictorDataTable.Rows.Count; i++)
        {
          if ((i + 1) > numPredictors)
          {
            DataRow deleteThisRow = predictorDataTable.Rows[i];
            rowsToDelete.Add(deleteThisRow);
          }
        }
        foreach (DataRow drow in rowsToDelete)
        {
          predictorDataTable.Rows.Remove(drow);
        }
      }//Add rows if row counts is less than the new value 
      else if (predictorDataTable.Rows.Count < numPredictors)
      {
        for (int i = predictorDataTable.Rows.Count; i < numPredictors; i++)
        {
          predictorDataTable.Rows.Add();
        }

      }
      return predictorDataTable;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridCoefficients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridCoefficients.Rows[e.RowIndex].HeaderCell;
      if (header.Value == null)
      {
        SetRecruitPredictorRowHeaders(dataGridCoefficients);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridObservations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridObservations.Rows[e.RowIndex].HeaderCell;
      if (header.Value == null)
      {
        SetRecruitPredictorRowHeaders(dataGridObservations);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predictorDataGrid"></param>
    private void SetRecruitPredictorRowHeaders(NftDataGridView predictorDataGrid)
    {
      for (int i = 0; i < predictorDataGrid.Rows.Count; i++)
      {
        predictorDataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
      }
    }

    /// <summary>
    /// Interface controls and Data Binding Setup
    /// </summary>
    /// <param name="recruitSelection">Recruitment data object</param>
    /// <param name="panelRecruitModelParameter"></param>
    public void SetPredictorRecruitmentcontrols(PredictorRecruitment recruitSelection, Panel panelRecruitModelParameter)
    {
      //Create a new coefficient and/or table if they are null
      if (recruitSelection.CoefficientTable == null)
      {
        recruitSelection.CoefficientTable = PredictorRecruitment.SetNewCoefficientTable(0);
      }
      if (recruitSelection.ObservationTable == null)
      {
        recruitSelection.ObservationTable = PredictorRecruitment.SetNewObsTable(0, SeqYears);
      }

      //Set Data Bindings
      _ = spinBoxNumRecruitPredictors.DataBindings.Add("value", recruitSelection, "NumRecruitPredictors",
          true, DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxVariance.DataBindings.Add("text", recruitSelection, "Variance", false,
          DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxIntercept.DataBindings.Add("text", recruitSelection, "Intercept", false,
          DataSourceUpdateMode.OnPropertyChanged);

      //Set DataGridView's Data Source
      CoefficientTable = recruitSelection.CoefficientTable;
      ObservationTable = recruitSelection.ObservationTable;

      //Set panel
      panelRecruitModelParameter.Controls.Clear();
      Dock = DockStyle.Fill;
      panelRecruitModelParameter.Controls.Add(this);

    }
  }

}
