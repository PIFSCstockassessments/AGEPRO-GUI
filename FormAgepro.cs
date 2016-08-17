using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
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

        public FormAgepro()
        {
            InitializeComponent();
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

            controlGeneralOptions.SetGeneral += new EventHandler(StartupStateEvent_SetGeneralButton);

            //Load General Options Controls to AGEPRO Parameter panel
            this.panelAgeproParameter.Controls.Clear();
            this.panelAgeproParameter.Controls.Add(controlGeneralOptions);

            //initially set Number of Ages
            int initalNumAges = controlGeneralOptions.generalFirstAgeClass;
         
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
          

        public void StartupStateEvent_SetGeneralButton(object sender, EventArgs e)
        {
            try
            {
                //TODO TODO TODO: Validate GeneralOption Parameters

                //TODO Disable/'Do not load' parameters to Discard Weight and Discard Fraction if 
                //Discards are Present is not checked

                //Use general options parameters to set inputFile parameters 
                int generalSetNumAges = controlGeneralOptions.generalLastAgeClass -
                    controlGeneralOptions.generalFirstAgeClass;
                int generalSetNumYears = Convert.ToInt32(controlGeneralOptions.generalLastYearProjection) -
                    Convert.ToInt32(controlGeneralOptions.generalFirstYearProjection);

                controlMiscOptions.miscOptionsNAges = generalSetNumAges;
                controlMiscOptions.miscOptionsFirstAge = controlGeneralOptions.generalFirstAgeClass;

                //Activate Naivagation Panel if in first-run/startup state.
                EnableNavigationPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not set AGEPRO general paraneters." + Environment.NewLine + ex.Message, 
                    "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Terminate
            this.Close();
        }

        private void aboutAGEPROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About Box Dialog
            AboutAgepro aboutDialog = new AboutAgepro();
            aboutDialog.ShowDialog();
        }

        private void treeViewNavigation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedTreeNode = treeViewNavigation.SelectedNode.Name.ToString();
            
            //TODO REFACTOR THIS SWITCH STATEMEMT
            Dictionary<string, Action> treeNodeDict = 
                new Dictionary<string, Action> {

                {"treeNodeGeneral", selectGeneralOptionsParameterPanel},
                {"treeNodeJan1", selectJan1WeightsParameterPanel},
                {"treeNodeSSB", selectSSBWeightsParameterPanel},
                {"treeNodeMidYear", selectMidYearWeightsParameterPanel},
                {"treeNodeCatchWeight", selectCatchWeightParameterPanel},
                {"treeNodeDiscardWeight", selectDiscardWeightParameterPanel},
                {"treeNodeFisherySelectivity", selectFisherySelectivityParameterPanel},
                {"treeNodeDiscardFraction", selectDiscardFractionParameterPanel},
                {"treeNodeNaturalMortality", selectNaturalMortalityParameterPanel},
                {"treeNodeBiological", selectBiologicalParameterPanel},
                {"treeNodeBootstrapping", selectBootstrappingParameterPanel},
                {"treeNodeMiscOptions", selectMiscOptionsParameterPanel},
            };
            
            if (treeNodeDict.ContainsKey(selectedTreeNode))
            {
                treeNodeDict[selectedTreeNode].Invoke();
            }



            //switch (selectedTreeNode)
            //{
            //    case "treeNodeGeneral":
            //        panelAgeproParameter.Controls.Clear();
            //        panelAgeproParameter.Controls.Add(controlGeneralOptions);
            //        break;
            //    case "treeNodeJan1":
            //        panelAgeproParameter.Controls.Clear();
            //        controlJan1Weight.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlJan1Weight);
            //        break;
            //    case "treeNodeSSB":
            //        panelAgeproParameter.Controls.Clear();
            //        controlSSBWeight.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlSSBWeight);
            //        break;
            //    case "treeNodeMidYear":
            //        panelAgeproParameter.Controls.Clear();
            //        controlMidYearWeight.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlMidYearWeight);
            //        break;
            //    case "treeNodeCatchWeight":
            //        panelAgeproParameter.Controls.Clear();
            //        controlCatchWeight.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlCatchWeight);
            //        break;
            //    case "treeNodeDiscardWeight":
            //        panelAgeproParameter.Controls.Clear();
            //        controlDiscardWeight.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlDiscardWeight);
            //        break;
            //    case "treeNodeFisherySelectivity":
            //        panelAgeproParameter.Controls.Clear();
            //        controlFisherySelectivity.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlFisherySelectivity);
            //        break;
            //    case "treeNodeDiscardFraction":
            //        panelAgeproParameter.Controls.Clear();
            //        controlDiscardFraction.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlDiscardFraction);
            //        break;
            //    case "treeNodeNaturalMortality":
            //        panelAgeproParameter.Controls.Clear();
            //        controlNaturalMortality.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlNaturalMortality);
            //        break;
            //    case "treeNodeBiological":
            //        panelAgeproParameter.Controls.Clear();
            //        controlBiological.Dock = DockStyle.Fill;
            //        panelAgeproParameter.Controls.Add(controlBiological);
            //        break;
            //    case "treeNodeBootstrapping":
            //        panelAgeproParameter.Controls.Clear();
            //        panelAgeproParameter.Controls.Add(controlBootstrap);
            //        break;
            //    case "treeNodeMiscOptions":
            //        panelAgeproParameter.Controls.Clear();
            //        panelAgeproParameter.Controls.Add(controlMiscOptions);
            //        break;
            //    default:
            //        break;
            //}
        }

        private void selectGeneralOptionsParameterPanel()
        {
            selectAgeproParameterPanel(controlGeneralOptions);
        }
        private void selectJan1WeightsParameterPanel()
        {
            selectAgeproParameterPanel(controlJan1Weight, true);
        }
        private void selectSSBWeightsParameterPanel()
        {
            selectAgeproParameterPanel(controlSSBWeight, true);
        }
        private void selectMidYearWeightsParameterPanel()
        {
            selectAgeproParameterPanel(controlMidYearWeight, true);
        }
        private void selectCatchWeightParameterPanel()
        {
            selectAgeproParameterPanel(controlCatchWeight, true);
        }
        private void selectDiscardWeightParameterPanel()
        {
            selectAgeproParameterPanel(controlDiscardWeight, true);
        }
        private void selectFisherySelectivityParameterPanel()
        {
            selectAgeproParameterPanel(controlFisherySelectivity, true);
        }
        private void selectDiscardFractionParameterPanel()
        {
            selectAgeproParameterPanel(controlDiscardFraction, true);
        }
        private void selectNaturalMortalityParameterPanel()
        {
            selectAgeproParameterPanel(controlNaturalMortality, true);
        }
        private void selectBiologicalParameterPanel()
        {
            selectAgeproParameterPanel(controlBiological, true);
        }
        private void selectBootstrappingParameterPanel()
        {
            selectAgeproParameterPanel(controlBootstrap);
        }
        private void selectMiscOptionsParameterPanel()
        {
            selectAgeproParameterPanel(controlMiscOptions);
        }

        private void selectAgeproParameterPanel(UserControl ageproParameterControl, bool dockFill = false)
        {
            this.panelAgeproParameter.Controls.Clear();
            if (dockFill == true)
            {
                ageproParameterControl.Dock = DockStyle.Fill;
            }
            this.panelAgeproParameter.Controls.Add(ageproParameterControl);
        }

        /// <summary>
        /// 
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
                    //Use AGEPRO.CoreLib.AgeproInputFile.ReadInputFile
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

        private void EnableNavigationPanel()
        {
            //Activate Naivagation Panel if in first-run/startup state.
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

        }

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
                getAgeproInputDataTable (controlBiological.fractionMortality, inpFile.biological.TSpawn);
            controlBiological.fractionMortalityTimeVarying = inpFile.biological.timeVarying;
            controlBiological.readFractionMortalityState = false;

            //Bootstrapping
            controlBootstrap.bootstrapFilename = inpFile.bootstrap.bootstrapFile;
            controlBootstrap.bootstrapIterations = inpFile.bootstrap.numBootstraps.ToString();
            controlBootstrap.bootstrapScaleFactors = inpFile.bootstrap.popScaleFactor.ToString();
            
            //Misc Options
            controlMiscOptions.miscOptionsSummaryReport = inpFile.options.enableSummaryReport;
            controlMiscOptions.miscOptionsAuxStochasticFiles = inpFile.options.enableDataFiles;
            controlMiscOptions.miscOptionsExportR = inpFile.options.enableExportR;
            controlMiscOptions.miscOptionsPercentileReport = inpFile.options.enablePercentileReport;
            controlMiscOptions.miscOptionsReportPercentile = Convert.ToDouble(inpFile.reportPercentile.percentile);
            
            controlMiscOptions.miscOptionsRefpointsReport = inpFile.options.enableRefpoint;
            controlMiscOptions.miscOptionsSpawnBiomass = inpFile.refpoint.refSpawnBio.ToString();
            controlMiscOptions.miscOptionsJan1Biomass = inpFile.refpoint.refJan1Bio.ToString();
            controlMiscOptions.miscOptionsMeanBiomass = inpFile.refpoint.refMeanBio.ToString();
            controlMiscOptions.miscOptionsFishingMortality = inpFile.refpoint.refFMort.ToString();
            
            controlMiscOptions.miscOptionsScaleFactors = inpFile.options.enableScaleFactors;
            controlMiscOptions.miscOptionsScaleFactorBiomass = inpFile.scale.scaleBio.ToString();
            controlMiscOptions.miscOptionsScaleFactorRecruits = inpFile.scale.scaleRec.ToString();
            controlMiscOptions.miscoptionsScaleFactorStockNumbers = inpFile.scale.scaleStockNum.ToString();

            controlMiscOptions.miscOptionsBounds = inpFile.options.enableBounds;
            controlMiscOptions.miscOptionsBoundsMaxWeight = inpFile.bounds.maxWeight.ToString();
            controlMiscOptions.miscOptionsBoundsNaturalMortality = inpFile.bounds.maxNatMort.ToString();

            controlMiscOptions.miscOptionsRetroAdjustmentFactors = inpFile.options.enableRetroAdjustmentFactors;
            controlMiscOptions.miscOptionsNAges = inpFile.general.NumAges();
            controlMiscOptions.miscOptionsFirstAge = inpFile.general.ageBegin;  

            controlMiscOptions.miscOptionsRetroAdjustmentFactorTable = 
                getAgeproInputDataTable(controlMiscOptions.miscOptionsRetroAdjustmentFactorTable, inpFile.retroAdjustOption.retroAdjust);
                      
            if (controlMiscOptions.miscOptionsRetroAdjustmentFactors == true)
            {
                controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
            }

            
            
            
            Console.WriteLine("Loaded AGEPRO Parameters ..");
        }


        private void loadStochasticAgeInputData(ControlStochasticAge ctl, AGEPRO.CoreLib.AgeproStochasticAgeTable inp, 
            AGEPRO.CoreLib.AgeproGeneral generalOpt)
        {   
            ctl.readInputFileState = true;
            ctl.seqYears = Array.ConvertAll(generalOpt.SeqYears(), element => element.ToString());
            ctl.numFleets = generalOpt.numFleets;
            ctl.timeVarying = inp.timeVarying;
            ctl.stochasticDataFile = inp.dataFile;
            ctl.stochasticAgeTable = getAgeproInputDataTable(ctl.stochasticAgeTable, inp.byAgeData);
            ctl.stochasticCV = getAgeproInputDataTable(ctl.stochasticCV, inp.byAgeCV);
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

        private void loadWeightAgeInputData(ControlStochasticWeightAge ctl, AGEPRO.CoreLib.AgeproWeightAgeTable inp,
            AGEPRO.CoreLib.AgeproGeneral generalOpt, bool fallbackNullDataTable = false)
        {
            ctl.indexWeightOption = inp.weightOpt;
            loadStochasticAgeInputData((ControlStochasticAge)ctl, (AGEPRO.CoreLib.AgeproStochasticAgeTable)inp, generalOpt);

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

                    ctl.stochasticAgeTable = createFallbackAgeDataTable(generalOpt.NumAges(), numYears, generalOpt.numFleets);
                    ctl.enableTimeVaryingCheckBox = true;
                }
                if (!(ctl.stochasticCV != null))
                {
                    ctl.stochasticCV = createFallbackAgeDataTable(generalOpt.NumAges(), 1, generalOpt.numFleets);
                }
            }
        }

        private DataTable createFallbackAgeDataTable(int numAges, int numYears, int numFleets = 1)
        {
            DataTable fallbackAgeTable = new DataTable();

            for (int nage = 0; nage < numAges; nage++)
            {
                fallbackAgeTable.Columns.Add("Age " + (nage + 1));
            }
            int numFleetYears = numYears * numFleets;
            for (int iyear = 0; iyear < numFleetYears; iyear++)
            {
                fallbackAgeTable.Rows.Add();
            }
      
            return fallbackAgeTable;
        }

        private DataTable getAgeproInputDataTable (DataTable dgvTable, DataTable inpFileTable)
        {
            if (dgvTable != null)
            {
                dgvTable.Reset();
            }
            dgvTable = inpFileTable;
            return dgvTable;
        }

    }
}
