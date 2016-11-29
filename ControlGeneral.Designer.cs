namespace AGEPRO.GUI
{
    partial class ControlGeneral
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
            this.groupGeneralOptions = new System.Windows.Forms.GroupBox();
            this.spinBoxFirstAge = new System.Windows.Forms.NumericUpDown();
            this.buttonSetGeneral = new System.Windows.Forms.Button();
            this.checkBoxDiscards = new System.Windows.Forms.CheckBox();
            this.textBoxRandomSeed = new System.Windows.Forms.TextBox();
            this.textBoxLastAge = new System.Windows.Forms.TextBox();
            this.labelRandomSeed = new System.Windows.Forms.Label();
            this.labelLastAge = new System.Windows.Forms.Label();
            this.textBoxNumPopSim = new System.Windows.Forms.TextBox();
            this.labelNumPopSim = new System.Windows.Forms.Label();
            this.labelFirstAge = new System.Windows.Forms.Label();
            this.textBoxNumRecruitModels = new System.Windows.Forms.TextBox();
            this.textBoxLastYearProjection = new System.Windows.Forms.TextBox();
            this.labelNumRecruitModels = new System.Windows.Forms.Label();
            this.labelLastYearProjection = new System.Windows.Forms.Label();
            this.textBoxNumFleets = new System.Windows.Forms.TextBox();
            this.labelNumFleets = new System.Windows.Forms.Label();
            this.textBoxFirstYearProjection = new System.Windows.Forms.TextBox();
            this.labelFirstYearProjection = new System.Windows.Forms.Label();
            this.labelModelID = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxModelID = new System.Windows.Forms.TextBox();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.groupGeneralOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxFirstAge)).BeginInit();
            this.SuspendLayout();
            // 
            // groupGeneralOptions
            // 
            this.groupGeneralOptions.Controls.Add(this.spinBoxFirstAge);
            this.groupGeneralOptions.Controls.Add(this.buttonSetGeneral);
            this.groupGeneralOptions.Controls.Add(this.checkBoxDiscards);
            this.groupGeneralOptions.Controls.Add(this.textBoxRandomSeed);
            this.groupGeneralOptions.Controls.Add(this.textBoxLastAge);
            this.groupGeneralOptions.Controls.Add(this.labelRandomSeed);
            this.groupGeneralOptions.Controls.Add(this.labelLastAge);
            this.groupGeneralOptions.Controls.Add(this.textBoxNumPopSim);
            this.groupGeneralOptions.Controls.Add(this.labelNumPopSim);
            this.groupGeneralOptions.Controls.Add(this.labelFirstAge);
            this.groupGeneralOptions.Controls.Add(this.textBoxNumRecruitModels);
            this.groupGeneralOptions.Controls.Add(this.textBoxLastYearProjection);
            this.groupGeneralOptions.Controls.Add(this.labelNumRecruitModels);
            this.groupGeneralOptions.Controls.Add(this.labelLastYearProjection);
            this.groupGeneralOptions.Controls.Add(this.textBoxNumFleets);
            this.groupGeneralOptions.Controls.Add(this.labelNumFleets);
            this.groupGeneralOptions.Controls.Add(this.textBoxFirstYearProjection);
            this.groupGeneralOptions.Controls.Add(this.labelFirstYearProjection);
            this.groupGeneralOptions.Location = new System.Drawing.Point(58, 262);
            this.groupGeneralOptions.Name = "groupGeneralOptions";
            this.groupGeneralOptions.Size = new System.Drawing.Size(786, 221);
            this.groupGeneralOptions.TabIndex = 5;
            this.groupGeneralOptions.TabStop = false;
            this.groupGeneralOptions.Text = "Options";
            // 
            // spinBoxFirstAge
            // 
            this.spinBoxFirstAge.Location = new System.Drawing.Point(210, 99);
            this.spinBoxFirstAge.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinBoxFirstAge.Name = "spinBoxFirstAge";
            this.spinBoxFirstAge.Size = new System.Drawing.Size(120, 20);
            this.spinBoxFirstAge.TabIndex = 5;
            this.spinBoxFirstAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonSetGeneral
            // 
            this.buttonSetGeneral.Location = new System.Drawing.Point(620, 165);
            this.buttonSetGeneral.Name = "buttonSetGeneral";
            this.buttonSetGeneral.Size = new System.Drawing.Size(75, 23);
            this.buttonSetGeneral.TabIndex = 17;
            this.buttonSetGeneral.Text = "SET";
            this.buttonSetGeneral.UseVisualStyleBackColor = true;
            this.buttonSetGeneral.Click += new System.EventHandler(this.buttonSetGeneral_Click);
            // 
            // checkBoxDiscards
            // 
            this.checkBoxDiscards.AccessibleDescription = "";
            this.checkBoxDiscards.AutoSize = true;
            this.checkBoxDiscards.Location = new System.Drawing.Point(67, 165);
            this.checkBoxDiscards.Name = "checkBoxDiscards";
            this.checkBoxDiscards.Size = new System.Drawing.Size(124, 17);
            this.checkBoxDiscards.TabIndex = 8;
            this.checkBoxDiscards.Text = "Discards are Present";
            this.checkBoxDiscards.UseVisualStyleBackColor = true;
            // 
            // textBoxRandomSeed
            // 
            this.textBoxRandomSeed.Location = new System.Drawing.Point(575, 131);
            this.textBoxRandomSeed.Name = "textBoxRandomSeed";
            this.textBoxRandomSeed.Size = new System.Drawing.Size(120, 20);
            this.textBoxRandomSeed.TabIndex = 16;
            this.textBoxRandomSeed.Text = "0";
            // 
            // textBoxLastAge
            // 
            this.textBoxLastAge.Location = new System.Drawing.Point(210, 131);
            this.textBoxLastAge.Name = "textBoxLastAge";
            this.textBoxLastAge.Size = new System.Drawing.Size(120, 20);
            this.textBoxLastAge.TabIndex = 7;
            // 
            // labelRandomSeed
            // 
            this.labelRandomSeed.AutoSize = true;
            this.labelRandomSeed.Location = new System.Drawing.Point(385, 134);
            this.labelRandomSeed.Name = "labelRandomSeed";
            this.labelRandomSeed.Size = new System.Drawing.Size(115, 13);
            this.labelRandomSeed.TabIndex = 15;
            this.labelRandomSeed.Text = "Random Number Seed";
            // 
            // labelLastAge
            // 
            this.labelLastAge.AutoSize = true;
            this.labelLastAge.Location = new System.Drawing.Point(65, 134);
            this.labelLastAge.Name = "labelLastAge";
            this.labelLastAge.Size = new System.Drawing.Size(77, 13);
            this.labelLastAge.TabIndex = 6;
            this.labelLastAge.Text = "Last Age Class";
            // 
            // textBoxNumPopSim
            // 
            this.textBoxNumPopSim.Location = new System.Drawing.Point(575, 98);
            this.textBoxNumPopSim.Name = "textBoxNumPopSim";
            this.textBoxNumPopSim.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumPopSim.TabIndex = 14;
            // 
            // labelNumPopSim
            // 
            this.labelNumPopSim.AutoSize = true;
            this.labelNumPopSim.Location = new System.Drawing.Point(385, 101);
            this.labelNumPopSim.Name = "labelNumPopSim";
            this.labelNumPopSim.Size = new System.Drawing.Size(165, 13);
            this.labelNumPopSim.TabIndex = 13;
            this.labelNumPopSim.Text = "Number of Population Simulations";
            // 
            // labelFirstAge
            // 
            this.labelFirstAge.AutoSize = true;
            this.labelFirstAge.Location = new System.Drawing.Point(65, 101);
            this.labelFirstAge.Name = "labelFirstAge";
            this.labelFirstAge.Size = new System.Drawing.Size(76, 13);
            this.labelFirstAge.TabIndex = 4;
            this.labelFirstAge.Text = "First Age Class";
            // 
            // textBoxNumRecruitModels
            // 
            this.textBoxNumRecruitModels.Location = new System.Drawing.Point(575, 65);
            this.textBoxNumRecruitModels.Name = "textBoxNumRecruitModels";
            this.textBoxNumRecruitModels.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumRecruitModels.TabIndex = 12;
            this.textBoxNumRecruitModels.Text = "1";
            // 
            // textBoxLastYearProjection
            // 
            this.textBoxLastYearProjection.Location = new System.Drawing.Point(210, 65);
            this.textBoxLastYearProjection.Name = "textBoxLastYearProjection";
            this.textBoxLastYearProjection.Size = new System.Drawing.Size(120, 20);
            this.textBoxLastYearProjection.TabIndex = 3;
            // 
            // labelNumRecruitModels
            // 
            this.labelNumRecruitModels.AutoSize = true;
            this.labelNumRecruitModels.Location = new System.Drawing.Point(385, 68);
            this.labelNumRecruitModels.Name = "labelNumRecruitModels";
            this.labelNumRecruitModels.Size = new System.Drawing.Size(155, 13);
            this.labelNumRecruitModels.TabIndex = 11;
            this.labelNumRecruitModels.Text = "Number Of Recruitment Models";
            // 
            // labelLastYearProjection
            // 
            this.labelLastYearProjection.AutoSize = true;
            this.labelLastYearProjection.Location = new System.Drawing.Point(65, 68);
            this.labelLastYearProjection.Name = "labelLastYearProjection";
            this.labelLastYearProjection.Size = new System.Drawing.Size(114, 13);
            this.labelLastYearProjection.TabIndex = 2;
            this.labelLastYearProjection.Text = "Last Year In Projection";
            // 
            // textBoxNumFleets
            // 
            this.textBoxNumFleets.Location = new System.Drawing.Point(575, 32);
            this.textBoxNumFleets.Name = "textBoxNumFleets";
            this.textBoxNumFleets.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumFleets.TabIndex = 10;
            this.textBoxNumFleets.Text = "1";
            // 
            // labelNumFleets
            // 
            this.labelNumFleets.AutoSize = true;
            this.labelNumFleets.Location = new System.Drawing.Point(385, 35);
            this.labelNumFleets.Name = "labelNumFleets";
            this.labelNumFleets.Size = new System.Drawing.Size(89, 13);
            this.labelNumFleets.TabIndex = 9;
            this.labelNumFleets.Text = "Number Of Fleets";
            // 
            // textBoxFirstYearProjection
            // 
            this.textBoxFirstYearProjection.Location = new System.Drawing.Point(210, 32);
            this.textBoxFirstYearProjection.Name = "textBoxFirstYearProjection";
            this.textBoxFirstYearProjection.Size = new System.Drawing.Size(120, 20);
            this.textBoxFirstYearProjection.TabIndex = 1;
            // 
            // labelFirstYearProjection
            // 
            this.labelFirstYearProjection.AutoSize = true;
            this.labelFirstYearProjection.Location = new System.Drawing.Point(65, 35);
            this.labelFirstYearProjection.Name = "labelFirstYearProjection";
            this.labelFirstYearProjection.Size = new System.Drawing.Size(113, 13);
            this.labelFirstYearProjection.TabIndex = 0;
            this.labelFirstYearProjection.Text = "First Year In Projection";
            // 
            // labelModelID
            // 
            this.labelModelID.AutoSize = true;
            this.labelModelID.Location = new System.Drawing.Point(82, 173);
            this.labelModelID.Name = "labelModelID";
            this.labelModelID.Size = new System.Drawing.Size(50, 13);
            this.labelModelID.TabIndex = 0;
            this.labelModelID.Text = "Model ID";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(82, 215);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(50, 13);
            this.labelInputFile.TabIndex = 2;
            this.labelInputFile.Text = "Input File";
            // 
            // textBoxModelID
            // 
            this.textBoxModelID.Location = new System.Drawing.Point(154, 170);
            this.textBoxModelID.Name = "textBoxModelID";
            this.textBoxModelID.Size = new System.Drawing.Size(586, 20);
            this.textBoxModelID.TabIndex = 1;
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(154, 212);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(586, 20);
            this.textBoxInputFile.TabIndex = 3;
            // 
            // ControlGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.textBoxModelID);
            this.Controls.Add(this.labelInputFile);
            this.Controls.Add(this.labelModelID);
            this.Controls.Add(this.groupGeneralOptions);
            this.Name = "ControlGeneral";
            this.Size = new System.Drawing.Size(900, 520);
            this.groupGeneralOptions.ResumeLayout(false);
            this.groupGeneralOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxFirstAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupGeneralOptions;
        private System.Windows.Forms.Button buttonSetGeneral;
        private System.Windows.Forms.CheckBox checkBoxDiscards;
        private System.Windows.Forms.TextBox textBoxRandomSeed;
        private System.Windows.Forms.TextBox textBoxLastAge;
        private System.Windows.Forms.Label labelRandomSeed;
        private System.Windows.Forms.Label labelLastAge;
        private System.Windows.Forms.TextBox textBoxNumPopSim;
        private System.Windows.Forms.Label labelNumPopSim;
        private System.Windows.Forms.Label labelFirstAge;
        private System.Windows.Forms.TextBox textBoxNumRecruitModels;
        private System.Windows.Forms.TextBox textBoxLastYearProjection;
        private System.Windows.Forms.Label labelNumRecruitModels;
        private System.Windows.Forms.Label labelLastYearProjection;
        private System.Windows.Forms.TextBox textBoxNumFleets;
        private System.Windows.Forms.Label labelNumFleets;
        private System.Windows.Forms.TextBox textBoxFirstYearProjection;
        private System.Windows.Forms.Label labelFirstYearProjection;
        private System.Windows.Forms.NumericUpDown spinBoxFirstAge;
        private System.Windows.Forms.Label labelModelID;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.TextBox textBoxModelID;
        private System.Windows.Forms.TextBox textBoxInputFile;
    }
}
