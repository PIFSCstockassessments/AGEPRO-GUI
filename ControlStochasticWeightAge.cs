using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public partial class ControlStochasticWeightAge : AGEPRO.GUI.ControlStochasticAge
    {
        private System.Windows.Forms.RadioButton radioWeightsFromCatch;
        private System.Windows.Forms.RadioButton radioWeightsFromMidYear;
        private System.Windows.Forms.RadioButton radioWeightsFromSSB;
        private System.Windows.Forms.RadioButton radioWeightsFromJan1;

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
        
        }

        private void radioWeightsFromJan1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromSSB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromMidYear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromCatch_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
