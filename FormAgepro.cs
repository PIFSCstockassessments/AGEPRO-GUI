using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{

    public partial class FormAgepro : Form
    {
        private AgeproInputFile inputData;
        private ControlGeneral controlGeneralOptions;
        private ControlMiscOptions controlMiscOptions;
        private ControlBootstrap controlBootstrap;
        private ControlStochasticAge controlFisherySelectivity;
        private ControlStochasticAge controlDiscardFraction;
        private ControlStochasticAge controlNaturalMortality;
        private ControlBiological controlBiological;
        private ControlStochasticWeightAge controlJan1Weight;
        private ControlStochasticWeightAge controlSSBWeight;
        private ControlStochasticWeightAge controlMidYearWeight;
        private ControlStochasticWeightAge controlCatchWeight;
        private ControlStochasticWeightAge controlDiscardWeight;
        private ControlHarvestScenario controlHarvestScenario;
        private ControlRecruitment controlRecruitment;

        public FormAgepro()
        {
            InitializeComponent();
            SetupStartupState();
        }

        private void SetupStartupState()
        {
            //AGEPRO Input Data, If any
            inputData = new AgeproInputFile();

            //Load User Controls
            controlGeneralOptions = new ControlGeneral();
            controlMiscOptions = new ControlMiscOptions();
            controlBootstrap = new ControlBootstrap();
            controlFisherySelectivity = new ControlStochasticAge();
            controlDiscardFraction = new ControlStochasticAge();
            controlNaturalMortality = new ControlStochasticAge();
            controlBiological = new ControlBiological();
            controlJan1Weight = new ControlStochasticWeightAge();
            controlSSBWeight = new ControlStochasticWeightAge();
            controlMidYearWeight = new ControlStochasticWeightAge();
            controlCatchWeight = new ControlStochasticWeightAge();
            controlDiscardWeight = new ControlStochasticWeightAge();
            controlRecruitment = new ControlRecruitment();
            controlHarvestScenario = new ControlHarvestScenario();

            //Unsubcribe event handler in case previous one exists, before subcribing a new one
            controlGeneralOptions.SetGeneral -= new EventHandler(StartupStateEvent_SetGeneralButton);
            controlGeneralOptions.SetGeneral += new EventHandler(StartupStateEvent_SetGeneralButton);

            //Load General Options Controls to AGEPRO Parameter panel
            //TODO: create a function to set General Options Controls (for "Create New Case" menu option)
            this.panelAgeproParameter.Controls.Clear();
            controlGeneralOptions.Dock = DockStyle.Fill;
            this.panelAgeproParameter.Controls.Add(controlGeneralOptions);

            //initially set Number of Ages
            int initalNumAges = controlGeneralOptions.generalFirstAgeClass; //Spinbox Value

            //Biological Stochastic Options
            controlFisherySelectivity.stochasticParameterLabel = "Fishery Selectivity";
            controlFisherySelectivity.isMultiFleet = true;
            controlDiscardFraction.stochasticParameterLabel = "Discard Fraction";
            controlDiscardFraction.isMultiFleet = true;
            controlNaturalMortality.stochasticParameterLabel = "Natural Mortality";
            controlNaturalMortality.isMultiFleet = false;

            //Weight Age Options
            controlJan1Weight.isMultiFleet = false;
            controlSSBWeight.isMultiFleet = false;
            controlMidYearWeight.isMultiFleet = false;
            controlCatchWeight.isMultiFleet = true;
            controlDiscardWeight.isMultiFleet = true;

            controlJan1Weight.showJan1WeightsOption = false;
            controlJan1Weight.showSSBWeightsOption = false;
            controlJan1Weight.showMidYearWeightsOption = false;
            controlJan1Weight.showCatchWeightsOption = false;
            controlSSBWeight.showSSBWeightsOption = false;
            controlSSBWeight.showMidYearWeightsOption = false;
            controlSSBWeight.showCatchWeightsOption = false;
            controlMidYearWeight.showMidYearWeightsOption = false;
            controlMidYearWeight.showCatchWeightsOption = false;
            controlCatchWeight.showCatchWeightsOption = false;

            //Instatiate Startup State:
            //Disable Navigation Tree Panel, AGEPRO run options, etc...
            this.panelNavigation.Enabled = false;

        }
        
        /// <summary>
        /// Event when the "Create New Case" menu option is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dialog box to ensure that the user intends to start over and "create a new case"
            var dlgResult = MessageBox.Show("Do you want to start over with a new case?" 
                + Environment.NewLine + "New cases will discard current input data.", 
                "Create a new Case", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dlgResult == DialogResult.No)
            {
                //If not, exit this function.
                return;
            }
            else if(dlgResult == DialogResult.Yes)
            {
                //If so, Cleanup? and go to the Startup State
                SetupStartupState();
            }
            
        }

        /// <summary>
        /// Event when the "SET" button in the General options panel has been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartupStateEvent_SetGeneralButton(object sender, EventArgs e)
        {
            try
            {
                //Validate GeneralOption Parameters
                controlGeneralOptions.ValidateGeneralOptionsParameters();

                //Check for AGEPRO parameter data that has already been loaded/set 
                controlMiscOptions.miscOptionsNAges = controlGeneralOptions.NumAges();
                controlMiscOptions.miscOptionsFirstAge = controlGeneralOptions.generalFirstAgeClass;
                
                //Retro Adjustment Factors
                if (controlMiscOptions.miscOptionsEnableRetroAdjustmentFactors)
                {
                    if (controlMiscOptions.miscOptionsRetroAdjustmentFactorTable != null)
                    {
                        //In case NumAges is larger than previous row count, "reset" dataGridView 
                        if(controlGeneralOptions.NumAges() > 
                            controlMiscOptions.miscOptionsRetroAdjustmentFactorTable.Rows.Count)
                        {
                            controlMiscOptions.miscOptionsRetroAdjustmentFactorTable.Reset();
                        }
                    }
                    controlMiscOptions.miscOptionsRetroAdjustmentFactorTable =
                        controlMiscOptions.GetRetroAdjustmentFallbackTable(controlMiscOptions.miscOptionsNAges);
                    controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
                }

                //Set Stochastic Paramaeter DataGrids           
                CreateStochasticParameterFallbackDataTable(controlJan1Weight, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlSSBWeight, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlMidYearWeight, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlCatchWeight, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlFisherySelectivity, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlNaturalMortality, controlGeneralOptions);
                CreateStochasticParameterFallbackDataTable(controlBiological.maturityAge, controlGeneralOptions);
                
                //Show Discard DataTables if Discards options is checked
                if (controlGeneralOptions.generalDiscardsPresent == true)
                {
                    CreateStochasticParameterFallbackDataTable(controlDiscardFraction, controlGeneralOptions);
                    CreateStochasticParameterFallbackDataTable(controlDiscardWeight, controlGeneralOptions);
                }
                else
                {   //Otherwise "reset" the dataGridView if data exists. 
                    if(controlDiscardFraction.stochasticAgeTable != null)
                    {
                        controlDiscardFraction.stochasticAgeTable.Reset();
                        controlDiscardFraction.stochasticCV.Reset();
                    }
                    if (controlDiscardWeight.stochasticAgeTable != null)
                    {
                        controlDiscardWeight.stochasticAgeTable.Reset();
                        controlDiscardWeight.stochasticCV.Reset();
                    }
                }
                //Fraction Mortality
                controlBiological.CreateFractionMortalityColumns();

                //Recruitment
                /*
                controlRecruitment.numRecruitModels = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                controlRecruitment.recruitModelSelection = new int[controlRecruitment.numRecruitModels];
                controlRecruitment.SetDataGridComboBoxSelectRecruitModels(controlRecruitment.numRecruitModels);
                controlRecruitment.seqRecruitYears = controlGeneralOptions.SeqYears();
                controlRecruitment.recruitmentProb = 
                    CreateBlankDataTable(controlRecruitment.numRecruitModels, controlRecruitment.seqRecruitYears.Count(), 
                    "Selection");
                controlRecruitment.SetRecuitmentSelectionComboBox(controlRecruitment.numRecruitModels);
                controlRecruitment.collectionAgeproRecruitmentModels = 
                    new List<RecruitmentModel>(controlRecruitment.numRecruitModels);
                controlRecruitment.recruitingScalingFactor = 0;
                controlRecruitment.SSBScalingFactor = 0;
                */
                


                int nrecruit = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                List <RecruitmentModel> newCaseRecruitList = new List<RecruitmentModel>(nrecruit);
                for(int i = 0; i < nrecruit; i++){
                    newCaseRecruitList.Add(new NullSelectRecruitment());
                    newCaseRecruitList[i].obsYears = Array.ConvertAll<string,int>(controlGeneralOptions.SeqYears(), int.Parse);
                }   
                controlRecruitment.SetupControlRecruitment(
                    nrecruit,
                    newCaseRecruitList,
                    controlGeneralOptions.SeqYears(),
                    CreateBlankDataTable(Convert.ToInt32(nrecruit), controlGeneralOptions.SeqYears().Count(), "Selection"));
                
                //Harvest Scenario
                //Set harvest calculations to "Harvest Scenario"/None by Default
                controlHarvestScenario.seqYears = controlGeneralOptions.SeqYears();
                inputData.harvestScenario.analysisType = HarvestScenarioAnalysis.HarvestScenario;
                controlHarvestScenario.SetHarvestCalcuationOptionFromInput(inputData);
                DataTable userGenBasedHarvestScenarioTable = AgeproHarvestScenario.NewHarvestTable(
                    controlHarvestScenario.seqYears.Count(), 
                    Convert.ToInt32(controlGeneralOptions.generalNumberFleets));
                controlHarvestScenario.SetHarvestScenarioInputDataTable(userGenBasedHarvestScenarioTable);


                //Set General parameters to Nmfs.Agepro.CoreLib inputData class
                inputData.general.projYearStart = Convert.ToInt32(controlGeneralOptions.generalFirstYearProjection);
                inputData.general.projYearEnd = Convert.ToInt32(controlGeneralOptions.generalLastYearProjection);
                inputData.general.ageBegin = controlGeneralOptions.generalFirstAgeClass;
                inputData.general.ageEnd = controlGeneralOptions.generalLastAgeClass;
                inputData.general.numFleets = Convert.ToInt32(controlGeneralOptions.generalNumberFleets);
                inputData.general.numRecModels = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                inputData.general.numPopSims = Convert.ToInt32(controlGeneralOptions.generalNumberPopulationSimuations);
                inputData.general.seed = Convert.ToInt32(controlGeneralOptions.generalRandomSeed);
                inputData.general.hasDiscards = controlGeneralOptions.generalDiscardsPresent;
                inputData.general.inputFile = controlGeneralOptions.generalInputFile;

                //Activate Naivagation Panel if in first-run/startup state.
                //Disable/'Do not load' parameters to Discard Weight and Discard Fraction if 
                //Discards are Present is not checked
                EnableNavigationPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not set AGEPRO general paraneters." + Environment.NewLine + ex.Message,
                    "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Creates a empty Data Table for the Stochastic Parameter Control based on the user inputs gathered 
        /// from the General Options control parameter.
        /// </summary>
        /// <param name="ctl">Stochastic Parameter Control</param>
        /// <param name="genOpt">Paramters from the General Options Control</param>
        private void CreateStochasticParameterFallbackDataTable(ControlStochasticAge ctl, ControlGeneral genOpt)
        {
            ctl.numFleets = Convert.ToInt32(genOpt.generalNumberFleets);
            ctl.seqYears = genOpt.SeqYears();
            ctl.readInputFileState = true;
            //Reset Tables if they were used before
            if (ctl.stochasticAgeTable != null)
            {
                ctl.stochasticAgeTable.Reset();
                ctl.stochasticCV.Reset();
            }

            if (ctl.timeVarying == true)
            {
                ctl.stochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 
                    genOpt.SeqYears().Count(), ctl.numFleets);
            }
            else
            {
                ctl.stochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, ctl.numFleets);
            }
            ctl.stochasticCV = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, ctl.numFleets);
            ctl.readInputFileState = false;

        }

        /// <summary>
        /// Calls the OpenFileDialog Window to retrive an existing AGEPRO Input file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openExistingAGEPROInputDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openAgeproInputFile = new OpenFileDialog();

            openAgeproInputFile.InitialDirectory = "~";
            openAgeproInputFile.Filter = "AGEPRO input files (*.inp)|*.inp|All Files (*.*)|*.*";
            openAgeproInputFile.FilterIndex = 1;
            openAgeproInputFile.RestoreDirectory = true;
            
            if (openAgeproInputFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Use Nmfs.Agepro.CoreLib.AgeproInputFile.ReadInputFile
                    inputData = new AgeproInputFile();
                    inputData.ReadInputFile(openAgeproInputFile.FileName);
                    
                    controlGeneralOptions.generalInputFile = openAgeproInputFile.FileName;
                    
                    LoadAgeproInputParameters(this.inputData);

                    //Activate Naivagation Panel if in first-run/startup state.
                    EnableNavigationPanel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not load AGEPRO input file."+ Environment.NewLine + ex,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Event when "Save AGEPRO Input Data As ..." menu option is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAGEPROInputDataAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAgeproInputDataFileDialog();
        }

        /// <summary>
        /// Saves data that is currently on the GUI to file. 
        /// </summary>
        private void SaveAgeproInputDataFileDialog()
        {
            SaveFileDialog saveAgeproInputFile = new SaveFileDialog();
            saveAgeproInputFile.InitialDirectory = "~";
            saveAgeproInputFile.Filter = "AGEPRO input files (*.inp)|*.inp|All Files (*.*)|*.*";
            saveAgeproInputFile.FilterIndex = 1;
            saveAgeproInputFile.RestoreDirectory = true;

            if (saveAgeproInputFile.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    //Natural Mortality
                    inputData.jan1Weight.timeVarying = controlJan1Weight.timeVarying;
                    inputData.SSBWeight.timeVarying = controlSSBWeight.timeVarying;
                    inputData.meanWeight.timeVarying = controlSSBWeight.timeVarying;
                    inputData.catchWeight.timeVarying = controlCatchWeight.timeVarying;
                    inputData.maturity.timeVarying = controlBiological.maturityAge.timeVarying;
                    inputData.biological.timeVarying = controlBiological.fractionMortalityTimeVarying;
                    inputData.fishery.timeVarying = controlFisherySelectivity.timeVarying;
                    
                    if(inputData.general.hasDiscards == true)
                    {
                        inputData.discardWeight.timeVarying = controlDiscardWeight.timeVarying;
                        inputData.discardFraction.timeVarying = controlDiscardWeight.timeVarying;
                    }

                    //TEMP: DO Data Binding
                    //Misc options
                    inputData.options.enableSummaryReport = controlMiscOptions.miscOptionsEnableSummaryReport;
                    inputData.options.enableExportR = controlMiscOptions.miscOptionsEnableExportR;
                    inputData.options.enableAuxStochasticFiles = controlMiscOptions.miscOptionsEnableAuxStochasticFiles;
                    inputData.options.enablePercentileReport = controlMiscOptions.miscOptionsEnablePercentileReport;
                    inputData.options.enableRefpoint = controlMiscOptions.miscOptionsEnableRefpointsReport;
                    inputData.options.enableScaleFactors = controlMiscOptions.miscOptionsEnableScaleFactors;
                    inputData.options.enableBounds = controlMiscOptions.miscOptionsBounds;
                    inputData.options.enableRetroAdjustmentFactors = controlMiscOptions.miscOptionsEnableRetroAdjustmentFactors;

                    inputData.refpoint.refSpawnBio = Convert.ToDouble(controlMiscOptions.miscOptionsRefSpawnBiomass);
                    inputData.refpoint.refJan1Bio = Convert.ToDouble(controlMiscOptions.miscOptionsRefJan1Biomass);
                    inputData.refpoint.refMeanBio = Convert.ToDouble(controlMiscOptions.miscOptionsRefMeanBiomass);
                    inputData.refpoint.refFMort = Convert.ToDouble(controlMiscOptions.miscOptionsRefFishingMortality);

                    inputData.reportPercentile.percentile = controlMiscOptions.miscOptionsReportPercentile;

                    inputData.scale.scaleBio = Convert.ToDouble(controlMiscOptions.miscOptionsScaleFactorBiomass);
                    inputData.scale.scaleRec = Convert.ToDouble(controlMiscOptions.miscOptionsScaleFactorRecruits);
                    inputData.scale.scaleStockNum = Convert.ToDouble(controlMiscOptions.miscOptionsScaleFactorStockNumbers);

                    inputData.retroAdjustOption.retroAdjust = controlMiscOptions.miscOptionsRetroAdjustmentFactorTable;

                    inputData.WriteInputFile(saveAgeproInputFile.FileName);

                    MessageBox.Show("AGEPRO Input Data was saved at" + Environment.NewLine + saveAgeproInputFile.FileName,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AGEPRO input file was not saved." + Environment.NewLine + ex,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }

        }

        /// <summary>
        /// Programmicaly commit data in current active winform control.  
        /// </summary>
        private void commitFocusedControl()
        {
            //If a cell is in edit mode, commit changes and end edit mode.
            var ctlActive = FindFocusedControl(this.ActiveControl);
            if (ctlActive is DataGridViewTextBoxEditingControl)
            {
                EndEditModeFromDataGridViewTextBoxEditingControl((DataGridViewTextBoxEditingControl)ctlActive);
            }
            else if (ctlActive is TextBox)
            {
                //Take focus away from text box to force textBox validation.
                //use naviagation Tree workaround, since focusing on menuStrip isn't working
                this.treeViewNavigation.Focus();
                ctlActive.Focus(); //focus back to textBox.
                
            }
        }
        
        /// <summary>
        /// Event where "Launch AGEPRO Model" menu option is selected.
        /// This gathers the bootstrap file, and stores it with the the GUI input under the "AGEPRO" subdirectory
        /// in the desginagted user document directory. After the calcuation engine is done, the function will 
        /// attempt to display the AGEPRO calcuation engine output file (if requested) and the directory the
        /// outputs were written to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void launchAGEPROModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitFocusedControl();

            //Validate
            if (ValidateControlInputs() == false)
            {
                return;
            }
            if (ValidateBootstrapFilename() == false)
            {
                return;
            }

            //If Input Data is Valid LaunchAgeproModel() 
            LaunchAgeproModel();
            
        }


        private bool ValidateControlInputs()
        {
            double boundsMaxWeight;
            double boundsNaturalMortality;
            int numAges = controlGeneralOptions.NumAges();
            //Default values for bounds
            double defaultMaxWeightBound = 10.0;
            double defaultNatualMortalityBound = 1.0;

            //Enforce Bounds defaults if option is unchecked
            if(this.controlMiscOptions.miscOptionsBounds == false)
            {
                boundsMaxWeight = defaultMaxWeightBound;
                boundsNaturalMortality = defaultMaxWeightBound;
            }
            else
            {
                //Check Bounds text if they are empty. If so, use default value and inform the user about this.
                if (string.IsNullOrWhiteSpace(this.controlMiscOptions.miscOptionsBoundsMaxWeight))
                {
                    MessageBox.Show("Missing max weight bound. Using default value of " + defaultMaxWeightBound 
                        + ".", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    boundsMaxWeight = defaultMaxWeightBound;
                }
                else
                {
                    boundsMaxWeight = Convert.ToDouble(this.controlMiscOptions.miscOptionsBoundsMaxWeight);
                }

                if (string.IsNullOrWhiteSpace(this.controlMiscOptions.miscOptionsBoundsNaturalMortality))
                {
                    MessageBox.Show("Missing max natural mortality Bound. Using default value of " +
                        defaultNatualMortalityBound + ".", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    boundsNaturalMortality = defaultNatualMortalityBound;
                }
                else
                {
                    boundsNaturalMortality = Convert.ToDouble(
                        this.controlMiscOptions.miscOptionsBoundsNaturalMortality);
                }
                
            }

            //JAN-1 Weights (Stock Weights)
            if (controlJan1Weight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
            {
                return false;
            }
            //SSB Weights
            if (controlSSBWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
            {
                return false;
            }
            //Mean Weights
            if (controlMidYearWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
            {
                return false;
            }
            //Catch Weight
            if (controlCatchWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
            {
                return false;
            }
            //Natural Mortality
            if (controlNaturalMortality.ValidateStochasticParameter(numAges, boundsNaturalMortality) == false)
            {
                return false;
            }
            //(Biological) Maturity
            if (controlBiological.maturityAge.ValidateStochasticParameter(numAges) == false) 
            {
                return false;
            }
            //(Biological) Fraction Mortality Prior to Spawning (Biological)
            if (controlBiological.ValidateFractionMortalityDataGrid() == false)
            {
                return false;
            }
            //Fishery Selectivity
            if (controlFisherySelectivity.ValidateStochasticParameter(numAges) == false)
            {
                return false;
            }
            if (this.controlGeneralOptions.generalDiscardsPresent)
            {
                //Discard Weight
                if (this.controlDiscardWeight.ValidateStochasticParameter(numAges) == false)
                {
                    return false;
                }
                //Discard Fraction
                if (this.controlDiscardFraction.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
                {
                    return false;
                }
            }


            //Recruitment
            if (this.controlRecruitment.ValidateRecruitmentData() == false)
            {
                return false;
            }

            //Bootstrap
            if (this.controlBootstrap.ValidateBooleanInput() == false)
            {
                return false;
            }
            //Bootstrap Filename validtion via this.ValidateBootstrapFilename()

            //Harvest Scenario (this includes Rebuilder and P-Star options)
            if (this.controlHarvestScenario.ValidateHarvestScenario() == false)
            {
                return false;
            }

            //Misc Options: Reference Points, Retro Adjustment Factors, Bounds.
            if (this.controlMiscOptions.ValidateMiscOptions() == false)
            {
                return false;
            }

            //Aux Stochastic Output File Size Check 
            int numBootstraps = Convert.ToInt32(this.controlBootstrap.bootstrapIterations);
            int numSims = Convert.ToInt32(this.controlGeneralOptions.generalNumberPopulationSimuations);
            int numYears = this.controlGeneralOptions.SeqYears().Count();
            //size equals timeHorizon * numRealizations, which numRealizations is numBootstraps * numSims
            int auxFileRowSize = numBootstraps * numSims * numYears;
            if (this.controlMiscOptions.CheckOutputFileRowSize(auxFileRowSize) == false)
            {
                return false;
            }


            MessageBox.Show("Agepro Input Validated.",
                       "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }


        /// <summary>
        /// Validates The Bootstrap Filename parameter. If filename is invalid, it will attempt to find the 
        /// file, or otherwise it will ask the user if they want to explictly locate a file to open, via
        /// file dialog.
        /// </summary>
        /// <remarks>
        /// There are three methods how the bootstrap file can be located:
        /// 1. Filename exists from the bootstrap parameter
        /// 2. If not, assume that the bootsrap file (*.BSN) is in the same directory as the AGEPRO Input File.
        /// 3. Otherwise, User will must explictly locate the bootstrap file (via OpenFileDialog).
        /// 
        /// This is done automatically in LaunchAgeproModel. 
        /// </remarks>
        /// <returns></returns>
        private bool ValidateBootstrapFilename()
        {
            DialogResult bootstrapChoice;

            //Check Bootstrap File, but if value in textbox does not match, do not exit validation
            //Tell? user that they will have to supply bootstrap file.
            if (!File.Exists(this.controlBootstrap.bootstrapFilename))
            {
                if (File.Exists(Path.GetDirectoryName(inputData.general.inputFile) + "\\"
                    + Path.GetFileName(inputData.bootstrap.bootstrapFile)))
                {
                    string inpFileDir = Path.GetDirectoryName(inputData.general.inputFile);
                    string bsnFileName = Path.GetFileName(inputData.bootstrap.bootstrapFile);
                    bootstrapChoice = MessageBox.Show(
                        "Bootstrap filename was not found." + Environment.NewLine +
                        "However, a bootstap file " + bsnFileName + " was found at " + inpFileDir +
                        Environment.NewLine + Environment.NewLine +
                        "Continue?", "AGEPRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (bootstrapChoice == DialogResult.No)
                    {
                        return false;
                    }
                 
                }
                else
                {
                    bootstrapChoice = MessageBox.Show(
                        "Bootstrap filename was not found." + Environment.NewLine +
                        "However, the bootstrap file can be loaded via the open file dialog window."
                        + Environment.NewLine + Environment.NewLine + "Continue and load bootstrap file?",
                        "AGEPRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (bootstrapChoice == DialogResult.No)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }        

        /// <summary>
        /// This gathers the bootstrap file, and stores it with the the GUI input under the "AGEPRO" subdirectory
        /// in the desginagted user document directory. After the calcuation engine is done, the function will 
        /// attempt to display the AGEPRO calcuation engine output file (if requested) and the directory the
        /// outputs were written to.       
        /// </summary>
        private void LaunchAgeproModel()
        {
            string ageproModelJobName;
            string jobDT;
            //set the user data work directory  
            if (string.IsNullOrWhiteSpace(controlGeneralOptions.generalInputFile))
            {
                ageproModelJobName = "untitled_" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                jobDT = string.Format(ageproModelJobName + "_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            }
            else
            {
                ageproModelJobName = Path.GetFileNameWithoutExtension(controlGeneralOptions.generalInputFile);
                //Remove potential invalid filename characters 
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    ageproModelJobName = ageproModelJobName.Replace(c.ToString(), "");
                }
                jobDT = string.Format(ageproModelJobName + "_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
            }
            string ageproWorkPath = Path.Combine(Util.GetAgeproUserDataPath(), jobDT);
            string inpFile = Path.Combine(ageproWorkPath, ageproModelJobName + ".INP");
            string bsnFile = Path.Combine(ageproWorkPath, ageproModelJobName + ".BSN");

            if (!Directory.Exists(ageproWorkPath))
            {
                Directory.CreateDirectory(ageproWorkPath);
            }

            //check for bootstrap file
            //1. File Exists from the bootstrap parameter
            if (File.Exists(inputData.bootstrap.bootstrapFile))
            {
                File.Copy(inputData.bootstrap.bootstrapFile, bsnFile, true);
            }
            //2. If not, in the same directory as the AGEPRO Input File
            else if (File.Exists(Path.GetDirectoryName(inputData.general.inputFile) + "\\" + Path.GetFileName(inputData.bootstrap.bootstrapFile)))
            {
                File.Copy(Path.GetDirectoryName(inputData.general.inputFile) + "\\" + Path.GetFileName(inputData.bootstrap.bootstrapFile),
                    bsnFile, true);
            }
            //3. Else, Explictly locate the bootstrap file (via OpenFileDialog).
            else
            {
                OpenFileDialog openBootstrapFileDialog = ControlBootstrap.SetBootstrapOpenFileDialog();

                if (openBootstrapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(openBootstrapFileDialog.FileName, bsnFile, true);
                }
                else
                {
                    Console.WriteLine("Cancel Launch AGEPRO Model");
                    //If user declines (Cancel), do not Launch AGEPRO Calc Engine
                    return;
                }
            }

            string originalBSNFile = inputData.bootstrap.bootstrapFile;

            try
            {
                inputData.bootstrap.bootstrapFile = bsnFile; //set bootstrap file to copied workDir ver
                inputData.WriteInputFile(inpFile);

                //use command line to open AGEPRO40.exe
                LaunchAgeproCalcEngineProgram(inpFile);

                //crude method to search for AGEPRO output file
                string ageproOutfile = Directory.GetFiles(Path.GetDirectoryName(inpFile), "*.out").First();

                LaunchOutputViewerProgram(ageproOutfile, controlMiscOptions);

                //Open WorkPath directory for the user 
                Process.Start(ageproWorkPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured when Launching the AGEPRO Model." + Environment.NewLine + ex,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //reset original bootstrap filename 
                inputData.bootstrap.bootstrapFile = originalBSNFile;
            }
        }

        /// <summary>
        /// Launches the AGEPRO Calcuation Engine Program
        /// </summary>
        /// <param name="inpFile"></param>
        static void LaunchAgeproCalcEngineProgram(string inpFile)
        {
            string dirRoot = Path.GetPathRoot(Environment.SystemDirectory);

            ProcessStartInfo ageproEngine = new ProcessStartInfo();
            ageproEngine.WorkingDirectory = Application.StartupPath;
            ageproEngine.FileName = "AGEPRO40.exe";
            ageproEngine.Arguments = "\"\"" + inpFile + "\"\"";
            ageproEngine.WindowStyle = ProcessWindowStyle.Normal;

            try
            {
                using (Process exeProcess = Process.Start(ageproEngine))
                {
                    exeProcess.WaitForExit();
                }
                MessageBox.Show("AGEPRO Done. Can be Found at:" + Environment.NewLine + Path.GetDirectoryName(inpFile),
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured when running the AGEPRO Model." + Environment.NewLine + ex.Message,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Launches a program to view the AGEPRO calcuation engine output file
        /// </summary>
        /// <param name="outfile">AGEPRO calcuation engine output file</param>
        /// <param name="outputOptions"></param>
        static void LaunchOutputViewerProgram(string outfile, ControlMiscOptions outputOptions)
        {
            if (outputOptions.ageproOutputViewer == "System Default")
            {
                //open a program that is associated by its file type.
                //If no association exists, system will ask user for a program. 
                Process.Start(outfile); 
            }
            else if (outputOptions.ageproOutputViewer == "Notepad")
            {
                Process.Start("notepad.exe", outfile);
            }
           
        }
        

        /// <summary>
        /// Enables Navigation Panel, and menu controls that were disabled during the startup/first-run state.
        /// Change Discard Parameter enabled state by generalDiscardPresent option.  
        /// </summary>
        private void EnableNavigationPanel()
        {
            //Activates Naivagation Panel if in first-run/startup state.
            if (this.panelNavigation.Enabled == false)
            {
                this.panelNavigation.Enabled = true;
            }
            if(this.launchAGEPROModelToolStripMenuItem.Enabled == false)
            {
                this.launchAGEPROModelToolStripMenuItem.Enabled = true;
            }
            //if "Discards are Present" is not checked, disable the discard parameters panels.
            controlDiscardWeight.Enabled = controlGeneralOptions.generalDiscardsPresent;
            controlDiscardFraction.Enabled = controlGeneralOptions.generalDiscardsPresent;

            //Setup Data Binding for Parameter Controls  
            if (inputData != null)
            {
                controlBootstrap.SetBootstrapControls(inputData.bootstrap);
            }
            
        }

        /// <summary>
        /// Load AGEPRO InputFile data into AGEPRO Parameter Controls
        /// </summary>
        /// <param name="inpFile">AGEPRO CoreLib InputFile</param>
        private void LoadAgeproInputParameters(AgeproInputFile inpFile)
        {
            //General Options
            controlGeneralOptions.generalModelId = inpFile.caseID;
            controlGeneralOptions.generalFirstYearProjection = inpFile.general.projYearStart.ToString();
            controlGeneralOptions.generalLastYearProjection = inpFile.general.projYearEnd.ToString();
            controlGeneralOptions.generalFirstAgeClass = inpFile.general.ageBegin;
            controlGeneralOptions.generalLastAgeClass = inpFile.general.ageEnd;
            controlGeneralOptions.generalNumberFleets = inpFile.general.numFleets.ToString();
            controlGeneralOptions.generalNumberRecruitModels = inpFile.general.numRecModels.ToString();
            controlGeneralOptions.generalNumberPopulationSimuations = inpFile.general.numPopSims.ToString();
            controlGeneralOptions.generalRandomSeed = inpFile.general.seed.ToString();
            controlGeneralOptions.generalDiscardsPresent = inpFile.general.hasDiscards;

            //JAN-1
            loadWeightAgeInputData(controlJan1Weight, inpFile.jan1Weight, inpFile.general, true);

            //SSB
            loadWeightAgeInputData(controlSSBWeight, inpFile.SSBWeight, inpFile.general, true);

            //Mid-Year (Mean)
            loadWeightAgeInputData(controlMidYearWeight, inpFile.meanWeight, inpFile.general, true);

            //Catch Weight
            loadWeightAgeInputData(controlCatchWeight, inpFile.catchWeight, inpFile.general, true);

            //Discard Weight
            loadWeightAgeInputData(controlDiscardWeight, inpFile.discardWeight, inpFile.general,
                controlGeneralOptions.generalDiscardsPresent);  //Fallback Table Dependent on DiscardsPresent

            //Recruitment
            controlRecruitment.recruitModelSelection = new int[inpFile.general.numRecModels];
            controlRecruitment.recruitModelSelection = inpFile.recruitment.recruitType;
            controlRecruitment.numRecruitModels = inpFile.general.numRecModels;
            controlRecruitment.SetDataGridComboBoxSelectRecruitModels(controlRecruitment.numRecruitModels);
            controlRecruitment.recruitmentProb = inpFile.recruitment.recruitProb;
            controlRecruitment.seqRecruitYears = inpFile.recruitment.observationYears.Select(x => x.ToString()).ToArray();
            controlRecruitment.recruitingScalingFactor = inpFile.recruitment.recruitScalingFactor;
            controlRecruitment.SSBScalingFactor = inpFile.recruitment.SSBScalingFactor;
            controlRecruitment.collectionAgeproRecruitmentModels = inpFile.recruitment.recruitList;
            controlRecruitment.SetRecuitmentSelectionComboBox(inpFile.general.numRecModels);
            
            //Fishery Selectivity
            loadStochasticAgeInputData(controlFisherySelectivity, inpFile.fishery, inpFile.general);

            //Discard Fraction
            loadStochasticAgeInputData(controlDiscardFraction, inpFile.discardFraction, inpFile.general);

            //Natural Mortality
            loadStochasticAgeInputData(controlNaturalMortality, inpFile.naturalMortality, inpFile.general);

            //Maturity (Biological)
            loadStochasticAgeInputData(controlBiological.maturityAge, inpFile.maturity, inpFile.general);

            //Fraction Mortality Prior To Spawning (Biological)
            controlBiological.readFractionMortalityState = true;
            controlBiological.fractionMortality = 
                Util.GetAgeproInputDataTable (controlBiological.fractionMortality, inpFile.biological.TSpawn);
            controlBiological.fractionMortalityTimeVarying = inpFile.biological.timeVarying;
            controlBiological.readFractionMortalityState = false;

            //Harvest Scenario
            if (inpFile.harvestScenario.analysisType == HarvestScenarioAnalysis.Rebuilder)
            {
                controlHarvestScenario.Rebuilder = inpFile.rebuild;
            }
            else if (inpFile.harvestScenario.analysisType == HarvestScenarioAnalysis.PStar)
            {
                controlHarvestScenario.PStar = inpFile.pstar;
            }
            controlHarvestScenario.seqYears = inpFile.recruitment.observationYears.Select(x => x.ToString()).ToArray();
            controlHarvestScenario.SetHarvestScenarioInputDataTable(inpFile.harvestScenario.harvestScenarioTable);
            controlHarvestScenario.SetHarvestCalcuationOptionFromInput(inpFile);
            

            //Bootstrapping
            controlBootstrap.bootstrapFilename = inpFile.bootstrap.bootstrapFile;
            controlBootstrap.bootstrapIterations = inpFile.bootstrap.numBootstraps.ToString();
            controlBootstrap.bootstrapScaleFactors = inpFile.bootstrap.popScaleFactor.ToString();
            
            //Misc Options
            controlMiscOptions.miscOptionsEnableSummaryReport = inpFile.options.enableSummaryReport;
            controlMiscOptions.miscOptionsEnableAuxStochasticFiles = inpFile.options.enableAuxStochasticFiles;
            controlMiscOptions.miscOptionsEnableExportR = inpFile.options.enableExportR;
            controlMiscOptions.miscOptionsEnablePercentileReport = inpFile.options.enablePercentileReport;
            controlMiscOptions.miscOptionsReportPercentile = Convert.ToDouble(inpFile.reportPercentile.percentile);
            
            controlMiscOptions.miscOptionsEnableRefpointsReport = inpFile.options.enableRefpoint;
            controlMiscOptions.miscOptionsRefSpawnBiomass = inpFile.refpoint.refSpawnBio.ToString();
            controlMiscOptions.miscOptionsRefJan1Biomass = inpFile.refpoint.refJan1Bio.ToString();
            controlMiscOptions.miscOptionsRefMeanBiomass = inpFile.refpoint.refMeanBio.ToString();
            controlMiscOptions.miscOptionsRefFishingMortality = inpFile.refpoint.refFMort.ToString();
            
            controlMiscOptions.miscOptionsEnableScaleFactors = inpFile.options.enableScaleFactors;
            controlMiscOptions.miscOptionsScaleFactorBiomass = inpFile.scale.scaleBio.ToString();
            controlMiscOptions.miscOptionsScaleFactorRecruits = inpFile.scale.scaleRec.ToString();
            controlMiscOptions.miscOptionsScaleFactorStockNumbers = inpFile.scale.scaleStockNum.ToString();

            controlMiscOptions.miscOptionsBounds = inpFile.options.enableBounds;
            controlMiscOptions.miscOptionsBoundsMaxWeight = inpFile.bounds.maxWeight.ToString();
            controlMiscOptions.miscOptionsBoundsNaturalMortality = inpFile.bounds.maxNatMort.ToString();

            controlMiscOptions.miscOptionsEnableRetroAdjustmentFactors = inpFile.options.enableRetroAdjustmentFactors;
            controlMiscOptions.miscOptionsNAges = inpFile.general.NumAges();
            controlMiscOptions.miscOptionsFirstAge = inpFile.general.ageBegin;  

            controlMiscOptions.miscOptionsRetroAdjustmentFactorTable = 
                Util.GetAgeproInputDataTable(controlMiscOptions.miscOptionsRetroAdjustmentFactorTable, 
                inpFile.retroAdjustOption.retroAdjust);
                      
            if (controlMiscOptions.miscOptionsEnableRetroAdjustmentFactors == true)
            {
                controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
            }

            Console.WriteLine("Loaded AGEPRO Parameters ..");
        }

        /// <summary>
        /// Generalized method to load Stochastic Data Parameters from AGEPRO Input Data files.
        /// </summary>
        /// <param name="ctl">AGEPRO Stochastic Parameter User Control and Values</param>
        /// <param name="inp">AGEPRO InputFile StochasticAge Parameters </param>
        /// <param name="generalOpt">AGEPRO InputFile General Options values</param>
        private void loadStochasticAgeInputData(ControlStochasticAge ctl, Nmfs.Agepro.CoreLib.AgeproStochasticAgeTable inp, 
            Nmfs.Agepro.CoreLib.AgeproGeneral generalOpt)
        {   
            ctl.readInputFileState = true;
            ctl.seqYears = Array.ConvertAll(generalOpt.SeqYears(), element => element.ToString());
            ctl.numFleets = generalOpt.numFleets;
            ctl.timeVarying = inp.timeVarying;
            ctl.stochasticDataFile = inp.dataFile;
            ctl.stochasticAgeTable = Util.GetAgeproInputDataTable(ctl.stochasticAgeTable, inp.byAgeData);
            ctl.stochasticCV = Util.GetAgeproInputDataTable(ctl.stochasticCV, inp.byAgeCV);
            if (!(ctl.stochasticAgeTable != null))
            {
                ctl.enableTimeVaryingCheckBox = false;
            }
            else
            {
                ctl.enableTimeVaryingCheckBox = true;
            }
            ctl.readInputFileState = false;
        }

        /// <summary>
        /// Generalized method to load Stochastic Weight of Age Parameters from AGEPRO Input Data Files.
        /// </summary>
        /// <param name="ctl">AGEPRO Stochastic Weight of Age User Control and Values</param>
        /// <param name="inp">AGEPRO InputFile Weight of Age Onject</param>
        /// <param name="generalOpt">AGEPRO InputFile General Options</param>
        /// <param name="fallbackNullDataTable">Option to generate a empty DataTable if Input File does not 
        /// provide one</param>
        private void loadWeightAgeInputData(ControlStochasticWeightAge ctl, Nmfs.Agepro.CoreLib.AgeproWeightAgeTable inp,
            Nmfs.Agepro.CoreLib.AgeproGeneral generalOpt, bool fallbackNullDataTable = false)
        {
            ctl.indexWeightOption = inp.weightOpt;
            loadStochasticAgeInputData((ControlStochasticAge)ctl, (Nmfs.Agepro.CoreLib.AgeproStochasticAgeTable)inp, generalOpt);

            //Option to to fallback and create a empty DataTable if there input file DataTable (for 
            //weightAgeTable CVtable is Null)
            if (fallbackNullDataTable == true)
            {
                if (!(ctl.stochasticAgeTable != null))
                {
                    int numYears;
                    if (ctl.timeVarying == true)
                    {
                        numYears = generalOpt.NumYears();
                    }
                    else
                    {
                        numYears = 1;
                    }

                    ctl.stochasticAgeTable = CreateFallbackAgeDataTable(generalOpt.NumAges(), numYears, generalOpt.numFleets);
                    ctl.enableTimeVaryingCheckBox = true;
                }
                if (!(ctl.stochasticCV != null))
                {
                    ctl.stochasticCV = CreateFallbackAgeDataTable(generalOpt.NumAges(), 1, generalOpt.numFleets);
                }
            }
        }

        /// <summary>
        /// Creates an empty DataTable for AGEPRO Parameter Control based on the number ages and years (or 
        /// fleet-years).
        /// </summary>
        /// <param name="numAges">Number of Age Classes.</param>
        /// <param name="numYears">Number of Years (from First year to Last Year of projection)</param>
        /// <param name="numFleets">Number of Fleets. Default is 1</param>
        /// <returns>Returns a empty DataTable</returns>
        private DataTable CreateFallbackAgeDataTable(int numAges, int numYears, int numFleets = 1)
        {
            int numFleetYears = numYears * numFleets;
            return CreateBlankDataTable(numAges, numFleetYears, "Age");
        }

        /// <summary>
        /// Creates a generalized empty DataTable.
        /// </summary>
        /// <param name="yCol">Number of columns</param>
        /// <param name="xRows">Number of Rows</param>
        /// <param name="colName">Column Names</param>
        /// <returns></returns>
        private DataTable CreateBlankDataTable(int yCol, int xRows, string colName)
        {
            DataTable blankDataTable = new DataTable();

            for (int icol = 0; icol < yCol; icol++)
            {
                blankDataTable.Columns.Add(colName + " " + (icol + 1));
            }
            for (int row = 0; row < xRows; row++)
            {
                blankDataTable.Rows.Add();
            }
            return blankDataTable;
        }


        /// <summary>
        /// Closes the AGEPRO GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Terminate
            this.Close();
        }

        /// <summary>
        /// Opens the AGEPRO About Dialog Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutAGEPROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            commitFocusedControl();
            //About Box Dialog
            AboutAgepro aboutDialog = new AboutAgepro();
            aboutDialog.ShowDialog();
        }


        //stackoverflow.com/questions/435433/what-is-the-preferred-way-to-find-focused-control-in-winforms-app
        private static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl; //null if control wasn't container
            }
            return control;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvtb"></param>
        private void EndEditModeFromDataGridViewTextBoxEditingControl(DataGridViewTextBoxEditingControl dgvtb)
        {
            DataGridView dgw = dgvtb.EditingControlDataGridView;
            dgw.EndEdit();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {                
            var ctlCut = FindFocusedControl(this.ActiveControl);

            if (ctlCut != null)
            {
                if (ctlCut is TextBox)
                {
                    //Note: Text Boxes data bonded to AGEPRO_CoreLib will still retain their value 
                    //if nothing.
                    TextBox textBoxToCut = (TextBox)ctlCut;
                    textBoxToCut.Cut();
                }
                else if (ctlCut is NftDataGridView)
                {
                    NftDataGridView dataCellsToCut = (NftDataGridView)ctlCut;
                    dataCellsToCut.OnCopy();
                    dataCellsToCut.OnDelete();
                    dataCellsToCut.ClearSelection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ctlCopy = FindFocusedControl(this.ActiveControl);
            if (ctlCopy != null)
            {
                if (ctlCopy is TextBox)
                {
                    TextBox textBoxToCopy = (TextBox)ctlCopy;
                    textBoxToCopy.Copy();
                }
                else if (ctlCopy is NftDataGridView)
                {
                    NftDataGridView dataCellsToCopy = (NftDataGridView)ctlCopy;
                    dataCellsToCopy.OnCopy();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ctlPaste = FindFocusedControl(this.ActiveControl);
            if (ctlPaste != null)
            {
                if (ctlPaste is TextBox)
                {
                    TextBox textBoxToPaste = (TextBox)ctlPaste;
                    textBoxToPaste.Paste();
                }
                else if (ctlPaste is NftDataGridView)
                {
                    NftDataGridView dataCellsToPaste = (NftDataGridView)ctlPaste;
                    dataCellsToPaste.OnPaste();
                    dataCellsToPaste.ClearSelection();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ctlDelete = FindFocusedControl(this.ActiveControl);
            if (ctlDelete != null)
            {
                if (ctlDelete is TextBox)
                {
                    TextBox textBoxTextToClear = (TextBox)ctlDelete;
                    textBoxTextToClear.Clear();
                }
                else if (ctlDelete is NftDataGridView)
                {
                    NftDataGridView dataCellsToClear = (NftDataGridView)ctlDelete;
                    dataCellsToClear.OnDelete();
                    dataCellsToClear.ClearSelection();
                }
            }
        }

        /// TreeViewNavigation 

        /// <summary>
        /// Replaces an AGEPRO parameter user control in panelAgeproParmeter when a tree node from 
        /// treeViewNavigation is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewNavigation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedTreeNode = treeViewNavigation.SelectedNode.Name.ToString();

            //treeNode Action Dictionary
            Dictionary<string, Action> treeNodeDict =
                new Dictionary<string, Action> {

                {"treeNodeGeneral", selectGeneralOptionsParameterPanel},
                {"treeNodeJan1", selectJan1WeightsParameterPanel},
                {"treeNodeSSB", selectSSBWeightsParameterPanel},
                {"treeNodeMidYear", selectMidYearWeightsParameterPanel},
                {"treeNodeCatchWeight", selectCatchWeightParameterPanel},
                {"treeNodeDiscardWeight", selectDiscardWeightParameterPanel},
                {"treeNodeRecruitment",selectRecruitmentParameterPanel},
                {"treeNodeFisherySelectivity", selectFisherySelectivityParameterPanel},
                {"treeNodeDiscardFraction", selectDiscardFractionParameterPanel},
                {"treeNodeNaturalMortality", selectNaturalMortalityParameterPanel},
                {"treeNodeBiological", selectBiologicalParameterPanel},
                {"treeNodeBootstrapping", selectBootstrappingParameterPanel},
                {"treeNodeHarvestScenario", selectHarvestScenarioParameterPanel},
                {"treeNodeMiscOptions", selectMiscOptionsParameterPanel},
                
            };

            //If treeNode Action Dictionary key matches 'selectedTreeNode', then invoke the key's method
            if (treeNodeDict.ContainsKey(selectedTreeNode))
            {
                treeNodeDict[selectedTreeNode].Invoke();
            }

        }

        private void selectGeneralOptionsParameterPanel()
        {
            SelectAgeproParameterPanel(controlGeneralOptions, true);
        }
        private void selectJan1WeightsParameterPanel()
        {
            SelectAgeproParameterPanel(controlJan1Weight);
        }
        private void selectSSBWeightsParameterPanel()
        {
            SelectAgeproParameterPanel(controlSSBWeight);
        }
        private void selectMidYearWeightsParameterPanel()
        {
            SelectAgeproParameterPanel(controlMidYearWeight);
        }
        private void selectCatchWeightParameterPanel()
        {
            SelectAgeproParameterPanel(controlCatchWeight);
        }
        private void selectDiscardWeightParameterPanel()
        {
            SelectAgeproParameterPanel(controlDiscardWeight);
        }
        private void selectFisherySelectivityParameterPanel()
        {
            SelectAgeproParameterPanel(controlFisherySelectivity);
        }
        private void selectDiscardFractionParameterPanel()
        {
            SelectAgeproParameterPanel(controlDiscardFraction);
        }
        private void selectNaturalMortalityParameterPanel()
        {
            SelectAgeproParameterPanel(controlNaturalMortality);
        }
        private void selectBiologicalParameterPanel()
        {
            SelectAgeproParameterPanel(controlBiological);
        }
        private void selectBootstrappingParameterPanel()
        {
            SelectAgeproParameterPanel(controlBootstrap);
        }
        private void selectHarvestScenarioParameterPanel()
        {
            SelectAgeproParameterPanel(controlHarvestScenario);
        }
        private void selectMiscOptionsParameterPanel()
        {
            SelectAgeproParameterPanel(controlMiscOptions, false);
        }
        private void selectRecruitmentParameterPanel()
        {
            SelectAgeproParameterPanel(controlRecruitment);
        }

        /// <summary>
        /// Generalized method to set an AGEPRO Parameter User Control in the AGEPRO Parameter Panel
        /// </summary>
        /// <param name="ageproParameterControl">AGEPRO Parameter User Control</param>
        /// <param name="dockFill">Option to set Panel's Dock value to Dockstyle.Fill </param>
        private void SelectAgeproParameterPanel(UserControl ageproParameterControl, bool dockFill = true)
        {
            this.panelAgeproParameter.Controls.Clear();
            if (dockFill == true)
            {
                ageproParameterControl.Dock = DockStyle.Fill;
            }
            this.panelAgeproParameter.Controls.Add(ageproParameterControl);
        }


    }
}
