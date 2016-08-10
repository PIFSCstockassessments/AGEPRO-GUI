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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioParameterFromFile = new System.Windows.Forms.RadioButton();
            this.radioParameterFromUser = new System.Windows.Forms.RadioButton();
            this.tableLayoutStochasticAgePanel.SuspendLayout();
            this.groupOptions.SuspendLayout();
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
            this.tableLayoutStochasticAgePanel.Controls.Add(this.groupOptions, 1, 1);
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
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.radioParameterFromFile);
            this.groupOptions.Controls.Add(this.radioParameterFromUser);
            this.groupOptions.Location = new System.Drawing.Point(23, 23);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(789, 52);
            this.groupOptions.TabIndex = 4;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // radioParameterFromFile
            // 
            this.radioParameterFromFile.AutoSize = true;
            this.radioParameterFromFile.Location = new System.Drawing.Point(301, 20);
            this.radioParameterFromFile.Name = "radioParameterFromFile";
            this.radioParameterFromFile.Size = new System.Drawing.Size(203, 17);
            this.radioParameterFromFile.TabIndex = 1;
            this.radioParameterFromFile.TabStop = true;
            this.radioParameterFromFile.Text = "Read Stochtastic Parameter From File";
            this.radioParameterFromFile.UseVisualStyleBackColor = true;
            // 
            // radioParameterFromUser
            // 
            this.radioParameterFromUser.AutoSize = true;
            this.radioParameterFromUser.Location = new System.Drawing.Point(26, 20);
            this.radioParameterFromUser.Name = "radioParameterFromUser";
            this.radioParameterFromUser.Size = new System.Drawing.Size(232, 17);
            this.radioParameterFromUser.TabIndex = 0;
            this.radioParameterFromUser.TabStop = true;
            this.radioParameterFromUser.Text = "User Specified Stochastic Parameter at Age";
            this.radioParameterFromUser.UseVisualStyleBackColor = true;
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
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutStochasticAgePanel;
        private System.Windows.Forms.Panel panelStochasticParameterAge;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.RadioButton radioParameterFromFile;
        private System.Windows.Forms.RadioButton radioParameterFromUser;
    }
}
