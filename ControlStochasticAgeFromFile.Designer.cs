namespace AGEPRO.GUI
{
    partial class ControlStochasticAgeFromFile
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
            this.labelDataFile = new System.Windows.Forms.Label();
            this.textBoxDataFile = new System.Windows.Forms.TextBox();
            this.buttonLoadDataFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDataFile
            // 
            this.labelDataFile.AutoSize = true;
            this.labelDataFile.Location = new System.Drawing.Point(19, 47);
            this.labelDataFile.Name = "labelDataFile";
            this.labelDataFile.Size = new System.Drawing.Size(49, 13);
            this.labelDataFile.TabIndex = 0;
            this.labelDataFile.Text = "Data File";
            // 
            // textBoxDataFile
            // 
            this.textBoxDataFile.Location = new System.Drawing.Point(22, 64);
            this.textBoxDataFile.Name = "textBoxDataFile";
            this.textBoxDataFile.Size = new System.Drawing.Size(721, 20);
            this.textBoxDataFile.TabIndex = 1;
            // 
            // buttonLoadDataFile
            // 
            this.buttonLoadDataFile.Location = new System.Drawing.Point(759, 61);
            this.buttonLoadDataFile.Name = "buttonLoadDataFile";
            this.buttonLoadDataFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadDataFile.TabIndex = 2;
            this.buttonLoadDataFile.Text = "Browse";
            this.buttonLoadDataFile.UseVisualStyleBackColor = true;
            // 
            // ControlStochasticAgeFromFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonLoadDataFile);
            this.Controls.Add(this.textBoxDataFile);
            this.Controls.Add(this.labelDataFile);
            this.Name = "ControlStochasticAgeFromFile";
            this.Size = new System.Drawing.Size(870, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataFile;
        private System.Windows.Forms.TextBox textBoxDataFile;
        private System.Windows.Forms.Button buttonLoadDataFile;
    }
}
