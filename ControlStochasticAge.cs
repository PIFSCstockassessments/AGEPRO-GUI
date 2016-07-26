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
    public partial class ControlStochasticAge : UserControl
    {
        private ControlStochasticAgeDataGridTable controlStochasticParamAgeFromUser;
        private ControlStochasticAgeFromFile controlStochasticParamAgeFromFile;
        
        public ControlStochasticAge(string paramName="Stochastic Parameter")
        {
            InitializeComponent();
            controlStochasticParamAgeFromUser = new ControlStochasticAgeDataGridTable();
            controlStochasticParamAgeFromFile = new ControlStochasticAgeFromFile();
            radioParameterFromUser.Checked = true; //User Specfied Option Selected by Default

            string stochasticParameter = paramName;
            radioParameterFromUser.Text = "User Specified " + stochasticParameter + " At Age";
            radioParameterFromFile.Text = "Read "+ stochasticParameter + " From File";
            controlStochasticParamAgeFromUser.stochasticParamAgeDataGridLabel = stochasticParameter + " Of Age";
        }
        public bool timeVarying
        {
            get { return controlStochasticParamAgeFromUser.timeVarying; }
            set { controlStochasticParamAgeFromUser.timeVarying = value; }
        }
        public DataTable stochasticAgeTable
        {
            get { return controlStochasticParamAgeFromUser.stochasticAgeTable; }
            set { controlStochasticParamAgeFromUser.stochasticAgeTable = value; }
        }
        public DataTable stochasticCV
        {
            get { return controlStochasticParamAgeFromUser.stochasticCV; }
            set { controlStochasticParamAgeFromUser.stochasticCV = value; }
        }
        public string[] seqYears
        {
            get { return controlStochasticParamAgeFromUser.seqYears; }
            set { controlStochasticParamAgeFromUser.seqYears = value; }
        }
        public int numFleets
        {
            get { return controlStochasticParamAgeFromUser.numFleets; }
            set { controlStochasticParamAgeFromUser.numFleets = value; }
        }
        public string stochasticDataFile
        {
            get { return controlStochasticParamAgeFromFile.stochasticDataFile; }
            set { controlStochasticParamAgeFromFile.stochasticDataFile = value; }
        }
        public bool isMultiFleet
        {
            get { return controlStochasticParamAgeFromUser.multiFleetTable; }
            set { controlStochasticParamAgeFromUser.multiFleetTable = value; }
        }
        
        
        private void radioParameterFromUser_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromUser);
        }

        private void radioParameterFromFile_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromFile);
        }
    }
}
