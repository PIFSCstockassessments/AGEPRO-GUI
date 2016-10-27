namespace AGEPRO.GUI
{
    partial class ControlHarvestScenario
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
            this.labelHarvestScenario = new System.Windows.Forms.Label();
            this.dataGridHarvestScenarioTable = new System.Windows.Forms.DataGridView();
            this.groupAltCalcParameters = new System.Windows.Forms.GroupBox();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.radioPStar = new System.Windows.Forms.RadioButton();
            this.radioRebuilderTarget = new System.Windows.Forms.RadioButton();
            this.panelAltCalcParameters = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHarvestScenarioTable)).BeginInit();
            this.groupAltCalcParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHarvestScenario
            // 
            this.labelHarvestScenario.AutoSize = true;
            this.labelHarvestScenario.Location = new System.Drawing.Point(26, 22);
            this.labelHarvestScenario.Name = "labelHarvestScenario";
            this.labelHarvestScenario.Size = new System.Drawing.Size(89, 13);
            this.labelHarvestScenario.TabIndex = 0;
            this.labelHarvestScenario.Text = "Harvest Scenario";
            // 
            // dataGridHarvestScenarioTable
            // 
            this.dataGridHarvestScenarioTable.AllowUserToAddRows = false;
            this.dataGridHarvestScenarioTable.AllowUserToDeleteRows = false;
            this.dataGridHarvestScenarioTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHarvestScenarioTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHarvestScenarioTable.Location = new System.Drawing.Point(29, 38);
            this.dataGridHarvestScenarioTable.Name = "dataGridHarvestScenarioTable";
            this.dataGridHarvestScenarioTable.Size = new System.Drawing.Size(360, 460);
            this.dataGridHarvestScenarioTable.TabIndex = 1;
            this.dataGridHarvestScenarioTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridHarvestScenarioTable_CellFormatting);
            // 
            // groupAltCalcParameters
            // 
            this.groupAltCalcParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAltCalcParameters.Controls.Add(this.radioNone);
            this.groupAltCalcParameters.Controls.Add(this.radioPStar);
            this.groupAltCalcParameters.Controls.Add(this.radioRebuilderTarget);
            this.groupAltCalcParameters.Location = new System.Drawing.Point(411, 22);
            this.groupAltCalcParameters.Name = "groupAltCalcParameters";
            this.groupAltCalcParameters.Size = new System.Drawing.Size(465, 69);
            this.groupAltCalcParameters.TabIndex = 2;
            this.groupAltCalcParameters.TabStop = false;
            this.groupAltCalcParameters.Text = "Additional Calcuations";
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Location = new System.Drawing.Point(294, 32);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(166, 17);
            this.radioNone.TabIndex = 2;
            this.radioNone.Text = "None (Only Harvest Scenario)";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radioNone_CheckedChanged);
            // 
            // radioPStar
            // 
            this.radioPStar.AutoSize = true;
            this.radioPStar.Location = new System.Drawing.Point(154, 32);
            this.radioPStar.Name = "radioPStar";
            this.radioPStar.Size = new System.Drawing.Size(134, 17);
            this.radioPStar.TabIndex = 1;
            this.radioPStar.Text = "Perform P-Star Analysis";
            this.radioPStar.UseVisualStyleBackColor = true;
            this.radioPStar.CheckedChanged += new System.EventHandler(this.radioPStar_CheckedChanged);
            // 
            // radioRebuilderTarget
            // 
            this.radioRebuilderTarget.AutoSize = true;
            this.radioRebuilderTarget.Location = new System.Drawing.Point(15, 32);
            this.radioRebuilderTarget.Name = "radioRebuilderTarget";
            this.radioRebuilderTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioRebuilderTarget.Size = new System.Drawing.Size(133, 17);
            this.radioRebuilderTarget.TabIndex = 0;
            this.radioRebuilderTarget.Text = "Apply Rebuilder Target";
            this.radioRebuilderTarget.UseVisualStyleBackColor = true;
            this.radioRebuilderTarget.CheckedChanged += new System.EventHandler(this.radioRebuilderTarget_CheckedChanged);
            // 
            // panelAltCalcParameters
            // 
            this.panelAltCalcParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAltCalcParameters.Location = new System.Drawing.Point(411, 98);
            this.panelAltCalcParameters.MinimumSize = new System.Drawing.Size(480, 400);
            this.panelAltCalcParameters.Name = "panelAltCalcParameters";
            this.panelAltCalcParameters.Size = new System.Drawing.Size(485, 400);
            this.panelAltCalcParameters.TabIndex = 3;
            // 
            // ControlHarvestScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHarvestScenario);
            this.Controls.Add(this.panelAltCalcParameters);
            this.Controls.Add(this.groupAltCalcParameters);
            this.Controls.Add(this.dataGridHarvestScenarioTable);
            this.Name = "ControlHarvestScenario";
            this.Size = new System.Drawing.Size(900, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHarvestScenarioTable)).EndInit();
            this.groupAltCalcParameters.ResumeLayout(false);
            this.groupAltCalcParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHarvestScenario;
        private System.Windows.Forms.DataGridView dataGridHarvestScenarioTable;
        private System.Windows.Forms.GroupBox groupAltCalcParameters;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.RadioButton radioPStar;
        private System.Windows.Forms.RadioButton radioRebuilderTarget;
        private System.Windows.Forms.Panel panelAltCalcParameters;
    }
}
