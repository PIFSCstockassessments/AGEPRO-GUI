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
      this.textBoxRefFishMortality = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelFishMortality = new System.Windows.Forms.Label();
      this.textBoxRefMeanBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.checkBoxEnableRefpoints = new System.Windows.Forms.CheckBox();
      this.labelMeanBiomass = new System.Windows.Forms.Label();
      this.textBoxRefJan1Biomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelJan1Biomass = new System.Windows.Forms.Label();
      this.textBoxRefSpawnBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelSpawnBiomass = new System.Windows.Forms.Label();
      this.groupBounds = new System.Windows.Forms.GroupBox();
      this.textBoxBoundsNatMortality = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelBoundsNatMortality = new System.Windows.Forms.Label();
      this.textBoxBoundsMaxWeight = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelBoundsMaxWeight = new System.Windows.Forms.Label();
      this.checkBoxBounds = new System.Windows.Forms.CheckBox();
      this.groupScaleFactors = new System.Windows.Forms.GroupBox();
      this.textBoxScaleFactorRecruits = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelScaleFactorRecruits = new System.Windows.Forms.Label();
      this.textBoxScaleFactorsStockNum = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelScaleFactorStockNum = new System.Windows.Forms.Label();
      this.textBoxScaleFactorBiomass = new Nmfs.Agepro.Gui.NftTextBox();
      this.labelScaleFactorBiomass = new System.Windows.Forms.Label();
      this.checkBoxEnableScaleFactors = new System.Windows.Forms.CheckBox();
      this.groupRetroAdjustment = new System.Windows.Forms.GroupBox();
      this.checkBoxEnableRetroAdjustment = new System.Windows.Forms.CheckBox();
      this.dataGridRetroAdjustment = new Nmfs.Agepro.Gui.NftDataGridView();
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
      this.groupOuputOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spinBoxReportPercentile)).BeginInit();
      this.groupRefpoints.SuspendLayout();
      this.groupBounds.SuspendLayout();
      this.groupScaleFactors.SuspendLayout();
      this.groupRetroAdjustment.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridRetroAdjustment)).BeginInit();
      this.groupBox_StockSummmaryFlag.SuspendLayout();
      this.groupOutputViewer.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupOuputOptions
      // 
      this.groupOuputOptions.Controls.Add(this.spinBoxReportPercentile);
      this.groupOuputOptions.Controls.Add(this.labelReportPercentile);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnablePercentileReport);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnableExportR);
      this.groupOuputOptions.Controls.Add(this.checkBoxEnableAuxStochasticFiles);
      this.groupOuputOptions.Location = new System.Drawing.Point(39, 190);
      this.groupOuputOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupOuputOptions.Name = "groupOuputOptions";
      this.groupOuputOptions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupOuputOptions.Size = new System.Drawing.Size(541, 151);
      this.groupOuputOptions.TabIndex = 1;
      this.groupOuputOptions.TabStop = false;
      this.groupOuputOptions.Text = "Output Options";
      // 
      // spinBoxReportPercentile
      // 
      this.spinBoxReportPercentile.DecimalPlaces = 1;
      this.spinBoxReportPercentile.Enabled = false;
      this.spinBoxReportPercentile.Location = new System.Drawing.Point(212, 108);
      this.spinBoxReportPercentile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.spinBoxReportPercentile.Name = "spinBoxReportPercentile";
      this.spinBoxReportPercentile.Size = new System.Drawing.Size(143, 22);
      this.spinBoxReportPercentile.TabIndex = 5;
      // 
      // labelReportPercentile
      // 
      this.labelReportPercentile.AutoSize = true;
      this.labelReportPercentile.Enabled = false;
      this.labelReportPercentile.Location = new System.Drawing.Point(85, 111);
      this.labelReportPercentile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelReportPercentile.Name = "labelReportPercentile";
      this.labelReportPercentile.Size = new System.Drawing.Size(111, 16);
      this.labelReportPercentile.TabIndex = 4;
      this.labelReportPercentile.Text = "Report Percentile";
      // 
      // checkBoxEnablePercentileReport
      // 
      this.checkBoxEnablePercentileReport.AutoSize = true;
      this.checkBoxEnablePercentileReport.Location = new System.Drawing.Point(23, 81);
      this.checkBoxEnablePercentileReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnablePercentileReport.Name = "checkBoxEnablePercentileReport";
      this.checkBoxEnablePercentileReport.Size = new System.Drawing.Size(187, 20);
      this.checkBoxEnablePercentileReport.TabIndex = 3;
      this.checkBoxEnablePercentileReport.Text = "Request Percentile Report";
      this.checkBoxEnablePercentileReport.UseVisualStyleBackColor = true;
      this.checkBoxEnablePercentileReport.CheckedChanged += new System.EventHandler(this.CheckBoxPercentileReport_CheckedChanged);
      // 
      // checkBoxEnableExportR
      // 
      this.checkBoxEnableExportR.AutoSize = true;
      this.checkBoxEnableExportR.Location = new System.Drawing.Point(23, 53);
      this.checkBoxEnableExportR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableExportR.Name = "checkBoxEnableExportR";
      this.checkBoxEnableExportR.Size = new System.Drawing.Size(142, 20);
      this.checkBoxEnableExportR.TabIndex = 2;
      this.checkBoxEnableExportR.Text = "Export Results to R";
      this.checkBoxEnableExportR.UseVisualStyleBackColor = true;
      // 
      // checkBoxEnableAuxStochasticFiles
      // 
      this.checkBoxEnableAuxStochasticFiles.AutoSize = true;
      this.checkBoxEnableAuxStochasticFiles.Location = new System.Drawing.Point(23, 25);
      this.checkBoxEnableAuxStochasticFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableAuxStochasticFiles.Name = "checkBoxEnableAuxStochasticFiles";
      this.checkBoxEnableAuxStochasticFiles.Size = new System.Drawing.Size(267, 20);
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
      this.groupRefpoints.Location = new System.Drawing.Point(588, 270);
      this.groupRefpoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupRefpoints.Name = "groupRefpoints";
      this.groupRefpoints.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupRefpoints.Size = new System.Drawing.Size(520, 187);
      this.groupRefpoints.TabIndex = 5;
      this.groupRefpoints.TabStop = false;
      this.groupRefpoints.Text = "Reference Points";
      // 
      // textBoxRefFishMortality
      // 
      this.textBoxRefFishMortality.Enabled = false;
      this.textBoxRefFishMortality.Location = new System.Drawing.Point(252, 148);
      this.textBoxRefFishMortality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxRefFishMortality.Name = "textBoxRefFishMortality";
      this.textBoxRefFishMortality.ParamName = null;
      this.textBoxRefFishMortality.PrevValidValue = "";
      this.textBoxRefFishMortality.Size = new System.Drawing.Size(155, 22);
      this.textBoxRefFishMortality.TabIndex = 8;
      // 
      // labelFishMortality
      // 
      this.labelFishMortality.AutoSize = true;
      this.labelFishMortality.Enabled = false;
      this.labelFishMortality.Location = new System.Drawing.Point(25, 151);
      this.labelFishMortality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelFishMortality.Name = "labelFishMortality";
      this.labelFishMortality.Size = new System.Drawing.Size(103, 16);
      this.labelFishMortality.TabIndex = 7;
      this.labelFishMortality.Text = "Fishing Mortality";
      // 
      // textBoxRefMeanBiomass
      // 
      this.textBoxRefMeanBiomass.Enabled = false;
      this.textBoxRefMeanBiomass.Location = new System.Drawing.Point(252, 116);
      this.textBoxRefMeanBiomass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxRefMeanBiomass.Name = "textBoxRefMeanBiomass";
      this.textBoxRefMeanBiomass.ParamName = null;
      this.textBoxRefMeanBiomass.PrevValidValue = "";
      this.textBoxRefMeanBiomass.Size = new System.Drawing.Size(155, 22);
      this.textBoxRefMeanBiomass.TabIndex = 6;
      // 
      // checkBoxEnableRefpoints
      // 
      this.checkBoxEnableRefpoints.AutoSize = true;
      this.checkBoxEnableRefpoints.Location = new System.Drawing.Point(29, 23);
      this.checkBoxEnableRefpoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableRefpoints.Name = "checkBoxEnableRefpoints";
      this.checkBoxEnableRefpoints.Size = new System.Drawing.Size(279, 20);
      this.checkBoxEnableRefpoints.TabIndex = 0;
      this.checkBoxEnableRefpoints.Text = "Enable Reference Point Threshold Report";
      this.checkBoxEnableRefpoints.UseVisualStyleBackColor = true;
      this.checkBoxEnableRefpoints.CheckedChanged += new System.EventHandler(this.CheckBoxRefpoints_CheckedChanged);
      // 
      // labelMeanBiomass
      // 
      this.labelMeanBiomass.AutoSize = true;
      this.labelMeanBiomass.Enabled = false;
      this.labelMeanBiomass.Location = new System.Drawing.Point(25, 119);
      this.labelMeanBiomass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelMeanBiomass.Name = "labelMeanBiomass";
      this.labelMeanBiomass.Size = new System.Drawing.Size(128, 16);
      this.labelMeanBiomass.TabIndex = 5;
      this.labelMeanBiomass.Text = "Mean Biomass (MT)";
      // 
      // textBoxRefJan1Biomass
      // 
      this.textBoxRefJan1Biomass.Enabled = false;
      this.textBoxRefJan1Biomass.Location = new System.Drawing.Point(252, 84);
      this.textBoxRefJan1Biomass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxRefJan1Biomass.Name = "textBoxRefJan1Biomass";
      this.textBoxRefJan1Biomass.ParamName = null;
      this.textBoxRefJan1Biomass.PrevValidValue = "";
      this.textBoxRefJan1Biomass.Size = new System.Drawing.Size(155, 22);
      this.textBoxRefJan1Biomass.TabIndex = 4;
      // 
      // labelJan1Biomass
      // 
      this.labelJan1Biomass.AutoSize = true;
      this.labelJan1Biomass.Enabled = false;
      this.labelJan1Biomass.Location = new System.Drawing.Point(25, 87);
      this.labelJan1Biomass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelJan1Biomass.Name = "labelJan1Biomass";
      this.labelJan1Biomass.Size = new System.Drawing.Size(164, 16);
      this.labelJan1Biomass.TabIndex = 3;
      this.labelJan1Biomass.Text = "Jan-1 Stock Biomass (MT)";
      // 
      // textBoxRefSpawnBiomass
      // 
      this.textBoxRefSpawnBiomass.Enabled = false;
      this.textBoxRefSpawnBiomass.Location = new System.Drawing.Point(252, 52);
      this.textBoxRefSpawnBiomass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxRefSpawnBiomass.Name = "textBoxRefSpawnBiomass";
      this.textBoxRefSpawnBiomass.ParamName = null;
      this.textBoxRefSpawnBiomass.PrevValidValue = "";
      this.textBoxRefSpawnBiomass.Size = new System.Drawing.Size(155, 22);
      this.textBoxRefSpawnBiomass.TabIndex = 2;
      // 
      // labelSpawnBiomass
      // 
      this.labelSpawnBiomass.AutoSize = true;
      this.labelSpawnBiomass.Enabled = false;
      this.labelSpawnBiomass.Location = new System.Drawing.Point(25, 55);
      this.labelSpawnBiomass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelSpawnBiomass.Name = "labelSpawnBiomass";
      this.labelSpawnBiomass.Size = new System.Drawing.Size(190, 16);
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
      this.groupBounds.Location = new System.Drawing.Point(588, 140);
      this.groupBounds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBounds.Name = "groupBounds";
      this.groupBounds.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBounds.Size = new System.Drawing.Size(520, 122);
      this.groupBounds.TabIndex = 4;
      this.groupBounds.TabStop = false;
      this.groupBounds.Text = "Bounds";
      // 
      // textBoxBoundsNatMortality
      // 
      this.textBoxBoundsNatMortality.Enabled = false;
      this.textBoxBoundsNatMortality.Location = new System.Drawing.Point(211, 84);
      this.textBoxBoundsNatMortality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxBoundsNatMortality.Name = "textBoxBoundsNatMortality";
      this.textBoxBoundsNatMortality.ParamName = null;
      this.textBoxBoundsNatMortality.PrevValidValue = "";
      this.textBoxBoundsNatMortality.Size = new System.Drawing.Size(132, 22);
      this.textBoxBoundsNatMortality.TabIndex = 4;
      this.textBoxBoundsNatMortality.Text = "1.0";
      // 
      // labelBoundsNatMortality
      // 
      this.labelBoundsNatMortality.AutoSize = true;
      this.labelBoundsNatMortality.Enabled = false;
      this.labelBoundsNatMortality.Location = new System.Drawing.Point(20, 87);
      this.labelBoundsNatMortality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelBoundsNatMortality.Name = "labelBoundsNatMortality";
      this.labelBoundsNatMortality.Size = new System.Drawing.Size(163, 16);
      this.labelBoundsNatMortality.TabIndex = 3;
      this.labelBoundsNatMortality.Text = "Maximum Natural Mortality";
      // 
      // textBoxBoundsMaxWeight
      // 
      this.textBoxBoundsMaxWeight.Enabled = false;
      this.textBoxBoundsMaxWeight.Location = new System.Drawing.Point(211, 52);
      this.textBoxBoundsMaxWeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxBoundsMaxWeight.Name = "textBoxBoundsMaxWeight";
      this.textBoxBoundsMaxWeight.ParamName = null;
      this.textBoxBoundsMaxWeight.PrevValidValue = "";
      this.textBoxBoundsMaxWeight.Size = new System.Drawing.Size(132, 22);
      this.textBoxBoundsMaxWeight.TabIndex = 2;
      this.textBoxBoundsMaxWeight.Text = "10.0";
      // 
      // labelBoundsMaxWeight
      // 
      this.labelBoundsMaxWeight.AutoSize = true;
      this.labelBoundsMaxWeight.Enabled = false;
      this.labelBoundsMaxWeight.Location = new System.Drawing.Point(20, 55);
      this.labelBoundsMaxWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelBoundsMaxWeight.Name = "labelBoundsMaxWeight";
      this.labelBoundsMaxWeight.Size = new System.Drawing.Size(135, 16);
      this.labelBoundsMaxWeight.TabIndex = 1;
      this.labelBoundsMaxWeight.Text = "Maximum Weight (kg)";
      // 
      // checkBoxBounds
      // 
      this.checkBoxBounds.AutoSize = true;
      this.checkBoxBounds.Location = new System.Drawing.Point(24, 23);
      this.checkBoxBounds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxBounds.Name = "checkBoxBounds";
      this.checkBoxBounds.Size = new System.Drawing.Size(123, 20);
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
      this.groupScaleFactors.Location = new System.Drawing.Point(588, 464);
      this.groupScaleFactors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupScaleFactors.Name = "groupScaleFactors";
      this.groupScaleFactors.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupScaleFactors.Size = new System.Drawing.Size(520, 158);
      this.groupScaleFactors.TabIndex = 6;
      this.groupScaleFactors.TabStop = false;
      this.groupScaleFactors.Text = "Scaling Factors for Output Report";
      // 
      // textBoxScaleFactorRecruits
      // 
      this.textBoxScaleFactorRecruits.Enabled = false;
      this.textBoxScaleFactorRecruits.Location = new System.Drawing.Point(195, 85);
      this.textBoxScaleFactorRecruits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxScaleFactorRecruits.Name = "textBoxScaleFactorRecruits";
      this.textBoxScaleFactorRecruits.ParamName = null;
      this.textBoxScaleFactorRecruits.PrevValidValue = "";
      this.textBoxScaleFactorRecruits.Size = new System.Drawing.Size(132, 22);
      this.textBoxScaleFactorRecruits.TabIndex = 4;
      // 
      // labelScaleFactorRecruits
      // 
      this.labelScaleFactorRecruits.AutoSize = true;
      this.labelScaleFactorRecruits.Enabled = false;
      this.labelScaleFactorRecruits.Location = new System.Drawing.Point(29, 89);
      this.labelScaleFactorRecruits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelScaleFactorRecruits.Name = "labelScaleFactorRecruits";
      this.labelScaleFactorRecruits.Size = new System.Drawing.Size(56, 16);
      this.labelScaleFactorRecruits.TabIndex = 3;
      this.labelScaleFactorRecruits.Text = "Recruits";
      // 
      // textBoxScaleFactorsStockNum
      // 
      this.textBoxScaleFactorsStockNum.Enabled = false;
      this.textBoxScaleFactorsStockNum.Location = new System.Drawing.Point(195, 117);
      this.textBoxScaleFactorsStockNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxScaleFactorsStockNum.Name = "textBoxScaleFactorsStockNum";
      this.textBoxScaleFactorsStockNum.ParamName = null;
      this.textBoxScaleFactorsStockNum.PrevValidValue = "";
      this.textBoxScaleFactorsStockNum.Size = new System.Drawing.Size(132, 22);
      this.textBoxScaleFactorsStockNum.TabIndex = 6;
      // 
      // labelScaleFactorStockNum
      // 
      this.labelScaleFactorStockNum.AutoSize = true;
      this.labelScaleFactorStockNum.Enabled = false;
      this.labelScaleFactorStockNum.Location = new System.Drawing.Point(28, 121);
      this.labelScaleFactorStockNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelScaleFactorStockNum.Name = "labelScaleFactorStockNum";
      this.labelScaleFactorStockNum.Size = new System.Drawing.Size(99, 16);
      this.labelScaleFactorStockNum.TabIndex = 5;
      this.labelScaleFactorStockNum.Text = "Stock Numbers";
      // 
      // textBoxScaleFactorBiomass
      // 
      this.textBoxScaleFactorBiomass.Enabled = false;
      this.textBoxScaleFactorBiomass.Location = new System.Drawing.Point(195, 53);
      this.textBoxScaleFactorBiomass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.textBoxScaleFactorBiomass.Name = "textBoxScaleFactorBiomass";
      this.textBoxScaleFactorBiomass.ParamName = null;
      this.textBoxScaleFactorBiomass.PrevValidValue = "";
      this.textBoxScaleFactorBiomass.Size = new System.Drawing.Size(132, 22);
      this.textBoxScaleFactorBiomass.TabIndex = 2;
      // 
      // labelScaleFactorBiomass
      // 
      this.labelScaleFactorBiomass.AutoSize = true;
      this.labelScaleFactorBiomass.Enabled = false;
      this.labelScaleFactorBiomass.Location = new System.Drawing.Point(29, 57);
      this.labelScaleFactorBiomass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelScaleFactorBiomass.Name = "labelScaleFactorBiomass";
      this.labelScaleFactorBiomass.Size = new System.Drawing.Size(60, 16);
      this.labelScaleFactorBiomass.TabIndex = 1;
      this.labelScaleFactorBiomass.Text = "Biomass";
      // 
      // checkBoxEnableScaleFactors
      // 
      this.checkBoxEnableScaleFactors.AutoSize = true;
      this.checkBoxEnableScaleFactors.Location = new System.Drawing.Point(29, 25);
      this.checkBoxEnableScaleFactors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableScaleFactors.Name = "checkBoxEnableScaleFactors";
      this.checkBoxEnableScaleFactors.Size = new System.Drawing.Size(288, 20);
      this.checkBoxEnableScaleFactors.TabIndex = 0;
      this.checkBoxEnableScaleFactors.Text = "Specify Scale Factors for Output Report File";
      this.checkBoxEnableScaleFactors.UseVisualStyleBackColor = true;
      this.checkBoxEnableScaleFactors.CheckedChanged += new System.EventHandler(this.CheckBoxScaleFactors_CheckedChanged);
      // 
      // groupRetroAdjustment
      // 
      this.groupRetroAdjustment.Controls.Add(this.checkBoxEnableRetroAdjustment);
      this.groupRetroAdjustment.Controls.Add(this.dataGridRetroAdjustment);
      this.groupRetroAdjustment.Location = new System.Drawing.Point(39, 348);
      this.groupRetroAdjustment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupRetroAdjustment.Name = "groupRetroAdjustment";
      this.groupRetroAdjustment.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupRetroAdjustment.Size = new System.Drawing.Size(541, 274);
      this.groupRetroAdjustment.TabIndex = 2;
      this.groupRetroAdjustment.TabStop = false;
      this.groupRetroAdjustment.Text = "Retrospective Adjustment Factors";
      // 
      // checkBoxEnableRetroAdjustment
      // 
      this.checkBoxEnableRetroAdjustment.AutoSize = true;
      this.checkBoxEnableRetroAdjustment.Location = new System.Drawing.Point(23, 25);
      this.checkBoxEnableRetroAdjustment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableRetroAdjustment.Name = "checkBoxEnableRetroAdjustment";
      this.checkBoxEnableRetroAdjustment.Size = new System.Drawing.Size(278, 20);
      this.checkBoxEnableRetroAdjustment.TabIndex = 1;
      this.checkBoxEnableRetroAdjustment.Text = "Specify Retrospective Adjustment Factors";
      this.checkBoxEnableRetroAdjustment.UseVisualStyleBackColor = true;
      this.checkBoxEnableRetroAdjustment.CheckedChanged += new System.EventHandler(this.CheckBoxRetroAdjustment_CheckedChanged);
      // 
      // dataGridRetroAdjustment
      // 
      this.dataGridRetroAdjustment.AllowUserToAddRows = false;
      this.dataGridRetroAdjustment.AllowUserToDeleteRows = false;
      this.dataGridRetroAdjustment.AllowUserToResizeRows = false;
      this.dataGridRetroAdjustment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dataGridRetroAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridRetroAdjustment.ColumnHeadersVisible = false;
      this.dataGridRetroAdjustment.Location = new System.Drawing.Point(23, 49);
      this.dataGridRetroAdjustment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.dataGridRetroAdjustment.Name = "dataGridRetroAdjustment";
      this.dataGridRetroAdjustment.nftReadOnly = false;
      this.dataGridRetroAdjustment.RowHeadersWidth = 75;
      this.dataGridRetroAdjustment.Size = new System.Drawing.Size(475, 210);
      this.dataGridRetroAdjustment.TabIndex = 0;
      this.dataGridRetroAdjustment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridRetroAdjustment_CellFormatting);
      // 
      // comboBoxOutputViewerProgram
      // 
      this.comboBoxOutputViewerProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxOutputViewerProgram.Items.AddRange(new object[] {
            "System Default",
            "Notepad",
            "None"});
      this.comboBoxOutputViewerProgram.Location = new System.Drawing.Point(24, 39);
      this.comboBoxOutputViewerProgram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.comboBoxOutputViewerProgram.Name = "comboBoxOutputViewerProgram";
      this.comboBoxOutputViewerProgram.Size = new System.Drawing.Size(451, 24);
      this.comboBoxOutputViewerProgram.TabIndex = 1;
      // 
      // labelOutputViewerProgram
      // 
      this.labelOutputViewerProgram.AutoSize = true;
      this.labelOutputViewerProgram.Location = new System.Drawing.Point(20, 20);
      this.labelOutputViewerProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelOutputViewerProgram.Name = "labelOutputViewerProgram";
      this.labelOutputViewerProgram.Size = new System.Drawing.Size(234, 16);
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
      this.groupBox_StockSummmaryFlag.Location = new System.Drawing.Point(39, 18);
      this.groupBox_StockSummmaryFlag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox_StockSummmaryFlag.Name = "groupBox_StockSummmaryFlag";
      this.groupBox_StockSummmaryFlag.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox_StockSummmaryFlag.Size = new System.Drawing.Size(541, 164);
      this.groupBox_StockSummmaryFlag.TabIndex = 0;
      this.groupBox_StockSummmaryFlag.TabStop = false;
      this.groupBox_StockSummmaryFlag.Text = "Stock Distribution Summary and Auxiliary Data Files";
      // 
      // radioButtonStockAge_ExcludeStockNumAux
      // 
      this.radioButtonStockAge_ExcludeStockNumAux.AutoSize = true;
      this.radioButtonStockAge_ExcludeStockNumAux.Location = new System.Drawing.Point(23, 134);
      this.radioButtonStockAge_ExcludeStockNumAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioButtonStockAge_ExcludeStockNumAux.Name = "radioButtonStockAge_ExcludeStockNumAux";
      this.radioButtonStockAge_ExcludeStockNumAux.Size = new System.Drawing.Size(370, 20);
      this.radioButtonStockAge_ExcludeStockNumAux.TabIndex = 4;
      this.radioButtonStockAge_ExcludeStockNumAux.TabStop = true;
      this.radioButtonStockAge_ExcludeStockNumAux.Text = "Output Stock Of Age, Auxiliary Files EXCEPT Stock of Age";
      this.radioButtonStockAge_ExcludeStockNumAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_ExcludeStockNumAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_ExcludeStockNumAux_CheckedChanged);
      // 
      // radioButtonStockAge_NoAux
      // 
      this.radioButtonStockAge_NoAux.AutoSize = true;
      this.radioButtonStockAge_NoAux.Location = new System.Drawing.Point(23, 106);
      this.radioButtonStockAge_NoAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioButtonStockAge_NoAux.Name = "radioButtonStockAge_NoAux";
      this.radioButtonStockAge_NoAux.Size = new System.Drawing.Size(258, 20);
      this.radioButtonStockAge_NoAux.TabIndex = 3;
      this.radioButtonStockAge_NoAux.TabStop = true;
      this.radioButtonStockAge_NoAux.Text = "Ouptut Stock Of Age, NO Auxiilary Files";
      this.radioButtonStockAge_NoAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_NoAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_NoAux_CheckedChanged);
      // 
      // radioButtonNoStockAge_NoAux
      // 
      this.radioButtonNoStockAge_NoAux.AutoSize = true;
      this.radioButtonNoStockAge_NoAux.Location = new System.Drawing.Point(23, 78);
      this.radioButtonNoStockAge_NoAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioButtonNoStockAge_NoAux.Name = "radioButtonNoStockAge_NoAux";
      this.radioButtonNoStockAge_NoAux.Size = new System.Drawing.Size(240, 20);
      this.radioButtonNoStockAge_NoAux.TabIndex = 2;
      this.radioButtonNoStockAge_NoAux.TabStop = true;
      this.radioButtonNoStockAge_NoAux.Text = "NO Stock Of Age and Auxiliary Files";
      this.radioButtonNoStockAge_NoAux.UseVisualStyleBackColor = true;
      this.radioButtonNoStockAge_NoAux.CheckedChanged += new System.EventHandler(this.radioButtonNoStockAge_NoAux_CheckedChanged);
      // 
      // radioButtonStockAge_AllAux
      // 
      this.radioButtonStockAge_AllAux.AutoSize = true;
      this.radioButtonStockAge_AllAux.Location = new System.Drawing.Point(23, 49);
      this.radioButtonStockAge_AllAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioButtonStockAge_AllAux.Name = "radioButtonStockAge_AllAux";
      this.radioButtonStockAge_AllAux.Size = new System.Drawing.Size(285, 20);
      this.radioButtonStockAge_AllAux.TabIndex = 1;
      this.radioButtonStockAge_AllAux.TabStop = true;
      this.radioButtonStockAge_AllAux.Text = "Output Stock Of Age AND ALL Auxiliary files";
      this.radioButtonStockAge_AllAux.UseVisualStyleBackColor = true;
      this.radioButtonStockAge_AllAux.CheckedChanged += new System.EventHandler(this.radioButtonStockAge_AllAux_CheckedChanged);
      // 
      // radioButtonNoStockAge_ExcludeStockNumAux
      // 
      this.radioButtonNoStockAge_ExcludeStockNumAux.AutoSize = true;
      this.radioButtonNoStockAge_ExcludeStockNumAux.Location = new System.Drawing.Point(23, 21);
      this.radioButtonNoStockAge_ExcludeStockNumAux.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioButtonNoStockAge_ExcludeStockNumAux.Name = "radioButtonNoStockAge_ExcludeStockNumAux";
      this.radioButtonNoStockAge_ExcludeStockNumAux.Size = new System.Drawing.Size(442, 20);
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
      this.groupOutputViewer.Location = new System.Drawing.Point(588, 55);
      this.groupOutputViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupOutputViewer.Name = "groupOutputViewer";
      this.groupOutputViewer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupOutputViewer.Size = new System.Drawing.Size(520, 80);
      this.groupOutputViewer.TabIndex = 3;
      this.groupOutputViewer.TabStop = false;
      this.groupOutputViewer.Text = "Output File Viewer";
      // 
      // checkBoxEnableVer40Format
      // 
      this.checkBoxEnableVer40Format.AutoSize = true;
      this.checkBoxEnableVer40Format.Location = new System.Drawing.Point(589, 27);
      this.checkBoxEnableVer40Format.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBoxEnableVer40Format.Name = "checkBoxEnableVer40Format";
      this.checkBoxEnableVer40Format.Size = new System.Drawing.Size(316, 20);
      this.checkBoxEnableVer40Format.TabIndex = 7;
      this.checkBoxEnableVer40Format.Text = "Enable AGEPRO VERSION 4.0 input File Format";
      this.checkBoxEnableVer40Format.UseVisualStyleBackColor = true;
      this.checkBoxEnableVer40Format.CheckedChanged += new System.EventHandler(this.checkBoxEnableVer40Format_CheckedChanged);
      // 
      // ControlMiscOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.checkBoxEnableVer40Format);
      this.Controls.Add(this.groupOutputViewer);
      this.Controls.Add(this.groupBox_StockSummmaryFlag);
      this.Controls.Add(this.groupRetroAdjustment);
      this.Controls.Add(this.groupScaleFactors);
      this.Controls.Add(this.groupBounds);
      this.Controls.Add(this.groupRefpoints);
      this.Controls.Add(this.groupOuputOptions);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "ControlMiscOptions";
      this.Size = new System.Drawing.Size(1200, 640);
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
      this.groupBox_StockSummmaryFlag.ResumeLayout(false);
      this.groupBox_StockSummmaryFlag.PerformLayout();
      this.groupOutputViewer.ResumeLayout(false);
      this.groupOutputViewer.PerformLayout();
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
  }
}
