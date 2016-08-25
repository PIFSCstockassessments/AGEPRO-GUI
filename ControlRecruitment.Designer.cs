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
            this.tabControlRecruitment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlRecruitment
            // 
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
            // ControlRecruitment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlRecruitment);
            this.Name = "ControlRecruitment";
            this.Size = new System.Drawing.Size(900, 500);
            this.tabControlRecruitment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRecruitment;
        private System.Windows.Forms.TabPage tabRecruitment;
        private System.Windows.Forms.TabPage tabRecruitModels;
    }
}
