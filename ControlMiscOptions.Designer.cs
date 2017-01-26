﻿namespace Nmfs.Agepro.Gui
{
    partial class ControlMiscOptions
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
            this.groupOuputOptions = new System.Windows.Forms.GroupBox();
            this.spinBoxReportPercentile = new System.Windows.Forms.NumericUpDown();
            this.labelReportPercentile = new System.Windows.Forms.Label();
            this.checkBoxPercentileReport = new System.Windows.Forms.CheckBox();
            this.checkBoxExportR = new System.Windows.Forms.CheckBox();
            this.checkBoxAuxStochasticFiles = new System.Windows.Forms.CheckBox();
            this.checkBoxSummayReport = new System.Windows.Forms.CheckBox();
            this.groupRefpoints = new System.Windows.Forms.GroupBox();
            this.textBoxRefFishMortality = new System.Windows.Forms.TextBox();
            this.labelFishMortality = new System.Windows.Forms.Label();
            this.textBoxRefMeanBiomass = new System.Windows.Forms.TextBox();
            this.checkBoxRefpoints = new System.Windows.Forms.CheckBox();
            this.labelMeanBiomass = new System.Windows.Forms.Label();
            this.textBoxRefJan1Biomass = new System.Windows.Forms.TextBox();
            this.labelJan1Biomass = new System.Windows.Forms.Label();
            this.textBoxRefSpawnBiomass = new System.Windows.Forms.TextBox();
            this.labelSpawnBiomass = new System.Windows.Forms.Label();
            this.groupBounds = new System.Windows.Forms.GroupBox();
            this.textBoxBoundsNatMortality = new System.Windows.Forms.TextBox();
            this.labelBoundsNatMortality = new System.Windows.Forms.Label();
            this.textBoxBoundsMaxWeight = new System.Windows.Forms.TextBox();
            this.labelBoundsMaxWeight = new System.Windows.Forms.Label();
            this.checkBoxBounds = new System.Windows.Forms.CheckBox();
            this.groupScaleFactors = new System.Windows.Forms.GroupBox();
            this.textBoxScaleFactorRecruits = new System.Windows.Forms.TextBox();
            this.labelScaleFactorRecruits = new System.Windows.Forms.Label();
            this.textBoxScaleFactorsStockNum = new System.Windows.Forms.TextBox();
            this.labelScaleFactorStockNum = new System.Windows.Forms.Label();
            this.textBoxScaleFactorBiomass = new System.Windows.Forms.TextBox();
            this.labelScaleFactorBiomass = new System.Windows.Forms.Label();
            this.checkBoxScaleFactors = new System.Windows.Forms.CheckBox();
            this.groupRetroAdjustment = new System.Windows.Forms.GroupBox();
            this.checkBoxRetroAdjustment = new System.Windows.Forms.CheckBox();
            this.dataGridRetroAdjustment = new Nmfs.Agepro.Gui.NftDataGridView();
            this.groupOutputViewer = new System.Windows.Forms.GroupBox();
            this.labelOutputViewerProgram = new System.Windows.Forms.Label();
            this.comboBoxOutputViewerProgram = new System.Windows.Forms.ComboBox();
            this.groupOuputOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxReportPercentile)).BeginInit();
            this.groupRefpoints.SuspendLayout();
            this.groupBounds.SuspendLayout();
            this.groupScaleFactors.SuspendLayout();
            this.groupRetroAdjustment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRetroAdjustment)).BeginInit();
            this.groupOutputViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOuputOptions
            // 
            this.groupOuputOptions.Controls.Add(this.spinBoxReportPercentile);
            this.groupOuputOptions.Controls.Add(this.labelReportPercentile);
            this.groupOuputOptions.Controls.Add(this.checkBoxPercentileReport);
            this.groupOuputOptions.Controls.Add(this.checkBoxExportR);
            this.groupOuputOptions.Controls.Add(this.checkBoxAuxStochasticFiles);
            this.groupOuputOptions.Controls.Add(this.checkBoxSummayReport);
            this.groupOuputOptions.Location = new System.Drawing.Point(29, 15);
            this.groupOuputOptions.Name = "groupOuputOptions";
            this.groupOuputOptions.Size = new System.Drawing.Size(353, 143);
            this.groupOuputOptions.TabIndex = 0;
            this.groupOuputOptions.TabStop = false;
            this.groupOuputOptions.Text = "Output Options";
            // 
            // spinBoxReportPercentile
            // 
            this.spinBoxReportPercentile.DecimalPlaces = 1;
            this.spinBoxReportPercentile.Enabled = false;
            this.spinBoxReportPercentile.Location = new System.Drawing.Point(165, 114);
            this.spinBoxReportPercentile.Name = "spinBoxReportPercentile";
            this.spinBoxReportPercentile.Size = new System.Drawing.Size(107, 20);
            this.spinBoxReportPercentile.TabIndex = 5;
            // 
            // labelReportPercentile
            // 
            this.labelReportPercentile.AutoSize = true;
            this.labelReportPercentile.Enabled = false;
            this.labelReportPercentile.Location = new System.Drawing.Point(70, 116);
            this.labelReportPercentile.Name = "labelReportPercentile";
            this.labelReportPercentile.Size = new System.Drawing.Size(89, 13);
            this.labelReportPercentile.TabIndex = 4;
            this.labelReportPercentile.Text = "Report Percentile";
            // 
            // checkBoxPercentileReport
            // 
            this.checkBoxPercentileReport.AutoSize = true;
            this.checkBoxPercentileReport.Location = new System.Drawing.Point(23, 92);
            this.checkBoxPercentileReport.Name = "checkBoxPercentileReport";
            this.checkBoxPercentileReport.Size = new System.Drawing.Size(151, 17);
            this.checkBoxPercentileReport.TabIndex = 3;
            this.checkBoxPercentileReport.Text = "Request Percentile Report";
            this.checkBoxPercentileReport.UseVisualStyleBackColor = true;
            this.checkBoxPercentileReport.CheckedChanged += new System.EventHandler(this.checkBoxPercentileReport_CheckedChanged);
            // 
            // checkBoxExportR
            // 
            this.checkBoxExportR.AutoSize = true;
            this.checkBoxExportR.Location = new System.Drawing.Point(23, 69);
            this.checkBoxExportR.Name = "checkBoxExportR";
            this.checkBoxExportR.Size = new System.Drawing.Size(117, 17);
            this.checkBoxExportR.TabIndex = 2;
            this.checkBoxExportR.Text = "Export Results to R";
            this.checkBoxExportR.UseVisualStyleBackColor = true;
            // 
            // checkBoxAuxStochasticFiles
            // 
            this.checkBoxAuxStochasticFiles.AutoSize = true;
            this.checkBoxAuxStochasticFiles.Location = new System.Drawing.Point(23, 46);
            this.checkBoxAuxStochasticFiles.Name = "checkBoxAuxStochasticFiles";
            this.checkBoxAuxStochasticFiles.Size = new System.Drawing.Size(214, 17);
            this.checkBoxAuxStochasticFiles.TabIndex = 1;
            this.checkBoxAuxStochasticFiles.Text = "Generate Auxiliary Stochastic Data Files";
            this.checkBoxAuxStochasticFiles.UseVisualStyleBackColor = true;
            // 
            // checkBoxSummayReport
            // 
            this.checkBoxSummayReport.AutoSize = true;
            this.checkBoxSummayReport.Location = new System.Drawing.Point(23, 23);
            this.checkBoxSummayReport.Name = "checkBoxSummayReport";
            this.checkBoxSummayReport.Size = new System.Drawing.Size(262, 17);
            this.checkBoxSummayReport.TabIndex = 0;
            this.checkBoxSummayReport.Text = "Output Summary Report of Stock Numbers At Age";
            this.checkBoxSummayReport.UseVisualStyleBackColor = true;
            // 
            // groupRefpoints
            // 
            this.groupRefpoints.Controls.Add(this.textBoxRefFishMortality);
            this.groupRefpoints.Controls.Add(this.labelFishMortality);
            this.groupRefpoints.Controls.Add(this.textBoxRefMeanBiomass);
            this.groupRefpoints.Controls.Add(this.checkBoxRefpoints);
            this.groupRefpoints.Controls.Add(this.labelMeanBiomass);
            this.groupRefpoints.Controls.Add(this.textBoxRefJan1Biomass);
            this.groupRefpoints.Controls.Add(this.labelJan1Biomass);
            this.groupRefpoints.Controls.Add(this.textBoxRefSpawnBiomass);
            this.groupRefpoints.Controls.Add(this.labelSpawnBiomass);
            this.groupRefpoints.Location = new System.Drawing.Point(29, 164);
            this.groupRefpoints.Name = "groupRefpoints";
            this.groupRefpoints.Size = new System.Drawing.Size(353, 152);
            this.groupRefpoints.TabIndex = 1;
            this.groupRefpoints.TabStop = false;
            this.groupRefpoints.Text = "Reference Points";
            // 
            // textBoxRefFishMortality
            // 
            this.textBoxRefFishMortality.Enabled = false;
            this.textBoxRefFishMortality.Location = new System.Drawing.Point(189, 120);
            this.textBoxRefFishMortality.Name = "textBoxFishMortality";
            this.textBoxRefFishMortality.Size = new System.Drawing.Size(117, 20);
            this.textBoxRefFishMortality.TabIndex = 8;
            // 
            // labelFishMortality
            // 
            this.labelFishMortality.AutoSize = true;
            this.labelFishMortality.Enabled = false;
            this.labelFishMortality.Location = new System.Drawing.Point(19, 123);
            this.labelFishMortality.Name = "labelFishMortality";
            this.labelFishMortality.Size = new System.Drawing.Size(82, 13);
            this.labelFishMortality.TabIndex = 7;
            this.labelFishMortality.Text = "Fishing Mortality";
            // 
            // textBoxRefMeanBiomass
            // 
            this.textBoxRefMeanBiomass.Enabled = false;
            this.textBoxRefMeanBiomass.Location = new System.Drawing.Point(189, 94);
            this.textBoxRefMeanBiomass.Name = "textBoxMeanBiomass";
            this.textBoxRefMeanBiomass.Size = new System.Drawing.Size(117, 20);
            this.textBoxRefMeanBiomass.TabIndex = 6;
            // 
            // checkBoxRefpoints
            // 
            this.checkBoxRefpoints.AutoSize = true;
            this.checkBoxRefpoints.Location = new System.Drawing.Point(22, 19);
            this.checkBoxRefpoints.Name = "checkBoxRefpoints";
            this.checkBoxRefpoints.Size = new System.Drawing.Size(223, 17);
            this.checkBoxRefpoints.TabIndex = 0;
            this.checkBoxRefpoints.Text = "Output Reference Point Threshold Report";
            this.checkBoxRefpoints.UseVisualStyleBackColor = true;
            this.checkBoxRefpoints.CheckedChanged += new System.EventHandler(this.checkBoxRefpoints_CheckedChanged);
            // 
            // labelMeanBiomass
            // 
            this.labelMeanBiomass.AutoSize = true;
            this.labelMeanBiomass.Enabled = false;
            this.labelMeanBiomass.Location = new System.Drawing.Point(19, 97);
            this.labelMeanBiomass.Name = "labelMeanBiomass";
            this.labelMeanBiomass.Size = new System.Drawing.Size(101, 13);
            this.labelMeanBiomass.TabIndex = 5;
            this.labelMeanBiomass.Text = "Mean Biomass (MT)";
            // 
            // textBoxRefJan1Biomass
            // 
            this.textBoxRefJan1Biomass.Enabled = false;
            this.textBoxRefJan1Biomass.Location = new System.Drawing.Point(189, 68);
            this.textBoxRefJan1Biomass.Name = "textBoxJan1Biomass";
            this.textBoxRefJan1Biomass.Size = new System.Drawing.Size(117, 20);
            this.textBoxRefJan1Biomass.TabIndex = 4;
            // 
            // labelJan1Biomass
            // 
            this.labelJan1Biomass.AutoSize = true;
            this.labelJan1Biomass.Enabled = false;
            this.labelJan1Biomass.Location = new System.Drawing.Point(19, 71);
            this.labelJan1Biomass.Name = "labelJan1Biomass";
            this.labelJan1Biomass.Size = new System.Drawing.Size(131, 13);
            this.labelJan1Biomass.TabIndex = 3;
            this.labelJan1Biomass.Text = "Jan-1 Stock Biomass (MT)";
            // 
            // textBoxRefSpawnBiomass
            // 
            this.textBoxRefSpawnBiomass.Enabled = false;
            this.textBoxRefSpawnBiomass.Location = new System.Drawing.Point(189, 42);
            this.textBoxRefSpawnBiomass.Name = "textBoxSpawnBiomass";
            this.textBoxRefSpawnBiomass.Size = new System.Drawing.Size(117, 20);
            this.textBoxRefSpawnBiomass.TabIndex = 2;
            // 
            // labelSpawnBiomass
            // 
            this.labelSpawnBiomass.AutoSize = true;
            this.labelSpawnBiomass.Enabled = false;
            this.labelSpawnBiomass.Location = new System.Drawing.Point(19, 45);
            this.labelSpawnBiomass.Name = "labelSpawnBiomass";
            this.labelSpawnBiomass.Size = new System.Drawing.Size(152, 13);
            this.labelSpawnBiomass.TabIndex = 1;
            this.labelSpawnBiomass.Text = "Spawning Stock Biomass (MT)";
            // 
            // groupBounds
            // 
            this.groupBounds.Controls.Add(this.textBoxBoundsNatMortality);
            this.groupBounds.Controls.Add(this.labelBoundsNatMortality);
            this.groupBounds.Controls.Add(this.textBoxBoundsMaxWeight);
            this.groupBounds.Controls.Add(this.labelBoundsMaxWeight);
            this.groupBounds.Controls.Add(this.checkBoxBounds);
            this.groupBounds.Location = new System.Drawing.Point(402, 15);
            this.groupBounds.Name = "groupBounds";
            this.groupBounds.Size = new System.Drawing.Size(353, 99);
            this.groupBounds.TabIndex = 3;
            this.groupBounds.TabStop = false;
            this.groupBounds.Text = "Bounds";
            // 
            // textBoxBoundsNatMortality
            // 
            this.textBoxBoundsNatMortality.Enabled = false;
            this.textBoxBoundsNatMortality.Location = new System.Drawing.Point(158, 68);
            this.textBoxBoundsNatMortality.Name = "textBoxBoundsNatMortality";
            this.textBoxBoundsNatMortality.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoundsNatMortality.TabIndex = 4;
            this.textBoxBoundsNatMortality.Text = "1.0";
            // 
            // labelBoundsNatMortality
            // 
            this.labelBoundsNatMortality.AutoSize = true;
            this.labelBoundsNatMortality.Enabled = false;
            this.labelBoundsNatMortality.Location = new System.Drawing.Point(15, 71);
            this.labelBoundsNatMortality.Name = "labelBoundsNatMortality";
            this.labelBoundsNatMortality.Size = new System.Drawing.Size(130, 13);
            this.labelBoundsNatMortality.TabIndex = 3;
            this.labelBoundsNatMortality.Text = "Maximum Natural Mortality";
            // 
            // textBoxBoundsMaxWeight
            // 
            this.textBoxBoundsMaxWeight.Enabled = false;
            this.textBoxBoundsMaxWeight.Location = new System.Drawing.Point(158, 42);
            this.textBoxBoundsMaxWeight.Name = "textBoxBoundsMaxWeight";
            this.textBoxBoundsMaxWeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxBoundsMaxWeight.TabIndex = 2;
            this.textBoxBoundsMaxWeight.Text = "10.0";
            // 
            // labelBoundsMaxWeight
            // 
            this.labelBoundsMaxWeight.AutoSize = true;
            this.labelBoundsMaxWeight.Enabled = false;
            this.labelBoundsMaxWeight.Location = new System.Drawing.Point(15, 45);
            this.labelBoundsMaxWeight.Name = "labelBoundsMaxWeight";
            this.labelBoundsMaxWeight.Size = new System.Drawing.Size(109, 13);
            this.labelBoundsMaxWeight.TabIndex = 1;
            this.labelBoundsMaxWeight.Text = "Maximum Weight (kg)";
            // 
            // checkBoxBounds
            // 
            this.checkBoxBounds.AutoSize = true;
            this.checkBoxBounds.Location = new System.Drawing.Point(18, 19);
            this.checkBoxBounds.Name = "checkBoxBounds";
            this.checkBoxBounds.Size = new System.Drawing.Size(100, 17);
            this.checkBoxBounds.TabIndex = 0;
            this.checkBoxBounds.Text = "Specify Bounds";
            this.checkBoxBounds.UseVisualStyleBackColor = true;
            this.checkBoxBounds.CheckedChanged += new System.EventHandler(this.checkBoxBounds_CheckedChanged);
            // 
            // groupScaleFactors
            // 
            this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorRecruits);
            this.groupScaleFactors.Controls.Add(this.labelScaleFactorRecruits);
            this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorsStockNum);
            this.groupScaleFactors.Controls.Add(this.labelScaleFactorStockNum);
            this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorBiomass);
            this.groupScaleFactors.Controls.Add(this.labelScaleFactorBiomass);
            this.groupScaleFactors.Controls.Add(this.checkBoxScaleFactors);
            this.groupScaleFactors.Location = new System.Drawing.Point(29, 322);
            this.groupScaleFactors.Name = "groupScaleFactors";
            this.groupScaleFactors.Size = new System.Drawing.Size(353, 136);
            this.groupScaleFactors.TabIndex = 2;
            this.groupScaleFactors.TabStop = false;
            this.groupScaleFactors.Text = "Scale Factors for Output Report";
            // 
            // textBoxScaleFactorRecruits
            // 
            this.textBoxScaleFactorRecruits.Enabled = false;
            this.textBoxScaleFactorRecruits.Location = new System.Drawing.Point(144, 74);
            this.textBoxScaleFactorRecruits.Name = "textBoxScaleFactorRecruits";
            this.textBoxScaleFactorRecruits.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleFactorRecruits.TabIndex = 4;
            // 
            // labelScaleFactorRecruits
            // 
            this.labelScaleFactorRecruits.AutoSize = true;
            this.labelScaleFactorRecruits.Enabled = false;
            this.labelScaleFactorRecruits.Location = new System.Drawing.Point(20, 77);
            this.labelScaleFactorRecruits.Name = "labelScaleFactorRecruits";
            this.labelScaleFactorRecruits.Size = new System.Drawing.Size(46, 13);
            this.labelScaleFactorRecruits.TabIndex = 3;
            this.labelScaleFactorRecruits.Text = "Recruits";
            // 
            // textBoxScaleFactorsStockNum
            // 
            this.textBoxScaleFactorsStockNum.Enabled = false;
            this.textBoxScaleFactorsStockNum.Location = new System.Drawing.Point(144, 100);
            this.textBoxScaleFactorsStockNum.Name = "textBoxScaleFactorsStockNum";
            this.textBoxScaleFactorsStockNum.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleFactorsStockNum.TabIndex = 6;
            // 
            // labelScaleFactorStockNum
            // 
            this.labelScaleFactorStockNum.AutoSize = true;
            this.labelScaleFactorStockNum.Enabled = false;
            this.labelScaleFactorStockNum.Location = new System.Drawing.Point(19, 103);
            this.labelScaleFactorStockNum.Name = "labelScaleFactorStockNum";
            this.labelScaleFactorStockNum.Size = new System.Drawing.Size(80, 13);
            this.labelScaleFactorStockNum.TabIndex = 5;
            this.labelScaleFactorStockNum.Text = "Stock Numbers";
            // 
            // textBoxScaleFactorBiomass
            // 
            this.textBoxScaleFactorBiomass.Enabled = false;
            this.textBoxScaleFactorBiomass.Location = new System.Drawing.Point(144, 48);
            this.textBoxScaleFactorBiomass.Name = "textBoxScaleFactorBiomass";
            this.textBoxScaleFactorBiomass.Size = new System.Drawing.Size(100, 20);
            this.textBoxScaleFactorBiomass.TabIndex = 2;
            // 
            // labelScaleFactorBiomass
            // 
            this.labelScaleFactorBiomass.AutoSize = true;
            this.labelScaleFactorBiomass.Enabled = false;
            this.labelScaleFactorBiomass.Location = new System.Drawing.Point(20, 51);
            this.labelScaleFactorBiomass.Name = "labelScaleFactorBiomass";
            this.labelScaleFactorBiomass.Size = new System.Drawing.Size(46, 13);
            this.labelScaleFactorBiomass.TabIndex = 1;
            this.labelScaleFactorBiomass.Text = "Biomass";
            // 
            // checkBoxScaleFactors
            // 
            this.checkBoxScaleFactors.AutoSize = true;
            this.checkBoxScaleFactors.Location = new System.Drawing.Point(22, 20);
            this.checkBoxScaleFactors.Name = "checkBoxScaleFactors";
            this.checkBoxScaleFactors.Size = new System.Drawing.Size(214, 17);
            this.checkBoxScaleFactors.TabIndex = 0;
            this.checkBoxScaleFactors.Text = "Specify Scale Factors for Output Report";
            this.checkBoxScaleFactors.UseVisualStyleBackColor = true;
            this.checkBoxScaleFactors.CheckedChanged += new System.EventHandler(this.checkBoxScaleFactors_CheckedChanged);
            // 
            // groupRetroAdjustment
            // 
            this.groupRetroAdjustment.Controls.Add(this.checkBoxRetroAdjustment);
            this.groupRetroAdjustment.Controls.Add(this.dataGridRetroAdjustment);
            this.groupRetroAdjustment.Location = new System.Drawing.Point(403, 120);
            this.groupRetroAdjustment.Name = "groupRetroAdjustment";
            this.groupRetroAdjustment.Size = new System.Drawing.Size(352, 266);
            this.groupRetroAdjustment.TabIndex = 4;
            this.groupRetroAdjustment.TabStop = false;
            this.groupRetroAdjustment.Text = "Retrospective Adjustment Factors";
            // 
            // checkBoxRetroAdjustment
            // 
            this.checkBoxRetroAdjustment.AutoSize = true;
            this.checkBoxRetroAdjustment.Location = new System.Drawing.Point(17, 20);
            this.checkBoxRetroAdjustment.Name = "checkBoxRetroAdjustment";
            this.checkBoxRetroAdjustment.Size = new System.Drawing.Size(223, 17);
            this.checkBoxRetroAdjustment.TabIndex = 1;
            this.checkBoxRetroAdjustment.Text = "Specify Retrospective Adjustment Factors";
            this.checkBoxRetroAdjustment.UseVisualStyleBackColor = true;
            this.checkBoxRetroAdjustment.CheckedChanged += new System.EventHandler(this.checkBoxRetroAdjustment_CheckedChanged);
            // 
            // dataGridRetroAdjustment
            // 
            this.dataGridRetroAdjustment.AllowUserToAddRows = false;
            this.dataGridRetroAdjustment.AllowUserToDeleteRows = false;
            this.dataGridRetroAdjustment.AllowUserToResizeRows = false;
            this.dataGridRetroAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRetroAdjustment.ColumnHeadersVisible = false;
            this.dataGridRetroAdjustment.Location = new System.Drawing.Point(17, 40);
            this.dataGridRetroAdjustment.Name = "dataGridRetroAdjustment";
            this.dataGridRetroAdjustment.RowHeadersWidth = 75;
            this.dataGridRetroAdjustment.Size = new System.Drawing.Size(329, 220);
            this.dataGridRetroAdjustment.TabIndex = 0;
            this.dataGridRetroAdjustment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridRetroAdjustment_CellFormatting);
            // 
            // groupOutputViewer
            // 
            this.groupOutputViewer.Controls.Add(this.comboBoxOutputViewerProgram);
            this.groupOutputViewer.Controls.Add(this.labelOutputViewerProgram);
            this.groupOutputViewer.Location = new System.Drawing.Point(403, 392);
            this.groupOutputViewer.Name = "groupOutputViewer";
            this.groupOutputViewer.Size = new System.Drawing.Size(352, 75);
            this.groupOutputViewer.TabIndex = 5;
            this.groupOutputViewer.TabStop = false;
            this.groupOutputViewer.Text = "Output File Viewer";
            // 
            // labelOutputViewerProgram
            // 
            this.labelOutputViewerProgram.AutoSize = true;
            this.labelOutputViewerProgram.Location = new System.Drawing.Point(14, 23);
            this.labelOutputViewerProgram.Name = "labelOutputViewerProgram";
            this.labelOutputViewerProgram.Size = new System.Drawing.Size(189, 13);
            this.labelOutputViewerProgram.TabIndex = 0;
            this.labelOutputViewerProgram.Text = "Program to View AGEPRO Output File ";
            // 
            // comboBoxOutputViewerProgram
            // 
            this.comboBoxOutputViewerProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutputViewerProgram.Items.AddRange(new object[] {
            "System Default",
            "Notepad",
            "None"});
            this.comboBoxOutputViewerProgram.Location = new System.Drawing.Point(17, 39);
            this.comboBoxOutputViewerProgram.Name = "comboBoxOutputViewerProgram";
            this.comboBoxOutputViewerProgram.Size = new System.Drawing.Size(318, 21);
            this.comboBoxOutputViewerProgram.TabIndex = 1;
            // 
            // ControlMiscOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupOutputViewer);
            this.Controls.Add(this.groupRetroAdjustment);
            this.Controls.Add(this.groupScaleFactors);
            this.Controls.Add(this.groupBounds);
            this.Controls.Add(this.groupRefpoints);
            this.Controls.Add(this.groupOuputOptions);
            this.Name = "ControlMiscOptions";
            this.Size = new System.Drawing.Size(900, 520);
            this.groupOuputOptions.ResumeLayout(false);
            this.groupOuputOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxReportPercentile)).EndInit();
            this.groupRefpoints.ResumeLayout(false);
            this.groupRefpoints.PerformLayout();
            this.groupBounds.ResumeLayout(false);
            this.groupBounds.PerformLayout();
            this.groupScaleFactors.ResumeLayout(false);
            this.groupScaleFactors.PerformLayout();
            this.groupRetroAdjustment.ResumeLayout(false);
            this.groupRetroAdjustment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRetroAdjustment)).EndInit();
            this.groupOutputViewer.ResumeLayout(false);
            this.groupOutputViewer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOuputOptions;
        private System.Windows.Forms.Label labelReportPercentile;
        private System.Windows.Forms.CheckBox checkBoxPercentileReport;
        private System.Windows.Forms.CheckBox checkBoxExportR;
        private System.Windows.Forms.CheckBox checkBoxAuxStochasticFiles;
        private System.Windows.Forms.CheckBox checkBoxSummayReport;
        private System.Windows.Forms.GroupBox groupRefpoints;
        private System.Windows.Forms.TextBox textBoxRefFishMortality;
        private System.Windows.Forms.Label labelFishMortality;
        private System.Windows.Forms.TextBox textBoxRefMeanBiomass;
        private System.Windows.Forms.CheckBox checkBoxRefpoints;
        private System.Windows.Forms.Label labelMeanBiomass;
        private System.Windows.Forms.TextBox textBoxRefJan1Biomass;
        private System.Windows.Forms.Label labelJan1Biomass;
        private System.Windows.Forms.TextBox textBoxRefSpawnBiomass;
        private System.Windows.Forms.Label labelSpawnBiomass;
        private System.Windows.Forms.GroupBox groupBounds;
        private System.Windows.Forms.TextBox textBoxBoundsNatMortality;
        private System.Windows.Forms.Label labelBoundsNatMortality;
        private System.Windows.Forms.TextBox textBoxBoundsMaxWeight;
        private System.Windows.Forms.Label labelBoundsMaxWeight;
        private System.Windows.Forms.CheckBox checkBoxBounds;
        private System.Windows.Forms.GroupBox groupScaleFactors;
        private System.Windows.Forms.TextBox textBoxScaleFactorRecruits;
        private System.Windows.Forms.Label labelScaleFactorRecruits;
        private System.Windows.Forms.TextBox textBoxScaleFactorsStockNum;
        private System.Windows.Forms.Label labelScaleFactorStockNum;
        private System.Windows.Forms.TextBox textBoxScaleFactorBiomass;
        private System.Windows.Forms.Label labelScaleFactorBiomass;
        private System.Windows.Forms.CheckBox checkBoxScaleFactors;
        private System.Windows.Forms.GroupBox groupRetroAdjustment;
        private System.Windows.Forms.CheckBox checkBoxRetroAdjustment;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridRetroAdjustment;
        private System.Windows.Forms.NumericUpDown spinBoxReportPercentile;
        private System.Windows.Forms.GroupBox groupOutputViewer;
        private System.Windows.Forms.ComboBox comboBoxOutputViewerProgram;
        private System.Windows.Forms.Label labelOutputViewerProgram;
    }
}
