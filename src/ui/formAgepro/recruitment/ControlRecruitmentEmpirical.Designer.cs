namespace Nmfs.Agepro.Gui
{
    partial class ControlRecruitmentEmpirical
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
            this.groupEmpiricalParameters = new System.Windows.Forms.GroupBox();
            this.textBoxSSBHinge = new System.Windows.Forms.TextBox();
            this.labelSSBHinge = new System.Windows.Forms.Label();
            this.buttonSetParameters = new System.Windows.Forms.Button();
            this.spinBoxNumObservations = new System.Windows.Forms.NumericUpDown();
            this.labelNumObservations = new System.Windows.Forms.Label();
            this.labelObservations = new System.Windows.Forms.Label();
            this.dataGridRecruitTable = new Nmfs.Agepro.Gui.NftDataGridView();
            this.groupEmpiricalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupEmpiricalParameters
            // 
            this.groupEmpiricalParameters.Controls.Add(this.textBoxSSBHinge);
            this.groupEmpiricalParameters.Controls.Add(this.labelSSBHinge);
            this.groupEmpiricalParameters.Controls.Add(this.buttonSetParameters);
            this.groupEmpiricalParameters.Controls.Add(this.spinBoxNumObservations);
            this.groupEmpiricalParameters.Controls.Add(this.labelNumObservations);
            this.groupEmpiricalParameters.Location = new System.Drawing.Point(0, 0);
            this.groupEmpiricalParameters.Name = "groupEmpiricalParameters";
            this.groupEmpiricalParameters.Size = new System.Drawing.Size(574, 90);
            this.groupEmpiricalParameters.TabIndex = 0;
            this.groupEmpiricalParameters.TabStop = false;
            // 
            // textBoxSSBHinge
            // 
            this.textBoxSSBHinge.Location = new System.Drawing.Point(225, 51);
            this.textBoxSSBHinge.Name = "textBoxSSBHinge";
            this.textBoxSSBHinge.Size = new System.Drawing.Size(120, 20);
            this.textBoxSSBHinge.TabIndex = 4;
            this.textBoxSSBHinge.Visible = false;
            // 
            // labelSSBHinge
            // 
            this.labelSSBHinge.AutoSize = true;
            this.labelSSBHinge.Location = new System.Drawing.Point(18, 56);
            this.labelSSBHinge.Name = "labelSSBHinge";
            this.labelSSBHinge.Size = new System.Drawing.Size(89, 13);
            this.labelSSBHinge.TabIndex = 3;
            this.labelSSBHinge.Text = "SSB Hinge Value";
            this.labelSSBHinge.Visible = false;
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
            // spinBoxNumObservations
            // 
            this.spinBoxNumObservations.Location = new System.Drawing.Point(225, 14);
            this.spinBoxNumObservations.Name = "spinBoxNumObservations";
            this.spinBoxNumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxNumObservations.TabIndex = 1;
            // 
            // labelNumObservations
            // 
            this.labelNumObservations.AutoSize = true;
            this.labelNumObservations.Location = new System.Drawing.Point(18, 16);
            this.labelNumObservations.Name = "labelNumObservations";
            this.labelNumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelNumObservations.TabIndex = 0;
            this.labelNumObservations.Text = "Number Of Observations";
            // 
            // labelObservations
            // 
            this.labelObservations.AutoSize = true;
            this.labelObservations.Location = new System.Drawing.Point(-3, 101);
            this.labelObservations.Name = "labelObservations";
            this.labelObservations.Size = new System.Drawing.Size(69, 13);
            this.labelObservations.TabIndex = 1;
            this.labelObservations.Text = "Observations";
            // 
            // dataGridRecruitTable
            // 
            this.dataGridRecruitTable.AllowUserToAddRows = false;
            this.dataGridRecruitTable.AllowUserToDeleteRows = false;
            this.dataGridRecruitTable.AllowUserToResizeRows = false;
            this.dataGridRecruitTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRecruitTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridRecruitTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecruitTable.Location = new System.Drawing.Point(0, 117);
            this.dataGridRecruitTable.Name = "dataGridRecruitTable";
            this.dataGridRecruitTable.nftReadOnly = false;
            this.dataGridRecruitTable.RowHeadersWidth = 70;
            this.dataGridRecruitTable.Size = new System.Drawing.Size(855, 223);
            this.dataGridRecruitTable.TabIndex = 2;
            this.dataGridRecruitTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridRecruitTable_CellFormatting);
            // 
            // ControlRecruitmentEmpirical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridRecruitTable);
            this.Controls.Add(this.labelObservations);
            this.Controls.Add(this.groupEmpiricalParameters);
            this.MinimumSize = new System.Drawing.Size(870, 355);
            this.Name = "ControlRecruitmentEmpirical";
            this.Size = new System.Drawing.Size(870, 355);
            this.groupEmpiricalParameters.ResumeLayout(false);
            this.groupEmpiricalParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumObservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupEmpiricalParameters;
        protected System.Windows.Forms.Button buttonSetParameters;
        protected System.Windows.Forms.NumericUpDown spinBoxNumObservations;
        protected System.Windows.Forms.Label labelNumObservations;
        protected System.Windows.Forms.Label labelObservations;
        protected Nmfs.Agepro.Gui.NftDataGridView dataGridRecruitTable;
        protected System.Windows.Forms.TextBox textBoxSSBHinge;
        protected System.Windows.Forms.Label labelSSBHinge;
    }
}
