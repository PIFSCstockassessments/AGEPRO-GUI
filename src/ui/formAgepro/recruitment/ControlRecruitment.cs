using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitment : UserControl
  {
    public int NumRecruitModels { get; set; }
    public int[] RecruitModelSelection { get; set; }
    public string[] SeqRecruitYears { get; set; }
    public Dictionary <int, string> recruitmentDictionary { get; set; }

    public List<RecruitmentModelProperty> CollectionAgeproRecruitmentModels { get; set; }

    private DataGridViewComboBoxColumn columnRecruitModelSelection;
    public bool PopulateDGV { get; set; }

    public double RecruitingScalingFactor
    {
      get => Convert.ToDouble(textBoxRecruitngScalingFactor.Text);
      set => textBoxRecruitngScalingFactor.Text = value.ToString();
    }
    public double SSBScalingFactor
    {
      get => Convert.ToDouble(textBoxSSBScalingFactor.Text);
      set => textBoxSSBScalingFactor.Text = value.ToString();
    }
    public DataTable RecruitmentProb
    {
      get => (DataTable)dataGridRecruitProb.DataSource;
      set => dataGridRecruitProb.DataSource = value;
    }

    public ControlRecruitment()
    {
      PopulateDGV = true;
      InitializeComponent();

      columnRecruitModelSelection = new DataGridViewComboBoxColumn
      {
        DataPropertyName = "columnRecruitModelSelect",
        HeaderText = "Recruitment Model",
        Width = 500
      };

      RecruitModelDictionaryContainer modelDictionaryObject = new RecruitModelDictionaryContainer();
      recruitmentDictionary = modelDictionaryObject.RecruitDictionary;
      columnRecruitModelSelection.DataSource = recruitmentDictionary.ToList();

      //Use the RecruitDictionary object to popluate dataGridRecruitModelSelection's Combo Boxes
      //Dictionary<int, string> recuritDict = RecruitDictionary();
      //columnRecruitModelSelection.DataSource = recuritDict.ToList();
      columnRecruitModelSelection.ValueMember = "Key";
      columnRecruitModelSelection.DisplayMember = "Value";
      _ = dataGridComboBoxSelectRecruitModels.Columns.Add(columnRecruitModelSelection);
      dataGridComboBoxSelectRecruitModels.RowHeadersWidth = 100;

      //Recruitment Prob
      dataGridRecruitProb.RowHeadersWidth = 100;

      ///Select Recruitment Models: 
      ///Don't want to cut/paste these values, but still want the user to use combo boxes to
      ///select a recruitment model.
      dataGridComboBoxSelectRecruitModels.nftReadOnly = true;
      dataGridComboBoxSelectRecruitModels.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

    }

    protected override void OnLoad(EventArgs e)
    {
      PopulateDGV = true;

      labelRecruitSelection.Text = GetSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);
      //Set prevValidValues
      textBoxRecruitngScalingFactor.PrevValidValue = RecruitingScalingFactor.ToString();
      textBoxSSBScalingFactor.PrevValidValue = SSBScalingFactor.ToString();

      if (CollectionAgeproRecruitmentModels.Count == 0)
      {
        //if AgeproRecruitmentModel Colletction list is empty, intialize it
        List<RecruitmentModelProperty> userSpecRecruitList = new List<RecruitmentModelProperty>();
        for (int i = 0; i < NumRecruitModels; i++)
        {
          userSpecRecruitList.Add(new NullSelectRecruitment());
        }
        CollectionAgeproRecruitmentModels = userSpecRecruitList;
      }

      base.OnLoad(e);
      PopulateDGV = false;
    }

    /// <summary>
    /// Sets up values for ControlRecruitment controls whenever the user either 
    /// opens an existing AGEPRO input data file or creates a new case.
    /// </summary>
    /// <param name="nrecruits"> Number of Recuitment Models.</param>
    /// <param name="selectedModels">AgeproRecruitment CoreLib object.</param>
    public void SetupControlRecruitment(int nrecruits,
        AgeproRecruitment objRecruitment)
    {
      //Cleanup any previously used recruitment parameter controls.
      panelRecruitModelParameter.Controls.Clear();
      textBoxRecruitngScalingFactor.Clear();
      textBoxSSBScalingFactor.Clear();

      //Bindings
      textBoxRecruitngScalingFactor.DataBindings.Clear();
      textBoxSSBScalingFactor.DataBindings.Clear();
      _ = textBoxRecruitngScalingFactor.DataBindings.Add("Text", objRecruitment, "recruitScalingFactor", true,
        DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxSSBScalingFactor.DataBindings.Add("Text", objRecruitment, "SSBScalingFactor", true,
        DataSourceUpdateMode.OnPropertyChanged);
      textBoxRecruitngScalingFactor.PrevValidValue = textBoxRecruitngScalingFactor.Text;
      textBoxSSBScalingFactor.PrevValidValue = textBoxSSBScalingFactor.Text;

      //numRecuritModels
      NumRecruitModels = nrecruits;

      //collectionAgeproRecruitmentModels
      CollectionAgeproRecruitmentModels = objRecruitment.RecruitCollection;

      //seqRecruitYears
      SeqRecruitYears = Array.ConvertAll(objRecruitment.ObservationYears, element => element.ToString());

      //recruitModelSelection
      SetRecruitModelSelection(nrecruits, objRecruitment);

      //setup RecruitmentSelectionComboBox in recruit models tab
      SetRecuitmentSelectionComboBox(nrecruits);

      //setup dataGridComboBoxSelectRecruitModels in recruitment tab
      SetDataGridComboBoxSelectRecruitModels(nrecruits);

      //recruitmentProb
      RecruitmentProb = objRecruitment.RecruitProb;

      //recruitmentScalingfactor
      RecruitingScalingFactor = objRecruitment.RecruitScalingFactor;
    
      //SSBScalingFactor
      SSBScalingFactor = objRecruitment.SSBScalingFactor;
    }

    /// <summary>
    /// Sets up an array of recruit model integers. Array size based on nrecruits.
    /// </summary>
    /// <param name="nrecruits">Number of Recruits</param>
    /// <param name="objRecruitment">CoreLib.AgeproRecruitment object</param>
    private void SetRecruitModelSelection(int nrecruits, AgeproRecruitment objRecruitment)
    {
      RecruitModelSelection = new int[nrecruits];
      //recruitModelSelection from RecruitCollection
      if (objRecruitment.ObservationYears.Count() > 0)
      {
        for (int rmodel = 0; rmodel < objRecruitment.RecruitCollection.Count; rmodel++)
        {
          RecruitModelSelection[rmodel] = objRecruitment.RecruitCollection[rmodel].recruitModelNum;
        }
      }
    }


    /// <summary>
    /// Poplulates Recruitment Model Drepdown Box
    /// </summary>
    /// <param name="numRecruitModels"></param>
    public void SetDataGridComboBoxSelectRecruitModels(int numRecruitModels)
    {
      if (dataGridComboBoxSelectRecruitModels != null)
      {
        //Clear Out rows from Previous Run/Load/Call
        dataGridComboBoxSelectRecruitModels.Rows.Clear();
      }

      for (int i = 0; i < numRecruitModels; i++)
      {
        _ = dataGridComboBoxSelectRecruitModels.Rows.Add(); //Add Empty Row w/ ComboBoxColumn
      }

      int irecruit = 0;
      foreach (DataGridViewRow recruitSelection in dataGridComboBoxSelectRecruitModels.Rows)
      {
        //Set ComboBox Value with intended recruit model number.
        ((DataGridViewComboBoxCell)recruitSelection.Cells[0]).Value = RecruitModelSelection[irecruit];
        irecruit++;
      }

    }

    /// <summary>
    /// Populates the comboBoxRecruitmentSelection in the Recruit Models Tab
    /// </summary>
    /// <param name="numSelections">Recruitment selection count.</param>
    public void SetRecuitmentSelectionComboBox(int numSelections)
    {
      string[] selectionList = new string[numSelections];
      for (int i = 0; i < selectionList.Count(); i++)
      {
        selectionList[i] = "Recruitment Selection - " + (i + 1);
      }
      comboBoxRecruitSelection.DataSource = selectionList;

    }

    /// <summary>
    /// Sets Up The Column Headers for the Recruitment Probability Data Grid
    /// </summary>
    private void SetRecruitmentProbRowHeaders()
    {
      int iyear = 0;
      foreach (DataGridViewRow yearRow in dataGridRecruitProb.Rows)
      {
        yearRow.HeaderCell.Value = SeqRecruitYears[iyear];
        iyear++;
      }
    }
        
    /// <summary>
    /// Recruitment Probabilitity Format
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridRecruitProb_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridRecruitProb.Rows[e.RowIndex].HeaderCell;

      if (!(header.Value != null))
      {
        SetRecruitmentProbRowHeaders();
      }
    }

    /// <summary>
    /// Recruit Selection Formatting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridComboBoxSelectRecruitModels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridComboBoxSelectRecruitModels.Rows[e.RowIndex].HeaderCell;

      if (!(header.Value != null))
      {

        for (int i = 0; i < dataGridComboBoxSelectRecruitModels.Rows.Count; i++)
        {
          dataGridComboBoxSelectRecruitModels.Rows[i].HeaderCell.Value = "Selection " + (i + 1);
        }

      }
    }

    /// <summary>
    /// Model-Specfic Recriut Selection Formatting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ComboBoxRecruitSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (CollectionAgeproRecruitmentModels != null)
      {
        ComboBox modelSelectionCbx = sender as ComboBox;

        labelRecruitSelection.Text = GetSelectedRecruitmentModelName(modelSelectionCbx.SelectedIndex);

        RecruitmentModelProperty currentRecruitSelection = CollectionAgeproRecruitmentModels[modelSelectionCbx.SelectedIndex];

        LoadRecruitModelParameterControls(currentRecruitSelection);
      }

    }

    //TODO:REFACTOR 
    private void LoadRecruitModelParameterControls(RecruitmentModelProperty currentRecruitSelection)
    {
      if (currentRecruitSelection is EmpiricalRecruitment)
      {
        if (((EmpiricalRecruitment)currentRecruitSelection).SubType == EmpiricalType.Empirical)
        {
          EmpiricalRecruitment currentEmpiricalRecruitSelection = (EmpiricalRecruitment)currentRecruitSelection;

          ControlRecruitmentEmpirical empiricalParameterControls = new ControlRecruitmentEmpirical();

          empiricalParameterControls.SetEmpiricalRecruitmentControls(currentEmpiricalRecruitSelection, panelRecruitModelParameter);
          empiricalParameterControls.CollectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          empiricalParameterControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;

        }
        else if (((EmpiricalRecruitment)currentRecruitSelection).SubType == EmpiricalType.TwoStage)
        {
          EmpiricalTwoStageRecruitment currentTwoStageEmpiricalRecruitSelection =
              (EmpiricalTwoStageRecruitment)currentRecruitSelection;

          //Load TwoStage Controls
          ControlRecruitmentEmpiricalTwoStage twoStageControls = new ControlRecruitmentEmpiricalTwoStage();
          twoStageControls.SetTwoStageEmpiricalRecruitmentControls(currentTwoStageEmpiricalRecruitSelection,
              panelRecruitModelParameter);
          twoStageControls.CollectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          twoStageControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
        }
        else if (((EmpiricalRecruitment)currentRecruitSelection).SubType == EmpiricalType.CDFZero)
        {
          EmpiricalCDFZero currentEmpiricalCDFZeroRecruitmentSelection = (EmpiricalCDFZero)currentRecruitSelection;

          ControlRecruitmentEmpirical empiricalCDFZeroControls = new ControlRecruitmentEmpirical();

          empiricalCDFZeroControls.SetEmpiricalCDFZeroRecruitmentControls(
              currentEmpiricalCDFZeroRecruitmentSelection, panelRecruitModelParameter);
          empiricalCDFZeroControls.CollectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          empiricalCDFZeroControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;


        }
        else if (((EmpiricalRecruitment)currentRecruitSelection).SubType == EmpiricalType.Fixed)
        {
          EmpiricalFixedRecruitment currentFixedRecruitmentSelection = (EmpiricalFixedRecruitment)currentRecruitSelection;

          ControlRecruitmentFixed fixedRecruitmentControls = new ControlRecruitmentFixed();
          fixedRecruitmentControls.seqYears = SeqRecruitYears;
          fixedRecruitmentControls.SetFixedRecruitmentControls(currentFixedRecruitmentSelection, panelRecruitModelParameter);
          fixedRecruitmentControls.collectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          fixedRecruitmentControls.collectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
        }

      }
      else if (currentRecruitSelection is ParametricRecruitment)
      {
        if (((ParametricRecruitment)currentRecruitSelection).Subtype == ParametricType.Curve)
        {
          ParametricCurve currentParametricCurveRecruit = (ParametricCurve)currentRecruitSelection;

          ControlRecruitmentParametricCurve parametricCurveControls = new ControlRecruitmentParametricCurve();

          parametricCurveControls.CollectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          parametricCurveControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
          parametricCurveControls.SetParametricRecruitmentControls(currentParametricCurveRecruit, panelRecruitModelParameter);

        }
        else if (((ParametricRecruitment)currentRecruitSelection).Subtype == ParametricType.Lognormal)
        {
          ParametricLognormal currentParametricLognormalRecruit = (ParametricLognormal)currentRecruitSelection;

          ControlRecruitmentParametricLognormal lognormalControls = new ControlRecruitmentParametricLognormal();

          lognormalControls.SetParametricRecruitmentControls(currentParametricLognormalRecruit, panelRecruitModelParameter);
          lognormalControls.CollectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
          lognormalControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
        }
      }
      else if (currentRecruitSelection is PredictorRecruitment)
      {
        PredictorRecruitment currentPredictorRecruitSelection = (PredictorRecruitment)currentRecruitSelection;

        ControlRecruitmentPredictor predictorParameterControls = new ControlRecruitmentPredictor();

        predictorParameterControls.seqYears = SeqRecruitYears;
        predictorParameterControls.collectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
        predictorParameterControls.collectionAgeproRecruitmentModels = CollectionAgeproRecruitmentModels;
        predictorParameterControls.SetPredictorRecruitmentcontrols(currentPredictorRecruitSelection, panelRecruitModelParameter);
      }
      else if (currentRecruitSelection is MarkovMatrixRecruitment)
      {
        MarkovMatrixRecruitment currentRecruit = (MarkovMatrixRecruitment)currentRecruitSelection;

        ControlRecruitmentMarkovMatrix markovControls = new ControlRecruitmentMarkovMatrix();

        markovControls.SetRecruitmentControls(currentRecruit, panelRecruitModelParameter);
        markovControls.CollectionAgeproRecruitModels = CollectionAgeproRecruitmentModels;
        markovControls.CollectionSelectedIndex = comboBoxRecruitSelection.SelectedIndex;
      }
      else
      {
        panelRecruitModelParameter.Controls.Clear();
      }

    }


    /// <summary>
    /// Returns the Selected Recruitment's Model Name based how it's model number matches the Recruit Dictionary. 
    /// </summary>
    /// <param name="index">Index of RecruitmentModelSelection Array</param>
    /// <returns>String value from RecruitDictionary</returns>
    private string GetSelectedRecruitmentModelName(int index)
    {
      int selectedModel = RecruitModelSelection[index];
      if (recruitmentDictionary.TryGetValue(selectedModel, out string selectedRecruitModelName))
      {
        return selectedRecruitModelName;
      }
      else
      {
        //Throw an Error if selected model number doesn't match the dictionary.
        return "...";
      }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TabControlRecruitment_SelectedIndexChanged(object sender, EventArgs e)
    {
      //When switching to the "Recruit Model" Tab, set up selected model name for labelRecruitSelection
      if ((sender as TabControl).SelectedIndex == 1)
      {
        labelRecruitSelection.Text = GetSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);

        //Catch for nulls
        if (CollectionAgeproRecruitmentModels.Count != 0)
        {
          RecruitmentModelProperty selectedRecruitModel = CollectionAgeproRecruitmentModels[comboBoxRecruitSelection.SelectedIndex];
          //Load the appropriate panel
          LoadRecruitModelParameterControls(selectedRecruitModel);
        }
        else
        {
          panelRecruitModelParameter.Controls.Clear();
        }
      }
    }



    // This event handler manually raises the CellValueChanged event 
    // by calling the CommitEdit method. 
    private void DataGridComboBoxSelectRecruitModels_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (dataGridComboBoxSelectRecruitModels.IsCurrentCellDirty)
      {
        try
        {
          // This fires the cell value changed handler below
          _ = dataGridComboBoxSelectRecruitModels.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        catch (Exception ex)
        {
          _ = MessageBox.Show("AGEPRO Recruitment selection can not be made." + Environment.NewLine +
              ex.Message, "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

          //Store previous value in case of error
          NftDataGridView senderDgv = sender as NftDataGridView;
          DataGridViewComboBoxEditingControl senderCbxCell = senderDgv.EditingControl as DataGridViewComboBoxEditingControl;
          object oldKey = senderDgv.CurrentCell.Value;
          //Revert selected value 
          senderCbxCell.SelectedValue = oldKey;
        }

      }
    }

    private void DataGridComboBoxSelectRecruitModels_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (PopulateDGV == false)
      {
        DataGridViewComboBoxCell cbxCell = (DataGridViewComboBoxCell)dataGridComboBoxSelectRecruitModels.Rows[e.RowIndex].Cells[0];
        //Should only bind to events to Recruitment Model Column
        if (e.ColumnIndex == 0)
        {
          if (cbxCell != null)
          {
            var currentModel = dataGridComboBoxSelectRecruitModels.CurrentCell.RowIndex;
            var senderDGV = sender as NftDataGridView;
            var senderCbx = senderDGV.EditingControl as DataGridViewComboBoxEditingControl;
            //check if senderCbx is actually the checkbox or not. (Programmically, sender would be null)
            if (senderCbx != null)
            {
              OnSelectingRecruitModel(currentModel, senderCbx);
            }

            dataGridComboBoxSelectRecruitModels.Invalidate();
          }
        }
      }

    }

    /// <summary>
    /// Sets the Recruitment Model of the current index of the multi-recruitment array based off from the
    /// current selected cell value of dataGridComboBoxRecruitModel. 
    /// </summary>
    /// <param name="currentModel">Index of the recruitment collection array</param>
    /// <param name="modelCbx">The DataGridViewComboBoxCell object that is being selected by the user</param>
    private void OnSelectingRecruitModel(int currentModel, DataGridViewComboBoxEditingControl modelCbx)
    {

      object kvpKey;
      object selectedRecruit = modelCbx.SelectedItem;
      if (selectedRecruit != null)
      {
        Type typeSelectedRecruit = selectedRecruit.GetType();
        if (typeSelectedRecruit.IsGenericType)
        {
          Type baseTypeSelectedRecruit = typeSelectedRecruit.GetGenericTypeDefinition();
          if (baseTypeSelectedRecruit == typeof(KeyValuePair<,>))
          {
            _ = baseTypeSelectedRecruit.GetGenericArguments();

            kvpKey = typeSelectedRecruit.GetProperty("Key").GetValue(selectedRecruit, null);
            RecruitModelSelection[currentModel] = Convert.ToInt32(kvpKey);

            int selectedModelNum = Convert.ToInt32(kvpKey);
            if (CollectionAgeproRecruitmentModels[currentModel] != null)
            {
              CollectionAgeproRecruitmentModels[currentModel] =
                  AgeproRecruitment.GetRecruitmentModel(selectedModelNum);

            }

          }
        }
      }

    }
    //end OnSelectingRecruitingModel


    /// <summary>
    /// Recruitment Validation
    /// </summary>
    /// <returns></returns>
    private ValidationResult ValidateGeneralRecruitmentParameters()
    {
      List<string> errorMsgList = new List<string>();
      //Select Recruitment Models
      if (dataGridComboBoxSelectRecruitModels.HasBlankOrNullCells())
      {
        errorMsgList.Add("Select Recruitment Model Data Grid has invalid data.");
      }
      //Recruitment Scaling Factor
      if (string.IsNullOrWhiteSpace(textBoxRecruitngScalingFactor.Text))
      {
        errorMsgList.Add("Missing Recruitment Scaling Factor value.");
      }
      //SSB Scaling Factor
      if (string.IsNullOrWhiteSpace(textBoxSSBScalingFactor.Text))
      {
        errorMsgList.Add("Missing Recruitment SSB Scaling Factor value.");
      }

      //Recruitment Probability
      if (dataGridRecruitProb.HasBlankOrNullCells())
      {
        errorMsgList.Add("Recruitment probability table has missing values.");
      }
      foreach (DataRow drow in RecruitmentProb.Rows)
      {
        //List rows that have nulls/missing data
        if (drow.ItemArray.Any(x => string.IsNullOrWhiteSpace(x.ToString())))
        {
          errorMsgList.Add("At row " + (RecruitmentProb.Rows.IndexOf(drow) + 1) +
              ": Empty or missing value found.");
        }
        else
        {
          string[] recruitProbRow = Array.ConvertAll(drow.ItemArray, item => item.ToString());
          if (AgeproRecruitment.CheckRecruitProbabilitySum(recruitProbRow) == false)
          {
            double rowSumRecruitProb = Array.ConvertAll<string, double>(recruitProbRow, double.Parse).Sum();
            errorMsgList.Add("At row " + RecruitmentProb.Rows.IndexOf(drow) +
                ": Recruitment probablity sum does not equal 1.0; probability sum is "
                + rowSumRecruitProb.ToString());
          }
        }


      }

      var results = errorMsgList.EnumerateValidationResults();

      return results;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool ValidateRecruitmentData()
    {

      ValidationResult vaildGeneralRecruitParameters =
          ValidateGeneralRecruitmentParameters();

      if (vaildGeneralRecruitParameters.IsValid == false)
      {
        _ = MessageBox.Show(vaildGeneralRecruitParameters.Message,
            "AGEPRO Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        return false;
      }

      //Recruit Models
      ValidationResult vaildRecruitmentModelResult;

      foreach (RecruitmentModelProperty rmodelSelection in CollectionAgeproRecruitmentModels)
      {
        int rmodelIndex = CollectionAgeproRecruitmentModels.IndexOf(rmodelSelection);

        vaildRecruitmentModelResult = rmodelSelection.ValidationCheck();

        if (vaildRecruitmentModelResult.IsValid == false)
        {
          _ = MessageBox.Show($"In Recruitment Selection {rmodelIndex + 1} - \"{GetSelectedRecruitmentModelName(rmodelIndex)}\" : " +
            $"{Environment.NewLine}{vaildRecruitmentModelResult.Message}",
            "AGEPRO Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          
          return false;
        }
      }


      return true;
    }


    /// <summary>
    /// Resizes DataTable Object in DataGridView.
    /// </summary>
    /// <param name="dgvTable"></param>
    /// <param name="newRowCount"></param>
    /// <returns></returns>
    public static DataTable ResizeDataGridTable(DataTable dgvTable, int newRowCount)
    {
      //Delete rows if current count excceds new value
      if (dgvTable.Rows.Count > newRowCount)
      {
        List<DataRow> rowsToDelete = new List<DataRow>();
        for (int i = 0; i < dgvTable.Rows.Count; i++)
        {
          if ((i + 1) > newRowCount)
          {
            DataRow deleteThisRow = dgvTable.Rows[i];
            rowsToDelete.Add(deleteThisRow);
          }
        }
        foreach (DataRow drow in rowsToDelete)
        {
          dgvTable.Rows.Remove(drow);
        }
      }//Add rows if row counts is less than the new value 
      else if (dgvTable.Rows.Count < newRowCount)
      {
        for (int i = dgvTable.Rows.Count; i < newRowCount; i++)
        {
          dgvTable.Rows.Add();
        }
      }
      return dgvTable;
    }

    /// <summary>
    /// Resizes the DataTable Object in DataGridView
    /// </summary>
    /// <param name="dgvTable"></param>
    /// <param name="newRowCount"></param>
    /// <param name="newColCount"></param>
    /// <returns></returns>
    public static DataTable ResizeDataGridTable(DataTable dgvTable, int newRowCount, int newColCount)
    {
      //Delete Cols if current column count excceds new value
      if (dgvTable.Columns.Count > newColCount)
      {
        List<DataColumn> colsToDelete = new List<DataColumn>();
        for (int j = 0; j < dgvTable.Columns.Count; j++)
        {
          if ((j + 1) > newColCount)
          {
            DataColumn deleteThisCol = dgvTable.Columns[j];
            colsToDelete.Add(deleteThisCol);
          }
        }
        foreach (DataColumn dcol in colsToDelete)
        {
          dgvTable.Columns.Remove(dcol);
        }
      }//Add columns if current column count is less than the new value
      else if (dgvTable.Columns.Count < newColCount)
      {
        for (int j = dgvTable.Columns.Count; j < newColCount; j++)
        {
          dgvTable.Columns.Add();
        }
      }

      return ResizeDataGridTable(dgvTable, newRowCount);
    }

    private bool ValidateScalingFactor(NftTextBox txtFactor, string paramName)
    {
      //Validate Scaling Factor As Numerical
      if (!double.TryParse(txtFactor.Text, out double scaleFactor))
      {
        _ = MessageBox.Show(paramName + " must be a numeric value.", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtFactor.Text = txtFactor.PrevValidValue;
        return false;
      }
      //Validate Scaling Factor as Positive Number
      if (scaleFactor < 0)
      {
        _ = MessageBox.Show(paramName + " must be a positive number.", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtFactor.Text = txtFactor.PrevValidValue;
        return false;
      }
      
      return true; // If Valid 
    }



    /// <summary>
    /// Recruiting Scaling Factor Input Validator. Raise the cancel event flag if Scaling Factors are not valid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxRecruitngScalingFactor_Validating(object sender, CancelEventArgs e)
    {
      if (!ValidateScalingFactor(textBoxRecruitngScalingFactor, "Recruitment Scaling Factor"))
      {
        e.Cancel = true;
      }
    }

    /// <summary>
    /// SSB Scaling Factor Input Validator. Raise the cancel event flag if Scaling Factors are not valid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBoxSSBScalingFactor_Validating(object sender, CancelEventArgs e)
    {
      if (!ValidateScalingFactor(textBoxSSBScalingFactor, "SSB Scaling Factor"))
      {
        e.Cancel = true;
      }
    }





  }
}
