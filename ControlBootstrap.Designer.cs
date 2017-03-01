namespace Nmfs.Agepro.Gui
{
    partial class ControlBootstrap
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
            this.labelBootstrapFile = new System.Windows.Forms.Label();
            this.textBoxBootstrapFile = new System.Windows.Forms.TextBox();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.groupBootstrapOptions = new System.Windows.Forms.GroupBox();
            this.textBoxPopScaleFactors = new System.Windows.Forms.TextBox();
            this.labelPopScaleFactors = new System.Windows.Forms.Label();
            this.textBoxNumBootstrapIterations = new System.Windows.Forms.TextBox();
            this.labelNumBootstrapIterations = new System.Windows.Forms.Label();
            this.groupBootstrapOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBootstrapFile
            // 
            this.labelBootstrapFile.AutoSize = true;
            this.labelBootstrapFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBootstrapFile.Location = new System.Drawing.Point(39, 42);
            this.labelBootstrapFile.Name = "labelBootstrapFile";
            this.labelBootstrapFile.Size = new System.Drawing.Size(85, 13);
            this.labelBootstrapFile.TabIndex = 0;
            this.labelBootstrapFile.Text = "Bootstrap File";
            // 
            // textBoxBootstrapFile
            // 
            this.textBoxBootstrapFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootstrapFile.Location = new System.Drawing.Point(42, 59);
            this.textBoxBootstrapFile.Name = "textBoxBootstrapFile";
            this.textBoxBootstrapFile.Size = new System.Drawing.Size(738, 20);
            this.textBoxBootstrapFile.TabIndex = 1;
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFile.Location = new System.Drawing.Point(786, 57);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.TabIndex = 2;
            this.buttonLoadFile.Text = "Load File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // groupBootstrapOptions
            // 
            this.groupBootstrapOptions.Controls.Add(this.textBoxPopScaleFactors);
            this.groupBootstrapOptions.Controls.Add(this.labelPopScaleFactors);
            this.groupBootstrapOptions.Controls.Add(this.textBoxNumBootstrapIterations);
            this.groupBootstrapOptions.Controls.Add(this.labelNumBootstrapIterations);
            this.groupBootstrapOptions.Location = new System.Drawing.Point(42, 117);
            this.groupBootstrapOptions.Name = "groupBootstrapOptions";
            this.groupBootstrapOptions.Size = new System.Drawing.Size(404, 102);
            this.groupBootstrapOptions.TabIndex = 3;
            this.groupBootstrapOptions.TabStop = false;
            this.groupBootstrapOptions.Text = "Bootstrap Options";
            // 
            // textBoxPopScaleFactors
            // 
            this.textBoxPopScaleFactors.Location = new System.Drawing.Point(232, 61);
            this.textBoxPopScaleFactors.Name = "textBoxPopScaleFactors";
            this.textBoxPopScaleFactors.Size = new System.Drawing.Size(100, 20);
            this.textBoxPopScaleFactors.TabIndex = 3;
            this.textBoxPopScaleFactors.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPopScaleFactors_Validating);
            this.textBoxPopScaleFactors.Validated += new System.EventHandler(this.textBoxPopScaleFactors_Validated);
            // 
            // labelPopScaleFactors
            // 
            this.labelPopScaleFactors.AutoSize = true;
            this.labelPopScaleFactors.Location = new System.Drawing.Point(26, 64);
            this.labelPopScaleFactors.Name = "labelPopScaleFactors";
            this.labelPopScaleFactors.Size = new System.Drawing.Size(125, 13);
            this.labelPopScaleFactors.TabIndex = 2;
            this.labelPopScaleFactors.Text = "Population Scale Factors";
            // 
            // textBoxNumBootstrapIterations
            // 
            this.textBoxNumBootstrapIterations.Location = new System.Drawing.Point(232, 25);
            this.textBoxNumBootstrapIterations.Name = "textBoxNumBootstrapIterations";
            this.textBoxNumBootstrapIterations.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumBootstrapIterations.TabIndex = 1;
            // 
            // labelNumBootstrapIterations
            // 
            this.labelNumBootstrapIterations.AutoSize = true;
            this.labelNumBootstrapIterations.Location = new System.Drawing.Point(26, 32);
            this.labelNumBootstrapIterations.Name = "labelNumBootstrapIterations";
            this.labelNumBootstrapIterations.Size = new System.Drawing.Size(150, 13);
            this.labelNumBootstrapIterations.TabIndex = 0;
            this.labelNumBootstrapIterations.Text = "Number of Bootstrap Iterations";
            // 
            // ControlBootstrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBootstrapOptions);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.textBoxBootstrapFile);
            this.Controls.Add(this.labelBootstrapFile);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "ControlBootstrap";
            this.Size = new System.Drawing.Size(900, 520);
            this.groupBootstrapOptions.ResumeLayout(false);
            this.groupBootstrapOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBootstrapFile;
        private System.Windows.Forms.TextBox textBoxBootstrapFile;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.GroupBox groupBootstrapOptions;
        private System.Windows.Forms.TextBox textBoxPopScaleFactors;
        private System.Windows.Forms.Label labelPopScaleFactors;
        private System.Windows.Forms.TextBox textBoxNumBootstrapIterations;
        private System.Windows.Forms.Label labelNumBootstrapIterations;
    }
}
