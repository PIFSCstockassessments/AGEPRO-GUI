using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlStochasticAge : UserControl
    {
        protected ControlStochasticAgeDataGridTable controlStochasticParamAgeFromUser;
        protected ControlStochasticAgeFromFile controlStochasticParamAgeFromFile;
        protected bool settingParameterForControl { get; set; }
        public string stochasticParameterLabel { get; set; }
        
        public ControlStochasticAge()
        {
            InitializeComponent();
            controlStochasticParamAgeFromUser = new ControlStochasticAgeDataGridTable();
            controlStochasticParamAgeFromFile = new ControlStochasticAgeFromFile();
            radioParameterFromUser.Checked = true; //User Specfied Option Selected by Default
            stochasticParameterLabel = "Stochastic Parameters"; //Default Fallback Text
            settingParameterForControl = false;

            controlStochasticParamAgeFromFile.timeVaryingFileChecked += 
                new EventHandler(linkTimeVaryingUserSpecAndFromFile);
            controlStochasticParamAgeFromUser.timeVaryingCheckedChangedEvent +=
                new EventHandler(linkTimeVaryingUserSpecAndFromFile);
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
        public bool enableTimeVaryingCheckBox
        {
            get { return controlStochasticParamAgeFromUser.enableTimeVaryingCheckBox; }
            set { controlStochasticParamAgeFromUser.enableTimeVaryingCheckBox = value; }
        }

        protected void linkTimeVaryingUserSpecAndFromFile(object sender, EventArgs e)
        {
            var timeVaryingControl = sender as CheckBox;
            if (timeVaryingControl.Name == "checkBoxTimeVaryingFile")
            {
                timeVarying = timeVaryingControl.Checked;                
            }
            else if (timeVaryingControl.Name == "checkBoxTimeVarying")
            {
                controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Checked = timeVaryingControl.Checked;
                
            }
        }
        
        protected override void OnLoad(EventArgs e)
        {
            //(Re)Set Stochastic Parameter Label/Options text 
            radioParameterFromUser.Text = "User Specified " + this.stochasticParameterLabel + " At Age";
            radioParameterFromFile.Text = "Read " + this.stochasticParameterLabel + " From File";
            controlStochasticParamAgeFromUser.stochasticParamAgeDataGridLabel = this.stochasticParameterLabel + " Of Age";
            controlStochasticParamAgeFromFile.stochasticParameterFileLabel = this.stochasticParameterLabel;

            //enforce 'Time Varying' value inbetween the 'User Specifed DataGrid Tables' & 'File Dialog' panels
            controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Checked = timeVarying;
            controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Enabled = enableTimeVaryingCheckBox;
            //In cases where Stochastic Parameters has null data source (where the 'time varying' check box should 
            //be disabled), use that disabled state for the 'from file' panel.
            controlStochasticParamAgeFromFile.Enabled = enableTimeVaryingCheckBox;  

            base.OnLoad(e);
        }
        protected virtual void radioParameterFromUser_CheckedChanged(object sender, EventArgs e)
        {
            if (settingParameterForControl == false)
            {
                panelStochasticParameterAge.Controls.Clear();
                controlStochasticParamAgeFromUser.Dock = DockStyle.Fill;
                panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromUser);
            }

        }

        protected virtual void radioParameterFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (settingParameterForControl == false)
            {
                panelStochasticParameterAge.Controls.Clear();
                controlStochasticParamAgeFromFile.Dock = DockStyle.Fill;
                panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromFile);
            }
            
        }

        public virtual bool ValidateStochasticParameter(int numAges)
        {
            bool isVaildParameter = false;
            if (this.radioParameterFromUser.Checked)
            {
                //check if Data Grid has Blank or Null Cells 
                if (controlStochasticParamAgeFromUser.StochasticAgeDataGridTableContainMissingData())
                {
                    MessageBox.Show(this.stochasticParameterLabel + " At Age Data Table has " +
                        "blank or missing values.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (controlStochasticParamAgeFromUser.StochasticCVDataGridTableContainMissingData())
                {
                    MessageBox.Show(this.stochasticParameterLabel + " CV Data Table has" +
                        "blank or missing values.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            else
            {
                //If the Stochastic Table Data File Doesn't Exist
                if (!(System.IO.File.Exists(stochasticDataFile)))
                {
                    MessageBox.Show(this.stochasticParameterLabel + " stochastic table file does not exist", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
            isVaildParameter = true;
            return isVaildParameter;
        }

        public virtual bool ValidateStochasticParameter(int numAges, double upperBounds)
        {
            if (ValidateStochasticParameter(numAges) == false)
            {
                return false;
            }

            //Get DataTables
            DataTable stochasticTableToCheckBounds;
            if (this.radioParameterFromUser.Checked)
            {
                stochasticTableToCheckBounds = this.stochasticAgeTable;
            }
            else
            {   
                //Read in stochastic table file for validation.
                stochasticTableToCheckBounds = 
                    Nmfs.Agepro.CoreLib.AgeproStochasticAgeTable.ReadStochasticTableFile(stochasticDataFile, numAges);
            }

            //Check if a cell/item has excceded the upper bound.     
            foreach (DataRow rowLines in stochasticTableToCheckBounds.Rows)
            {
                foreach (var item in rowLines.ItemArray)
                {
                    if (Convert.ToDouble(item) > upperBounds)
                    {
                        MessageBox.Show(this.stochasticParameterLabel + " at Age excceds the Upper Bound of " +
                        upperBounds + Environment.NewLine +
                        "Upper bounds limit for "+ this.stochasticParameterLabel + " can be set in 'Misc. Options' panel.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
