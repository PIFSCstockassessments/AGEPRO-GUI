namespace AGEPRO.GUI
{
    partial class ControlRecruitmentEmperical
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
            this.groupEmpericalParameters = new System.Windows.Forms.GroupBox();
            this.labelNumObservations = new System.Windows.Forms.Label();
            this.spinBoxNumObservations = new System.Windows.Forms.NumericUpDown();
            this.buttonSetParameters = new System.Windows.Forms.Button();
            this.labelObservations = new System.Windows.Forms.Label();
            this.dataGridRecruitTable = new System.Windows.Forms.DataGridView();
            this.groupEmpericalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupEmpericalParameters
            // 
            this.groupEmpericalParameters.Controls.Add(this.buttonSetParameters);
            this.groupEmpericalParameters.Controls.Add(this.spinBoxNumObservations);
            this.groupEmpericalParameters.Controls.Add(this.labelNumObservations);
            this.groupEmpericalParameters.Location = new System.Drawing.Point(0, 0);
            this.groupEmpericalParameters.Name = "groupEmpericalParameters";
            this.groupEmpericalParameters.Size = new System.Drawing.Size(574, 90);
            this.groupEmpericalParameters.TabIndex = 0;
            this.groupEmpericalParameters.TabStop = false;
            // 
            // labelNumObservations
            // 
            this.labelNumObservations.AutoSize = true;
            this.labelNumObservations.Location = new System.Drawing.Point(18, 16);
            this.labelNumObservations.Name = "labelNumObservations";
            this.labelNumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelNumObservations.TabIndex = 0;
            this.labelNumObservations.Text = "Number Of Observations";
            // 
            // spinBoxNumObservations
            // 
            this.spinBoxNumObservations.Location = new System.Drawing.Point(225, 14);
            this.spinBoxNumObservations.Name = "spinBoxNumObservations";
            this.spinBoxNumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxNumObservations.TabIndex = 1;
            // 
            // buttonSetParameters
            // 
            this.buttonSetParameters.Location = new System.Drawing.Point(478, 51);
            this.buttonSetParameters.Name = "buttonSetParameters";
            this.buttonSetParameters.Size = new System.Drawing.Size(75, 23);
            this.buttonSetParameters.TabIndex = 2;
            this.buttonSetParameters.Text = "SET";
            this.buttonSetParameters.UseVisualStyleBackColor = true;
            // 
            // labelObservations
            // 
            this.labelObservations.AutoSize = true;
            this.labelObservations.Location = new System.Drawing.Point(-3, 101);
            this.labelObservations.Name = "labelObservations";
            this.labelObservations.Size = new System.Drawing.Size(69, 13);
            this.labelObservations.TabIndex = 1;
            this.labelObservations.Text = "Observations";
            // 
            // dataGridRecruitTable
            // 
            this.dataGridRecruitTable.AllowUserToAddRows = false;
            this.dataGridRecruitTable.AllowUserToDeleteRows = false;
            this.dataGridRecruitTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridRecruitTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecruitTable.Location = new System.Drawing.Point(0, 117);
            this.dataGridRecruitTable.Name = "dataGridRecruitTable";
            this.dataGridRecruitTable.Size = new System.Drawing.Size(855, 223);
            this.dataGridRecruitTable.TabIndex = 2;
            // 
            // ControlRecruitmentEmperical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridRecruitTable);
            this.Controls.Add(this.labelObservations);
            this.Controls.Add(this.groupEmpericalParameters);
            this.MinimumSize = new System.Drawing.Size(870, 355);
            this.Name = "ControlRecruitmentEmperical";
            this.Size = new System.Drawing.Size(870, 355);
            this.groupEmpericalParameters.ResumeLayout(false);
            this.groupEmpericalParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxNumObservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecruitTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupEmpericalParameters;
        private System.Windows.Forms.Button buttonSetParameters;
        private System.Windows.Forms.NumericUpDown spinBoxNumObservations;
        private System.Windows.Forms.Label labelNumObservations;
        private System.Windows.Forms.Label labelObservations;
        private System.Windows.Forms.DataGridView dataGridRecruitTable;
    }
}
