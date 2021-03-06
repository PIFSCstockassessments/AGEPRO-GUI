﻿namespace Nmfs.Agepro.Gui
{
    partial class ControlRecruitmentPredictor
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
            this.groupPredictorParameters = new System.Windows.Forms.GroupBox();
            this.textBoxIntercept = new System.Windows.Forms.TextBox();
            this.textBoxVariance = new System.Windows.Forms.TextBox();
            this.labelIntercept = new System.Windows.Forms.Label();
            this.labelVariance = new System.Windows.Forms.Label();
            this.buttonSetParameters = new System.Windows.Forms.Button();
            this.spinBoxNumRecruitPredictors = new System.Windows.Forms.NumericUpDown();
            this.labelNumRecruitPredictors = new System.Windows.Forms.Label();
            this.labelCoefficients = new System.Windows.Forms.Label();
            this.labelObservations = new System.Windows.Forms.Label();
            this.dataGridCoefficients = new Nmfs.Agepro.Gui.NftDataGridView();
            this.dataGridObservations = new Nmfs.Agepro.Gui.NftDataGridView();
            this.groupPredictorParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumRecruitPredictors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoefficients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridObservations)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPredictorParameters
            // 
            this.groupPredictorParameters.Controls.Add(this.textBoxIntercept);
            this.groupPredictorParameters.Controls.Add(this.textBoxVariance);
            this.groupPredictorParameters.Controls.Add(this.labelIntercept);
            this.groupPredictorParameters.Controls.Add(this.labelVariance);
            this.groupPredictorParameters.Controls.Add(this.buttonSetParameters);
            this.groupPredictorParameters.Controls.Add(this.spinBoxNumRecruitPredictors);
            this.groupPredictorParameters.Controls.Add(this.labelNumRecruitPredictors);
            this.groupPredictorParameters.Location = new System.Drawing.Point(0, 0);
            this.groupPredictorParameters.Name = "groupPredictorParameters";
            this.groupPredictorParameters.Size = new System.Drawing.Size(574, 94);
            this.groupPredictorParameters.TabIndex = 1;
            this.groupPredictorParameters.TabStop = false;
            // 
            // textBoxIntercept
            // 
            this.textBoxIntercept.Location = new System.Drawing.Point(225, 66);
            this.textBoxIntercept.Name = "textBoxIntercept";
            this.textBoxIntercept.Size = new System.Drawing.Size(120, 20);
            this.textBoxIntercept.TabIndex = 6;
            // 
            // textBoxVariance
            // 
            this.textBoxVariance.Location = new System.Drawing.Point(225, 40);
            this.textBoxVariance.Name = "textBoxVariance";
            this.textBoxVariance.Size = new System.Drawing.Size(120, 20);
            this.textBoxVariance.TabIndex = 5;
            // 
            // labelIntercept
            // 
            this.labelIntercept.AutoSize = true;
            this.labelIntercept.Location = new System.Drawing.Point(18, 69);
            this.labelIntercept.Name = "labelIntercept";
            this.labelIntercept.Size = new System.Drawing.Size(49, 13);
            this.labelIntercept.TabIndex = 4;
            this.labelIntercept.Text = "Intercept";
            // 
            // labelVariance
            // 
            this.labelVariance.AutoSize = true;
            this.labelVariance.Location = new System.Drawing.Point(18, 43);
            this.labelVariance.Name = "labelVariance";
            this.labelVariance.Size = new System.Drawing.Size(49, 13);
            this.labelVariance.TabIndex = 3;
            this.labelVariance.Text = "Variance";
            // 
            // buttonSetParameters
            // 
            this.buttonSetParameters.Location = new System.Drawing.Point(478, 51);
            this.buttonSetParameters.Name = "buttonSetParameters";
            this.buttonSetParameters.Size = new System.Drawing.Size(75, 23);
            this.buttonSetParameters.TabIndex = 2;
            this.buttonSetParameters.Text = "SET";
            this.buttonSetParameters.UseVisualStyleBackColor = true;
            this.buttonSetParameters.Click += new System.EventHandler(this.ButtonSetParameters_Click);
            // 
            // spinBoxNumRecruitPredictors
            // 
            this.spinBoxNumRecruitPredictors.Location = new System.Drawing.Point(225, 14);
            this.spinBoxNumRecruitPredictors.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.spinBoxNumRecruitPredictors.Name = "spinBoxNumRecruitPredictors";
            this.spinBoxNumRecruitPredictors.Size = new System.Drawing.Size(120, 20);
            this.spinBoxNumRecruitPredictors.TabIndex = 1;
            // 
            // labelNumRecruitPredictors
            // 
            this.labelNumRecruitPredictors.AutoSize = true;
            this.labelNumRecruitPredictors.Location = new System.Drawing.Point(18, 16);
            this.labelNumRecruitPredictors.Name = "labelNumRecruitPredictors";
            this.labelNumRecruitPredictors.Size = new System.Drawing.Size(168, 13);
            this.labelNumRecruitPredictors.TabIndex = 0;
            this.labelNumRecruitPredictors.Text = "Number Of Recruitment Predictors";
            // 
            // labelCoefficients
            // 
            this.labelCoefficients.AutoSize = true;
            this.labelCoefficients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoefficients.Location = new System.Drawing.Point(-3, 105);
            this.labelCoefficients.Name = "labelCoefficients";
            this.labelCoefficients.Size = new System.Drawing.Size(62, 13);
            this.labelCoefficients.TabIndex = 2;
            this.labelCoefficients.Text = "Coefficients";
            // 
            // labelObservations
            // 
            this.labelObservations.AutoSize = true;
            this.labelObservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObservations.Location = new System.Drawing.Point(276, 105);
            this.labelObservations.Name = "labelObservations";
            this.labelObservations.Size = new System.Drawing.Size(69, 13);
            this.labelObservations.TabIndex = 3;
            this.labelObservations.Text = "Observations";
            // 
            // dataGridCoefficients
            // 
            this.dataGridCoefficients.AllowUserToAddRows = false;
            this.dataGridCoefficients.AllowUserToDeleteRows = false;
            this.dataGridCoefficients.AllowUserToResizeRows = false;
            this.dataGridCoefficients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridCoefficients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridCoefficients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCoefficients.Location = new System.Drawing.Point(0, 121);
            this.dataGridCoefficients.Name = "dataGridCoefficients";
            this.dataGridCoefficients.nftReadOnly = false;
            this.dataGridCoefficients.RowHeadersWidth = 70;
            this.dataGridCoefficients.Size = new System.Drawing.Size(251, 219);
            this.dataGridCoefficients.TabIndex = 4;
            this.dataGridCoefficients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridCoefficients_CellFormatting);
            // 
            // dataGridObservations
            // 
            this.dataGridObservations.AllowUserToAddRows = false;
            this.dataGridObservations.AllowUserToDeleteRows = false;
            this.dataGridObservations.AllowUserToResizeRows = false;
            this.dataGridObservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridObservations.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridObservations.Location = new System.Drawing.Point(279, 121);
            this.dataGridObservations.Name = "dataGridObservations";
            this.dataGridObservations.nftReadOnly = false;
            this.dataGridObservations.RowHeadersWidth = 70;
            this.dataGridObservations.Size = new System.Drawing.Size(565, 219);
            this.dataGridObservations.TabIndex = 5;
            this.dataGridObservations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridObservations_CellFormatting);
            // 
            // ControlRecruitmentPredictor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridObservations);
            this.Controls.Add(this.dataGridCoefficients);
            this.Controls.Add(this.labelObservations);
            this.Controls.Add(this.labelCoefficients);
            this.Controls.Add(this.groupPredictorParameters);
            this.MinimumSize = new System.Drawing.Size(870, 355);
            this.Name = "ControlRecruitmentPredictor";
            this.Size = new System.Drawing.Size(870, 355);
            this.groupPredictorParameters.ResumeLayout(false);
            this.groupPredictorParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumRecruitPredictors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCoefficients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridObservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPredictorParameters;
        private System.Windows.Forms.TextBox textBoxIntercept;
        private System.Windows.Forms.TextBox textBoxVariance;
        private System.Windows.Forms.Label labelIntercept;
        private System.Windows.Forms.Label labelVariance;
        private System.Windows.Forms.Button buttonSetParameters;
        private System.Windows.Forms.NumericUpDown spinBoxNumRecruitPredictors;
        private System.Windows.Forms.Label labelNumRecruitPredictors;
        private System.Windows.Forms.Label labelCoefficients;
        private System.Windows.Forms.Label labelObservations;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridCoefficients;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridObservations;
    }
}
