using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public partial class ControlRecruitmentEmpirical : UserControl
    {
        private int maxNumObservations { get; set; }

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
        private void buttonSetParameters_Click(object sender, EventArgs e)
        {
            try
            {
                int newNumObservationsValue = Convert.ToInt32(this.spinBoxNumObservations.Value);
                
                //Catch if the number of Observations exceed maxNumObservations limit 
                //(in case control couldn't prevent it)
                if (newNumObservationsValue > maxNumObservations)
                {
                    throw new AGEPRO.CoreLib.InvalidRecruitmentParameterException(
                        "Number of Observations exceed maximum limit of " + maxNumObservations +".");
                }

                //Delete rows if current count excceds new value
                if (this.dataGridRecruitTable.RowCount > newNumObservationsValue)
                {
                    List<DataRow> rowsToDelete = new List<DataRow>();
                    for(int i=0; i < (this.dataGridRecruitTable.RowCount); i++)
                    {
                        if ((i+1) > newNumObservationsValue)
                        {
                            DataRow deleteThisRow = ((DataTable)this.dataGridRecruitTable.DataSource).Rows[i];
                            rowsToDelete.Add(deleteThisRow);
                        }
                    }
                    foreach (DataRow drow in rowsToDelete)
                    {
                        ((DataTable)this.dataGridRecruitTable.DataSource).Rows.Remove(drow);
                    }
                }//Add rows if row counts is less than the new value 
                else if (this.dataGridRecruitTable.RowCount < newNumObservationsValue)
                {
                    for (int i = this.dataGridRecruitTable.RowCount; i < newNumObservationsValue; i++)
                    {
                        ((DataTable)this.dataGridRecruitTable.DataSource).Rows.Add();
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Can not resize number of Observation(s)." + Environment.NewLine + ex.Message,
                   "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }


    }
}
