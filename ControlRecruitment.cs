using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitment : UserControl
    {
        public int numRecruitModels { get; set; }
        public int[] recruitModelSelection { get; set; }
        public string[] seqRecruitYears { get; set; }
        private DataGridViewComboBoxColumn columnRecruitModelSelection;

        public ControlRecruitment()
        {
            InitializeComponent();

            columnRecruitModelSelection = new DataGridViewComboBoxColumn();
            columnRecruitModelSelection.DataPropertyName = "columnRecruitModelSelect";
            columnRecruitModelSelection.HeaderText = "Recruitment Model";
            columnRecruitModelSelection.Width = 500;

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
            SetRecruitSelectionDataGridView(numRecruitModels);
            base.OnLoad(e);
        }

        public void SetRecruitSelectionDataGridView(int numRecruitModels)
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
            recruitModelDictionary.Add(2, "Model 2: Emperical Recruits per Spawning Biomass Distribution");
            recruitModelDictionary.Add(3, "Model 3: Emperical Recruitment Distributiion");
            recruitModelDictionary.Add(4, "Model 4: Two-Stage Emperical Recruits per Spawning Biomass Distribution");
            recruitModelDictionary.Add(5, "Model 5: Beverton-Holt Curve w/ Lognormal Error");
            recruitModelDictionary.Add(6, "Model 6: Ricker Curve w/ Lognormal Error");
            recruitModelDictionary.Add(7, "Model 7: Shepherd Curve w/ Lognormal Error");
            recruitModelDictionary.Add(8, "Model 8: Lognormal Distribution");
            //Model 9 was removed in AGEPRO 4.0
            recruitModelDictionary.Add(10, "Model 10: Beverton-Holt Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(11, "Model 11: Ricker Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(12, "Model 12: Shepherd Curve w/ Autocorrected Lognormal Error");
            recruitModelDictionary.Add(13, "Model 13: Autocorrected Lognormal Distribution");
            recruitModelDictionary.Add(14, "Model 14: Emperical Cumulative Distribution Function of Recruitment");
            recruitModelDictionary.Add(15, "Model 15: Two-Stage Emperical Cumulative Distribution Function of Recruitment");
            recruitModelDictionary.Add(16, "Model 16: Linear Recruits per Spawning Biomass Predictor w/ Normal Error");
            recruitModelDictionary.Add(17, "Model 17: Loglinear Recruits per Spawning Biomass Predictor w/ Lognormal Error");
            recruitModelDictionary.Add(18, "Model 18: Linear Recruitment Predictor w/ Normal Error");
            recruitModelDictionary.Add(19, "Model 19: Loglinear Recruitment Predictor w/ Lognormal Error");
            recruitModelDictionary.Add(20, "Model 20: Fixed Recruitment");
            recruitModelDictionary.Add(21, "Model 21: Emperical Cumulative Distribution Function of Recruitment w/ Linear Decline to Zero");

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

        private void dataGridSelectRecruitModels_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox selectedModel = e.Control as ComboBox;
                selectedModel.SelectionChangeCommitted += OnSelectingRecruitModelComboBox;
            }
        }

        private void OnSelectingRecruitModelComboBox(object sender, EventArgs e)
        {
            var currentModel = dataGridSelectRecruitModels.CurrentCell.RowIndex;
            var senderCbx = sender as DataGridViewComboBoxEditingControl;
            
            if(senderCbx.SelectedIndex >= 0)
            {
                object kvpKey;
                var selectedRecruit = senderCbx.SelectedItem;
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
                        }
                    }    
                }
            }
            
        }


    }
}
