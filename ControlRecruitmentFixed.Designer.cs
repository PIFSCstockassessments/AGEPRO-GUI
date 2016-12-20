namespace AGEPRO.GUI
{
    partial class ControlRecruitmentFixed
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
            this.dataGridFixedRecruitment = new AGEPRO.GUI.NftDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFixedRecruitment)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFixedRecruitment
            // 
            this.dataGridFixedRecruitment.AllowUserToAddRows = false;
            this.dataGridFixedRecruitment.AllowUserToDeleteRows = false;
            this.dataGridFixedRecruitment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridFixedRecruitment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFixedRecruitment.Location = new System.Drawing.Point(0, 18);
            this.dataGridFixedRecruitment.Name = "dataGridFixedRecruitment";
            this.dataGridFixedRecruitment.RowHeadersWidth = 81;
            this.dataGridFixedRecruitment.Size = new System.Drawing.Size(735, 312);
            this.dataGridFixedRecruitment.TabIndex = 0;
            this.dataGridFixedRecruitment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridFixedRecruitment_CellFormatting);
            // 
            // ControlRecruitmentFixed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridFixedRecruitment);
            this.MinimumSize = new System.Drawing.Size(870, 355);
            this.Name = "ControlRecruitmentFixed";
            this.Size = new System.Drawing.Size(870, 355);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFixedRecruitment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AGEPRO.GUI.NftDataGridView dataGridFixedRecruitment;
    }
}
