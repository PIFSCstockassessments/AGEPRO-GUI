using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentEmpirical : UserControl
  {
    protected int MaxNumObservations { get; set; }
    public List<RecruitmentModelProperty> CollectionAgeproRecruitmentModels { get; set; }
    public int CollectionSelectedIndex { get; set; }
    private EmpiricalType EmpiricalSubtype { get; set; }

    public int numObservations
    {
      get => Convert.ToInt32(spinBoxNumObservations.Value);
      set => spinBoxNumObservations.Value = value;
    }
    public DataTable observationTable
    {
      get => (DataTable)dataGridRecruitTable.DataSource;
      set => dataGridRecruitTable.DataSource = value;
    }

    public ControlRecruitmentEmpirical()
    {
      InitializeComponent();
      MaxNumObservations = 500;
      spinBoxNumObservations.Maximum = MaxNumObservations;
      EmpiricalSubtype = EmpiricalType.Empirical;
    }
      
    /// <summary>
    /// Changes the number of rows in the observations table, based on the value the
    /// Number of Observations spin box was set to.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void ButtonSetParameters_Click(object sender, EventArgs e)
    {
      try
      {
        int newNumObservationsValue = Convert.ToInt32(spinBoxNumObservations.Value);

        //Catch if the number of Observations exceed maxNumObservations limit 
        //(in case control couldn't prevent it)
        if (newNumObservationsValue > MaxNumObservations)
        {
          throw new InvalidAgeproParameterException(
              $"Number of Observations exceed maximum limit of {MaxNumObservations}.");
        }
        observationTable = ControlRecruitment.ResizeDataGridTable(observationTable, newNumObservationsValue);
        numObservations = newNumObservationsValue;
        (CollectionAgeproRecruitmentModels[CollectionSelectedIndex] as EmpiricalRecruitment).NumObs = newNumObservationsValue;
        if (EmpiricalSubtype == EmpiricalType.CDFZero)
        {
          ((EmpiricalCDFZero)CollectionAgeproRecruitmentModels[CollectionSelectedIndex]).SSBHinge =
            Convert.ToDouble(textBoxSSBHinge.Text);
        }
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show("Can not resize number of Observation(s)." + Environment.NewLine + ex.Message,
           "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentEmpiricalRecruitSelection"></param>
    /// <param name="panelRecruitModelParameter"></param>
    public virtual void SetEmpiricalRecruitmentControls(EmpiricalRecruitment currentEmpiricalRecruitSelection,
        Panel panelRecruitModelParameter)
    {
      //create empty obsTable if null
      if (currentEmpiricalRecruitSelection.ObsTable == null)
      {
        currentEmpiricalRecruitSelection.ObsTable = currentEmpiricalRecruitSelection.SetNewObsTable(0);
      }

      //Load control in panelRecruitModelParameter
      _ = spinBoxNumObservations.DataBindings.Add("value", currentEmpiricalRecruitSelection, "numObs",
          true, DataSourceUpdateMode.OnPropertyChanged);
      observationTable = currentEmpiricalRecruitSelection.ObsTable;

      panelRecruitModelParameter.Controls.Clear();
      Dock = DockStyle.Fill;
      panelRecruitModelParameter.Controls.Add(this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentRecruit"></param>
    /// <param name="panelRecruitModelParameter"></param>
    public void SetEmpiricalCDFZeroRecruitmentControls(EmpiricalCDFZero currentRecruit, Panel panelRecruitModelParameter)
    {
      textBoxSSBHinge.Visible = true;
      labelSSBHinge.Visible = true;
      EmpiricalSubtype = EmpiricalType.CDFZero;

      _ = textBoxSSBHinge.DataBindings.Add("text", currentRecruit, "SSBHinge",
          true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);

      SetEmpiricalRecruitmentControls(currentRecruit, panelRecruitModelParameter);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridRecruitTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridRecruitTable.Rows[e.RowIndex].HeaderCell;
      if (header.Value == null)
      {
        SetEmpiricalRowHeadsers(dataGridRecruitTable);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="empiricalDataGrid"></param>
    protected void SetEmpiricalRowHeadsers(NftDataGridView empiricalDataGrid)
    {
      for (int i = 0; i < empiricalDataGrid.Rows.Count; i++)
      {
        empiricalDataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
      }
    }



  }
}
