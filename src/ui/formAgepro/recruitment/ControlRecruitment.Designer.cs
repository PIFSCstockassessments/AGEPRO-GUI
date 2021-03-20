namespace Nmfs.Agepro.Gui
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
            this.labelRecruitProb = new System.Windows.Forms.Label();
            this.labelSelectRecruitModels = new System.Windows.Forms.Label();
            this.dataGridRecruitProb = new Nmfs.Agepro.Gui.NftDataGridView();
            this.dataGridComboBoxSelectRecruitModels = new Nmfs.Agepro.Gui.NftDataGridView();
            this.groupScalingFactor = new System.Windows.Forms.GroupBox();
            this.textBoxSSBScalingFactor = new Nmfs.Agepro.Gui.NftTextBox();
            this.textBoxRecruitngScalingFactor = new Nmfs.Agepro.Gui.NftTextBox();
            this.labelSSBScalingFactor = new System.Windows.Forms.Label();
            this.labelRecruitmentScalingFactor = new System.Windows.Forms.Label();
            this.tabRecruitModels = new System.Windows.Forms.TabPage();
            this.panelRecruitModelParameter = new System.Windows.Forms.Panel();
            this.groupRecruitSelectionBox = new System.Windows.Forms.GroupBox();
            this.labelRecruitSelection = new System.Windows.Forms.Label();
            this.comboBoxRecruitSelection = new System.Windows.Forms.ComboBox();
            this.tabControlRecruitment.SuspendLayout();
            this.tabRecruitment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitProb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComboBoxSelectRecruitModels)).BeginInit();
            this.groupScalingFactor.SuspendLayout();
            this.tabRecruitModels.SuspendLayout();
            this.groupRecruitSelectionBox.SuspendLayout();
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
            this.tabControlRecruitment.Size = new System.Drawing.Size(897, 491);
            this.tabControlRecruitment.TabIndex = 0;
            this.tabControlRecruitment.SelectedIndexChanged += new System.EventHandler(this.tabControlRecruitment_SelectedIndexChanged);
            // 
            // tabRecruitment
            // 
            this.tabRecruitment.Controls.Add(this.labelRecruitProb);
            this.tabRecruitment.Controls.Add(this.labelSelectRecruitModels);
            this.tabRecruitment.Controls.Add(this.dataGridRecruitProb);
            this.tabRecruitment.Controls.Add(this.dataGridComboBoxSelectRecruitModels);
            this.tabRecruitment.Controls.Add(this.groupScalingFactor);
            this.tabRecruitment.Location = new System.Drawing.Point(4, 22);
            this.tabRecruitment.Name = "tabRecruitment";
            this.tabRecruitment.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecruitment.Size = new System.Drawing.Size(889, 465);
            this.tabRecruitment.TabIndex = 0;
            this.tabRecruitment.Text = "Recruitment";
            this.tabRecruitment.UseVisualStyleBackColor = true;
            // 
            // labelRecruitProb
            // 
            this.labelRecruitProb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecruitProb.AutoSize = true;
            this.labelRecruitProb.Location = new System.Drawing.Point(15, 195);
            this.labelRecruitProb.Name = "labelRecruitProb";
            this.labelRecruitProb.Size = new System.Drawing.Size(110, 13);
            this.labelRecruitProb.TabIndex = 3;
            this.labelRecruitProb.Text = "Recruitment Probabily";
            // 
            // labelSelectRecruitModels
            // 
            this.labelSelectRecruitModels.AutoSize = true;
            this.labelSelectRecruitModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectRecruitModels.Location = new System.Drawing.Point(15, 7);
            this.labelSelectRecruitModels.Name = "labelSelectRecruitModels";
            this.labelSelectRecruitModels.Size = new System.Drawing.Size(159, 13);
            this.labelSelectRecruitModels.TabIndex = 1;
            this.labelSelectRecruitModels.Text = "Select Recruitment Models";
            // 
            // dataGridRecruitProb
            // 
            this.dataGridRecruitProb.AllowUserToAddRows = false;
            this.dataGridRecruitProb.AllowUserToDeleteRows = false;
            this.dataGridRecruitProb.AllowUserToResizeRows = false;
            this.dataGridRecruitProb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRecruitProb.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridRecruitProb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecruitProb.Location = new System.Drawing.Point(18, 211);
            this.dataGridRecruitProb.Name = "dataGridRecruitProb";
            this.dataGridRecruitProb.nftReadOnly = false;
            this.dataGridRecruitProb.Size = new System.Drawing.Size(843, 154);
            this.dataGridRecruitProb.TabIndex = 4;
            this.dataGridRecruitProb.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridRecruitProb_CellFormatting);
            // 
            // dataGridComboBoxSelectRecruitModels
            // 
            this.dataGridComboBoxSelectRecruitModels.AllowUserToAddRows = false;
            this.dataGridComboBoxSelectRecruitModels.AllowUserToDeleteRows = false;
            this.dataGridComboBoxSelectRecruitModels.AllowUserToResizeRows = false;
            this.dataGridComboBoxSelectRecruitModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComboBoxSelectRecruitModels.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridComboBoxSelectRecruitModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComboBoxSelectRecruitModels.Location = new System.Drawing.Point(18, 23);
            this.dataGridComboBoxSelectRecruitModels.Name = "dataGridComboBoxSelectRecruitModels";
            this.dataGridComboBoxSelectRecruitModels.nftReadOnly = false;
            this.dataGridComboBoxSelectRecruitModels.ShowEditingIcon = false;
            this.dataGridComboBoxSelectRecruitModels.Size = new System.Drawing.Size(843, 154);
            this.dataGridComboBoxSelectRecruitModels.TabIndex = 2;
            this.dataGridComboBoxSelectRecruitModels.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridComboBoxSelectRecruitModels_CellFormatting);
            this.dataGridComboBoxSelectRecruitModels.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridComboBoxSelectRecruitModels_CellValueChanged);
            this.dataGridComboBoxSelectRecruitModels.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridComboBoxSelectRecruitModels_CurrentCellDirtyStateChanged);
            // 
            // groupScalingFactor
            // 
            this.groupScalingFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupScalingFactor.Controls.Add(this.textBoxSSBScalingFactor);
            this.groupScalingFactor.Controls.Add(this.textBoxRecruitngScalingFactor);
            this.groupScalingFactor.Controls.Add(this.labelSSBScalingFactor);
            this.groupScalingFactor.Controls.Add(this.labelRecruitmentScalingFactor);
            this.groupScalingFactor.Location = new System.Drawing.Point(18, 388);
            this.groupScalingFactor.Name = "groupScalingFactor";
            this.groupScalingFactor.Size = new System.Drawing.Size(846, 71);
            this.groupScalingFactor.TabIndex = 4;
            this.groupScalingFactor.TabStop = false;
            // 
            // textBoxSSBScalingFactor
            // 
            this.textBoxSSBScalingFactor.Location = new System.Drawing.Point(643, 29);
            this.textBoxSSBScalingFactor.Name = "textBoxSSBScalingFactor";
            this.textBoxSSBScalingFactor.ParamName = null;
            this.textBoxSSBScalingFactor.PrevValidValue = "";
            this.textBoxSSBScalingFactor.Size = new System.Drawing.Size(131, 20);
            this.textBoxSSBScalingFactor.TabIndex = 3;
            this.textBoxSSBScalingFactor.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSSBScalingFactor_Validating);
            // 
            // textBoxRecruitngScalingFactor
            // 
            this.textBoxRecruitngScalingFactor.Location = new System.Drawing.Point(229, 29);
            this.textBoxRecruitngScalingFactor.Name = "textBoxRecruitngScalingFactor";
            this.textBoxRecruitngScalingFactor.ParamName = null;
            this.textBoxRecruitngScalingFactor.PrevValidValue = "";
            this.textBoxRecruitngScalingFactor.Size = new System.Drawing.Size(131, 20);
            this.textBoxRecruitngScalingFactor.TabIndex = 2;
            this.textBoxRecruitngScalingFactor.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRecruitngScalingFactor_Validating);
            // 
            // labelSSBScalingFactor
            // 
            this.labelSSBScalingFactor.AutoSize = true;
            this.labelSSBScalingFactor.Location = new System.Drawing.Point(482, 32);
            this.labelSSBScalingFactor.Name = "labelSSBScalingFactor";
            this.labelSSBScalingFactor.Size = new System.Drawing.Size(99, 13);
            this.labelSSBScalingFactor.TabIndex = 3;
            this.labelSSBScalingFactor.Text = "SSB Scaling Factor";
            // 
            // labelRecruitmentScalingFactor
            // 
            this.labelRecruitmentScalingFactor.AutoSize = true;
            this.labelRecruitmentScalingFactor.Location = new System.Drawing.Point(39, 32);
            this.labelRecruitmentScalingFactor.Name = "labelRecruitmentScalingFactor";
            this.labelRecruitmentScalingFactor.Size = new System.Drawing.Size(135, 13);
            this.labelRecruitmentScalingFactor.TabIndex = 1;
            this.labelRecruitmentScalingFactor.Text = "Recruitment Scaling Factor";
            // 
            // tabRecruitModels
            // 
            this.tabRecruitModels.Controls.Add(this.panelRecruitModelParameter);
            this.tabRecruitModels.Controls.Add(this.groupRecruitSelectionBox);
            this.tabRecruitModels.Location = new System.Drawing.Point(4, 22);
            this.tabRecruitModels.Name = "tabRecruitModels";
            this.tabRecruitModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecruitModels.Size = new System.Drawing.Size(889, 465);
            this.tabRecruitModels.TabIndex = 1;
            this.tabRecruitModels.Text = "Recruit Model";
            this.tabRecruitModels.UseVisualStyleBackColor = true;
            // 
            // panelRecruitModelParameter
            // 
            this.panelRecruitModelParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRecruitModelParameter.Location = new System.Drawing.Point(17, 110);
            this.panelRecruitModelParameter.Name = "panelRecruitModelParameter";
            this.panelRecruitModelParameter.Size = new System.Drawing.Size(872, 355);
            this.panelRecruitModelParameter.TabIndex = 1;
            // 
            // groupRecruitSelectionBox
            // 
            this.groupRecruitSelectionBox.Controls.Add(this.labelRecruitSelection);
            this.groupRecruitSelectionBox.Controls.Add(this.comboBoxRecruitSelection);
            this.groupRecruitSelectionBox.Location = new System.Drawing.Point(17, 6);
            this.groupRecruitSelectionBox.Name = "groupRecruitSelectionBox";
            this.groupRecruitSelectionBox.Size = new System.Drawing.Size(542, 89);
            this.groupRecruitSelectionBox.TabIndex = 0;
            this.groupRecruitSelectionBox.TabStop = false;
            // 
            // labelRecruitSelection
            // 
            this.labelRecruitSelection.AutoSize = true;
            this.labelRecruitSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRecruitSelection.Location = new System.Drawing.Point(21, 52);
            this.labelRecruitSelection.MinimumSize = new System.Drawing.Size(475, 20);
            this.labelRecruitSelection.Name = "labelRecruitSelection";
            this.labelRecruitSelection.Size = new System.Drawing.Size(475, 20);
            this.labelRecruitSelection.TabIndex = 1;
            this.labelRecruitSelection.Text = "label1";
            this.labelRecruitSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxRecruitSelection
            // 
            this.comboBoxRecruitSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecruitSelection.Location = new System.Drawing.Point(21, 19);
            this.comboBoxRecruitSelection.Name = "comboBoxRecruitSelection";
            this.comboBoxRecruitSelection.Size = new System.Drawing.Size(473, 21);
            this.comboBoxRecruitSelection.TabIndex = 0;
            this.comboBoxRecruitSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecruitSelection_SelectedIndexChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitProb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComboBoxSelectRecruitModels)).EndInit();
            this.groupScalingFactor.ResumeLayout(false);
            this.groupScalingFactor.PerformLayout();
            this.tabRecruitModels.ResumeLayout(false);
            this.groupRecruitSelectionBox.ResumeLayout(false);
            this.groupRecruitSelectionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlRecruitment;
        private System.Windows.Forms.TabPage tabRecruitment;
        private System.Windows.Forms.TabPage tabRecruitModels;
        private System.Windows.Forms.Label labelRecruitProb;
        private System.Windows.Forms.Label labelSelectRecruitModels;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridRecruitProb;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridComboBoxSelectRecruitModels;
        private System.Windows.Forms.GroupBox groupScalingFactor;
        private Nmfs.Agepro.Gui.NftTextBox textBoxSSBScalingFactor;
        private Nmfs.Agepro.Gui.NftTextBox textBoxRecruitngScalingFactor;
        private System.Windows.Forms.Label labelSSBScalingFactor;
        private System.Windows.Forms.Label labelRecruitmentScalingFactor;
        private System.Windows.Forms.GroupBox groupRecruitSelectionBox;
        private System.Windows.Forms.Label labelRecruitSelection;
        private System.Windows.Forms.ComboBox comboBoxRecruitSelection;
        private System.Windows.Forms.Panel panelRecruitModelParameter;
    }
}
