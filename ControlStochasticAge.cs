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
    public enum StochasticAgeFleetDependency
    {
        dependent,
        independent
    };

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

            //By Default, Stochastic Parameters are fleet independent.
            fleetDependency = StochasticAgeFleetDependency.independent;

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
        public StochasticAgeFleetDependency fleetDependency 
        {
            get { return controlStochasticParamAgeFromUser.fleetDependent; }
            set { controlStochasticParamAgeFromUser.fleetDependent = value; }
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

        /// <summary>
        /// Generalized method to load Stochastic Data Parameters from AGEPRO Input Data files.
        /// </summary>
        /// <param name="inp">AGEPRO InputFile StochasticAge Parameters </param>
        /// <param name="generalOpt">AGEPRO InputFile General Options values</param>
        public void LoadStochasticAgeInputData(Nmfs.Agepro.CoreLib.AgeproStochasticAgeTable inp,
            Nmfs.Agepro.CoreLib.AgeproGeneral generalOpt)
        {
            this.readInputFileState = true;
            this.seqYears = Array.ConvertAll(generalOpt.SeqYears(), element => element.ToString());
            this.numFleets = generalOpt.numFleets;
            this.timeVarying = inp.timeVarying;
            this.stochasticDataFile = inp.dataFile;
            this.stochasticAgeTable = Util.GetAgeproInputDataTable(this.stochasticAgeTable, inp.byAgeData);
            this.stochasticCV = Util.GetAgeproInputDataTable(this.stochasticCV, inp.byAgeCV);
            if (!(this.stochasticAgeTable != null))
            {
                this.enableTimeVaryingCheckBox = false;
            }
            else
            {
                this.enableTimeVaryingCheckBox = true;
            }
            this.readInputFileState = false;
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

        /// <summary>
        /// Creates a empty Data Table for the Stochastic Parameter Control based on the user inputs gathered 
        /// from the General Options control parameter.
        /// </summary>
        /// <param name="genOpt">Paramters from the General Options Control</param>
        /// <param name="objNT">Object representing the Stochastic Parameter</param>
        /// <param name="fleetDependent">Is this Stochastic Parameter dependent on the 
        /// nubmber of fleets? Default is false.</param>
        public void CreateStochasticParameterFallbackDataTable(ControlGeneral genOpt,
            Nmfs.Agepro.CoreLib.AgeproStochasticAgeTable objNT,
            StochasticAgeFleetDependency fleetDependent = StochasticAgeFleetDependency.independent)
        {
            this.numFleets = Convert.ToInt32(genOpt.generalNumberFleets);
            this.seqYears = genOpt.SeqYears();
            this.readInputFileState = true;
            //Reset Tables if they were used before
            if (this.stochasticAgeTable != null)
            {
                this.stochasticAgeTable.Reset();
                this.stochasticCV.Reset();
            }

            if (this.timeVarying == true)
            {
                this.stochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(),
                    genOpt.SeqYears().Count(), this.numFleets);
            }
            else
            {
                if (fleetDependent == StochasticAgeFleetDependency.dependent)
                {
                    this.stochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, this.numFleets);
                    this.stochasticCV = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, this.numFleets);
                }
                else
                {
                    this.stochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, 1);
                    this.stochasticCV = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, 1);
                }

            }

            objNT.byAgeData = this.stochasticAgeTable;
            objNT.byAgeCV = this.stochasticCV;

            this.readInputFileState = false;

        }

        /// <summary>
        /// Creates an empty DataTable for AGEPRO Parameter Control based on the number ages and years (or 
        /// fleet-years).
        /// </summary>
        /// <param name="numAges">Number of Age Classes.</param>
        /// <param name="numYears">Number of Years (from First year to Last Year of projection)</param>
        /// <param name="numFleets">Number of Fleets. Default is 1</param>
        /// <returns>Returns a empty DataTable</returns>
        public DataTable CreateFallbackAgeDataTable(int numAges, int numYears, int numFleets = 1)
        {
            int numFleetYears = numYears * numFleets;

            DataTable fallbackTable = new DataTable();

            for (int icol = 0; icol < numAges; icol++)
            {
                fallbackTable.Columns.Add("Age" + " " + (icol + 1));
            }
            for (int row = 0; row < numFleetYears; row++)
            {
                fallbackTable.Rows.Add();
            }
            Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(fallbackTable);

            return fallbackTable;
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
