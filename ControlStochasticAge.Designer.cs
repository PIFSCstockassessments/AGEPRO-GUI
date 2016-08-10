namespace AGEPRO.GUI
{
    partial class ControlStochasticAge
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
            this.tableLayoutStochasticAgePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelStochasticParameterAge = new System.Windows.Forms.Panel();
            this.tableLayoutStochasticAgePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutStochasticAgePanel
            // 
            this.tableLayoutStochasticAgePanel.AutoSize = true;
            this.tableLayoutStochasticAgePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutStochasticAgePanel.ColumnCount = 2;
            this.tableLayoutStochasticAgePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStochasticAgePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStochasticAgePanel.Controls.Add(this.panelStochasticParameterAge, 1, 2);
            this.tableLayoutStochasticAgePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStochasticAgePanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutStochasticAgePanel.MinimumSize = new System.Drawing.Size(900, 480);
            this.tableLayoutStochasticAgePanel.Name = "tableLayoutStochasticAgePanel";
            this.tableLayoutStochasticAgePanel.RowCount = 3;
            this.tableLayoutStochasticAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutStochasticAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutStochasticAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutStochasticAgePanel.Size = new System.Drawing.Size(900, 480);
            this.tableLayoutStochasticAgePanel.TabIndex = 2;
            // 
            // panelStochasticParameterAge
            // 
            this.panelStochasticParameterAge.AutoSize = true;
            this.panelStochasticParameterAge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStochasticParameterAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStochasticParameterAge.Location = new System.Drawing.Point(23, 92);
            this.panelStochasticParameterAge.MinimumSize = new System.Drawing.Size(873, 350);
            this.panelStochasticParameterAge.Name = "panelStochasticParameterAge";
            this.panelStochasticParameterAge.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.panelStochasticParameterAge.Size = new System.Drawing.Size(874, 385);
            this.panelStochasticParameterAge.TabIndex = 3;
            // 
            // ControlStochasticAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutStochasticAgePanel);
            this.Name = "ControlStochasticAge";
            this.Size = new System.Drawing.Size(900, 480);
            this.tableLayoutStochasticAgePanel.ResumeLayout(false);
            this.tableLayoutStochasticAgePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutStochasticAgePanel;
        private System.Windows.Forms.Panel panelStochasticParameterAge;
    }
}
