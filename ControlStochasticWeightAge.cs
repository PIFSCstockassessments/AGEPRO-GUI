using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
    public enum StochasticWeightOfAge
    {
        Jan1Weight,
        SSBWeight,
        MidYearWeight,
        CatchWeight,
        DiscardWeight
    }

    public partial class ControlStochasticWeightAge : Nmfs.Agepro.Gui.ControlStochasticAge
    {
        private System.Windows.Forms.RadioButton radioWeightsFromCatch;
        private System.Windows.Forms.RadioButton radioWeightsFromMidYear;
        private System.Windows.Forms.RadioButton radioWeightsFromSSB;
        private System.Windows.Forms.RadioButton radioWeightsFromJan1;

        public int indexWeightOption { get; set; }
        public Dictionary<int, RadioButton> weightOptionDictionary;
        public StochasticWeightOfAge weightAgeType { get; set; }

        public ControlStochasticWeightAge()
        {
            InitializeComponent();

            this.stochasticParameterLabel = "Weights";

            //Add Controls to Layout Programmically 
            this.SuspendLayout();
            tableLayoutStochasticAgePanel.RowStyles[1].SizeType = SizeType.Percent;
            tableLayoutStochasticAgePanel.RowStyles[1].Height = 19;
            tableLayoutStochasticAgePanel.RowStyles[2].SizeType = SizeType.Percent;
            tableLayoutStochasticAgePanel.RowStyles[2].Height = 81;

            this.radioWeightsFromJan1 = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromSSB = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromMidYear = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromCatch = new System.Windows.Forms.RadioButton();
            
            groupOptions.Size = new Size(733, 89);

            // 
            // radioWeightsFromJan1
            // 
            this.radioWeightsFromJan1.AutoSize = true;
            this.radioWeightsFromJan1.Location = new System.Drawing.Point(25, 44);
            this.radioWeightsFromJan1.Name = "radioWeightsFromJan1";
            this.radioWeightsFromJan1.Size = new System.Drawing.Size(154, 17);
            this.radioWeightsFromJan1.TabIndex = 2;
            this.radioWeightsFromJan1.TabStop = true;
            this.radioWeightsFromJan1.Text = "Use JAN-1 Weights At Age";
            this.radioWeightsFromJan1.UseVisualStyleBackColor = true;
            this.radioWeightsFromJan1.CheckedChanged += new System.EventHandler(this.radioWeightsFromJan1_CheckedChanged);
            // 
            // radioWeightsFromSSB
            // 
            this.radioWeightsFromSSB.AutoSize = true;
            this.radioWeightsFromSSB.Location = new System.Drawing.Point(301, 44);
            this.radioWeightsFromSSB.Name = "radioWeightsFromSSB";
            this.radioWeightsFromSSB.Size = new System.Drawing.Size(146, 17);
            this.radioWeightsFromSSB.TabIndex = 3;
            this.radioWeightsFromSSB.TabStop = true;
            this.radioWeightsFromSSB.Text = "Use SSB Weights At Age";
            this.radioWeightsFromSSB.UseVisualStyleBackColor = true;
            this.radioWeightsFromSSB.CheckedChanged += new System.EventHandler(this.radioWeightsFromSSB_CheckedChanged);
            // 
            // radioWeightsFromMidYear
            // 
            this.radioWeightsFromMidYear.AutoSize = true;
            this.radioWeightsFromMidYear.Location = new System.Drawing.Point(25, 68);
            this.radioWeightsFromMidYear.Name = "radioWeightsFromMidYear";
            this.radioWeightsFromMidYear.Size = new System.Drawing.Size(166, 17);
            this.radioWeightsFromMidYear.TabIndex = 4;
            this.radioWeightsFromMidYear.TabStop = true;
            this.radioWeightsFromMidYear.Text = "Use Mid-Year Weights At Age";
            this.radioWeightsFromMidYear.UseVisualStyleBackColor = true;
            this.radioWeightsFromMidYear.CheckedChanged += new System.EventHandler(this.radioWeightsFromMidYear_CheckedChanged);
            // 
            // radioWeightsFromCatch
            // 
            this.radioWeightsFromCatch.AutoSize = true;
            this.radioWeightsFromCatch.Location = new System.Drawing.Point(301, 68);
            this.radioWeightsFromCatch.Name = "radioWeightsFromCatch";
            this.radioWeightsFromCatch.Size = new System.Drawing.Size(152, 17);
            this.radioWeightsFromCatch.TabIndex = 5;
            this.radioWeightsFromCatch.TabStop = true;
            this.radioWeightsFromCatch.Text = "Use Catch Weights At Age";
            this.radioWeightsFromCatch.UseVisualStyleBackColor = true;
            this.radioWeightsFromCatch.CheckedChanged += new System.EventHandler(this.radioWeightsFromCatch_CheckedChanged);
            

            //Add to optionsGroupBox
            this.groupOptions.Controls.Add(this.radioWeightsFromJan1);
            this.groupOptions.Controls.Add(this.radioWeightsFromSSB);
            this.groupOptions.Controls.Add(this.radioWeightsFromMidYear);
            this.groupOptions.Controls.Add(this.radioWeightsFromCatch);

            this.ResumeLayout();

            SetWeightOptionDictionary();


        }

        public bool showJan1WeightsOption
        {
            get { return radioWeightsFromJan1.Visible; }
            set { radioWeightsFromJan1.Visible = value; }
        }
        public bool showSSBWeightsOption
        {
            get { return radioWeightsFromSSB.Visible; }
            set { radioWeightsFromSSB.Visible = value; }
        }
        public bool showMidYearWeightsOption
        {
            get { return radioWeightsFromMidYear.Visible; }
            set { radioWeightsFromMidYear.Visible = value; }
        }
        public bool showCatchWeightsOption
        {
            get { return radioWeightsFromCatch.Visible; }
            set { radioWeightsFromCatch.Visible = value; }
        }
        
        protected override void OnLoad(EventArgs e)
        {
            if (weightOptionDictionary.ContainsKey(indexWeightOption))
            {
                weightOptionDictionary[indexWeightOption].Checked = true;
            }

            base.OnLoad(e);
        }

        private void radioWeightsFromJan1_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
        }

        private void radioWeightsFromSSB_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
        }

        private void radioWeightsFromMidYear_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
        }

        private void radioWeightsFromCatch_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
        }

        /// <summary>
        /// Creates the Stochastic Weights of Option Dictionary Object.
        /// </summary>
        private void SetWeightOptionDictionary()
        {
            weightOptionDictionary = new Dictionary<int, RadioButton>();

            weightOptionDictionary.Add(0, this.radioParameterFromUser);
            weightOptionDictionary.Add(1, this.radioParameterFromFile);
            weightOptionDictionary.Add(-1, this.radioWeightsFromJan1);
            weightOptionDictionary.Add(-2, this.radioWeightsFromSSB);
            weightOptionDictionary.Add(-3, this.radioWeightsFromMidYear);
            weightOptionDictionary.Add(-4, this.radioWeightsFromCatch);

        }

 
        /// <summary>
        /// Generalized method to load Stochastic Weight of Age Parameters from AGEPRO Input Data Files.
        /// </summary>
        /// <param name="ctl">AGEPRO Stochastic Weight of Age User Control and Values</param>
        /// <param name="inp">AGEPRO InputFile Weight of Age Onject</param>
        /// <param name="generalOpt">AGEPRO InputFile General Options</param>
        /// <param name="fallbackNullDataTable">Option to generate a empty DataTable if Input File does not 
        /// provide one</param>
        public void LoadWeightAgeInputData(Nmfs.Agepro.CoreLib.AgeproWeightAgeTable inp,
            Nmfs.Agepro.CoreLib.AgeproGeneral generalOpt, bool fallbackNullDataTable = false)
        {
            this.indexWeightOption = inp.weightOpt;
            base.LoadStochasticAgeInputData(inp, generalOpt);

 

            //Create a empty DataTable if there input file DataTable (for 
            //weightAgeTable CVtable is Null)
            //if fallbackNullDataTable is true
            if (this.stochasticAgeTable == null)
            {
                int numYears;
                if (this.timeVarying == true)
                {
                    numYears = generalOpt.NumYears();
                }
                else
                {
                    numYears = 1;
                }
                    
                this.stochasticAgeTable = CreateFallbackAgeDataTable(generalOpt.NumAges(), numYears, generalOpt.numFleets);
                this.enableTimeVaryingCheckBox = true;
            }
            if (!(this.stochasticCV != null))
            {
                this.stochasticCV = CreateFallbackAgeDataTable(generalOpt.NumAges(), 1, generalOpt.numFleets);
            }
            
        }




        public override bool ValidateStochasticParameter(int numAges, double upperBounds)
        {
            if (weightOptionDictionary.ContainsKey(indexWeightOption))
            {
                if (this.indexWeightOption == 0 || this.indexWeightOption == 1)
                {
                    return base.ValidateStochasticParameter(numAges, upperBounds);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Invalid weight of at Age option.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        
        
    }
}
