namespace AGEPRO.GUI
{
    partial class ControlRecruitment
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
            this.tabControlRecruitment = new System.Windows.Forms.TabControl();
            this.tabRecruitment = new System.Windows.Forms.TabPage();
            this.tabRecruitModels = new System.Windows.Forms.TabPage();
            this.groupScalingFactor = new System.Windows.Forms.GroupBox();
            this.labelRecruitmentScalingFactor = new System.Windows.Forms.Label();
            this.labelSSBScalingFactor = new System.Windows.Forms.Label();
            this.textBoxRecruitngScalingFactor = new System.Windows.Forms.TextBox();
            this.textBoxSSBScalingFactor = new System.Windows.Forms.TextBox();
            this.dataGridSelectRecruitModels = new System.Windows.Forms.DataGridView();
            this.dataGridRecruitProb = new System.Windows.Forms.DataGridView();
            this.labelSelectRecruitModels = new System.Windows.Forms.Label();
            this.labelRecruitProb = new System.Windows.Forms.Label();
            this.tabControlRecruitment.SuspendLayout();
            this.tabRecruitment.SuspendLayout();
            this.groupScalingFactor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSelectRecruitModels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitProb)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlRecruitment
            // 
            this.tabControlRecruitment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlRecruitment.Controls.Add(this.tabRecruitment);
            this.tabControlRecruitment.Controls.Add(this.tabRecruitModels);
            this.tabControlRecruitment.Location = new System.Drawing.Point(0, 6);
            this.tabControlRecruitment.Name = "tabControlRecruitment";
            this.tabControlRecruitment.SelectedIndex = 0;
            this.tabControlRecruitment.Size = new System.Drawing.Size(897, 494);
            this.tabControlRecruitment.TabIndex = 0;
            // 
            // tabRecruitment
            // 
            this.tabRecruitment.Controls.Add(this.labelRecruitProb);
            this.tabRecruitment.Controls.Add(this.labelSelectRecruitModels);
            this.tabRecruitment.Controls.Add(this.dataGridRecruitProb);
            this.tabRecruitment.Controls.Add(this.dataGridSelectRecruitModels);
            this.tabRecruitment.Controls.Add(this.groupScalingFactor);
            this.tabRecruitment.Location = new System.Drawing.Point(4, 22);
            this.tabRecruitment.Name = "tabRecruitment";
            this.tabRecruitment.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecruitment.Size = new System.Drawing.Size(889, 468);
            this.tabRecruitment.TabIndex = 0;
            this.tabRecruitment.Text = "Recruitment";
            this.tabRecruitment.UseVisualStyleBackColor = true;
            // 
            // tabRecruitModels
            // 
            this.tabRecruitModels.Location = new System.Drawing.Point(4, 22);
            this.tabRecruitModels.Name = "tabRecruitModels";
            this.tabRecruitModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecruitModels.Size = new System.Drawing.Size(889, 468);
            this.tabRecruitModels.TabIndex = 1;
            this.tabRecruitModels.Text = "Recruit Model";
            this.tabRecruitModels.UseVisualStyleBackColor = true;
            // 
            // groupScalingFactor
            // 
            this.groupScalingFactor.Controls.Add(this.textBoxSSBScalingFactor);
            this.groupScalingFactor.Controls.Add(this.textBoxRecruitngScalingFactor);
            this.groupScalingFactor.Controls.Add(this.labelSSBScalingFactor);
            this.groupScalingFactor.Controls.Add(this.labelRecruitmentScalingFactor);
            this.groupScalingFactor.Location = new System.Drawing.Point(15, 374);
            this.groupScalingFactor.Name = "groupScalingFactor";
            this.groupScalingFactor.Size = new System.Drawing.Size(846, 71);
            this.groupScalingFactor.TabIndex = 0;
            this.groupScalingFactor.TabStop = false;
            // 
            // labelRecruitmentScalingFactor
            // 
            this.labelRecruitmentScalingFactor.AutoSize = true;
            this.labelRecruitmentScalingFactor.Location = new System.Drawing.Point(39, 32);
            this.labelRecruitmentScalingFactor.Name = "labelRecruitmentScalingFactor";
            this.labelRecruitmentScalingFactor.Size = new System.Drawing.Size(135, 13);
            this.labelRecruitmentScalingFactor.TabIndex = 0;
            this.labelRecruitmentScalingFactor.Text = "Recruitment Scaling Factor";
            // 
            // labelSSBScalingFactor
            // 
            this.labelSSBScalingFactor.AutoSize = true;
            this.labelSSBScalingFactor.Location = new System.Drawing.Point(482, 32);
            this.labelSSBScalingFactor.Name = "labelSSBScalingFactor";
            this.labelSSBScalingFactor.Size = new System.Drawing.Size(99, 13);
            this.labelSSBScalingFactor.TabIndex = 1;
            this.labelSSBScalingFactor.Text = "SSB Scaling Factor";
            // 
            // textBoxRecruitngScalingFactor
            // 
            this.textBoxRecruitngScalingFactor.Location = new System.Drawing.Point(229, 29);
            this.textBoxRecruitngScalingFactor.Name = "textBoxRecruitngScalingFactor";
            this.textBoxRecruitngScalingFactor.Size = new System.Drawing.Size(131, 20);
            this.textBoxRecruitngScalingFactor.TabIndex = 2;
            // 
            // textBoxSSBScalingFactor
            // 
            this.textBoxSSBScalingFactor.Location = new System.Drawing.Point(643, 29);
            this.textBoxSSBScalingFactor.Name = "textBoxSSBScalingFactor";
            this.textBoxSSBScalingFactor.Size = new System.Drawing.Size(131, 20);
            this.textBoxSSBScalingFactor.TabIndex = 3;
            // 
            // dataGridSelectRecruitModels
            // 
            this.dataGridSelectRecruitModels.AllowUserToAddRows = false;
            this.dataGridSelectRecruitModels.AllowUserToDeleteRows = false;
            this.dataGridSelectRecruitModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSelectRecruitModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSelectRecruitModels.Location = new System.Drawing.Point(18, 23);
            this.dataGridSelectRecruitModels.Name = "dataGridSelectRecruitModels";
            this.dataGridSelectRecruitModels.Size = new System.Drawing.Size(843, 154);
            this.dataGridSelectRecruitModels.TabIndex = 1;
            // 
            // dataGridRecruitProb
            // 
            this.dataGridRecruitProb.AllowUserToAddRows = false;
            this.dataGridRecruitProb.AllowUserToDeleteRows = false;
            this.dataGridRecruitProb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRecruitProb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecruitProb.Location = new System.Drawing.Point(18, 211);
            this.dataGridRecruitProb.Name = "dataGridRecruitProb";
            this.dataGridRecruitProb.Size = new System.Drawing.Size(843, 157);
            this.dataGridRecruitProb.TabIndex = 2;
            // 
            // labelSelectRecruitModels
            // 
            this.labelSelectRecruitModels.AutoSize = true;
            this.labelSelectRecruitModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectRecruitModels.Location = new System.Drawing.Point(15, 7);
            this.labelSelectRecruitModels.Name = "labelSelectRecruitModels";
            this.labelSelectRecruitModels.Size = new System.Drawing.Size(159, 13);
            this.labelSelectRecruitModels.TabIndex = 3;
            this.labelSelectRecruitModels.Text = "Select Recruitment Models";
            // 
            // labelRecruitProb
            // 
            this.labelRecruitProb.AutoSize = true;
            this.labelRecruitProb.Location = new System.Drawing.Point(15, 195);
            this.labelRecruitProb.Name = "labelRecruitProb";
            this.labelRecruitProb.Size = new System.Drawing.Size(110, 13);
            this.labelRecruitProb.TabIndex = 4;
            this.labelRecruitProb.Text = "Recruitment Probabily";
            // 
            // ControlRecruitment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlRecruitment);
            this.Name = "ControlRecruitment";
            this.Size = new System.Drawing.Size(900, 500);
            this.tabControlRecruitment.ResumeLayout(false);
            this.tabRecruitment.ResumeLayout(false);
            this.tabRecruitment.PerformLayout();
            this.groupScalingFactor.ResumeLayout(false);
            this.groupScalingFactor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSelectRecruitModels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitProb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRecruitment;
        private System.Windows.Forms.TabPage tabRecruitment;
        private System.Windows.Forms.TabPage tabRecruitModels;
        private System.Windows.Forms.Label labelRecruitProb;
        private System.Windows.Forms.Label labelSelectRecruitModels;
        private System.Windows.Forms.DataGridView dataGridRecruitProb;
        private System.Windows.Forms.DataGridView dataGridSelectRecruitModels;
        private System.Windows.Forms.GroupBox groupScalingFactor;
        private System.Windows.Forms.TextBox textBoxSSBScalingFactor;
        private System.Windows.Forms.TextBox textBoxRecruitngScalingFactor;
        private System.Windows.Forms.Label labelSSBScalingFactor;
        private System.Windows.Forms.Label labelRecruitmentScalingFactor;
    }
}
