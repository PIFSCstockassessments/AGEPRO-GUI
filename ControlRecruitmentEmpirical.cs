using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitmentEmpirical : UserControl
    {
        protected int maxNumObservations { get; set; }
        public List<RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }
        public int collectionSelectedIndex { get; set; }

        public ControlRecruitmentEmpirical()
        {
            InitializeComponent();
            maxNumObservations = 500;
            spinBoxNumObservations.Maximum = maxNumObservations;
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
                    throw new AGEPRO.CoreLib.InvalidRecruitmentParameterException(
                        "Number of Observations exceed maximum limit of " + maxNumObservations + ".");
                }
                observationTable = ControlRecruitment.ResizeDataGridTable(observationTable, newNumObservationsValue);
                numObservations = newNumObservationsValue;
                ((EmpiricalRecruitment)this.collectionAgeproRecruitmentModels[this.collectionSelectedIndex]).numObs
                    = newNumObservationsValue;
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
    }
}
