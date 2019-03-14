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

        /// <summary>
        /// Initiates the Control's "Startup State" or the "Uninitialized Model" phase.
        /// </summary>
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
            controlJan1Weight = new ControlStochasticWeightAge(new int[] {0,1});
            controlSSBWeight = new ControlStochasticWeightAge(new int[] {0,1,-1});
            controlMidYearWeight = new ControlStochasticWeightAge(new int[] {0,1,-1,-2});
            controlCatchWeight = new ControlStochasticWeightAge(new int[] {0,1,-1,-2,-3});
            controlDiscardWeight = new ControlStochasticWeightAge(new int[] {0,1,-1,-2,-3,-4});
            controlRecruitment = new ControlRecruitment();
            controlHarvestScenario = new ControlHarvestScenario();

            //Unsubcribe event handler in case previous one exists, before subcribing a new one
            controlGeneralOptions.SetGeneral -= new EventHandler(EventSetButton_CreateNewCase);
            controlGeneralOptions.SetGeneral += new EventHandler(EventSetButton_CreateNewCase);

            //Load General Options Controls to AGEPRO Parameter panel           
            this.panelAgeproParameter.Controls.Clear();
            controlGeneralOptions.Dock = DockStyle.Fill;
            this.panelAgeproParameter.Controls.Add(controlGeneralOptions);
            //Set General Options Controls (to handle "New Cases")
            controlGeneralOptions.generalInputFile = "";
            controlGeneralOptions.generalModelId = "untitled";

            //initially set Number of Ages
            int initalNumAges = controlGeneralOptions.generalFirstAgeClass; //Spinbox Value

            //Biological Stochastic Options
            controlFisherySelectivity.stochasticParameterLabel = "Fishery Selectivity";
            controlFisherySelectivity.isMultiFleet = true;
            controlFisherySelectivity.fleetDependency = StochasticAgeFleetDependency.dependent;
            controlDiscardFraction.stochasticParameterLabel = "Discard Fraction";
            controlDiscardFraction.isMultiFleet = true;
            controlDiscardFraction.fleetDependency = StochasticAgeFleetDependency.dependent;
            controlNaturalMortality.stochasticParameterLabel = "Natural Mortality";
            controlNaturalMortality.isMultiFleet = false;
            controlNaturalMortality.fleetDependency = StochasticAgeFleetDependency.independent;



            //Weight Age Options
            controlJan1Weight.isMultiFleet = false;
            controlJan1Weight.fleetDependency = StochasticAgeFleetDependency.independent;
            controlSSBWeight.isMultiFleet = false;
            controlSSBWeight.fleetDependency = StochasticAgeFleetDependency.independent;
            controlMidYearWeight.isMultiFleet = false;
            controlMidYearWeight.fleetDependency = StochasticAgeFleetDependency.independent;
            controlCatchWeight.isMultiFleet = true;
            controlCatchWeight.fleetDependency = StochasticAgeFleetDependency.dependent;
            controlDiscardWeight.isMultiFleet = true;
            controlDiscardWeight.fleetDependency = StochasticAgeFleetDependency.dependent;

            controlJan1Weight.weightAgeType = StochasticWeightOfAge.Jan1Weight;
            controlSSBWeight.weightAgeType = StochasticWeightOfAge.SSBWeight;
            controlMidYearWeight.weightAgeType = StochasticWeightOfAge.MidYearWeight;
            controlCatchWeight.weightAgeType = StochasticWeightOfAge.CatchWeight;
            controlDiscardWeight.weightAgeType = StochasticWeightOfAge.DiscardWeight;

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
            this.saveAGEPROInputDataAsToolStripMenuItem.Enabled = false;

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
        public void EventSetButton_CreateNewCase(object sender, EventArgs e)
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
                controlJan1Weight.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.jan1Weight);
                controlSSBWeight.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.SSBWeight);
                controlMidYearWeight.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.meanWeight);
                controlCatchWeight.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.catchWeight,
                    StochasticAgeFleetDependency.dependent);
                controlFisherySelectivity.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.fishery,
                    StochasticAgeFleetDependency.dependent);
                
                controlNaturalMortality.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.naturalMortality);
                controlBiological.maturityAge.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.maturity);
                
                //Show Discard DataTables if Discards options is checked
                if (controlGeneralOptions.generalDiscardsPresent == true)
                {
                    controlDiscardFraction.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.discardFraction,
                        StochasticAgeFleetDependency.dependent);
                    controlDiscardWeight.CreateStochasticParameterFallbackDataTable(controlGeneralOptions, inputData.discardWeight);
                
                }
                else
                {   //Otherwise remove ("reset") any dataGridView existing data. 
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
                
                //(Biological) Fraction Mortality
                inputData.biological.CreateFallbackTSpawnTable(controlGeneralOptions.SeqYears());
                controlBiological.fractionMortality = inputData.biological.TSpawn;

                //Recruitment
                int nrecruit = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                inputData.recruitment.newCaseRecruitment(nrecruit, controlGeneralOptions.SeqYears());
                controlRecruitment.SetupControlRecruitment(nrecruit, inputData.recruitment);
                

                //Harvest Scenario
                //Set harvest calculations to "Harvest Scenario"/None by Default
                controlHarvestScenario.seqYears = controlGeneralOptions.SeqYears();
                inputData.harvestScenario.analysisType = HarvestScenarioAnalysis.HarvestScenario;
                controlHarvestScenario.SetHarvestCalcuationOptionFromInput(inputData);
                DataTable userGenBasedHarvestScenarioTable = AgeproHarvestScenario.NewHarvestTable(
                    controlHarvestScenario.seqYears.Count(), 
                    Convert.ToInt32(controlGeneralOptions.generalNumberFleets));
                controlHarvestScenario.SetHarvestScenarioInputDataTable(userGenBasedHarvestScenarioTable);
                inputData.harvestScenario.harvestScenarioTable = userGenBasedHarvestScenarioTable;

                //Bootstrap
                controlBootstrap.SetBootstrapControls(inputData.bootstrap);


                //New Cases references version included in AGEPRO Reference Manual
                inputData.version = "AGEPRO VERSION 4.2";

                //Save General Options input to CoreLib Input Data Object
                inputData.general.projYearStart = Convert.ToInt32(controlGeneralOptions.generalFirstYearProjection); 
                inputData.general.projYearEnd = Convert.ToInt32(controlGeneralOptions.generalLastYearProjection);
                inputData.general.ageBegin = controlGeneralOptions.generalFirstAgeClass;
                inputData.general.ageEnd = controlGeneralOptions.generalLastAgeClass;
                inputData.general.numFleets = Convert.ToInt32(controlGeneralOptions.generalNumberFleets);
                inputData.general.numRecModels = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                inputData.general.numPopSims = Convert.ToInt32(controlGeneralOptions.generalNumberPopulationSimuations);
                inputData.general.seed = Convert.ToInt32(controlGeneralOptions.generalRandomSeed);
                inputData.general.hasDiscards = controlGeneralOptions.generalDiscardsPresent;

                //Activate Naivagation Panel if in first-run/startup state.
                //Disable/'Do not load' parameters to Discard Weight and Discard Fraction if 
                //Discards are Present is not checked
                EnableNavigationPanel();

                MessageBox.Show ("General AGEPRO Projection Parameters set." + Environment.NewLine + Environment.NewLine +
                "Recruitment and Bootstrap file is required to save as AGEPRO input file or "+
                "to launch AGEPRO model.","AGEPRO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not set AGEPRO general paraneters." + Environment.NewLine + ex.Message,
                    "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

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
                    //Validate
                    if (ValidateControlInputs() == false)
                    {
                        throw new InvalidAgeproParameterException("Unable to save AGEPRO Input Data due to invalid input.");
                    }

                    //Case Id
                    this.inputData.caseID = controlGeneralOptions.generalModelId;

                    //Natural Mortality
                    controlJan1Weight.bindStochasticAgeData(this.inputData.jan1Weight);
                    controlSSBWeight.bindStochasticAgeData(this.inputData.SSBWeight);
                    controlMidYearWeight.bindStochasticAgeData(this.inputData.meanWeight);
                    controlCatchWeight.bindStochasticAgeData(this.inputData.catchWeight);
                    controlBiological.maturityAge.bindStochasticAgeData(this.inputData.maturity);
                    this.inputData.biological.timeVarying = controlBiological.fractionMortalityTimeVarying;
                    controlFisherySelectivity.bindStochasticAgeData(this.inputData.fishery);

                    if(this.inputData.general.hasDiscards == true)
                    {
                        controlDiscardWeight.bindStochasticAgeData(this.inputData.discardWeight);
                        controlDiscardFraction.bindStochasticAgeData(this.inputData.discardFraction);     
                    }

                    //Misc options
                    this.inputData.options.enableSummaryReport = controlMiscOptions.miscOptionsEnableSummaryReport;
                    this.inputData.options.enableExportR = controlMiscOptions.miscOptionsEnableExportR;
                    this.inputData.options.enableAuxStochasticFiles = controlMiscOptions.miscOptionsEnableAuxStochasticFiles;
                    this.inputData.options.enablePercentileReport = controlMiscOptions.miscOptionsEnablePercentileReport;
                    this.inputData.options.enableRefpoint = controlMiscOptions.miscOptionsEnableRefpointsReport;
                    this.inputData.options.enableScaleFactors = controlMiscOptions.miscOptionsEnableScaleFactors;
                    this.inputData.options.enableBounds = controlMiscOptions.miscOptionsBounds;
                    this.inputData.options.enableRetroAdjustmentFactors = controlMiscOptions.miscOptionsEnableRetroAdjustmentFactors;

                    this.inputData.refpoint.refSpawnBio = Double.Parse(controlMiscOptions.miscOptionsRefSpawnBiomass);
                    this.inputData.refpoint.refJan1Bio = Double.Parse(controlMiscOptions.miscOptionsRefJan1Biomass);
                    this.inputData.refpoint.refMeanBio = Double.Parse(controlMiscOptions.miscOptionsRefMeanBiomass);
                    this.inputData.refpoint.refFMort = Double.Parse(controlMiscOptions.miscOptionsRefFishingMortality);

                    this.inputData.reportPercentile.percentile = controlMiscOptions.miscOptionsReportPercentile;

                    this.inputData.scale.scaleBio = Double.Parse(controlMiscOptions.miscOptionsScaleFactorBiomass);
                    this.inputData.scale.scaleRec = Double.Parse(controlMiscOptions.miscOptionsScaleFactorRecruits);
                    this.inputData.scale.scaleStockNum = Double.Parse(controlMiscOptions.miscOptionsScaleFactorStockNumbers);

                    this.inputData.retroAdjustOption.retroAdjust = controlMiscOptions.miscOptionsRetroAdjustmentFactorTable;

                    this.inputData.WriteInputFile(saveAgeproInputFile.FileName);

                    //Set filename to generalOptions Input File textbox
                    this.controlGeneralOptions.generalInputFile = saveAgeproInputFile.FileName;
 
                    MessageBox.Show("AGEPRO Input Data was saved at" + Environment.NewLine + saveAgeproInputFile.FileName,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("AGEPRO input file was not saved." + Environment.NewLine + ex.Message,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
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
            controlJan1Weight.LoadWeightAgeInputData(inpFile.jan1Weight, inpFile.general);

            //SSB
            controlSSBWeight.LoadWeightAgeInputData(inpFile.SSBWeight, inpFile.general);

            //Mid-Year (Mean)
            controlMidYearWeight.LoadWeightAgeInputData(inpFile.meanWeight, inpFile.general);

            //Catch Weight
            controlCatchWeight.LoadWeightAgeInputData(inpFile.catchWeight, inpFile.general);

            //Discard Weight
            controlDiscardWeight.LoadWeightAgeInputData(inpFile.discardWeight, inpFile.general);

            //Recruitment
            controlRecruitment.SetupControlRecruitment(inpFile.general.numRecModels, inpFile.recruitment);

            //Fishery Selectivity
            controlFisherySelectivity.LoadStochasticAgeInputData(inpFile.fishery, inpFile.general);

            //Discard Fraction
            controlDiscardFraction.LoadStochasticAgeInputData(inpFile.discardFraction, inpFile.general);

            //Natural Mortality
            controlNaturalMortality.LoadStochasticAgeInputData(inpFile.naturalMortality, inpFile.general);

            //Maturity (Biological)
            controlBiological.maturityAge.LoadStochasticAgeInputData(inpFile.maturity, inpFile.general);

            //Fraction Mortality Prior To Spawning (Biological)
            controlBiological.readFractionMortalityState = true;
            controlBiological.fractionMortality =
                Util.GetAgeproInputDataTable(controlBiological.fractionMortality, inpFile.biological.TSpawn);
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
        /// Programmicaly commit data in current active winform control.  
        /// </summary>
        private void commitFocusedControl()
        {
            //If a cell is in edit mode, commit changes and end edit mode.
            var ctlActive = FindFocusedControl(this.ActiveControl);
            if (ctlActive is DataGridViewTextBoxEditingControl)
            {
                ((DataGridViewTextBoxEditingControl)ctlActive).EditingControlDataGridView.EndEdit();
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

        /// <summary>
        /// AGEPRO GUI Control input validation. 
        /// </summary>
        /// <returns>
        /// If all control inputs pass validation checks, a dialog message will 
        /// verify so and return true. 
        /// The first invaild case will exit validation, a dialog message of the type of 
        /// invalidation, and return false.
        /// </returns>
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
            if (this.controlBootstrap.ValidateBootstrapInput() == false)
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

            //Set the user data work directory  
            if (string.IsNullOrWhiteSpace(controlGeneralOptions.generalInputFile))
            {
                ageproModelJobName = "untitled_";
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
            //Store original bootstrap filename in case of error
            string originalBSNFile = inputData.bootstrap.bootstrapFile;

            try
            {
                //Set bootstrap filename to copied workDir version
                inputData.bootstrap.bootstrapFile = bsnFile; 
                
                //Write Interface Inputs to file
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
            if (this.saveAGEPROInputDataAsToolStripMenuItem.Enabled == false)
            {
                this.saveAGEPROInputDataAsToolStripMenuItem.Enabled = true;
            }
            //if "Discards are Present" is not checked, disable the discard parameters panels.
            controlDiscardWeight.Enabled = controlGeneralOptions.generalDiscardsPresent;
            controlDiscardFraction.Enabled = controlGeneralOptions.generalDiscardsPresent;

            //Setup Data Binding for Parameter Controls  
            if (inputData != null)
            {
                controlBootstrap.SetBootstrapControls(inputData.bootstrap);
                controlMiscOptions.SetupRefpointDataBindings(inputData.refpoint);
                controlMiscOptions.SetupScaleFactorsDataBindings(inputData.scale);
                controlMiscOptions.SetupBoundsDataBindings(inputData.bounds);
            }
            
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
        /// Method to find the current Active or Focused Control.
        /// </summary>
        /// <see cref="Https://stackoverflow.com/questions/435433/what-is-the-preferred-way-to-find-focused-control-in-winforms-app"/>
        /// <param name="control">Control object</param>
        /// <returns></returns>
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
        /// Raises the Cut clipboard function from the "Cut" edit menu option.
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
        /// Raises the Copy clipboard function from the "Copy" edit menu option.
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
        /// Raises the Paste clipboard function from the "Paste" edit menu option.
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
        /// Raises the Delete clipboard command from the "Delete" edit menu option. 
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

        /// <summary>
        /// Opens the "Age Structured Projection Model (AGEPRO)" help manual when the user
        /// clicks on the "Html Help" menu item under Help.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void htmlHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get location of the application's path.
            var loc = Path.GetDirectoryName(Application.ExecutablePath);

            //Append help html file and load it
            string helpHtmlPath = loc + @"/doc/agepro_manual.html";
            System.Diagnostics.Process.Start(helpHtmlPath);
        }

        /// <summary>
        /// Launches Brodizak's "AGEPRO Reference Manual" when the user clicks on
        /// the "Reference Manual (Pdf)" menu item under Help.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void referenceManualpdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Get Location of Application Path
            var loc = Path.GetDirectoryName(Application.ExecutablePath);

            //Load Reference Manual from there
            string refManualPath = Path.Combine(loc, "doc", "AGEPRO_v4.2_Reference_Manual.pdf");
            if (!File.Exists(refManualPath))
            {
                throw new InvalidAgeproGuiParameterException("Reference Manual was not found.");
            }

            System.Diagnostics.Process.Start(refManualPath);
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


    }
}
