namespace Nmfs.Agepro.Gui
{
    partial class ControlBiological
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
      this.tabControlBiological = new System.Windows.Forms.TabControl();
      this.tabMaturity = new System.Windows.Forms.TabPage();
      this.tabFractionMortality = new System.Windows.Forms.TabPage();
      this.labelFractionMortality = new System.Windows.Forms.Label();
      this.dataGridFractionMortality = new Nmfs.Agepro.Gui.NftDataGridView();
      this.checkBoxFractionMortalityTimeVarying = new System.Windows.Forms.CheckBox();
      this.tabControlBiological.SuspendLayout();
      this.tabFractionMortality.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridFractionMortality)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControlBiological
      // 
      this.tabControlBiological.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControlBiological.Controls.Add(this.tabMaturity);
      this.tabControlBiological.Controls.Add(this.tabFractionMortality);
      this.tabControlBiological.Location = new System.Drawing.Point(3, 15);
      this.tabControlBiological.Name = "tabControlBiological";
      this.tabControlBiological.SelectedIndex = 0;
      this.tabControlBiological.Size = new System.Drawing.Size(894, 482);
      this.tabControlBiological.TabIndex = 0;
      // 
      // tabMaturity
      // 
      this.tabMaturity.Location = new System.Drawing.Point(4, 22);
      this.tabMaturity.Name = "tabMaturity";
      this.tabMaturity.Padding = new System.Windows.Forms.Padding(3);
      this.tabMaturity.Size = new System.Drawing.Size(886, 456);
      this.tabMaturity.TabIndex = 0;
      this.tabMaturity.Text = "Maturity";
      this.tabMaturity.UseVisualStyleBackColor = true;
      // 
      // tabFractionMortality
      // 
      this.tabFractionMortality.Controls.Add(this.checkBoxFractionMortalityTimeVarying);
      this.tabFractionMortality.Controls.Add(this.dataGridFractionMortality);
      this.tabFractionMortality.Controls.Add(this.labelFractionMortality);
      this.tabFractionMortality.Location = new System.Drawing.Point(4, 22);
      this.tabFractionMortality.Name = "tabFractionMortality";
      this.tabFractionMortality.Padding = new System.Windows.Forms.Padding(3);
      this.tabFractionMortality.Size = new System.Drawing.Size(886, 456);
      this.tabFractionMortality.TabIndex = 1;
      this.tabFractionMortality.Text = "Fraction Mortality";
      this.tabFractionMortality.UseVisualStyleBackColor = true;
      // 
      // labelFractionMortality
      // 
      this.labelFractionMortality.AutoSize = true;
      this.labelFractionMortality.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelFractionMortality.Location = new System.Drawing.Point(19, 31);
      this.labelFractionMortality.Name = "labelFractionMortality";
      this.labelFractionMortality.Size = new System.Drawing.Size(209, 13);
      this.labelFractionMortality.TabIndex = 0;
      this.labelFractionMortality.Text = "Fraction Mortality Prior to Spawning";
      // 
      // dataGridFractionMortality
      // 
      this.dataGridFractionMortality.AllowUserToAddRows = false;
      this.dataGridFractionMortality.AllowUserToDeleteRows = false;
      this.dataGridFractionMortality.AllowUserToResizeRows = false;
      this.dataGridFractionMortality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridFractionMortality.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dataGridFractionMortality.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridFractionMortality.Location = new System.Drawing.Point(22, 50);
      this.dataGridFractionMortality.Name = "dataGridFractionMortality";
      this.dataGridFractionMortality.nftReadOnly = false;
      this.dataGridFractionMortality.RowHeadersWidth = 180;
      this.dataGridFractionMortality.Size = new System.Drawing.Size(832, 89);
      this.dataGridFractionMortality.TabIndex = 1;
      this.dataGridFractionMortality.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridFractionMortality_CellFormatting);
      // 
      // checkBoxFractionMortalityTimeVarying
      // 
      this.checkBoxFractionMortalityTimeVarying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBoxFractionMortalityTimeVarying.AutoSize = true;
      this.checkBoxFractionMortalityTimeVarying.Location = new System.Drawing.Point(756, 30);
      this.checkBoxFractionMortalityTimeVarying.Name = "checkBoxFractionMortalityTimeVarying";
      this.checkBoxFractionMortalityTimeVarying.Size = new System.Drawing.Size(87, 17);
      this.checkBoxFractionMortalityTimeVarying.TabIndex = 2;
      this.checkBoxFractionMortalityTimeVarying.Text = "Time Varying";
      this.checkBoxFractionMortalityTimeVarying.UseVisualStyleBackColor = true;
      this.checkBoxFractionMortalityTimeVarying.CheckedChanged += new System.EventHandler(this.checkBoxFractionMortalityTimeVarying_CheckedChanged);
      // 
      // ControlBiological
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tabControlBiological);
      this.Name = "ControlBiological";
      this.Size = new System.Drawing.Size(900, 500);
      this.tabControlBiological.ResumeLayout(false);
      this.tabFractionMortality.ResumeLayout(false);
      this.tabFractionMortality.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridFractionMortality)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlBiological;
        private System.Windows.Forms.TabPage tabMaturity;
        private System.Windows.Forms.TabPage tabFractionMortality;
    private System.Windows.Forms.CheckBox checkBoxFractionMortalityTimeVarying;
    private NftDataGridView dataGridFractionMortality;
    private System.Windows.Forms.Label labelFractionMortality;
  }
}
