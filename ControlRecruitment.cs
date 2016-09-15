﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitment : UserControl
    {
        public int numRecruitModels { get; set; }
        public int[] recruitModelSelection { get; set; }
        public string[] seqRecruitYears { get; set; }
        public List<AGEPRO.CoreLib.RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }

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
            dataGridSelectRecruitModels.Columns.Add(columnRecruitModelSelection);
            dataGridSelectRecruitModels.RowHeadersWidth = 100;

            //Recruitment Prob
            dataGridRecruitProb.RowHeadersWidth = 100;

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
            SetDataGridSelectRecruitModels(numRecruitModels);

            labelRecruitSelection.Text = getSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);

            if (collectionAgeproRecruitmentModels.Count == 0)
            {
                //if AgeproRecruitmentModel Colletction list is empty, intialize it
                List<RecruitmentModel> userSpecRecruitList = new List<RecruitmentModel>();
                for (int i = 0; i < numRecruitModels; i++)
                {
                    userSpecRecruitList.Add(new GeneralizedRecruitment());
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
        public void SetDataGridSelectRecruitModels(int numRecruitModels)
        {
            if (dataGridSelectRecruitModels != null)
            {
                //Clear Out rows from Previous Run/Load/Call
                dataGridSelectRecruitModels.Rows.Clear(); 
            }

            for (int i = 0; i < numRecruitModels; i++)
            {
                this.dataGridSelectRecruitModels.Rows.Add(); //Add Empty Row w/ ComboBoxColumn
            }

            int irecruit = 0;
            foreach (DataGridViewRow recruitSelection in this.dataGridSelectRecruitModels.Rows)
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

        private void dataGridSelectRecruitModels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridSelectRecruitModels.Rows[e.RowIndex].HeaderCell;
            
            if (!(header.Value != null))
            {
                
                for (int i = 0; i < dataGridSelectRecruitModels.Rows.Count; i++)
                {
                    dataGridSelectRecruitModels.Rows[i].HeaderCell.Value = "Selection " + (i + 1);
                }
                
            }
        }

        private void comboBoxRecruitSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox modelSelectionCbx = sender as ComboBox;

            labelRecruitSelection.Text = getSelectedRecruitmentModelName(modelSelectionCbx.SelectedIndex);

            RecruitmentModel currentRecruitSelection = this.collectionAgeproRecruitmentModels[modelSelectionCbx.SelectedIndex];

            if (currentRecruitSelection is EmpiricalRecruitment)
            {
                if (((EmpiricalRecruitment)currentRecruitSelection).subType == EmpiricalType.Empirical)
                {
                    //Load control in panelRecruitModelParameter
                    ControlRecruitmentEmpirical empiricalParameterControls = new ControlRecruitmentEmpirical();
                    panelRecruitModelParameter.Controls.Clear();
                    empiricalParameterControls.Dock = DockStyle.Fill;
                    panelRecruitModelParameter.Controls.Add(empiricalParameterControls);
                }
            }
            else if (currentRecruitSelection is PredictorRecruitment)
            {
                ControlRecruitmentPredictor predictorParameterControls = new ControlRecruitmentPredictor();
                panelRecruitModelParameter.Controls.Clear();
                predictorParameterControls.Dock = DockStyle.Fill;
                panelRecruitModelParameter.Controls.Add(predictorParameterControls);
            }
            
            

        }
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
                return "...";
            }
          
        }



        private void tabControlRecruitment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When switching to the "Recruit Model" Tab, set up selected model name for labelRecruitSelection
            if ((sender as TabControl).SelectedIndex == 1)
            {
                labelRecruitSelection.Text = getSelectedRecruitmentModelName(comboBoxRecruitSelection.SelectedIndex);

                //Load the appropriate 
                AGEPRO.CoreLib.RecruitmentModel selectedRecruitModel = collectionAgeproRecruitmentModels[comboBoxRecruitSelection.SelectedIndex]; 
            }
         }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        private void dataGridSelectRecruitModels_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridSelectRecruitModels.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridSelectRecruitModels.CommitEdit(DataGridViewDataErrorContexts.Commit); 
            }
        }

        private void dataGridSelectRecruitModels_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.populateDGV == false)
            {
                DataGridViewComboBoxCell cbxCell = (DataGridViewComboBoxCell)dataGridSelectRecruitModels.Rows[e.RowIndex].Cells[0];
                //Should only bind to events to Recruitment Model Column
                if (e.ColumnIndex == 0) 
                {
                    if (cbxCell != null)
                    {
                        var currentModel = dataGridSelectRecruitModels.CurrentCell.RowIndex;
                        var senderDGV = sender as DataGridView;
                        var senderCbx = senderDGV.EditingControl as DataGridViewComboBoxEditingControl;
                        OnSelectingRecruitModel(currentModel, senderCbx);

                        dataGridSelectRecruitModels.Invalidate();
                    }
                } 
            }
            
        }

        private void OnSelectingRecruitModel(int currentModel, DataGridViewComboBoxEditingControl modelCbx)
        {
            try
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
                            
                            Console.WriteLine("Debug1");
                        }
                    }    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("AGEPRO Recruitment selection can not be made." + Environment.NewLine + ex.Message,
                    "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }//end OnSelectingRecruitingModel

        

    }
}
