using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlRecruitmentEmpiricalTwoStage : Nmfs.Agepro.Gui.ControlRecruitmentEmpirical
    {
        public ControlRecruitmentEmpiricalTwoStage()
        {
            InitializeComponent();

            //Programmically Add Controls
            this.labelLv1NumObservations = new System.Windows.Forms.Label();
            this.spinBoxLv1NumObservations = new System.Windows.Forms.NumericUpDown();
            this.labelLv2NumObservations = new System.Windows.Forms.Label();
            this.spinBoxLv2NumObservations = new System.Windows.Forms.NumericUpDown();
            this.labelSSBBreakValue = new System.Windows.Forms.Label();
            this.textBoxSSBBreakValue = new System.Windows.Forms.TextBox();
            this.labelLv1ObservationTable = new System.Windows.Forms.Label();
            this.labelLv2ObservationTable = new System.Windows.Forms.Label();
            this.dataGridLv1ObservationTable = new Nmfs.Agepro.Gui.NftDataGridView();
            this.dataGridLv2ObservationTable = new Nmfs.Agepro.Gui.NftDataGridView();
            //this.groupEmpiricalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv1NumObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv2NumObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLv1ObservationTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLv2ObservationTable)).BeginInit();
            this.SuspendLayout();

            this.labelNumObservations.Visible = false;
            this.spinBoxNumObservations.Visible = false;
            this.dataGridRecruitTable.Visible = false;
            this.labelObservations.Visible = false;
            // 
            // labelLv1NumObservations
            // 
            this.labelLv1NumObservations.AutoSize = true;
            this.labelLv1NumObservations.Location = new System.Drawing.Point(18, 16);
            this.labelLv1NumObservations.Name = "labelLv1NumObservations";
            this.labelLv1NumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelLv1NumObservations.TabIndex = 0;
            this.labelLv1NumObservations.Text = "Level 1 Number Of Observations";
            // 
            // spinBoxLv1NumObservations
            // 
            this.spinBoxLv1NumObservations.Location = new System.Drawing.Point(225, 14);
            this.spinBoxLv1NumObservations.Name = "spinBoxLv1NumObservations";
            this.spinBoxLv1NumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxLv1NumObservations.TabIndex = 1;
            // 
            // labelLv2NumObservations
            // 
            this.labelLv2NumObservations.AutoSize = true;
            this.labelLv2NumObservations.Location = new System.Drawing.Point(18, 43);
            this.labelLv2NumObservations.Name = "labelLv2NumObservations";
            this.labelLv2NumObservations.Size = new System.Drawing.Size(123, 13);
            this.labelLv2NumObservations.TabIndex = 2;
            this.labelLv2NumObservations.Text = "Level 2 Number Of Observations";
            // 
            // spinBoxLv2NumObservations
            // 
            this.spinBoxLv2NumObservations.Location = new System.Drawing.Point(225, 40);
            this.spinBoxLv2NumObservations.Name = "spinBoxLv1NumObservations";
            this.spinBoxLv2NumObservations.Size = new System.Drawing.Size(120, 20);
            this.spinBoxLv2NumObservations.TabIndex = 3;
            // 
            // labelSSBBreakValue
            // 
            this.labelSSBBreakValue.AutoSize = true;
            this.labelSSBBreakValue.Location = new System.Drawing.Point(18, 69);
            this.labelSSBBreakValue.Name = "labelSSBBreakValue";
            this.labelSSBBreakValue.Size = new System.Drawing.Size(89, 13);
            this.labelSSBBreakValue.TabIndex = 5;
            this.labelSSBBreakValue.Text = "SSB Break Value (MT)";
            // 
            // textBoxSSBBreakValue
            // 
            this.textBoxSSBBreakValue.Location = new System.Drawing.Point(225, 66);
            this.textBoxSSBBreakValue.Name = "textBoxSSBBreakValue";
            this.textBoxSSBBreakValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxSSBBreakValue.TabIndex = 6;
            // 
            // labelLv1ObservationTable
            // 
            this.labelLv1ObservationTable.AutoSize = true;
            this.labelLv1ObservationTable.Location = new System.Drawing.Point(-3, 101);
            this.labelLv1ObservationTable.Name = "labelLv1Observations";
            this.labelLv1ObservationTable.Size = new System.Drawing.Size(69, 13);
            this.labelLv1ObservationTable.TabIndex = 8;
            this.labelLv1ObservationTable.Text = "Level 1 Observations";
            // 
            // dataGridLv1ObservationTable
            // 
            this.dataGridLv1ObservationTable.AllowUserToAddRows = false;
            this.dataGridLv1ObservationTable.AllowUserToDeleteRows = false;
            this.dataGridLv1ObservationTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) )));
            this.dataGridLv1ObservationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLv1ObservationTable.Location = new System.Drawing.Point(0, 117);
            this.dataGridLv1ObservationTable.Name = "dataGridLv1Observations";
            this.dataGridLv1ObservationTable.Size = new System.Drawing.Size(328, 223);
            this.dataGridLv1ObservationTable.TabIndex = 8;
            this.dataGridLv1ObservationTable.RowHeadersWidth = 70;
            this.dataGridLv1ObservationTable.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridLv1ObservationTable_CellFormatting);
            this.dataGridLv1ObservationTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridLv1ObservationTable_CellFormatting);
            // 
            // labelLv2ObservationTable
            // 
            this.labelLv2ObservationTable.AutoSize = true;
            this.labelLv2ObservationTable.Location = new System.Drawing.Point(447, 101);
            this.labelLv2ObservationTable.Name = "labelLv2Observations";
            this.labelLv2ObservationTable.Size = new System.Drawing.Size(69, 13);
            this.labelLv2ObservationTable.TabIndex = 9;
            this.labelLv2ObservationTable.Text = "Level 2 Observations";
            // 
            // dataGridLv1ObservationTable
            // 
            this.dataGridLv2ObservationTable.AllowUserToAddRows = false;
            this.dataGridLv2ObservationTable.AllowUserToDeleteRows = false;
            this.dataGridLv2ObservationTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) )));
            this.dataGridLv2ObservationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLv2ObservationTable.Location = new System.Drawing.Point(450, 117);
            this.dataGridLv2ObservationTable.Name = "dataGridLv1Observations";
            this.dataGridLv2ObservationTable.Size = new System.Drawing.Size(328, 223);
            this.dataGridLv2ObservationTable.TabIndex = 9;
            this.dataGridLv2ObservationTable.RowHeadersWidth = 70;
            this.dataGridLv1ObservationTable.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridLv2ObservationTable_CellFormatting);
            this.dataGridLv1ObservationTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridLv2ObservationTable_CellFormatting);


            this.buttonSetParameters.TabIndex = 7;
            this.groupEmpiricalParameters.Controls.Add(this.labelLv1NumObservations);
            this.groupEmpiricalParameters.Controls.Add(this.spinBoxLv1NumObservations);
            this.groupEmpiricalParameters.Controls.Add(this.labelLv2NumObservations);
            this.groupEmpiricalParameters.Controls.Add(this.spinBoxLv2NumObservations);
            this.groupEmpiricalParameters.Controls.Add(this.labelSSBBreakValue);
            this.groupEmpiricalParameters.Controls.Add(this.textBoxSSBBreakValue);
            this.groupEmpiricalParameters.Size = new System.Drawing.Size(574, 94);

            this.Controls.Add(this.labelLv1ObservationTable);
            this.Controls.Add(this.dataGridLv1ObservationTable);
            this.Controls.Add(this.labelLv2ObservationTable);
            this.Controls.Add(this.dataGridLv2ObservationTable);

            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv1NumObservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxLv2NumObservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLv1ObservationTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLv2ObservationTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }

        public int lv1NumObservations
        {
            get { return Convert.ToInt32(spinBoxLv1NumObservations.Value); }
            set { spinBoxLv1NumObservations.Value = value; }
        }
        public int lv2NumObservations
        {
            get { return Convert.ToInt32(spinBoxLv2NumObservations.Value); }
            set { spinBoxLv2NumObservations.Value = value; }
        }
        public int SSBBreakValue
        {
            get { return Convert.ToInt32(textBoxSSBBreakValue.Text); }
            set { textBoxSSBBreakValue.Text = value.ToString(); }
        }
        public DataTable lv1Observations
        {
            get { return (DataTable)dataGridLv1ObservationTable.DataSource; }
            set { dataGridLv1ObservationTable.DataSource = value; }
        }
        public DataTable lv2Observations
        {
            get { return (DataTable)dataGridLv2ObservationTable.DataSource; }
            set { dataGridLv2ObservationTable.DataSource = value; }
        }

        private System.Windows.Forms.Label labelLv1NumObservations;
        private System.Windows.Forms.NumericUpDown spinBoxLv1NumObservations;
        private System.Windows.Forms.Label labelLv2NumObservations;
        private System.Windows.Forms.NumericUpDown spinBoxLv2NumObservations;
        private System.Windows.Forms.Label labelSSBBreakValue;
        private System.Windows.Forms.TextBox textBoxSSBBreakValue;
        private System.Windows.Forms.Label labelLv1ObservationTable;
        private System.Windows.Forms.Label labelLv2ObservationTable;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridLv1ObservationTable;
        private Nmfs.Agepro.Gui.NftDataGridView dataGridLv2ObservationTable;

        protected override void buttonSetParameters_Click(object sender, EventArgs e)
        {
            try
            {
                int newNumLv1Obs = Convert.ToInt32(this.spinBoxLv1NumObservations.Value);
                int newNumLv2Obs = Convert.ToInt32(this.spinBoxLv2NumObservations.Value);

                if (newNumLv1Obs > maxNumObservations)
                {
                    throw new Nmfs.Agepro.CoreLib.InvalidAgeproParameterException(
                        "Number of Level 1 Observations exceed maximum limit of " + maxNumObservations + ".");
                }
                if (newNumLv2Obs > maxNumObservations)
                {
                    throw new Nmfs.Agepro.CoreLib.InvalidAgeproParameterException(
                        "Number of Level 2 Observations exceed maximum limit of " + maxNumObservations + ".");
                }

                lv1Observations = ControlRecruitment.ResizeDataGridTable(lv1Observations, newNumLv1Obs);
                lv2Observations = ControlRecruitment.ResizeDataGridTable(lv2Observations, newNumLv2Obs);

                ((Nmfs.Agepro.CoreLib.TwoStageEmpiricalRecruitment)
                    this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).lv1NumObs = newNumLv1Obs;
                ((Nmfs.Agepro.CoreLib.TwoStageEmpiricalRecruitment)
                    this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).lv2NumObs = newNumLv2Obs;
                ((Nmfs.Agepro.CoreLib.TwoStageEmpiricalRecruitment)
                    this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).SSBBreakVal 
                    = SSBBreakValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not resize number of Observation(s)." + Environment.NewLine + ex.Message,
                    "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void SetTwoStageEmpiricalRecruitmentControls(TwoStageEmpiricalRecruitment currentRecruit, 
            Panel panelRecruitModelParameter)
        {
            if (!(currentRecruit.lv1Obs != null))
            {
                currentRecruit.lv1Obs = currentRecruit.SetNewObsTable(0);
            }
            if (!(currentRecruit.lv2Obs != null))
            {
                currentRecruit.lv2Obs = currentRecruit.SetNewObsTable(0);
            }

            //Load TwoStage Controls
            this.lv1NumObservations = currentRecruit.lv1NumObs;
            this.lv2NumObservations = currentRecruit.lv2NumObs;
            this.SSBBreakValue = currentRecruit.SSBBreakVal;
            this.lv1Observations = currentRecruit.lv1Obs;
            this.lv2Observations = currentRecruit.lv2Obs;

            panelRecruitModelParameter.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelRecruitModelParameter.Controls.Add(this);
        }

        private void dataGridLv1ObservationTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = this.dataGridLv1ObservationTable.Rows[e.RowIndex].HeaderCell;
            if (!(header.Value != null))
            {
                base.SetEmpiricalRowHeadsers(this.dataGridLv1ObservationTable);
            }
        }

        private void dataGridLv2ObservationTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = this.dataGridLv2ObservationTable.Rows[e.RowIndex].HeaderCell;
            if (!(header.Value != null))
            {
                base.SetEmpiricalRowHeadsers(this.dataGridLv2ObservationTable);
            }
        }

    }
}
