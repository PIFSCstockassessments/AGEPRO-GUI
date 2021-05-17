namespace Nmfs.Agepro.Gui
{
    partial class ControlRecruitmentMarkovMatrix
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
            this.spinBoxNumRecruitLevels = new System.Windows.Forms.NumericUpDown();
            this.groupMarkovMatrixParameters = new System.Windows.Forms.GroupBox();
            this.labelNumSSBLevels = new System.Windows.Forms.Label();
            this.buttonSetParameters = new System.Windows.Forms.Button();
            this.spinBoxNumSSBLevels = new System.Windows.Forms.NumericUpDown();
            this.labelNumRecruitLevels = new System.Windows.Forms.Label();
            this.labelRecruitTable = new System.Windows.Forms.Label();
            this.labelSSBTable = new System.Windows.Forms.Label();
            this.labelProbabilityTable = new System.Windows.Forms.Label();
            this.dataGridRecruitTable = new Nmfs.Agepro.Gui.NftDataGridView();
            this.dataGridSSBTable = new Nmfs.Agepro.Gui.NftDataGridView();
            this.dataGridProbabilityTable = new Nmfs.Agepro.Gui.NftDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumRecruitLevels)).BeginInit();
            this.groupMarkovMatrixParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumSSBLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSSBTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProbabilityTable)).BeginInit();
            this.SuspendLayout();
            // 
            // spinBoxNumRecruitLevels
            // 
            this.spinBoxNumRecruitLevels.Location = new System.Drawing.Point(225, 14);
            this.spinBoxNumRecruitLevels.Name = "spinBoxNumRecruitLevels";
            this.spinBoxNumRecruitLevels.Size = new System.Drawing.Size(120, 20);
            this.spinBoxNumRecruitLevels.TabIndex = 1;
            // 
            // groupMarkovMatrixParameters
            // 
            this.groupMarkovMatrixParameters.Controls.Add(this.labelNumSSBLevels);
            this.groupMarkovMatrixParameters.Controls.Add(this.buttonSetParameters);
            this.groupMarkovMatrixParameters.Controls.Add(this.spinBoxNumSSBLevels);
            this.groupMarkovMatrixParameters.Controls.Add(this.spinBoxNumRecruitLevels);
            this.groupMarkovMatrixParameters.Controls.Add(this.labelNumRecruitLevels);
            this.groupMarkovMatrixParameters.Location = new System.Drawing.Point(0, 0);
            this.groupMarkovMatrixParameters.Name = "groupMarkovMatrixParameters";
            this.groupMarkovMatrixParameters.Size = new System.Drawing.Size(574, 70);
            this.groupMarkovMatrixParameters.TabIndex = 1;
            this.groupMarkovMatrixParameters.TabStop = false;
            // 
            // labelNumSSBLevels
            // 
            this.labelNumSSBLevels.AutoSize = true;
            this.labelNumSSBLevels.Location = new System.Drawing.Point(18, 42);
            this.labelNumSSBLevels.Name = "labelNumSSBLevels";
            this.labelNumSSBLevels.Size = new System.Drawing.Size(114, 13);
            this.labelNumSSBLevels.TabIndex = 3;
            this.labelNumSSBLevels.Text = "Number of SSB Levels";
            // 
            // buttonSetParameters
            // 
            this.buttonSetParameters.Location = new System.Drawing.Point(482, 37);
            this.buttonSetParameters.Name = "buttonSetParameters";
            this.buttonSetParameters.Size = new System.Drawing.Size(75, 23);
            this.buttonSetParameters.TabIndex = 2;
            this.buttonSetParameters.Text = "SET";
            this.buttonSetParameters.UseVisualStyleBackColor = true;
            this.buttonSetParameters.Click += new System.EventHandler(this.ButtonSetParameters_Click);
            // 
            // spinBoxNumSSBLevels
            // 
            this.spinBoxNumSSBLevels.Location = new System.Drawing.Point(225, 40);
            this.spinBoxNumSSBLevels.Name = "spinBoxNumSSBLevels";
            this.spinBoxNumSSBLevels.Size = new System.Drawing.Size(120, 20);
            this.spinBoxNumSSBLevels.TabIndex = 1;
            // 
            // labelNumRecruitLevels
            // 
            this.labelNumRecruitLevels.AutoSize = true;
            this.labelNumRecruitLevels.Location = new System.Drawing.Point(18, 16);
            this.labelNumRecruitLevels.Name = "labelNumRecruitLevels";
            this.labelNumRecruitLevels.Size = new System.Drawing.Size(152, 13);
            this.labelNumRecruitLevels.TabIndex = 0;
            this.labelNumRecruitLevels.Text = "Number Of Recruitment Levels";
            // 
            // labelRecruitTable
            // 
            this.labelRecruitTable.AutoSize = true;
            this.labelRecruitTable.Location = new System.Drawing.Point(-3, 73);
            this.labelRecruitTable.Name = "labelRecruitTable";
            this.labelRecruitTable.Size = new System.Drawing.Size(64, 13);
            this.labelRecruitTable.TabIndex = 2;
            this.labelRecruitTable.Text = "Recruitment";
            // 
            // labelSSBTable
            // 
            this.labelSSBTable.AutoSize = true;
            this.labelSSBTable.Location = new System.Drawing.Point(222, 73);
            this.labelSSBTable.Name = "labelSSBTable";
            this.labelSSBTable.Size = new System.Drawing.Size(28, 13);
            this.labelSSBTable.TabIndex = 3;
            this.labelSSBTable.Text = "SSB";
            // 
            // labelProbabilityTable
            // 
            this.labelProbabilityTable.AutoSize = true;
            this.labelProbabilityTable.Location = new System.Drawing.Point(441, 73);
            this.labelProbabilityTable.Name = "labelProbabilityTable";
            this.labelProbabilityTable.Size = new System.Drawing.Size(55, 13);
            this.labelProbabilityTable.TabIndex = 4;
            this.labelProbabilityTable.Text = "Probability";
            // 
            // dataGridRecruitTable
            // 
            this.dataGridRecruitTable.AllowUserToAddRows = false;
            this.dataGridRecruitTable.AllowUserToDeleteRows = false;
            this.dataGridRecruitTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridRecruitTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecruitTable.Location = new System.Drawing.Point(0, 89);
            this.dataGridRecruitTable.Name = "dataGridRecruitTable";
            this.dataGridRecruitTable.RowHeadersWidth = 51;
            this.dataGridRecruitTable.Size = new System.Drawing.Size(202, 240);
            this.dataGridRecruitTable.TabIndex = 5;
            this.dataGridRecruitTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridRecruitTable_CellFormatting);
            // 
            // dataGridSSBTable
            // 
            this.dataGridSSBTable.AllowUserToAddRows = false;
            this.dataGridSSBTable.AllowUserToDeleteRows = false;
            this.dataGridSSBTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridSSBTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSSBTable.Location = new System.Drawing.Point(225, 89);
            this.dataGridSSBTable.Name = "dataGridSSBTable";
            this.dataGridSSBTable.RowHeadersWidth = 51;
            this.dataGridSSBTable.Size = new System.Drawing.Size(202, 240);
            this.dataGridSSBTable.TabIndex = 5;
            this.dataGridSSBTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridSSBTable_CellFormatting);
            // 
            // dataGridProbabilityTable
            // 
            this.dataGridProbabilityTable.AllowUserToAddRows = false;
            this.dataGridProbabilityTable.AllowUserToDeleteRows = false;
            this.dataGridProbabilityTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProbabilityTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProbabilityTable.Location = new System.Drawing.Point(444, 89);
            this.dataGridProbabilityTable.Name = "dataGridProbabilityTable";
            this.dataGridProbabilityTable.RowHeadersWidth = 110;
            this.dataGridProbabilityTable.Size = new System.Drawing.Size(398, 240);
            this.dataGridProbabilityTable.TabIndex = 6;
            this.dataGridProbabilityTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridProbabilityTable_CellFormatting);
            // 
            // ControlRecruitmentMarkovMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridProbabilityTable);
            this.Controls.Add(this.dataGridSSBTable);
            this.Controls.Add(this.dataGridRecruitTable);
            this.Controls.Add(this.labelProbabilityTable);
            this.Controls.Add(this.labelSSBTable);
            this.Controls.Add(this.labelRecruitTable);
            this.Controls.Add(this.groupMarkovMatrixParameters);
            this.MinimumSize = new System.Drawing.Size(870, 355);
            this.Name = "ControlRecruitmentMarkovMatrix";
            this.Size = new System.Drawing.Size(870, 355);
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumRecruitLevels)).EndInit();
            this.groupMarkovMatrixParameters.ResumeLayout(false);
            this.groupMarkovMatrixParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumSSBLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSSBTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProbabilityTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.NumericUpDown spinBoxNumRecruitLevels;
        protected System.Windows.Forms.GroupBox groupMarkovMatrixParameters;
        protected System.Windows.Forms.Label labelNumSSBLevels;
        protected System.Windows.Forms.Button buttonSetParameters;
        protected System.Windows.Forms.NumericUpDown spinBoxNumSSBLevels;
        protected System.Windows.Forms.Label labelNumRecruitLevels;
        private System.Windows.Forms.Label labelRecruitTable;
        private System.Windows.Forms.Label labelSSBTable;
        private System.Windows.Forms.Label labelProbabilityTable;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridRecruitTable;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridSSBTable;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridProbabilityTable;
    }
}
