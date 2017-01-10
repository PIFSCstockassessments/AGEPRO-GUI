using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlRecruitmentEmpirical : UserControl
    {
        protected int maxNumObservations { get; set; }
        public List<RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }
        public int collectionSelectedIndex { get; set; }
        private EmpiricalType empiricalSubtype { get; set; }

        public ControlRecruitmentEmpirical()
        {
            InitializeComponent();
            maxNumObservations = 500;
            spinBoxNumObservations.Maximum = maxNumObservations;
            this.empiricalSubtype = EmpiricalType.Empirical;
        }

        public int numObservations
        {
            get { return Convert.ToInt32(spinBoxNumObservations.Value); }
            set { spinBoxNumObservations.Value = value; }
        }
        public DataTable observationTable
        {
            get { return (DataTable)dataGridRecruitTable.DataSource; }
            set { dataGridRecruitTable.DataSource = value; }
        }
       
        /// <summary>
        /// Changes the number of rows in the observations table, based on the value the
        /// Number of Observations spin box was set to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonSetParameters_Click(object sender, EventArgs e)
        {
            try
            {
                int newNumObservationsValue = Convert.ToInt32(this.spinBoxNumObservations.Value);

                //Catch if the number of Observations exceed maxNumObservations limit 
                //(in case control couldn't prevent it)
                if (newNumObservationsValue > maxNumObservations)
                {
                    throw new Nmfs.Agepro.CoreLib.InvalidAgeproParameterException(
                        "Number of Observations exceed maximum limit of " + maxNumObservations + ".");
                }
                observationTable = ControlRecruitment.ResizeDataGridTable(observationTable, newNumObservationsValue);
                numObservations = newNumObservationsValue;
                ((EmpiricalRecruitment)this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).numObs
                    = newNumObservationsValue;
                if (this.empiricalSubtype == EmpiricalType.CDFZero)
                {
                    ((EmpiricalCDFZero)this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).SSBHinge =
                        Convert.ToDouble(this.textBoxSSBHinge.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can not resize number of Observation(s)." + Environment.NewLine + ex.Message,
                   "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        public virtual void SetEmpiricalRecruitmentControls(EmpiricalRecruitment currentEmpiricalRecruitSelection, 
            Panel panelRecruitModelParameter)
        {
            //create empty obsTable if null
            if (!(currentEmpiricalRecruitSelection.obsTable != null))
            {
                currentEmpiricalRecruitSelection.obsTable = currentEmpiricalRecruitSelection.SetNewObsTable(0);
            }

            //Load control in panelRecruitModelParameter
            this.observationTable = currentEmpiricalRecruitSelection.obsTable;
            this.numObservations = currentEmpiricalRecruitSelection.numObs;

            panelRecruitModelParameter.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelRecruitModelParameter.Controls.Add(this);
        }

        public void SetEmpiricalCDFZeroRecruitmentControls(EmpiricalCDFZero currentRecruit, Panel panelRecruitModelParameter)
        {
            this.textBoxSSBHinge.Visible = true;
            this.labelSSBHinge.Visible = true;
            this.empiricalSubtype = EmpiricalType.CDFZero;

            this.textBoxSSBHinge.Text = currentRecruit.SSBHinge.Value.ToString(); //To explictly cast value from nullable double

            this.SetEmpiricalRecruitmentControls((EmpiricalRecruitment)currentRecruit, panelRecruitModelParameter);
        }

        private void dataGridRecruitTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = this.dataGridRecruitTable.Rows[e.RowIndex].HeaderCell;
            if (!(header.Value != null))
            {
                SetEmpiricalRowHeadsers(this.dataGridRecruitTable);
            }
        }

        protected void SetEmpiricalRowHeadsers(NftDataGridView empiricalDataGrid)
        {
            for (int i = 0; i < empiricalDataGrid.Rows.Count; i++)
            {
                empiricalDataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns></returns>
        protected virtual bool CheckMissingNumObservations(int selectedIndex)
        {
            //Number of Observations
            if (string.IsNullOrWhiteSpace(this.spinBoxNumObservations.Value.ToString()))
            {
                MessageBox.Show("Recruitment Selection " + selectedIndex + "has : "
                    + Environment.NewLine + "Missing number of Observations",
                    "AGEPRO Empirical Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        protected virtual bool ValidateObservationTable(int selectedIndex)
        {
            //Observation Table - Check for blank/null cells
            if (this.dataGridRecruitTable.HasBlankOrNullCells())
            {
                MessageBox.Show("Recruitment Selection " + selectedIndex + ": "
                    + Environment.NewLine + "Has missing Data in observation table",
                    "AGEPRO Empirical Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Observation Table - Check if value < 0.0001
            foreach (DataRow drow in this.observationTable.Rows)
            {
                foreach (DataColumn dcol in this.observationTable.Columns)
                {
                    if (Convert.ToDouble(drow[dcol]) < 0.0001)
                    {
                        MessageBox.Show("Recruitment Selection " + selectedIndex + ": "
                            + Environment.NewLine + "Has insignificant values in observation table",
                            "AGEPRO Empirical Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        protected virtual bool ValidateEmpiricalModel(EmpiricalRecruitment selectedRecruit, int selectedIndex)
        {
            if (selectedRecruit.subType == EmpiricalType.Empirical)
            {
                //Number of Observations
                if (CheckMissingNumObservations(selectedIndex) == false)
                {
                    return false;
                }
                //Observation Table
                if (ValidateObservationTable(selectedIndex) == false)
                {
                    return false;
                }

            }
            else if (selectedRecruit.subType == EmpiricalType.CDFZero)
            {
                //Number of Observations
                if (CheckMissingNumObservations(selectedIndex) == false)
                {
                    return false;
                }
                //SSB Hinge
                if (string.IsNullOrWhiteSpace(this.textBoxSSBHinge.Text.ToString()))
                {
                    MessageBox.Show("Recruitment Selection " + selectedIndex + "has : "
                        + Environment.NewLine + "Has missing SSB hinge value.",
                        "AGEPRO Empirical Recruitment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Observation Table
                if (ValidateObservationTable(selectedIndex) == false)
                {
                    return false;
                }
            }
            else if (selectedRecruit.subType == EmpiricalType.Fixed)
            {

            }
            return true;
        }

        protected virtual bool ValidateEmpiricalRecruitment(EmpiricalCDFZero selectedRecruit, int selectedIndex)
        {
            return true;
        }
    }
}
