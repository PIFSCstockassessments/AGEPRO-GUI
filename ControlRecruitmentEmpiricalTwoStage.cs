using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitmentEmpiricalTwoStage : AGEPRO.GUI.ControlRecruitmentEmpirical
    {
        public ControlRecruitmentEmpiricalTwoStage()
        {
            InitializeComponent();

            //Programmically Add Controls
            this.labelLv1NumObservations = new System.Windows.Forms.Label();
            this.spinBoxLv1NumObservations = new System.Windows.Forms.NumericUpDown();
            this.labelLv2NumObservations = new System.Windows.Forms.Label();
            this.spinBoxLv2NumObservations = new System.Windows.Forms.NumericUpDown();
            this.labelSSBBreakValue = new System.Windows.Forms.Label();
            this.textBoxSSBBreakValue = new System.Windows.Forms.TextBox();
            this.groupEmpiricalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv1NumObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv2NumObservations)).BeginInit();
            this.SuspendLayout();

            this.labelNumObservations.Visible = false;
            this.spinBoxNumObservations.Visible = false;
            // 
            // labelLv1NumObservations
            // 
            this.labelLv1NumObservations.AutoSize = true;
            this.labelLv1NumObservations.Location = new System.Drawing.Point(18, 16);
            this.labelLv1NumObservations.Name = "labelLv1NumObservations";
            this.labelLv1NumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelLv1NumObservations.TabIndex = 0;
            this.labelLv1NumObservations.Text = "Level 1 Number Of Observations";
            // 
            // spinBoxLv1NumObservations
            // 
            this.spinBoxLv1NumObservations.Location = new System.Drawing.Point(225, 14);
            this.spinBoxLv1NumObservations.Name = "spinBoxLv1NumObservations";
            this.spinBoxLv1NumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxLv1NumObservations.TabIndex = 1;
            // 
            // labelLv2NumObservations
            // 
            this.labelLv2NumObservations.AutoSize = true;
            this.labelLv2NumObservations.Location = new System.Drawing.Point(18, 43);
            this.labelLv2NumObservations.Name = "labelLv2NumObservations";
            this.labelLv2NumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelLv2NumObservations.TabIndex = 2;
            this.labelLv2NumObservations.Text = "Level 2 Number Of Observations";
            // 
            // spinBoxLv2NumObservations
            // 
            this.spinBoxLv2NumObservations.Location = new System.Drawing.Point(225, 40);
            this.spinBoxLv2NumObservations.Name = "spinBoxLv1NumObservations";
            this.spinBoxLv2NumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxLv2NumObservations.TabIndex = 3;
            // 
            // labelSSBBreakValue
            // 
            this.labelSSBBreakValue.AutoSize = true;
            this.labelSSBBreakValue.Location = new System.Drawing.Point(18, 69);
            this.labelSSBBreakValue.Name = "labelSSBBreakValue";
            this.labelSSBBreakValue.Size = new System.Drawing.Size(89, 13);
            this.labelSSBBreakValue.TabIndex = 5;
            this.labelSSBBreakValue.Text = "SSB Break Value (MT)";
            // 
            // textBoxSSBBreakValue
            // 
            this.textBoxSSBBreakValue.Location = new System.Drawing.Point(225, 66);
            this.textBoxSSBBreakValue.Name = "textBoxSSBBreakValue";
            this.textBoxSSBBreakValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxSSBBreakValue.TabIndex = 6;
            


            this.ResumeLayout(false);
            this.PerformLayout();
            
        }

        private System.Windows.Forms.Label labelLv1NumObservations;
        private System.Windows.Forms.NumericUpDown spinBoxLv1NumObservations;
        private System.Windows.Forms.Label labelLv2NumObservations;
        private System.Windows.Forms.NumericUpDown spinBoxLv2NumObservations;
        private System.Windows.Forms.Label labelSSBBreakValue;
        private System.Windows.Forms.TextBox textBoxSSBBreakValue;
        private System.Windows.Forms.Label labelLv2Observations;
        private System.Windows.Forms.DataGridView dataGridLv1Observations;
        private System.Windows.Forms.DataGridView dataGridLv2Observations;

        private void buttonSetParameters_Click(object sender, EventArgs e)
        {

        }
    }
}
