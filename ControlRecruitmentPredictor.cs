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
    public partial class ControlRecruitmentPredictor : UserControl
    {
        private int maxRecruitPredictors { get; set; }

        public ControlRecruitmentPredictor()
        {
            InitializeComponent();
            maxRecruitPredictors = 5;
            spinBoxNumRecruitPredictors.Maximum = maxRecruitPredictors;
        }

        public int numRecruitPredictors
        {
            get { return Convert.ToInt32(spinBoxNumRecruitPredictors.Value); }
            set { spinBoxNumRecruitPredictors.Value = value; }
        }
        public double variance
        {
            get { return Convert.ToDouble(textBoxVariance.Text); }
            set { textBoxVariance.Text = value.ToString(); }
        }
        public double intercept
        {
            get { return Convert.ToDouble(textBoxIntercept.Text); }
            set { textBoxIntercept.Text = value.ToString(); }
        }
        public DataTable coefficientTable
        {
            get { return (DataTable)dataGridCoefficients.DataSource; }
            set { dataGridCoefficients.DataSource = value; }
        }
        public DataTable observationTable
        {
            get { return (DataTable)dataGridObservations.DataSource; }
            set { dataGridObservations.DataSource = value; }
        }

        private void buttonSetParameters_Click(object sender, EventArgs e)
        {
            int newNumPredictors = Convert.ToInt32(this.spinBoxNumRecruitPredictors.Value);
            coefficientTable = ResizePredictorDataGridTables(coefficientTable, newNumPredictors);
            observationTable = ResizePredictorDataGridTables(observationTable, newNumPredictors);
        }

        private DataTable ResizePredictorDataGridTables(DataTable predictorDataTable, int numPredictors)
        {
            numPredictors = Convert.ToInt32(this.spinBoxNumRecruitPredictors.Value);

            //Catch if the number of Observations exceed maxNumObservations limit 
            //(in case control couldn't prevent it)
            if (numPredictors > maxRecruitPredictors)
            {
                throw new AGEPRO.CoreLib.InvalidRecruitmentParameterException(
                    "Number of Observations exceed maximum limit of " + maxRecruitPredictors + ".");
            }

            //Delete rows if current count excceds new value
            if (predictorDataTable.Rows.Count > numPredictors)
            {
                List<DataRow> rowsToDelete = new List<DataRow>();
                for (int i = 0; i < predictorDataTable.Rows.Count; i++)
                {
                    if ((i + 1) > numPredictors)
                    {
                        DataRow deleteThisRow = predictorDataTable.Rows[i];
                        rowsToDelete.Add(deleteThisRow);
                    }
                }
                foreach (DataRow drow in rowsToDelete)
                {
                    predictorDataTable.Rows.Remove(drow);
                }
            }//Add rows if row counts is less than the new value 
            else if (predictorDataTable.Rows.Count < numPredictors)
            {
                for (int i = predictorDataTable.Rows.Count; i < numPredictors; i++)
                {
                    predictorDataTable.Rows.Add();
                }

            }
            return predictorDataTable;

            
            
        }
    }

}
