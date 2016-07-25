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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioParameterFromFile = new System.Windows.Forms.RadioButton();
            this.radioParameterFromUser = new System.Windows.Forms.RadioButton();
            this.panelStochasticParameterAge = new System.Windows.Forms.Panel();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.radioParameterFromFile);
            this.groupOptions.Controls.Add(this.radioParameterFromUser);
            this.groupOptions.Location = new System.Drawing.Point(24, 24);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(789, 52);
            this.groupOptions.TabIndex = 0;
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
            this.radioParameterFromFile.CheckedChanged += new System.EventHandler(this.radioParameterFromFile_CheckedChanged);
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
            this.radioParameterFromUser.CheckedChanged += new System.EventHandler(this.radioParameterFromUser_CheckedChanged);
            // 
            // panelStochasticParameterAge
            // 
            this.panelStochasticParameterAge.Location = new System.Drawing.Point(14, 141);
            this.panelStochasticParameterAge.Name = "panelStochasticParameterAge";
            this.panelStochasticParameterAge.Size = new System.Drawing.Size(873, 350);
            this.panelStochasticParameterAge.TabIndex = 1;
            // 
            // ControlStochasticAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStochasticParameterAge);
            this.Controls.Add(this.groupOptions);
            this.Name = "ControlStochasticAge";
            this.Size = new System.Drawing.Size(900, 520);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.RadioButton radioParameterFromFile;
        private System.Windows.Forms.RadioButton radioParameterFromUser;
        private System.Windows.Forms.Panel panelStochasticParameterAge;
    }
}
