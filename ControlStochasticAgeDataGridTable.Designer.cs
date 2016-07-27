namespace AGEPRO.GUI
{
    partial class ControlStochasticAgeDataGridTable
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
            this.labelStochasticAgeTable = new System.Windows.Forms.Label();
            this.dataGridStochasticAgeTable = new System.Windows.Forms.DataGridView();
            this.labelCVTable = new System.Windows.Forms.Label();
            this.dataGridCVTable = new System.Windows.Forms.DataGridView();
            this.checkBoxTimeVarying = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStochasticAgeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCVTable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStochasticAgeTable
            // 
            this.labelStochasticAgeTable.AutoSize = true;
            this.labelStochasticAgeTable.Location = new System.Drawing.Point(0, 9);
            this.labelStochasticAgeTable.Name = "labelStochasticAgeTable";
            this.labelStochasticAgeTable.Size = new System.Drawing.Size(160, 13);
            this.labelStochasticAgeTable.TabIndex = 0;
            this.labelStochasticAgeTable.Text = "Stochastic Parameter Age Table";
            // 
            // dataGridStochasticAgeTable
            // 
            this.dataGridStochasticAgeTable.AllowUserToAddRows = false;
            this.dataGridStochasticAgeTable.AllowUserToDeleteRows = false;
            this.dataGridStochasticAgeTable.AllowUserToResizeRows = false;
            this.dataGridStochasticAgeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStochasticAgeTable.Location = new System.Drawing.Point(3, 26);
            this.dataGridStochasticAgeTable.Name = "dataGridStochasticAgeTable";
            this.dataGridStochasticAgeTable.RowHeadersWidth = 100;
            this.dataGridStochasticAgeTable.Size = new System.Drawing.Size(864, 213);
            this.dataGridStochasticAgeTable.TabIndex = 1;
            this.dataGridStochasticAgeTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridStochasticAgeTable_CellFormatting);
            // 
            // labelCVTable
            // 
            this.labelCVTable.AutoSize = true;
            this.labelCVTable.Location = new System.Drawing.Point(0, 252);
            this.labelCVTable.Name = "labelCVTable";
            this.labelCVTable.Size = new System.Drawing.Size(115, 13);
            this.labelCVTable.TabIndex = 2;
            this.labelCVTable.Text = "Coefficient Of Variation";
            // 
            // dataGridCVTable
            // 
            this.dataGridCVTable.AllowUserToAddRows = false;
            this.dataGridCVTable.AllowUserToDeleteRows = false;
            this.dataGridCVTable.AllowUserToResizeRows = false;
            this.dataGridCVTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCVTable.Location = new System.Drawing.Point(3, 268);
            this.dataGridCVTable.Name = "dataGridCVTable";
            this.dataGridCVTable.RowHeadersWidth = 100;
            this.dataGridCVTable.Size = new System.Drawing.Size(864, 79);
            this.dataGridCVTable.TabIndex = 3;
            this.dataGridCVTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridCVTable_CellFormatting);
            // 
            // checkBoxTimeVarying
            // 
            this.checkBoxTimeVarying.AutoSize = true;
            this.checkBoxTimeVarying.Location = new System.Drawing.Point(769, 9);
            this.checkBoxTimeVarying.Name = "checkBoxTimeVarying";
            this.checkBoxTimeVarying.Size = new System.Drawing.Size(87, 17);
            this.checkBoxTimeVarying.TabIndex = 4;
            this.checkBoxTimeVarying.Text = "Time Varying";
            this.checkBoxTimeVarying.UseVisualStyleBackColor = true;
            // 
            // ControlStochasticAgeDataGridTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxTimeVarying);
            this.Controls.Add(this.dataGridCVTable);
            this.Controls.Add(this.labelCVTable);
            this.Controls.Add(this.dataGridStochasticAgeTable);
            this.Controls.Add(this.labelStochasticAgeTable);
            this.Name = "ControlStochasticAgeDataGridTable";
            this.Size = new System.Drawing.Size(870, 350);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStochasticAgeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCVTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStochasticAgeTable;
        private System.Windows.Forms.DataGridView dataGridStochasticAgeTable;
        private System.Windows.Forms.Label labelCVTable;
        private System.Windows.Forms.DataGridView dataGridCVTable;
        private System.Windows.Forms.CheckBox checkBoxTimeVarying;
    }
}
