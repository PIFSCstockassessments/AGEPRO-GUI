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
            
            dataGridSelectRecruitModels.Rows.Add();
            //Recruitment Prob

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
        

        protected override void OnLoad(EventArgs e)
        {
            int irecruit = 0;
            foreach(DataGridViewRow recruitSelection in dataGridSelectRecruitModels.Rows)
            {
                ((DataGridViewComboBoxCell)recruitSelection.Cells[0]).Value = recruitModelSelection[irecruit];
                irecruit++;
            }
            //(DataGridViewComboBoxColumn)dataGridSelectRecruitModels.Columns[0];
            base.OnLoad(e);
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

    }
}
