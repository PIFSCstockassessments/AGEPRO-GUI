namespace AGEPRO.GUI
{
    partial class ControlHarvestCalcPStar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPStarParameters = new System.Windows.Forms.GroupBox();
            this.textBoxPStarTargetYear = new System.Windows.Forms.TextBox();
            this.textBoxOverfishingF = new System.Windows.Forms.TextBox();
            this.spinBoxNumPStarLevels = new System.Windows.Forms.NumericUpDown();
            this.dataGridPStarLevelValues = new System.Windows.Forms.DataGridView();
            this.labelPStarTargetYear = new System.Windows.Forms.Label();
            this.labelOverfishingF = new System.Windows.Forms.Label();
            this.labelNumPStarLevels = new System.Windows.Forms.Label();
            this.groupPStarParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumPStarLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPStarLevelValues)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPStarParameters
            // 
            this.groupPStarParameters.Controls.Add(this.textBoxPStarTargetYear);
            this.groupPStarParameters.Controls.Add(this.textBoxOverfishingF);
            this.groupPStarParameters.Controls.Add(this.spinBoxNumPStarLevels);
            this.groupPStarParameters.Controls.Add(this.dataGridPStarLevelValues);
            this.groupPStarParameters.Controls.Add(this.labelPStarTargetYear);
            this.groupPStarParameters.Controls.Add(this.labelOverfishingF);
            this.groupPStarParameters.Controls.Add(this.labelNumPStarLevels);
            this.groupPStarParameters.Location = new System.Drawing.Point(0, 3);
            this.groupPStarParameters.Name = "groupPStarParameters";
            this.groupPStarParameters.Size = new System.Drawing.Size(480, 282);
            this.groupPStarParameters.TabIndex = 0;
            this.groupPStarParameters.TabStop = false;
            this.groupPStarParameters.Text = "P-Star Specification";
            // 
            // textBoxPStarTargetYear
            // 
            this.textBoxPStarTargetYear.Location = new System.Drawing.Point(186, 113);
            this.textBoxPStarTargetYear.Name = "textBoxPStarTargetYear";
            this.textBoxPStarTargetYear.Size = new System.Drawing.Size(127, 20);
            this.textBoxPStarTargetYear.TabIndex = 6;
            // 
            // textBoxOverfishingF
            // 
            this.textBoxOverfishingF.Location = new System.Drawing.Point(186, 78);
            this.textBoxOverfishingF.Name = "textBoxOverfishingF";
            this.textBoxOverfishingF.Size = new System.Drawing.Size(127, 20);
            this.textBoxOverfishingF.TabIndex = 5;
            // 
            // spinBoxNumPStarLevels
            // 
            this.spinBoxNumPStarLevels.Location = new System.Drawing.Point(186, 43);
            this.spinBoxNumPStarLevels.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinBoxNumPStarLevels.Name = "spinBoxNumPStarLevels";
            this.spinBoxNumPStarLevels.Size = new System.Drawing.Size(72, 20);
            this.spinBoxNumPStarLevels.TabIndex = 4;
            // 
            // dataGridPStarLevelValues
            // 
            this.dataGridPStarLevelValues.AllowUserToAddRows = false;
            this.dataGridPStarLevelValues.AllowUserToDeleteRows = false;
            this.dataGridPStarLevelValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPStarLevelValues.Location = new System.Drawing.Point(6, 161);
            this.dataGridPStarLevelValues.Name = "dataGridPStarLevelValues";
            this.dataGridPStarLevelValues.RowHeadersVisible = false;
            this.dataGridPStarLevelValues.Size = new System.Drawing.Size(468, 92);
            this.dataGridPStarLevelValues.TabIndex = 3;
            // 
            // labelPStarTargetYear
            // 
            this.labelPStarTargetYear.AutoSize = true;
            this.labelPStarTargetYear.Location = new System.Drawing.Point(39, 116);
            this.labelPStarTargetYear.Name = "labelPStarTargetYear";
            this.labelPStarTargetYear.Size = new System.Drawing.Size(95, 13);
            this.labelPStarTargetYear.TabIndex = 2;
            this.labelPStarTargetYear.Text = "P-Star Target Year";
            // 
            // labelOverfishingF
            // 
            this.labelOverfishingF.AutoSize = true;
            this.labelOverfishingF.Location = new System.Drawing.Point(39, 81);
            this.labelOverfishingF.Name = "labelOverfishingF";
            this.labelOverfishingF.Size = new System.Drawing.Size(69, 13);
            this.labelOverfishingF.TabIndex = 1;
            this.labelOverfishingF.Text = "Overfishing F";
            // 
            // labelNumPStarLevels
            // 
            this.labelNumPStarLevels.AutoSize = true;
            this.labelNumPStarLevels.Location = new System.Drawing.Point(39, 45);
            this.labelNumPStarLevels.Name = "labelNumPStarLevels";
            this.labelNumPStarLevels.Size = new System.Drawing.Size(122, 13);
            this.labelNumPStarLevels.TabIndex = 0;
            this.labelNumPStarLevels.Text = "Number of P-Star Levels";
            // 
            // ControlHarvestCalcPStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPStarParameters);
            this.MinimumSize = new System.Drawing.Size(480, 400);
            this.Name = "ControlHarvestCalcPStar";
            this.Size = new System.Drawing.Size(480, 400);
            this.groupPStarParameters.ResumeLayout(false);
            this.groupPStarParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumPStarLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPStarLevelValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPStarParameters;
        private System.Windows.Forms.DataGridView dataGridPStarLevelValues;
        private System.Windows.Forms.Label labelPStarTargetYear;
        private System.Windows.Forms.Label labelOverfishingF;
        private System.Windows.Forms.Label labelNumPStarLevels;
        private System.Windows.Forms.TextBox textBoxPStarTargetYear;
        private System.Windows.Forms.TextBox textBoxOverfishingF;
        private System.Windows.Forms.NumericUpDown spinBoxNumPStarLevels;
    }
}
