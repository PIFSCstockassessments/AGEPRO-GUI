namespace Nmfs.Agepro.Gui
{
    partial class ControlRecruitmentParametricCurve
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
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.labelKparm = new System.Windows.Forms.Label();
            this.labelVariance = new System.Windows.Forms.Label();
            this.labelPhi = new System.Windows.Forms.Label();
            this.textBoxAlpha = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxBeta = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxKParm = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxVariance = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxPhi = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxLastResidual = new Nmfs.Agepro.Gui.NftTextBox();
            this.labelLastResidual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(34, 43);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(34, 13);
            this.labelAlpha.TabIndex = 0;
            this.labelAlpha.Text = "Alpha";
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(34, 76);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(29, 13);
            this.labelBeta.TabIndex = 2;
            this.labelBeta.Text = "Beta";
            // 
            // labelKparm
            // 
            this.labelKparm.AutoSize = true;
            this.labelKparm.Location = new System.Drawing.Point(34, 142);
            this.labelKparm.Name = "labelKparm";
            this.labelKparm.Size = new System.Drawing.Size(41, 13);
            this.labelKparm.TabIndex = 6;
            this.labelKparm.Text = "K-Parm";
            // 
            // labelVariance
            // 
            this.labelVariance.AutoSize = true;
            this.labelVariance.Location = new System.Drawing.Point(34, 109);
            this.labelVariance.Name = "labelVariance";
            this.labelVariance.Size = new System.Drawing.Size(49, 13);
            this.labelVariance.TabIndex = 4;
            this.labelVariance.Text = "Variance";
            // 
            // labelPhi
            // 
            this.labelPhi.AutoSize = true;
            this.labelPhi.Enabled = false;
            this.labelPhi.Location = new System.Drawing.Point(34, 175);
            this.labelPhi.Name = "labelPhi";
            this.labelPhi.Size = new System.Drawing.Size(22, 13);
            this.labelPhi.TabIndex = 8;
            this.labelPhi.Text = "Phi";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(166, 40);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(135, 20);
            this.textBoxAlpha.TabIndex = 1;
            // 
            // textBoxBeta
            // 
            this.textBoxBeta.Location = new System.Drawing.Point(166, 73);
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.Size = new System.Drawing.Size(135, 20);
            this.textBoxBeta.TabIndex = 3;
            // 
            // textBoxKParm
            // 
            this.textBoxKParm.Location = new System.Drawing.Point(166, 139);
            this.textBoxKParm.Name = "textBoxKParm";
            this.textBoxKParm.Size = new System.Drawing.Size(135, 20);
            this.textBoxKParm.TabIndex = 7;
            // 
            // textBoxVariance
            // 
            this.textBoxVariance.Location = new System.Drawing.Point(166, 106);
            this.textBoxVariance.Name = "textBoxVariance";
            this.textBoxVariance.Size = new System.Drawing.Size(135, 20);
            this.textBoxVariance.TabIndex = 5;
            // 
            // textBoxPhi
            // 
            this.textBoxPhi.Enabled = false;
            this.textBoxPhi.Location = new System.Drawing.Point(166, 172);
            this.textBoxPhi.Name = "textBoxPhi";
            this.textBoxPhi.Size = new System.Drawing.Size(135, 20);
            this.textBoxPhi.TabIndex = 9;
            // 
            // textBoxLastResidual
            // 
            this.textBoxLastResidual.Enabled = false;
            this.textBoxLastResidual.Location = new System.Drawing.Point(166, 205);
            this.textBoxLastResidual.Name = "textBoxLastResidual";
            this.textBoxLastResidual.Size = new System.Drawing.Size(135, 20);
            this.textBoxLastResidual.TabIndex = 11;
            // 
            // labelLastResidual
            // 
            this.labelLastResidual.AutoSize = true;
            this.labelLastResidual.Enabled = false;
            this.labelLastResidual.Location = new System.Drawing.Point(34, 208);
            this.labelLastResidual.Name = "labelLastResidual";
            this.labelLastResidual.Size = new System.Drawing.Size(71, 13);
            this.labelLastResidual.TabIndex = 10;
            this.labelLastResidual.Text = "Last Residual";
            // 
            // ControlRecruitmentParametricCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.labelLastResidual);
            this.Controls.Add(this.textBoxLastResidual);
            this.Controls.Add(this.textBoxPhi);
            this.Controls.Add(this.textBoxVariance);
            this.Controls.Add(this.textBoxKParm);
            this.Controls.Add(this.textBoxBeta);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.labelPhi);
            this.Controls.Add(this.labelVariance);
            this.Controls.Add(this.labelKparm);
            this.Controls.Add(this.labelBeta);
            this.Controls.Add(this.labelAlpha);
            this.Name = "ControlRecruitmentParametricCurve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.Label labelKparm;
        private System.Windows.Forms.Label labelVariance;
        private System.Windows.Forms.Label labelPhi;
        private Nmfs.Agepro.Gui.NftTextBox textBoxAlpha;
        private Nmfs.Agepro.Gui.NftTextBox textBoxBeta;
        private Nmfs.Agepro.Gui.NftTextBox textBoxKParm;
        private Nmfs.Agepro.Gui.NftTextBox textBoxVariance;
        private Nmfs.Agepro.Gui.NftTextBox textBoxPhi;
        private Nmfs.Agepro.Gui.NftTextBox textBoxLastResidual;
        private System.Windows.Forms.Label labelLastResidual;

    }
}
