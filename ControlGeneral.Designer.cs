﻿namespace Nmfs.Agepro.Gui
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
            this.labelNumFleets = new System.Windows.Forms.Label();
            this.labelFirstYearProjection = new System.Windows.Forms.Label();
            this.labelModelID = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxModelID = new System.Windows.Forms.TextBox();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.textBoxFirstYearProjection = new System.Windows.Forms.TextBox();
            this.textBoxLastYearProjection = new System.Windows.Forms.TextBox();
            this.labelLastYearProjection = new System.Windows.Forms.Label();
            this.labelNumRecruitModels = new System.Windows.Forms.Label();
            this.textBoxNumRecruitModels = new System.Windows.Forms.TextBox();
            this.textBoxNumFleets = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelGeneralOptions = new System.Windows.Forms.TableLayoutPanel();
            this.groupGeneralOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxFirstAge)).BeginInit();
            this.tableLayoutPanelGeneralOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupGeneralOptions
            // 
            this.groupGeneralOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupGeneralOptions.Controls.Add(this.tableLayoutPanelGeneralOptions);
            this.groupGeneralOptions.Location = new System.Drawing.Point(58, 262);
            this.groupGeneralOptions.Name = "groupGeneralOptions";
            this.groupGeneralOptions.Size = new System.Drawing.Size(786, 221);
            this.groupGeneralOptions.TabIndex = 5;
            this.groupGeneralOptions.TabStop = false;
            this.groupGeneralOptions.Text = "Options";
            // 
            // spinBoxFirstAge
            // 
            this.spinBoxFirstAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.spinBoxFirstAge.Location = new System.Drawing.Point(233, 67);
            this.spinBoxFirstAge.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinBoxFirstAge.MinimumSize = new System.Drawing.Size(120, 0);
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
            this.buttonSetGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonSetGeneral.Location = new System.Drawing.Point(616, 127);
            this.buttonSetGeneral.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonSetGeneral.Name = "buttonSetGeneral";
            this.buttonSetGeneral.Size = new System.Drawing.Size(75, 27);
            this.buttonSetGeneral.TabIndex = 17;
            this.buttonSetGeneral.Text = "SET";
            this.buttonSetGeneral.UseVisualStyleBackColor = true;
            this.buttonSetGeneral.Click += new System.EventHandler(this.buttonSetGeneral_Click);
            // 
            // checkBoxDiscards
            // 
            this.checkBoxDiscards.AccessibleDescription = "";
            this.checkBoxDiscards.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxDiscards.AutoSize = true;
            this.checkBoxDiscards.Location = new System.Drawing.Point(74, 132);
            this.checkBoxDiscards.MinimumSize = new System.Drawing.Size(127, 17);
            this.checkBoxDiscards.Name = "checkBoxDiscards";
            this.checkBoxDiscards.Size = new System.Drawing.Size(127, 17);
            this.checkBoxDiscards.TabIndex = 8;
            this.checkBoxDiscards.Text = "Discards are Present";
            this.checkBoxDiscards.UseVisualStyleBackColor = true;
            // 
            // textBoxRandomSeed
            // 
            this.textBoxRandomSeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxRandomSeed.Location = new System.Drawing.Point(590, 98);
            this.textBoxRandomSeed.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxRandomSeed.Name = "textBoxRandomSeed";
            this.textBoxRandomSeed.Size = new System.Drawing.Size(120, 20);
            this.textBoxRandomSeed.TabIndex = 16;
            this.textBoxRandomSeed.Text = "0";
            // 
            // textBoxLastAge
            // 
            this.textBoxLastAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLastAge.Location = new System.Drawing.Point(233, 98);
            this.textBoxLastAge.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxLastAge.Name = "textBoxLastAge";
            this.textBoxLastAge.Size = new System.Drawing.Size(120, 20);
            this.textBoxLastAge.TabIndex = 7;
            // 
            // labelRandomSeed
            // 
            this.labelRandomSeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRandomSeed.AutoSize = true;
            this.labelRandomSeed.Location = new System.Drawing.Point(431, 102);
            this.labelRandomSeed.Name = "labelRandomSeed";
            this.labelRandomSeed.Size = new System.Drawing.Size(115, 13);
            this.labelRandomSeed.TabIndex = 15;
            this.labelRandomSeed.Text = "Random Number Seed";
            // 
            // labelLastAge
            // 
            this.labelLastAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLastAge.AutoSize = true;
            this.labelLastAge.Location = new System.Drawing.Point(74, 102);
            this.labelLastAge.Name = "labelLastAge";
            this.labelLastAge.Size = new System.Drawing.Size(77, 13);
            this.labelLastAge.TabIndex = 6;
            this.labelLastAge.Text = "Last Age Class";
            // 
            // textBoxNumPopSim
            // 
            this.textBoxNumPopSim.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxNumPopSim.Location = new System.Drawing.Point(590, 67);
            this.textBoxNumPopSim.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxNumPopSim.Name = "textBoxNumPopSim";
            this.textBoxNumPopSim.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumPopSim.TabIndex = 14;
            // 
            // labelNumPopSim
            // 
            this.labelNumPopSim.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNumPopSim.AutoSize = true;
            this.labelNumPopSim.Location = new System.Drawing.Point(431, 64);
            this.labelNumPopSim.Name = "labelNumPopSim";
            this.labelNumPopSim.Size = new System.Drawing.Size(112, 26);
            this.labelNumPopSim.TabIndex = 13;
            this.labelNumPopSim.Text = "Number of Population Simulations";
            // 
            // labelFirstAge
            // 
            this.labelFirstAge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFirstAge.AutoSize = true;
            this.labelFirstAge.Location = new System.Drawing.Point(74, 71);
            this.labelFirstAge.Name = "labelFirstAge";
            this.labelFirstAge.Size = new System.Drawing.Size(76, 13);
            this.labelFirstAge.TabIndex = 4;
            this.labelFirstAge.Text = "First Age Class";
            // 
            // labelNumFleets
            // 
            this.labelNumFleets.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNumFleets.AutoSize = true;
            this.labelNumFleets.Location = new System.Drawing.Point(431, 9);
            this.labelNumFleets.Name = "labelNumFleets";
            this.labelNumFleets.Size = new System.Drawing.Size(89, 13);
            this.labelNumFleets.TabIndex = 9;
            this.labelNumFleets.Text = "Number Of Fleets";
            // 
            // labelFirstYearProjection
            // 
            this.labelFirstYearProjection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFirstYearProjection.AutoSize = true;
            this.labelFirstYearProjection.Location = new System.Drawing.Point(74, 9);
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
            this.textBoxModelID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModelID.Location = new System.Drawing.Point(154, 170);
            this.textBoxModelID.Name = "textBoxModelID";
            this.textBoxModelID.Size = new System.Drawing.Size(658, 20);
            this.textBoxModelID.TabIndex = 1;
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputFile.Location = new System.Drawing.Point(154, 212);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(658, 20);
            this.textBoxInputFile.TabIndex = 3;
            // 
            // textBoxFirstYearProjection
            // 
            this.textBoxFirstYearProjection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFirstYearProjection.Location = new System.Drawing.Point(233, 5);
            this.textBoxFirstYearProjection.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxFirstYearProjection.Name = "textBoxFirstYearProjection";
            this.textBoxFirstYearProjection.Size = new System.Drawing.Size(120, 20);
            this.textBoxFirstYearProjection.TabIndex = 1;
            // 
            // textBoxLastYearProjection
            // 
            this.textBoxLastYearProjection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLastYearProjection.Location = new System.Drawing.Point(233, 36);
            this.textBoxLastYearProjection.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxLastYearProjection.Name = "textBoxLastYearProjection";
            this.textBoxLastYearProjection.Size = new System.Drawing.Size(120, 20);
            this.textBoxLastYearProjection.TabIndex = 3;
            // 
            // labelLastYearProjection
            // 
            this.labelLastYearProjection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLastYearProjection.AutoSize = true;
            this.labelLastYearProjection.Location = new System.Drawing.Point(74, 40);
            this.labelLastYearProjection.Name = "labelLastYearProjection";
            this.labelLastYearProjection.Size = new System.Drawing.Size(114, 13);
            this.labelLastYearProjection.TabIndex = 2;
            this.labelLastYearProjection.Text = "Last Year In Projection";
            // 
            // labelNumRecruitModels
            // 
            this.labelNumRecruitModels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNumRecruitModels.AutoSize = true;
            this.labelNumRecruitModels.Location = new System.Drawing.Point(431, 33);
            this.labelNumRecruitModels.Name = "labelNumRecruitModels";
            this.labelNumRecruitModels.Size = new System.Drawing.Size(121, 26);
            this.labelNumRecruitModels.TabIndex = 11;
            this.labelNumRecruitModels.Text = "Number Of Recruitment Models";
            // 
            // textBoxNumRecruitModels
            // 
            this.textBoxNumRecruitModels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxNumRecruitModels.Location = new System.Drawing.Point(590, 36);
            this.textBoxNumRecruitModels.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxNumRecruitModels.Name = "textBoxNumRecruitModels";
            this.textBoxNumRecruitModels.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumRecruitModels.TabIndex = 12;
            this.textBoxNumRecruitModels.Text = "1";
            // 
            // textBoxNumFleets
            // 
            this.textBoxNumFleets.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxNumFleets.Location = new System.Drawing.Point(590, 5);
            this.textBoxNumFleets.MinimumSize = new System.Drawing.Size(120, 20);
            this.textBoxNumFleets.Name = "textBoxNumFleets";
            this.textBoxNumFleets.Size = new System.Drawing.Size(120, 20);
            this.textBoxNumFleets.TabIndex = 10;
            this.textBoxNumFleets.Text = "1";
            // 
            // tableLayoutPanelGeneralOptions
            // 
            this.tableLayoutPanelGeneralOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelGeneralOptions.ColumnCount = 7;
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10818F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.47083F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.80409F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.47083F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.80409F));
            this.tableLayoutPanelGeneralOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.341974F));
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelFirstYearProjection, 1, 0);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.buttonSetGeneral, 5, 4);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.spinBoxFirstAge, 2, 2);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.checkBoxDiscards, 1, 4);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxNumRecruitModels, 5, 1);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxRandomSeed, 5, 3);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxFirstYearProjection, 2, 0);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelRandomSeed, 4, 3);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxLastAge, 2, 3);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelNumFleets, 4, 0);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxNumFleets, 5, 0);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelLastAge, 1, 3);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelNumPopSim, 4, 2);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelNumRecruitModels, 4, 1);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxNumPopSim, 5, 2);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.textBoxLastYearProjection, 2, 1);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelFirstAge, 1, 2);
            this.tableLayoutPanelGeneralOptions.Controls.Add(this.labelLastYearProjection, 1, 1);
            this.tableLayoutPanelGeneralOptions.Location = new System.Drawing.Point(6, 34);
            this.tableLayoutPanelGeneralOptions.Name = "tableLayoutPanelGeneralOptions";
            this.tableLayoutPanelGeneralOptions.RowCount = 5;
            this.tableLayoutPanelGeneralOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80529F));
            this.tableLayoutPanelGeneralOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80529F));
            this.tableLayoutPanelGeneralOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80529F));
            this.tableLayoutPanelGeneralOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80937F));
            this.tableLayoutPanelGeneralOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.77476F));
            this.tableLayoutPanelGeneralOptions.Size = new System.Drawing.Size(774, 157);
            this.tableLayoutPanelGeneralOptions.TabIndex = 18;
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
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "ControlGeneral";
            this.Size = new System.Drawing.Size(900, 520);
            this.groupGeneralOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxFirstAge)).EndInit();
            this.tableLayoutPanelGeneralOptions.ResumeLayout(false);
            this.tableLayoutPanelGeneralOptions.PerformLayout();
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
        private System.Windows.Forms.Label labelNumFleets;
        private System.Windows.Forms.Label labelFirstYearProjection;
        private System.Windows.Forms.NumericUpDown spinBoxFirstAge;
        private System.Windows.Forms.Label labelModelID;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.TextBox textBoxModelID;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneralOptions;
        private System.Windows.Forms.TextBox textBoxNumRecruitModels;
        private System.Windows.Forms.TextBox textBoxFirstYearProjection;
        private System.Windows.Forms.Label labelNumRecruitModels;
        private System.Windows.Forms.TextBox textBoxNumFleets;
        private System.Windows.Forms.Label labelLastYearProjection;
        private System.Windows.Forms.TextBox textBoxLastYearProjection;
    }
}
