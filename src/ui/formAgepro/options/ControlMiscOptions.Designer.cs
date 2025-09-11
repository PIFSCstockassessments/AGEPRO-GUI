namespace Nmfs.Agepro.Gui
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
      this.checkBoxEnablePercentileReport = new System.Windows.Forms.CheckBox();
      this.checkBoxEnableExportR = new System.Windows.Forms.CheckBox();
      this.checkBoxEnableAuxStochasticFiles = new System.Windows.Forms.CheckBox();
      this.groupRefpoints = new System.Windows.Forms.GroupBox();
      this.labelFishMortality = new System.Windows.Forms.Label();
      this.checkBoxEnableRefpoints = new System.Windows.Forms.CheckBox();
      this.labelMeanBiomass = new System.Windows.Forms.Label();
      this.labelJan1Biomass = new System.Windows.Forms.Label();
      this.labelSpawnBiomass = new System.Windows.Forms.Label();
      this.groupBounds = new System.Windows.Forms.GroupBox();
      this.labelBoundsNatMortality = new System.Windows.Forms.Label();
      this.labelBoundsMaxWeight = new System.Windows.Forms.Label();
      this.checkBoxBounds = new System.Windows.Forms.CheckBox();
      this.groupScaleFactors = new System.Windows.Forms.GroupBox();
      this.labelScaleFactorRecruits = new System.Windows.Forms.Label();
      this.labelScaleFactorStockNum = new System.Windows.Forms.Label();
      this.labelScaleFactorBiomass = new System.Windows.Forms.Label();
      this.checkBoxEnableScaleFactors = new System.Windows.Forms.CheckBox();
      this.groupRetroAdjustment = new System.Windows.Forms.GroupBox();
      this.checkBoxEnableRetroAdjustment = new System.Windows.Forms.CheckBox();
      this.comboBoxOutputViewerProgram = new System.Windows.Forms.ComboBox();
      this.labelOutputViewerProgram = new System.Windows.Forms.Label();
      this.groupBox_StockSummmaryFlag = new System.Windows.Forms.GroupBox();
      this.radioButtonStockAge_ExcludeStockNumAux = new System.Windows.Forms.RadioButton();
      this.radioButtonStockAge_NoAux = new System.Windows.Forms.RadioButton();
      this.radioButtonNoStockAge_NoAux = new System.Windows.Forms.RadioButton();
      this.radioButtonStockAge_AllAux = new System.Windows.Forms.RadioButton();
      this.radioButtonNoStockAge_ExcludeStockNumAux = new System.Windows.Forms.RadioButton();
      this.groupOutputViewer = new System.Windows.Forms.GroupBox();
      this.checkBoxEnableVer40Format = new System.Windows.Forms.CheckBox();
      this.textBoxMiscOptionsInpfileVerString = new Nmfs.Agepro.Gui.NftTextBox();
      this.dataGridRetroAdjustment = new Nmfs.Agepro.Gui.NftDataGridView();
      this.textBoxScaleFactorRecruits = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxScaleFactorsStockNum = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxScaleFactorBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxBoundsNatMortality = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxBoundsMaxWeight = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxRefFishMortality = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxRefMeanBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxRefJan1Biomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.textBoxRefSpawnBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.groupOuputOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spinBoxReportPercentile)).BeginInit();
      this.groupRefpoints.SuspendLayout();
      this.groupBounds.SuspendLayout();
      this.groupScaleFactors.SuspendLayout();
      this.groupRetroAdjustment.SuspendLayout();
      this.groupBox_StockSummmaryFlag.SuspendLayout();
      this.groupOutputViewer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridRetroAdjustment)).BeginInit();
      this.SuspendLayout();
      // 
      // groupOuputOptions
      // 
      this.groupOuputOptions.Controls.Add(this.spinBoxReportPercentile);
      this.groupOuputOptions.Controls.Add(this.labelReportPercentile);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnablePercentileReport);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnableExportR);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnableAuxStochasticFiles);
      this.groupOuputOptions.Location = new System.Drawing.Point(29, 154);
      this.groupOuputOptions.Name = "groupOuputOptions";
      this.groupOuputOptions.Size = new System.Drawing.Size(406, 123);
      this.groupOuputOptions.TabIndex = 1;
      this.groupOuputOptions.TabStop = false;
      this.groupOuputOptions.Text = "Output Options";
      // 
      // spinBoxReportPercentile
      // 
      this.spinBoxReportPercentile.DecimalPlaces = 1;
      this.spinBoxReportPercentile.Enabled = false;
      this.spinBoxReportPercentile.Location = new System.Drawing.Point(159, 88);
      this.spinBoxReportPercentile.Name = "spinBoxReportPercentile";
      this.spinBoxReportPercentile.Size = new System.Drawing.Size(107, 20);
      this.spinBoxReportPercentile.TabIndex = 5;
      // 
      // labelReportPercentile
      // 
      this.labelReportPercentile.AutoSize = true;
      this.labelReportPercentile.Enabled = false;
      this.labelReportPercentile.Location = new System.Drawing.Point(64, 90);
      this.labelReportPercentile.Name = "labelReportPercentile";
      this.labelReportPercentile.Size = new System.Drawing.Size(89, 13);
      this.labelReportPercentile.TabIndex = 4;
      this.labelReportPercentile.Text = "Report Percentile";
      // 
      // checkBoxEnablePercentileReport
      // 
      this.checkBoxEnablePercentileReport.AutoSize = true;
      this.checkBoxEnablePercentileReport.Location = new System.Drawing.Point(17, 66);
      this.checkBoxEnablePercentileReport.Name = "checkBoxEnablePercentileReport";
      this.checkBoxEnablePercentileReport.Size = new System.Drawing.Size(151, 17);
      this.checkBoxEnablePercentileReport.TabIndex = 3;
      this.checkBoxEnablePercentileReport.Text = "Request Percentile Report";
      this.checkBoxEnablePercentileReport.UseVisualStyleBackColor = true;
      this.checkBoxEnablePercentileReport.CheckedChanged += new System.EventHandler(this.CheckBoxPercentileReport_CheckedChanged);
      // 
      // checkBoxEnableExportR
      // 
      this.checkBoxEnableExportR.AutoSize = true;
      this.checkBoxEnableExportR.Location = new System.Drawing.Point(17, 43);
      this.checkBoxEnableExportR.Name = "checkBoxEnableExportR";
      this.checkBoxEnableExportR.Size = new System.Drawing.Size(117, 17);
      this.checkBoxEnableExportR.TabIndex = 2;
      this.checkBoxEnableExportR.Text = "Export Results to R";
      this.checkBoxEnableExportR.UseVisualStyleBackColor = true;
      // 
      // checkBoxEnableAuxStochasticFiles
      // 
      this.checkBoxEnableAuxStochasticFiles.AutoSize = true;
      this.checkBoxEnableAuxStochasticFiles.Location = new System.Drawing.Point(17, 20);
      this.checkBoxEnableAuxStochasticFiles.Name = "checkBoxEnableAuxStochasticFiles";
      this.checkBoxEnableAuxStochasticFiles.Size = new System.Drawing.Size(214, 17);
      this.checkBoxEnableAuxStochasticFiles.TabIndex = 4;
      this.checkBoxEnableAuxStochasticFiles.Text = "Generate Auxiliary Stochastic Data Files";
      this.checkBoxEnableAuxStochasticFiles.UseVisualStyleBackColor = true;
      // 
      // groupRefpoints
      // 
      this.groupRefpoints.Controls.Add(this.textBoxRefFishMortality);
      this.groupRefpoints.Controls.Add(this.labelFishMortality);
      this.groupRefpoints.Controls.Add(this.textBoxRefMeanBiomass);
      this.groupRefpoints.Controls.Add(this.checkBoxEnableRefpoints);
      this.groupRefpoints.Controls.Add(this.labelMeanBiomass);
      this.groupRefpoints.Controls.Add(this.textBoxRefJan1Biomass);
      this.groupRefpoints.Controls.Add(this.labelJan1Biomass);
      this.groupRefpoints.Controls.Add(this.textBoxRefSpawnBiomass);
      this.groupRefpoints.Controls.Add(this.labelSpawnBiomass);
      this.groupRefpoints.Location = new System.Drawing.Point(441, 219);
      this.groupRefpoints.Name = "groupRefpoints";
      this.groupRefpoints.Size = new System.Drawing.Size(390, 152);
      this.groupRefpoints.TabIndex = 5;
      this.groupRefpoints.TabStop = false;
      this.groupRefpoints.Text = "Reference Points";
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
      // checkBoxEnableRefpoints
      // 
      this.checkBoxEnableRefpoints.AutoSize = true;
      this.checkBoxEnableRefpoints.Location = new System.Drawing.Point(22, 19);
      this.checkBoxEnableRefpoints.Name = "checkBoxEnableRefpoints";
      this.checkBoxEnableRefpoints.Size = new System.Drawing.Size(224, 17);
      this.checkBoxEnableRefpoints.TabIndex = 0;
      this.checkBoxEnableRefpoints.Text = "Enable Reference Point Threshold Report";
      this.checkBoxEnableRefpoints.UseVisualStyleBackColor = true;
      this.checkBoxEnableRefpoints.CheckedChanged += new System.EventHandler(this.CheckBoxRefpoints_CheckedChanged);
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
      this.groupBounds.Location = new System.Drawing.Point(441, 114);
      this.groupBounds.Name = "groupBounds";
      this.groupBounds.Size = new System.Drawing.Size(390, 99);
      this.groupBounds.TabIndex = 4;
      this.groupBounds.TabStop = false;
      this.groupBounds.Text = "Bounds";
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
      this.checkBoxBounds.CheckedChanged += new System.EventHandler(this.CheckBoxBounds_CheckedChanged);
      // 
      // groupScaleFactors
      // 
      this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorRecruits);
      this.groupScaleFactors.Controls.Add(this.labelScaleFactorRecruits);
      this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorsStockNum);
      this.groupScaleFactors.Controls.Add(this.labelScaleFactorStockNum);
      this.groupScaleFactors.Controls.Add(this.textBoxScaleFactorBiomass);
      this.groupScaleFactors.Controls.Add(this.labelScaleFactorBiomass);
      this.groupScaleFactors.Controls.Add(this.checkBoxEnableScaleFactors);
      this.groupScaleFactors.Location = new System.Drawing.Point(441, 377);
      this.groupScaleFactors.Name = "groupScaleFactors";
      this.groupScaleFactors.Size = new System.Drawing.Size(390, 128);
      this.groupScaleFactors.TabIndex = 6;
      this.groupScaleFactors.TabStop = false;
      this.groupScaleFactors.Text = "Scaling Factors for Output Report";
      // 
      // labelScaleFactorRecruits
      // 
      this.labelScaleFactorRecruits.AutoSize = true;
      this.labelScaleFactorRecruits.Enabled = false;
      this.labelScaleFactorRecruits.Location = new System.Drawing.Point(22, 72);
      this.labelScaleFactorRecruits.Name = "labelScaleFactorRecruits";
      this.labelScaleFactorRecruits.Size = new System.Drawing.Size(46, 13);
      this.labelScaleFactorRecruits.TabIndex = 3;
      this.labelScaleFactorRecruits.Text = "Recruits";
      // 
      // labelScaleFactorStockNum
      // 
      this.labelScaleFactorStockNum.AutoSize = true;
      this.labelScaleFactorStockNum.Enabled = false;
      this.labelScaleFactorStockNum.Location = new System.Drawing.Point(21, 98);
      this.labelScaleFactorStockNum.Name = "labelScaleFactorStockNum";
      this.labelScaleFactorStockNum.Size = new System.Drawing.Size(80, 13);
      this.labelScaleFactorStockNum.TabIndex = 5;
      this.labelScaleFactorStockNum.Text = "Stock Numbers";
      // 
      // labelScaleFactorBiomass
      // 
      this.labelScaleFactorBiomass.AutoSize = true;
      this.labelScaleFactorBiomass.Enabled = false;
      this.labelScaleFactorBiomass.Location = new System.Drawing.Point(22, 46);
      this.labelScaleFactorBiomass.Name = "labelScaleFactorBiomass";
      this.labelScaleFactorBiomass.Size = new System.Drawing.Size(46, 13);
      this.labelScaleFactorBiomass.TabIndex = 1;
      this.labelScaleFactorBiomass.Text = "Biomass";
      // 
      // checkBoxEnableScaleFactors
      // 
      this.checkBoxEnableScaleFactors.AutoSize = true;
      this.checkBoxEnableScaleFactors.Location = new System.Drawing.Point(22, 20);
      this.checkBoxEnableScaleFactors.Name = "checkBoxEnableScaleFactors";
      this.checkBoxEnableScaleFactors.Size = new System.Drawing.Size(233, 17);
      this.checkBoxEnableScaleFactors.TabIndex = 0;
      this.checkBoxEnableScaleFactors.Text = "Specify Scale Factors for Output Report File";
      this.checkBoxEnableScaleFactors.UseVisualStyleBackColor = true;
      this.checkBoxEnableScaleFactors.CheckedChanged += new System.EventHandler(this.CheckBoxScaleFactors_CheckedChanged);
      // 
      // groupRetroAdjustment
      // 
      this.groupRetroAdjustment.Controls.Add(this.checkBoxEnableRetroAdjustment);
      this.groupRetroAdjustment.Controls.Add(this.dataGridRetroAdjustment);
      this.groupRetroAdjustment.Location = new System.Drawing.Point(29, 283);
      this.groupRetroAdjustment.Name = "groupRetroAdjustment";
      this.groupRetroAdjustment.Size = new System.Drawing.Size(406, 223);
      this.groupRetroAdjustment.TabIndex = 2;
      this.groupRetroAdjustment.TabStop = false;
      this.groupRetroAdjustment.Text = "Retrospective Adjustment Factors";
      // 
      // checkBoxEnableRetroAdjustment
      // 
      this.checkBoxEnableRetroAdjustment.AutoSize = true;
      this.checkBoxEnableRetroAdjustment.Location = new System.Drawing.Point(17, 20);
      this.checkBoxEnableRetroAdjustment.Name = "checkBoxEnableRetroAdjustment";
      this.checkBoxEnableRetroAdjustment.Size = new System.Drawing.Size(223, 17);
      this.checkBoxEnableRetroAdjustment.TabIndex = 1;
      this.checkBoxEnableRetroAdjustment.Text = "Specify Retrospective Adjustment Factors";
      this.checkBoxEnableRetroAdjustment.UseVisualStyleBackColor = true;
      this.checkBoxEnableRetroAdjustment.CheckedChanged += new System.EventHandler(this.CheckBoxRetroAdjustment_CheckedChanged);
      // 
      // comboBoxOutputViewerProgram
      // 
      this.comboBoxOutputViewerProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxOutputViewerProgram.Items.AddRange(new object[] {
            "System Default",
            "Notepad",
            "None"});
      this.comboBoxOutputViewerProgram.Location = new System.Drawing.Point(18, 32);
      this.comboBoxOutputViewerProgram.Name = "comboBoxOutputViewerProgram";
      this.comboBoxOutputViewerProgram.Size = new System.Drawing.Size(339, 21);
      this.comboBoxOutputViewerProgram.TabIndex = 1;
      // 
      // labelOutputViewerProgram
      // 
      this.labelOutputViewerProgram.AutoSize = true;
      this.labelOutputViewerProgram.Location = new System.Drawing.Point(15, 16);
      this.labelOutputViewerProgram.Name = "labelOutputViewerProgram";
      this.labelOutputViewerProgram.Size = new System.Drawing.Size(189, 13);
      this.labelOutputViewerProgram.TabIndex = 0;
      this.labelOutputViewerProgram.Text = "Program to View AGEPRO Output File ";
      // 
      // groupBox_StockSummmaryFlag
      // 
      this.groupBox_StockSummmaryFlag.Controls.Add(this.radioButtonStockAge_ExcludeStockNumAux);
      this.groupBox_StockSummmaryFlag.Controls.Add(this.radioButtonStockAge_NoAux);
      this.groupBox_StockSummmaryFlag.Controls.Add(this.radioButtonNoStockAge_NoAux);
      this.groupBox_StockSummmaryFlag.Controls.Add(this.radioButtonStockAge_AllAux);
      this.groupBox_StockSummmaryFlag.Controls.Add(this.radioButtonNoStockAge_ExcludeStockNumAux);
      this.groupBox_StockSummmaryFlag.Location = new System.Drawing.Point(29, 15);
      this.groupBox_StockSummmaryFlag.Name = "groupBox_StockSummmaryFlag";
      this.groupBox_StockSummmaryFlag.Size = new System.Drawing.Size(406, 133);
      this.groupBox_StockSummmaryFlag.TabIndex = 0;
      this.groupBox_StockSummmaryFlag.TabStop = false;
      this.groupBox_StockSummmaryFlag.Text = "Stock Distribution Summary and Auxiliary Data Files";
      // 
      // radioButtonStockAge_ExcludeStockNumAux
      // 
      this.radioButtonStockAge_ExcludeStockNumAux.AutoSize = true;
      this.radioButtonStockAge_ExcludeStockNumAux.Location = new System.Drawing.Point(17, 109);
      this.radioButtonStockAge_ExcludeStockNumAux.Name = "radioButtonStockAge_ExcludeStockNumAux";
      this.radioButtonStockAge_ExcludeStockNumAux.Size = new System.Drawing.Size(302, 17);
      this.radioButtonStockAge_ExcludeStockNumAux.TabIndex = 4;
      this.radioButtonStockAge_ExcludeStockNumAux.TabStop = true;
      this.radioButtonStockAge_ExcludeStockNumAux.Text = "Output Stock Of Age, Auxiliary Files EXCEPT Stock of Age";
      this.radioButtonStockAge_ExcludeStockNumAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_ExcludeStockNumAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_ExcludeStockNumAux_CheckedChanged);
      // 
      // radioButtonStockAge_NoAux
      // 
      this.radioButtonStockAge_NoAux.AutoSize = true;
      this.radioButtonStockAge_NoAux.Location = new System.Drawing.Point(17, 86);
      this.radioButtonStockAge_NoAux.Name = "radioButtonStockAge_NoAux";
      this.radioButtonStockAge_NoAux.Size = new System.Drawing.Size(211, 17);
      this.radioButtonStockAge_NoAux.TabIndex = 3;
      this.radioButtonStockAge_NoAux.TabStop = true;
      this.radioButtonStockAge_NoAux.Text = "Ouptut Stock Of Age, NO Auxiilary Files";
      this.radioButtonStockAge_NoAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_NoAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_NoAux_CheckedChanged);
      // 
      // radioButtonNoStockAge_NoAux
      // 
      this.radioButtonNoStockAge_NoAux.AutoSize = true;
      this.radioButtonNoStockAge_NoAux.Location = new System.Drawing.Point(17, 63);
      this.radioButtonNoStockAge_NoAux.Name = "radioButtonNoStockAge_NoAux";
      this.radioButtonNoStockAge_NoAux.Size = new System.Drawing.Size(194, 17);
      this.radioButtonNoStockAge_NoAux.TabIndex = 2;
      this.radioButtonNoStockAge_NoAux.TabStop = true;
      this.radioButtonNoStockAge_NoAux.Text = "NO Stock Of Age and Auxiliary Files";
      this.radioButtonNoStockAge_NoAux.UseVisualStyleBackColor = true;
      this.radioButtonNoStockAge_NoAux.CheckedChanged += new System.EventHandler(this.radioButtonNoStockAge_NoAux_CheckedChanged);
      // 
      // radioButtonStockAge_AllAux
      // 
      this.radioButtonStockAge_AllAux.AutoSize = true;
      this.radioButtonStockAge_AllAux.Location = new System.Drawing.Point(17, 40);
      this.radioButtonStockAge_AllAux.Name = "radioButtonStockAge_AllAux";
      this.radioButtonStockAge_AllAux.Size = new System.Drawing.Size(234, 17);
      this.radioButtonStockAge_AllAux.TabIndex = 1;
      this.radioButtonStockAge_AllAux.TabStop = true;
      this.radioButtonStockAge_AllAux.Text = "Output Stock Of Age AND ALL Auxiliary files";
      this.radioButtonStockAge_AllAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_AllAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_AllAux_CheckedChanged);
      // 
      // radioButtonNoStockAge_ExcludeStockNumAux
      // 
      this.radioButtonNoStockAge_ExcludeStockNumAux.AutoSize = true;
      this.radioButtonNoStockAge_ExcludeStockNumAux.Location = new System.Drawing.Point(17, 17);
      this.radioButtonNoStockAge_ExcludeStockNumAux.Name = "radioButtonNoStockAge_ExcludeStockNumAux";
      this.radioButtonNoStockAge_ExcludeStockNumAux.Size = new System.Drawing.Size(359, 17);
      this.radioButtonNoStockAge_ExcludeStockNumAux.TabIndex = 0;
      this.radioButtonNoStockAge_ExcludeStockNumAux.TabStop = true;
      this.radioButtonNoStockAge_ExcludeStockNumAux.Text = "No Stock of Age, Output Auxiliary files EXCEPT Stock Numbers of Age";
      this.radioButtonNoStockAge_ExcludeStockNumAux.UseVisualStyleBackColor = true;
      this.radioButtonNoStockAge_ExcludeStockNumAux.CheckedChanged += new System.EventHandler(this.radioButtonNoStockAge_ExcludeStockNumAux_CheckedChanged);
      // 
      // groupOutputViewer
      // 
      this.groupOutputViewer.Controls.Add(this.comboBoxOutputViewerProgram);
      this.groupOutputViewer.Controls.Add(this.labelOutputViewerProgram);
      this.groupOutputViewer.Location = new System.Drawing.Point(441, 45);
      this.groupOutputViewer.Name = "groupOutputViewer";
      this.groupOutputViewer.Size = new System.Drawing.Size(390, 65);
      this.groupOutputViewer.TabIndex = 3;
      this.groupOutputViewer.TabStop = false;
      this.groupOutputViewer.Text = "Output File Viewer";
      // 
      // checkBoxEnableVer40Format
      // 
      this.checkBoxEnableVer40Format.AutoSize = true;
      this.checkBoxEnableVer40Format.Location = new System.Drawing.Point(442, 22);
      this.checkBoxEnableVer40Format.Name = "checkBoxEnableVer40Format";
      this.checkBoxEnableVer40Format.Size = new System.Drawing.Size(256, 17);
      this.checkBoxEnableVer40Format.TabIndex = 7;
      this.checkBoxEnableVer40Format.Text = "Enable AGEPRO VERSION 4.0 input File Format";
      this.checkBoxEnableVer40Format.UseVisualStyleBackColor = true;
      this.checkBoxEnableVer40Format.CheckedChanged += new System.EventHandler(this.checkBoxEnableVer40Format_CheckedChanged);
      // 
      // textBoxMiscOptionsInpfileVerString
      // 
      this.textBoxMiscOptionsInpfileVerString.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.textBoxMiscOptionsInpfileVerString.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxMiscOptionsInpfileVerString.Enabled = false;
      this.textBoxMiscOptionsInpfileVerString.Location = new System.Drawing.Point(704, 24);
      this.textBoxMiscOptionsInpfileVerString.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
      this.textBoxMiscOptionsInpfileVerString.Name = "textBoxMiscOptionsInpfileVerString";
      this.textBoxMiscOptionsInpfileVerString.ParamName = null;
      this.textBoxMiscOptionsInpfileVerString.PrevValidValue = "";
      this.textBoxMiscOptionsInpfileVerString.Size = new System.Drawing.Size(127, 13);
      this.textBoxMiscOptionsInpfileVerString.TabIndex = 8;
      this.textBoxMiscOptionsInpfileVerString.Text = "AGEPRO VERSION";
      // 
      // dataGridRetroAdjustment
      // 
      this.dataGridRetroAdjustment.AllowUserToAddRows = false;
      this.dataGridRetroAdjustment.AllowUserToDeleteRows = false;
      this.dataGridRetroAdjustment.AllowUserToResizeRows = false;
      this.dataGridRetroAdjustment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dataGridRetroAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridRetroAdjustment.ColumnHeadersVisible = false;
      this.dataGridRetroAdjustment.Location = new System.Drawing.Point(17, 40);
      this.dataGridRetroAdjustment.Name = "dataGridRetroAdjustment";
      this.dataGridRetroAdjustment.nftReadOnly = false;
      this.dataGridRetroAdjustment.RowHeadersWidth = 75;
      this.dataGridRetroAdjustment.Size = new System.Drawing.Size(356, 171);
      this.dataGridRetroAdjustment.TabIndex = 0;
      this.dataGridRetroAdjustment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridRetroAdjustment_CellFormatting);
      // 
      // textBoxScaleFactorRecruits
      // 
      this.textBoxScaleFactorRecruits.Enabled = false;
      this.textBoxScaleFactorRecruits.Location = new System.Drawing.Point(146, 69);
      this.textBoxScaleFactorRecruits.Name = "textBoxScaleFactorRecruits";
      this.textBoxScaleFactorRecruits.ParamName = null;
      this.textBoxScaleFactorRecruits.PrevValidValue = "";
      this.textBoxScaleFactorRecruits.Size = new System.Drawing.Size(100, 20);
      this.textBoxScaleFactorRecruits.TabIndex = 4;
      // 
      // textBoxScaleFactorsStockNum
      // 
      this.textBoxScaleFactorsStockNum.Enabled = false;
      this.textBoxScaleFactorsStockNum.Location = new System.Drawing.Point(146, 95);
      this.textBoxScaleFactorsStockNum.Name = "textBoxScaleFactorsStockNum";
      this.textBoxScaleFactorsStockNum.ParamName = null;
      this.textBoxScaleFactorsStockNum.PrevValidValue = "";
      this.textBoxScaleFactorsStockNum.Size = new System.Drawing.Size(100, 20);
      this.textBoxScaleFactorsStockNum.TabIndex = 6;
      // 
      // textBoxScaleFactorBiomass
      // 
      this.textBoxScaleFactorBiomass.Enabled = false;
      this.textBoxScaleFactorBiomass.Location = new System.Drawing.Point(146, 43);
      this.textBoxScaleFactorBiomass.Name = "textBoxScaleFactorBiomass";
      this.textBoxScaleFactorBiomass.ParamName = null;
      this.textBoxScaleFactorBiomass.PrevValidValue = "";
      this.textBoxScaleFactorBiomass.Size = new System.Drawing.Size(100, 20);
      this.textBoxScaleFactorBiomass.TabIndex = 2;
      // 
      // textBoxBoundsNatMortality
      // 
      this.textBoxBoundsNatMortality.Enabled = false;
      this.textBoxBoundsNatMortality.Location = new System.Drawing.Point(158, 68);
      this.textBoxBoundsNatMortality.Name = "textBoxBoundsNatMortality";
      this.textBoxBoundsNatMortality.ParamName = null;
      this.textBoxBoundsNatMortality.PrevValidValue = "";
      this.textBoxBoundsNatMortality.Size = new System.Drawing.Size(100, 20);
      this.textBoxBoundsNatMortality.TabIndex = 4;
      this.textBoxBoundsNatMortality.Text = "1.0";
      // 
      // textBoxBoundsMaxWeight
      // 
      this.textBoxBoundsMaxWeight.Enabled = false;
      this.textBoxBoundsMaxWeight.Location = new System.Drawing.Point(158, 42);
      this.textBoxBoundsMaxWeight.Name = "textBoxBoundsMaxWeight";
      this.textBoxBoundsMaxWeight.ParamName = null;
      this.textBoxBoundsMaxWeight.PrevValidValue = "";
      this.textBoxBoundsMaxWeight.Size = new System.Drawing.Size(100, 20);
      this.textBoxBoundsMaxWeight.TabIndex = 2;
      this.textBoxBoundsMaxWeight.Text = "10.0";
      // 
      // textBoxRefFishMortality
      // 
      this.textBoxRefFishMortality.Enabled = false;
      this.textBoxRefFishMortality.Location = new System.Drawing.Point(189, 120);
      this.textBoxRefFishMortality.Name = "textBoxRefFishMortality";
      this.textBoxRefFishMortality.ParamName = null;
      this.textBoxRefFishMortality.PrevValidValue = "";
      this.textBoxRefFishMortality.Size = new System.Drawing.Size(117, 20);
      this.textBoxRefFishMortality.TabIndex = 8;
      // 
      // textBoxRefMeanBiomass
      // 
      this.textBoxRefMeanBiomass.Enabled = false;
      this.textBoxRefMeanBiomass.Location = new System.Drawing.Point(189, 94);
      this.textBoxRefMeanBiomass.Name = "textBoxRefMeanBiomass";
      this.textBoxRefMeanBiomass.ParamName = null;
      this.textBoxRefMeanBiomass.PrevValidValue = "";
      this.textBoxRefMeanBiomass.Size = new System.Drawing.Size(117, 20);
      this.textBoxRefMeanBiomass.TabIndex = 6;
      // 
      // textBoxRefJan1Biomass
      // 
      this.textBoxRefJan1Biomass.Enabled = false;
      this.textBoxRefJan1Biomass.Location = new System.Drawing.Point(189, 68);
      this.textBoxRefJan1Biomass.Name = "textBoxRefJan1Biomass";
      this.textBoxRefJan1Biomass.ParamName = null;
      this.textBoxRefJan1Biomass.PrevValidValue = "";
      this.textBoxRefJan1Biomass.Size = new System.Drawing.Size(117, 20);
      this.textBoxRefJan1Biomass.TabIndex = 4;
      // 
      // textBoxRefSpawnBiomass
      // 
      this.textBoxRefSpawnBiomass.Enabled = false;
      this.textBoxRefSpawnBiomass.Location = new System.Drawing.Point(189, 42);
      this.textBoxRefSpawnBiomass.Name = "textBoxRefSpawnBiomass";
      this.textBoxRefSpawnBiomass.ParamName = null;
      this.textBoxRefSpawnBiomass.PrevValidValue = "";
      this.textBoxRefSpawnBiomass.Size = new System.Drawing.Size(117, 20);
      this.textBoxRefSpawnBiomass.TabIndex = 2;
      // 
      // ControlMiscOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.textBoxMiscOptionsInpfileVerString);
      this.Controls.Add(this.checkBoxEnableVer40Format);
      this.Controls.Add(this.groupOutputViewer);
      this.Controls.Add(this.groupBox_StockSummmaryFlag);
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
      this.groupBox_StockSummmaryFlag.ResumeLayout(false);
      this.groupBox_StockSummmaryFlag.PerformLayout();
      this.groupOutputViewer.ResumeLayout(false);
      this.groupOutputViewer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridRetroAdjustment)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOuputOptions;
        private System.Windows.Forms.Label labelReportPercentile;
        private System.Windows.Forms.CheckBox checkBoxEnablePercentileReport;
        private System.Windows.Forms.CheckBox checkBoxEnableExportR;
        private System.Windows.Forms.CheckBox checkBoxEnableAuxStochasticFiles;
        private System.Windows.Forms.GroupBox groupRefpoints;
        private Nmfs.Agepro.Gui.NftTextBox textBoxRefFishMortality;
        private System.Windows.Forms.Label labelFishMortality;
        private Nmfs.Agepro.Gui.NftTextBox textBoxRefMeanBiomass;
        private System.Windows.Forms.CheckBox checkBoxEnableRefpoints;
        private System.Windows.Forms.Label labelMeanBiomass;
        private Nmfs.Agepro.Gui.NftTextBox textBoxRefJan1Biomass;
        private System.Windows.Forms.Label labelJan1Biomass;
        private Nmfs.Agepro.Gui.NftTextBox textBoxRefSpawnBiomass;
        private System.Windows.Forms.Label labelSpawnBiomass;
        private System.Windows.Forms.GroupBox groupBounds;
        private Nmfs.Agepro.Gui.NftTextBox textBoxBoundsNatMortality;
        private System.Windows.Forms.Label labelBoundsNatMortality;
        private Nmfs.Agepro.Gui.NftTextBox textBoxBoundsMaxWeight;
        private System.Windows.Forms.Label labelBoundsMaxWeight;
        private System.Windows.Forms.CheckBox checkBoxBounds;
        private System.Windows.Forms.GroupBox groupScaleFactors;
        private Nmfs.Agepro.Gui.NftTextBox textBoxScaleFactorRecruits;
        private System.Windows.Forms.Label labelScaleFactorRecruits;
        private Nmfs.Agepro.Gui.NftTextBox textBoxScaleFactorsStockNum;
        private System.Windows.Forms.Label labelScaleFactorStockNum;
        private Nmfs.Agepro.Gui.NftTextBox textBoxScaleFactorBiomass;
        private System.Windows.Forms.Label labelScaleFactorBiomass;
        private System.Windows.Forms.CheckBox checkBoxEnableScaleFactors;
        private System.Windows.Forms.GroupBox groupRetroAdjustment;
        private System.Windows.Forms.CheckBox checkBoxEnableRetroAdjustment;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridRetroAdjustment;
        private System.Windows.Forms.NumericUpDown spinBoxReportPercentile;
        private System.Windows.Forms.ComboBox comboBoxOutputViewerProgram;
        private System.Windows.Forms.Label labelOutputViewerProgram;
    private System.Windows.Forms.GroupBox groupBox_StockSummmaryFlag;
    private System.Windows.Forms.RadioButton radioButtonNoStockAge_ExcludeStockNumAux;
    private System.Windows.Forms.RadioButton radioButtonNoStockAge_NoAux;
    private System.Windows.Forms.RadioButton radioButtonStockAge_AllAux;
    private System.Windows.Forms.RadioButton radioButtonStockAge_NoAux;
    private System.Windows.Forms.GroupBox groupOutputViewer;
    private System.Windows.Forms.RadioButton radioButtonStockAge_ExcludeStockNumAux;
    private System.Windows.Forms.CheckBox checkBoxEnableVer40Format;
    private NftTextBox textBoxMiscOptionsInpfileVerString;
  }
}
