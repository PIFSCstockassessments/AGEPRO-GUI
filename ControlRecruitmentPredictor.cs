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

        }
    }

}
