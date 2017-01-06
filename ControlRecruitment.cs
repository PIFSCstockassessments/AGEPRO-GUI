﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlRecruitment : UserControl
    {
        public int numRecruitModels { get; set; }
        public int[] recruitModelSelection { get; set; }
        public string[] seqRecruitYears { get; set; }

        public List<Nmfs.Agepro.CoreLib.RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }

        private DataGridViewComboBoxColumn columnRecruitModelSelection;
        public bool populateDGV { get; set; }

        public ControlRecruitment()
        {
            populateDGV = true;
            InitializeComponent();
            
            columnRecruitModelSelection = new DataGridViewComboBoxColumn();
            columnRecruitModelSelection.DataPropertyName = "columnRecruitModelSelect";
            columnRecruitModelSelection.HeaderText = "Recruitment Model";
            columnRecruitModelSelection.Width = 500;
            
            //Use the RecruitDictionary object to popluate dataGridRecruitModelSelection's Combo Boxes
            Dictionary <int, string> recuritDict = RecruitDictionary();
            columnRecruitModelSelection.DataSource = recuritDict.ToList();
            columnRecruitModelSelection.ValueMember = "Key";
            columnRecruitModelSelection.DisplayMember = "Value";
            dataGridComboBoxSelectRecruitModels.Columns.Add(columnRecruitModelSelection);
            dataGridComboBoxSelectRecruitModels.RowHeadersWidth = 100;

            //Recruitment Prob
            dataGridRecruitProb.RowHeadersWidth = 100;

            ///Select Recruitment Models: 
            ///Don't want to cut/paste these values, but still want the user to use combo boxes to
            ///select a recruitment model.
            this.dataGridComboBoxSelectRecruitModels.nftReadOnly = true;
            this.dataGridComboBoxSelectRecruitModels.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        }
        public int recruitingScalingFactor
        {
            get { return Convert.ToInt32(textBoxRecruitngScalingFactor.Text); }
            set { textBoxRecruitngScalingFactor.Text = value.ToString(); }
        }
        public int SSBScalingFactor
        {
            get { return Convert.ToInt32(textBoxSSBScalingFactor.Text); }
            set { textBoxSSBScalingFactor.Text = value.ToString(); }
        }
        public DataTable recruitmentProb
        {
            get { return (DataTable)dataGridRecruitProb.DataSource; }
            set { dataGridRecruitProb.DataSource = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.populateDGV = true;
            
            labelRecruitSelection.Text = getSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);

            if (collectionAgeproRecruitmentModels.Count == 0)
            {
                //if AgeproRecruitmentModel Colletction list is empty, intialize it
                List<RecruitmentModel> userSpecRecruitList = new List<RecruitmentModel>();
                for (int i = 0; i < numRecruitModels; i++)
                {
                    userSpecRecruitList.Add(new NullSelectRecruitment());
                }
                collectionAgeproRecruitmentModels = userSpecRecruitList;
            }

            base.OnLoad(e);
            populateDGV = false;
        }
        /// <summary>
        /// 
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
                this.dataGridComboBoxSelectRecruitModels.Rows.Add(); //Add Empty Row w/ ComboBoxColumn
            }

            int irecruit = 0;
            foreach (DataGridViewRow recruitSelection in this.dataGridComboBoxSelectRecruitModels.Rows)
            {
                //Set ComboBox Value with intended recruit model number.
                ((DataGridViewComboBoxCell)recruitSelection.Cells[0]).Value = this.recruitModelSelection[irecruit];
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
            foreach (DataGridViewRow yearRow in this.dataGridRecruitProb.Rows)
            {
                yearRow.HeaderCell.Value = seqRecruitYears[iyear];
                iyear++;
            }
        }

        

        /// <summary>
        /// Creates and sets the Recruitment Model Dictionary Object
        /// </summary>
        /// <returns>Returns the Recruitment Model Dictionary</returns>
        public Dictionary<int, string> RecruitDictionary()
        {
            //Future Feature: Generizse/Automate this Dictionary?
            Dictionary<int, string> recruitModelDictionary = new Dictionary<int, string>();

            recruitModelDictionary.Add(0, "None Selected");
            recruitModelDictionary.Add(1, "Model 1: Markov Matrix");
            recruitModelDictionary.Add(2, "Model 2: Empirical Recruits per Spawning Biomass Distribution");
            recruitModelDictionary.Add(3, "Model 3: Empirical Recruitment Distributiion");
            recruitModelDictionary.Add(4, "Model 4: Two-Stage Empirical Recruits per Spawning Biomass Distribution");
            recruitModelDictionary.Add(5, "Model 5: Beverton-Holt Curve w/ Lognormal Error");
            recruitModelDictionary.Add(6, "Model 6: Ricker Curve w/ Lognormal Error");
            recruitModelDictionary.Add(7, "Model 7: Shepherd Curve w/ Lognormal Error");
            recruitModelDictionary.Add(8, "Model 8: Lognormal Distribution");
            //Model 9 was removed in AGEPRO 4.0
            recruitModelDictionary.Add(10, "Model 10: Beverton-Holt Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(11, "Model 11: Ricker Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(12, "Model 12: Shepherd Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(13, "Model 13: Autocorrected Lognormal Distribution");
            recruitModelDictionary.Add(14, "Model 14: Empirical Cumulative Distribution Function of Recruitment");
            recruitModelDictionary.Add(15, "Model 15: Two-Stage Empirical Cumulative Distribution Function of Recruitment");
            recruitModelDictionary.Add(16, "Model 16: Linear Recruits per Spawning Biomass Predictor w/ Normal Error");
            recruitModelDictionary.Add(17, "Model 17: Loglinear Recruits per Spawning Biomass Predictor w/ Lognormal Error");
            recruitModelDictionary.Add(18, "Model 18: Linear Recruitment Predictor w/ Normal Error");
            recruitModelDictionary.Add(19, "Model 19: Loglinear Recruitment Predictor w/ Lognormal Error");
            recruitModelDictionary.Add(20, "Model 20: Fixed Recruitment");
            recruitModelDictionary.Add(21, "Model 21: Empirical Cumulative Distribution Function of Recruitment w/ Linear Decline to Zero");

            return recruitModelDictionary;
        }

        private void dataGridRecruitProb_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridRecruitProb.Rows[e.RowIndex].HeaderCell;

            if (!(header.Value != null))
            {
                SetRecruitmentProbRowHeaders();
            }
        }

        private void dataGridComboBoxSelectRecruitModels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void comboBoxRecruitSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (collectionAgeproRecruitmentModels != null)
            {
                ComboBox modelSelectionCbx = sender as ComboBox;

                labelRecruitSelection.Text = getSelectedRecruitmentModelName(modelSelectionCbx.SelectedIndex);

                RecruitmentModel currentRecruitSelection = this.collectionAgeproRecruitmentModels[modelSelectionCbx.SelectedIndex];

                LoadRecruitModelParameterControls(currentRecruitSelection);
            }
            
        }

        //TODO:REFACTOR 
        private void LoadRecruitModelParameterControls(RecruitmentModel currentRecruitSelection)
        {
            if (currentRecruitSelection is EmpiricalRecruitment)
            {
                if (((EmpiricalRecruitment)currentRecruitSelection).subType == EmpiricalType.Empirical)
                {
                    EmpiricalRecruitment currentEmpiricalRecruitSelection = (EmpiricalRecruitment)currentRecruitSelection;
                    
                    ControlRecruitmentEmpirical empiricalParameterControls = new ControlRecruitmentEmpirical();
                    
                    empiricalParameterControls.SetEmpiricalRecruitmentControls(currentEmpiricalRecruitSelection, panelRecruitModelParameter);
                    empiricalParameterControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    empiricalParameterControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
                    
                }
                else if (((EmpiricalRecruitment)currentRecruitSelection).subType == EmpiricalType.TwoStage)
                {
                    TwoStageEmpiricalRecruitment currentTwoStageEmpiricalRecruitSelection =
                        (TwoStageEmpiricalRecruitment)currentRecruitSelection;

                    //Load TwoStage Controls
                    ControlRecruitmentEmpiricalTwoStage twoStageControls = new ControlRecruitmentEmpiricalTwoStage();
                    twoStageControls.SetTwoStageEmpiricalRecruitmentControls(currentTwoStageEmpiricalRecruitSelection, 
                        panelRecruitModelParameter);
                    twoStageControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    twoStageControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
                }
                else if (((EmpiricalRecruitment)currentRecruitSelection).subType == EmpiricalType.CDFZero)
                {
                    EmpiricalCDFZero currentEmpiricalCDFZeroRecruitmentSelection = (EmpiricalCDFZero)currentRecruitSelection;

                    ControlRecruitmentEmpirical empiricalCDFZeroControls = new ControlRecruitmentEmpirical();

                    empiricalCDFZeroControls.SetEmpiricalCDFZeroRecruitmentControls(
                        currentEmpiricalCDFZeroRecruitmentSelection, panelRecruitModelParameter);
                    empiricalCDFZeroControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    empiricalCDFZeroControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;

                    
                }
                else if (((EmpiricalRecruitment)currentRecruitSelection).subType == EmpiricalType.Fixed)
                {
                    EmpiricalRecruitment currentFixedRecruitmentSelection = (EmpiricalRecruitment)currentRecruitSelection;

                    ControlRecruitmentFixed fixedRecruitmentControls = new ControlRecruitmentFixed();
                    fixedRecruitmentControls.seqYears = this.seqRecruitYears;
                    fixedRecruitmentControls.SetFixedRecruitmentControls(currentFixedRecruitmentSelection, panelRecruitModelParameter);
                    fixedRecruitmentControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    fixedRecruitmentControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
                }
                
            }
            else if (currentRecruitSelection is ParametricRecruitment)
            {
                if (((ParametricRecruitment)currentRecruitSelection).subtype == ParametricType.Curve)
                {
                    ParametricCurve currentParametricCurveRecruit = (ParametricCurve)currentRecruitSelection;

                    ControlRecruitmentParametricCurve parametricCurveControls = new ControlRecruitmentParametricCurve();

                    parametricCurveControls.SetParametricRecruitmentControls(currentParametricCurveRecruit, panelRecruitModelParameter);
                    parametricCurveControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    parametricCurveControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
                }
                else if (((ParametricRecruitment)currentRecruitSelection).subtype == ParametricType.Lognormal)
                {
                    ParametricLognormal currentParametricLognormalRecruit = (ParametricLognormal)currentRecruitSelection;

                    ControlRecruitmentParametricLognormal lognormalControls = new ControlRecruitmentParametricLognormal();

                    lognormalControls.SetParametricRecruitmentControls(currentParametricLognormalRecruit, panelRecruitModelParameter);
                    lognormalControls.collectionAgeproRecruitmentModels = this.collectionAgeproRecruitmentModels;
                    lognormalControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
                }
            }
            else if (currentRecruitSelection is PredictorRecruitment)
            {
                PredictorRecruitment currentPredictorRecruitSelection = (PredictorRecruitment)currentRecruitSelection;
                if (!(currentPredictorRecruitSelection.coefficientTable != null))
                {
                    currentPredictorRecruitSelection.coefficientTable = PredictorRecruitment.SetNewCoefficientTable(0);
                }
                if (!(currentPredictorRecruitSelection.observationTable != null))
                {
                    currentPredictorRecruitSelection.observationTable = 
                        PredictorRecruitment.SetNewObsTable(0, this.seqRecruitYears);
                }

                ControlRecruitmentPredictor predictorParameterControls = new ControlRecruitmentPredictor();
                predictorParameterControls.numRecruitPredictors = currentPredictorRecruitSelection.numRecruitPredictors;
                predictorParameterControls.variance = currentPredictorRecruitSelection.variance;
                predictorParameterControls.intercept = currentPredictorRecruitSelection.intercept;
                predictorParameterControls.coefficientTable = currentPredictorRecruitSelection.coefficientTable;
                predictorParameterControls.observationTable = currentPredictorRecruitSelection.observationTable;
                
                panelRecruitModelParameter.Controls.Clear();
                predictorParameterControls.Dock = DockStyle.Fill;
                panelRecruitModelParameter.Controls.Add(predictorParameterControls);
            }
            else if(currentRecruitSelection is MarkovMatrixRecruitment)
            {
                MarkovMatrixRecruitment currentRecruit = (MarkovMatrixRecruitment)currentRecruitSelection;

                ControlRecruitmentMarkovMatrix markovControls = new ControlRecruitmentMarkovMatrix();

                markovControls.SetRecruitmentControls(currentRecruit,panelRecruitModelParameter);
                markovControls.collectionAgeproRecruitModels = this.collectionAgeproRecruitmentModels;
                markovControls.collectionSelectedIndex = this.comboBoxRecruitSelection.SelectedIndex;
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
        private string getSelectedRecruitmentModelName(int index)
        {
            int selectedModel = this.recruitModelSelection[index];
            string selectedRecruitModelName;
            if (RecruitDictionary().TryGetValue(selectedModel, out selectedRecruitModelName))
            {
                return selectedRecruitModelName;
            }
            else
            {
                //TODO: Throw an Error if selected model number doesn't match the dictionary.
                return "...";
            }
          
        }

        private void tabControlRecruitment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When switching to the "Recruit Model" Tab, set up selected model name for labelRecruitSelection
            if ((sender as TabControl).SelectedIndex == 1)
            {
                //TODO: CATCH "NONE SELECTED" 
                labelRecruitSelection.Text = getSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);

                //Load the appropriate 
                RecruitmentModel selectedRecruitModel = collectionAgeproRecruitmentModels[comboBoxRecruitSelection.SelectedIndex];

                LoadRecruitModelParameterControls(selectedRecruitModel);
            }
         }



        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        private void dataGridComboBoxSelectRecruitModels_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridComboBoxSelectRecruitModels.IsCurrentCellDirty)
            {
                //Store previous value in case of error
                var senderDgv = sender as NftDataGridView;
                var oldKey = senderDgv.CurrentCell.Value; 
                var senderCbxCell = senderDgv.EditingControl as DataGridViewComboBoxEditingControl;
                
                try
                {  
                    // This fires the cell value changed handler below
                    dataGridComboBoxSelectRecruitModels.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AGEPRO Recruitment selection can not be made." + Environment.NewLine + 
                        ex.Message, "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    //Revert selected value 
                    senderCbxCell.SelectedValue = oldKey; 
                }
                 
            }
        }

        private void dataGridComboBoxSelectRecruitModels_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.populateDGV == false)
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
            var selectedRecruit = modelCbx.SelectedItem;
            if (selectedRecruit != null) 
            {
                Type typeSelectedRecruit = selectedRecruit.GetType();
                if (typeSelectedRecruit.IsGenericType)
                {
                    Type baseTypeSelectedRecruit = typeSelectedRecruit.GetGenericTypeDefinition();
                    if (baseTypeSelectedRecruit == typeof(KeyValuePair<,>))
                    {
                        Type[] argTypes = baseTypeSelectedRecruit.GetGenericArguments();

                        kvpKey = typeSelectedRecruit.GetProperty("Key").GetValue(selectedRecruit, null);
                        this.recruitModelSelection[currentModel] = Convert.ToInt32(kvpKey);

                        int selectedModelNum = Convert.ToInt32(kvpKey);
                        if (this.collectionAgeproRecruitmentModels[currentModel] != null)
                        {
                            this.collectionAgeproRecruitmentModels[currentModel] = 
                                AgeproRecruitment.GetNewRecruitModel(selectedModelNum);
                                
                        }
                            
                    }
                }    
            }
            
        }
        //end OnSelectingRecruitingModel

        public bool ValidateRecruitmentData()
        {
            if (this.dataGridComboBoxSelectRecruitModels.HasBlankOrNullCells() == false )
            {
                
                return false;
            }


            return true;
        }


        /// <summary>
        /// 
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
                for (int i = 0; i < (dgvTable.Rows.Count); i++)
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
        /// 
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

        

    }
}
