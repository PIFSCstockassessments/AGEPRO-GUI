namespace AGEPRO.GUI
{
    partial class ControlWeightAge
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
            this.tableLayoutWeightAgePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelStochasticParameterAge = new System.Windows.Forms.Panel();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioWeightsFromUser = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromFile = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromJan1 = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromSSB = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromMidYear = new System.Windows.Forms.RadioButton();
            this.radioWeightsFromCatch = new System.Windows.Forms.RadioButton();
            this.tableLayoutWeightAgePanel.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutWeightAgePanel
            // 
            this.tableLayoutWeightAgePanel.AutoSize = true;
            this.tableLayoutWeightAgePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutWeightAgePanel.ColumnCount = 2;
            this.tableLayoutWeightAgePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutWeightAgePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutWeightAgePanel.Controls.Add(this.panelStochasticParameterAge, 1, 2);
            this.tableLayoutWeightAgePanel.Controls.Add(this.groupOptions, 1, 1);
            this.tableLayoutWeightAgePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutWeightAgePanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutWeightAgePanel.MinimumSize = new System.Drawing.Size(900, 480);
            this.tableLayoutWeightAgePanel.Name = "tableLayoutWeightAgePanel";
            this.tableLayoutWeightAgePanel.RowCount = 3;
            this.tableLayoutWeightAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutWeightAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutWeightAgePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.tableLayoutWeightAgePanel.Size = new System.Drawing.Size(900, 520);
            this.tableLayoutWeightAgePanel.TabIndex = 3;
            // 
            // panelStochasticParameterAge
            // 
            this.panelStochasticParameterAge.AutoSize = true;
            this.panelStochasticParameterAge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStochasticParameterAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStochasticParameterAge.Location = new System.Drawing.Point(23, 118);
            this.panelStochasticParameterAge.MinimumSize = new System.Drawing.Size(873, 350);
            this.panelStochasticParameterAge.Name = "panelStochasticParameterAge";
            this.panelStochasticParameterAge.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.panelStochasticParameterAge.Size = new System.Drawing.Size(874, 399);
            this.panelStochasticParameterAge.TabIndex = 3;
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.radioWeightsFromCatch);
            this.groupOptions.Controls.Add(this.radioWeightsFromMidYear);
            this.groupOptions.Controls.Add(this.radioWeightsFromSSB);
            this.groupOptions.Controls.Add(this.radioWeightsFromJan1);
            this.groupOptions.Controls.Add(this.radioWeightsFromFile);
            this.groupOptions.Controls.Add(this.radioWeightsFromUser);
            this.groupOptions.Location = new System.Drawing.Point(23, 23);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(733, 89);
            this.groupOptions.TabIndex = 4;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // radioWeightsFromUser
            // 
            this.radioWeightsFromUser.AutoSize = true;
            this.radioWeightsFromUser.Location = new System.Drawing.Point(25, 20);
            this.radioWeightsFromUser.Name = "radioWeightsFromUser";
            this.radioWeightsFromUser.Size = new System.Drawing.Size(172, 17);
            this.radioWeightsFromUser.TabIndex = 0;
            this.radioWeightsFromUser.TabStop = true;
            this.radioWeightsFromUser.Text = "User Specified Weights Of Age";
            this.radioWeightsFromUser.UseVisualStyleBackColor = true;
            this.radioWeightsFromUser.CheckedChanged += new System.EventHandler(this.radioWeightsFromUser_CheckedChanged);
            // 
            // radioWeightsFromFile
            // 
            this.radioWeightsFromFile.AutoSize = true;
            this.radioWeightsFromFile.Location = new System.Drawing.Point(298, 20);
            this.radioWeightsFromFile.Name = "radioWeightsFromFile";
            this.radioWeightsFromFile.Size = new System.Drawing.Size(138, 17);
            this.radioWeightsFromFile.TabIndex = 1;
            this.radioWeightsFromFile.TabStop = true;
            this.radioWeightsFromFile.Text = "Read Weights From File";
            this.radioWeightsFromFile.UseVisualStyleBackColor = true;
            this.radioWeightsFromFile.CheckedChanged += new System.EventHandler(this.radioWeightsFromFile_CheckedChanged);
            // 
            // radioWeightsFromJan1
            // 
            this.radioWeightsFromJan1.AutoSize = true;
            this.radioWeightsFromJan1.Location = new System.Drawing.Point(25, 44);
            this.radioWeightsFromJan1.Name = "radioWeightsFromJan1";
            this.radioWeightsFromJan1.Size = new System.Drawing.Size(154, 17);
            this.radioWeightsFromJan1.TabIndex = 2;
            this.radioWeightsFromJan1.TabStop = true;
            this.radioWeightsFromJan1.Text = "Use JAN-1 Weights Of Age";
            this.radioWeightsFromJan1.UseVisualStyleBackColor = true;
            this.radioWeightsFromJan1.CheckedChanged += new System.EventHandler(this.radioWeightsFromJan1_CheckedChanged);
            // 
            // radioWeightsFromSSB
            // 
            this.radioWeightsFromSSB.AutoSize = true;
            this.radioWeightsFromSSB.Location = new System.Drawing.Point(298, 44);
            this.radioWeightsFromSSB.Name = "radioWeightsFromSSB";
            this.radioWeightsFromSSB.Size = new System.Drawing.Size(146, 17);
            this.radioWeightsFromSSB.TabIndex = 3;
            this.radioWeightsFromSSB.TabStop = true;
            this.radioWeightsFromSSB.Text = "Use SSB Weights Of Age";
            this.radioWeightsFromSSB.UseVisualStyleBackColor = true;
            this.radioWeightsFromSSB.CheckedChanged += new System.EventHandler(this.radioWeightsFromSSB_CheckedChanged);
            // 
            // radioWeightsFromMidYear
            // 
            this.radioWeightsFromMidYear.AutoSize = true;
            this.radioWeightsFromMidYear.Location = new System.Drawing.Point(25, 68);
            this.radioWeightsFromMidYear.Name = "radioWeightsFromMidYear";
            this.radioWeightsFromMidYear.Size = new System.Drawing.Size(166, 17);
            this.radioWeightsFromMidYear.TabIndex = 4;
            this.radioWeightsFromMidYear.TabStop = true;
            this.radioWeightsFromMidYear.Text = "Use Mid-Year Weights At Age";
            this.radioWeightsFromMidYear.UseVisualStyleBackColor = true;
            this.radioWeightsFromMidYear.CheckedChanged += new System.EventHandler(this.radioWeightsFromMidYear_CheckedChanged);
            // 
            // radioWeightsFromCatch
            // 
            this.radioWeightsFromCatch.AutoSize = true;
            this.radioWeightsFromCatch.Location = new System.Drawing.Point(298, 68);
            this.radioWeightsFromCatch.Name = "radioWeightsFromCatch";
            this.radioWeightsFromCatch.Size = new System.Drawing.Size(152, 17);
            this.radioWeightsFromCatch.TabIndex = 5;
            this.radioWeightsFromCatch.TabStop = true;
            this.radioWeightsFromCatch.Text = "Use Catch Weights At Age";
            this.radioWeightsFromCatch.UseVisualStyleBackColor = true;
            this.radioWeightsFromCatch.CheckedChanged += new System.EventHandler(this.radioWeightsFromCatch_CheckedChanged);
            // 
            // ControlWeightAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutWeightAgePanel);
            this.Name = "ControlWeightAge";
            this.Size = new System.Drawing.Size(900, 520);
            this.tableLayoutWeightAgePanel.ResumeLayout(false);
            this.tableLayoutWeightAgePanel.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutWeightAgePanel;
        private System.Windows.Forms.Panel panelStochasticParameterAge;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.RadioButton radioWeightsFromCatch;
        private System.Windows.Forms.RadioButton radioWeightsFromMidYear;
        private System.Windows.Forms.RadioButton radioWeightsFromSSB;
        private System.Windows.Forms.RadioButton radioWeightsFromJan1;
        private System.Windows.Forms.RadioButton radioWeightsFromFile;
        private System.Windows.Forms.RadioButton radioWeightsFromUser;
    }
}
