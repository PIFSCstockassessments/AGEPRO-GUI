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
    public partial class ControlWeightAge : UserControl
    {
        private ControlStochasticAgeDataGridTable controlStochasticParamAgeFromUser;
        private ControlStochasticAgeFromFile controlStochasticParamAgeFromFile;

        public int indexWeightOption { get; set; }
        public Dictionary<int, RadioButton> weightOptionDictionary;

        public ControlWeightAge()
        {
            InitializeComponent();
            controlStochasticParamAgeFromUser = new ControlStochasticAgeDataGridTable();
            controlStochasticParamAgeFromFile = new ControlStochasticAgeFromFile();
            radioWeightsFromUser.Checked = true; //User Specfied Option Selected by Default
            controlStochasticParamAgeFromUser.stochasticParamAgeDataGridLabel = "Weights of Age";
            controlStochasticParamAgeFromUser.numFleets = 1;

            setWeightOptionDictionary();
        }
        public bool timeVarying
        {
            get { return controlStochasticParamAgeFromUser.timeVarying; }
            set { controlStochasticParamAgeFromUser.timeVarying = value; }
        }
        public bool readInputFileState
        {
            get { return controlStochasticParamAgeFromUser.readInputFileState; }
            set { controlStochasticParamAgeFromUser.readInputFileState = value; }
        }
        public bool enableTimeVaryingCheckBox
        {
            get { return controlStochasticParamAgeFromUser.enableTimeVaryingCheckBox; }
            set { controlStochasticParamAgeFromUser.enableTimeVaryingCheckBox = value; }
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
        public string stochasticDataFile
        {
            get { return controlStochasticParamAgeFromFile.stochasticDataFile; }
            set { controlStochasticParamAgeFromFile.stochasticDataFile = value; }
        }
        protected override void OnLoad(EventArgs e)
        {
            //

            if(weightOptionDictionary.ContainsKey(indexWeightOption))
            {
                weightOptionDictionary[indexWeightOption].Checked = true;
            }

            base.OnLoad(e);
        }

        private void radioWeightsFromUser_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            controlStochasticParamAgeFromUser.Dock = DockStyle.Fill;
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromUser);
        }

        private void radioWeightsFromFile_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromFile);
        }

        private void radioWeightsFromJan1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromSSB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromMidYear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWeightsFromCatch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void setWeightOptionDictionary()
        {
            weightOptionDictionary = new Dictionary<int, RadioButton>();

            weightOptionDictionary.Add(0, radioWeightsFromUser);
            weightOptionDictionary.Add(1, radioWeightsFromFile);
            weightOptionDictionary.Add(-1, radioWeightsFromJan1);
            weightOptionDictionary.Add(-2, radioWeightsFromSSB);
            weightOptionDictionary.Add(-3, radioWeightsFromMidYear);
            weightOptionDictionary.Add(-4, radioWeightsFromCatch);
            
        }
    }
}
