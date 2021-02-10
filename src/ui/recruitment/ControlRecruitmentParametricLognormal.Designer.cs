namespace Nmfs.Agepro.Gui
{
    partial class ControlRecruitmentParametricLognormal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLastResidual = new System.Windows.Forms.Label();
            this.textBoxLastResidual = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxPhi = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxStdDeviation = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxMean = new Nmfs.Agepro.Gui.NftTextBox();
            this.labelPhi = new System.Windows.Forms.Label();
            this.labelStdDeviation = new System.Windows.Forms.Label();
            this.labelMean = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLastResidual
            // 
            this.labelLastResidual.AutoSize = true;
            this.labelLastResidual.Enabled = false;
            this.labelLastResidual.Location = new System.Drawing.Point(34, 142);
            this.labelLastResidual.Name = "labelLastResidual";
            this.labelLastResidual.Size = new System.Drawing.Size(71, 13);
            this.labelLastResidual.TabIndex = 18;
            this.labelLastResidual.Text = "Last Residual";
            // 
            // textBoxLastResidual
            // 
            this.textBoxLastResidual.Enabled = false;
            this.textBoxLastResidual.Location = new System.Drawing.Point(166, 139);
            this.textBoxLastResidual.Name = "textBoxLastResidual";
            this.textBoxLastResidual.ParamName = "Last Residual";
            this.textBoxLastResidual.PrevValidValue = "";
            this.textBoxLastResidual.Size = new System.Drawing.Size(135, 20);
            this.textBoxLastResidual.TabIndex = 19;
            this.textBoxLastResidual.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLastResidual_Validating);
            // 
            // textBoxPhi
            // 
            this.textBoxPhi.Enabled = false;
            this.textBoxPhi.Location = new System.Drawing.Point(166, 106);
            this.textBoxPhi.Name = "textBoxPhi";
            this.textBoxPhi.ParamName = "Phi";
            this.textBoxPhi.PrevValidValue = "";
            this.textBoxPhi.Size = new System.Drawing.Size(135, 20);
            this.textBoxPhi.TabIndex = 17;
            this.textBoxPhi.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPhi_Validating);
            // 
            // textBoxStdDeviation
            // 
            this.textBoxStdDeviation.Location = new System.Drawing.Point(166, 73);
            this.textBoxStdDeviation.Name = "textBoxStdDeviation";
            this.textBoxStdDeviation.ParamName = "Std. Deviation";
            this.textBoxStdDeviation.PrevValidValue = "";
            this.textBoxStdDeviation.Size = new System.Drawing.Size(135, 20);
            this.textBoxStdDeviation.TabIndex = 15;
            this.textBoxStdDeviation.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxStdDeviation_Validating);
            // 
            // textBoxMean
            // 
            this.textBoxMean.Location = new System.Drawing.Point(166, 40);
            this.textBoxMean.Name = "textBoxMean";
            this.textBoxMean.ParamName = "Mean";
            this.textBoxMean.PrevValidValue = "";
            this.textBoxMean.Size = new System.Drawing.Size(135, 20);
            this.textBoxMean.TabIndex = 13;
            this.textBoxMean.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMean_Validating);
            // 
            // labelPhi
            // 
            this.labelPhi.AutoSize = true;
            this.labelPhi.Enabled = false;
            this.labelPhi.Location = new System.Drawing.Point(34, 109);
            this.labelPhi.Name = "labelPhi";
            this.labelPhi.Size = new System.Drawing.Size(22, 13);
            this.labelPhi.TabIndex = 16;
            this.labelPhi.Text = "Phi";
            // 
            // labelStdDeviation
            // 
            this.labelStdDeviation.AutoSize = true;
            this.labelStdDeviation.Location = new System.Drawing.Point(34, 76);
            this.labelStdDeviation.Name = "labelStdDeviation";
            this.labelStdDeviation.Size = new System.Drawing.Size(74, 13);
            this.labelStdDeviation.TabIndex = 14;
            this.labelStdDeviation.Text = "Std. Deviation";
            // 
            // labelMean
            // 
            this.labelMean.AutoSize = true;
            this.labelMean.Location = new System.Drawing.Point(34, 43);
            this.labelMean.Name = "labelMean";
            this.labelMean.Size = new System.Drawing.Size(34, 13);
            this.labelMean.TabIndex = 12;
            this.labelMean.Text = "Mean";
            // 
            // ControlRecruitmentParametricLognormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.labelLastResidual);
            this.Controls.Add(this.textBoxLastResidual);
            this.Controls.Add(this.textBoxPhi);
            this.Controls.Add(this.textBoxStdDeviation);
            this.Controls.Add(this.textBoxMean);
            this.Controls.Add(this.labelPhi);
            this.Controls.Add(this.labelStdDeviation);
            this.Controls.Add(this.labelMean);
            this.Name = "ControlRecruitmentParametricLognormal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLastResidual;
        private Nmfs.Agepro.Gui.NftTextBox textBoxLastResidual;
        private Nmfs.Agepro.Gui.NftTextBox textBoxPhi;
        private Nmfs.Agepro.Gui.NftTextBox textBoxStdDeviation;
        private Nmfs.Agepro.Gui.NftTextBox textBoxMean;
        private System.Windows.Forms.Label labelPhi;
        private System.Windows.Forms.Label labelStdDeviation;
        private System.Windows.Forms.Label labelMean;
    }
}
