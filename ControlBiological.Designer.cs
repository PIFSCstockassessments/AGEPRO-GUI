namespace AGEPRO.GUI
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
            this.tabControlBiological.SuspendLayout();
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
            this.tabFractionMortality.Location = new System.Drawing.Point(4, 22);
            this.tabFractionMortality.Name = "tabFractionMortality";
            this.tabFractionMortality.Padding = new System.Windows.Forms.Padding(3);
            this.tabFractionMortality.Size = new System.Drawing.Size(886, 456);
            this.tabFractionMortality.TabIndex = 1;
            this.tabFractionMortality.Text = "Fraction Mortality";
            this.tabFractionMortality.UseVisualStyleBackColor = true;
            // 
            // ControlBiological
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlBiological);
            this.Name = "ControlBiological";
            this.Size = new System.Drawing.Size(900, 500);
            this.tabControlBiological.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlBiological;
        private System.Windows.Forms.TabPage tabMaturity;
        private System.Windows.Forms.TabPage tabFractionMortality;





    }
}
