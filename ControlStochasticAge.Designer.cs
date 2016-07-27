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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelStochasticParameterAge = new System.Windows.Forms.Panel();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioParameterFromFile = new System.Windows.Forms.RadioButton();
            this.radioParameterFromUser = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelStochasticParameterAge, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupOptions, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 520);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelStochasticParameterAge
            // 
            this.panelStochasticParameterAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelStochasticParameterAge.AutoSize = true;
            this.panelStochasticParameterAge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStochasticParameterAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStochasticParameterAge.Location = new System.Drawing.Point(23, 98);
            this.panelStochasticParameterAge.MinimumSize = new System.Drawing.Size(873, 350);
            this.panelStochasticParameterAge.Name = "panelStochasticParameterAge";
            this.panelStochasticParameterAge.Padding = new System.Windows.Forms.Padding(20, 0, 0, 50);
            this.panelStochasticParameterAge.Size = new System.Drawing.Size(873, 419);
            this.panelStochasticParameterAge.TabIndex = 3;
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.radioParameterFromFile);
            this.groupOptions.Controls.Add(this.radioParameterFromUser);
            this.groupOptions.Location = new System.Drawing.Point(23, 23);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(789, 52);
            this.groupOptions.TabIndex = 1;
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
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "ControlStochasticAge";
            this.Size = new System.Drawing.Size(900, 520);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.RadioButton radioParameterFromFile;
        private System.Windows.Forms.RadioButton radioParameterFromUser;
        private System.Windows.Forms.Panel panelStochasticParameterAge;
    }
}
