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
        private ControlHarvestScenario controlHarvestScenario;
        private ControlRecruitment controlRecruitment;

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
            controlRecruitment = new ControlRecruitment();
            controlHarvestScenario = new ControlHarvestScenario();

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
        private void selectHarvestScenarioParameterPanel()
        {
            selectAgeproParameterPanel(controlHarvestScenario, true);
        }
        private void selectMiscOptionsParameterPanel()
        {
            selectAgeproParameterPanel(controlMiscOptions);
        }
        private void selectRecruitmentParameterPanel()
        {
            selectAgeproParameterPanel(controlRecruitment, true);
        }

        /// <summary>
        /// Generalized method to set an AGEPRO Parameter User Control in the AGEPRO Parameter Panel
        /// </summary>
        /// <param name="ageproParameterControl">AGEPRO Parameter User Control</param>
        /// <param name="dockFill">Option to set Panel's Dock value to Dockstyle.Fill </param>
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
                if (controlMiscOptions.miscOptionsRetroAdjustmentFactors)
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
                controlRecruitment.numRecruitModels = Convert.ToInt32(controlGeneralOptions.generalNumberRecruitModels);
                controlRecruitment.recruitModelSelection = new int[controlRecruitment.numRecruitModels];
                controlRecruitment.SetDataGridSelectRecruitModels(controlRecruitment.numRecruitModels);
                controlRecruitment.seqRecruitYears = controlGeneralOptions.SeqYears();
                controlRecruitment.recruitmentProb = 
                    CreateBlankDataTable(controlRecruitment.numRecruitModels, controlRecruitment.seqRecruitYears.Count(), 
                    "Selection");
                controlRecruitment.SetRecuitmentSelectionComboBox(controlRecruitment.numRecruitModels);
                controlRecruitment.collectionAgeproRecruitmentModels = 
                    new List<RecruitmentModel>(controlRecruitment.numRecruitModels);
                
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

        private void saveAGEPROInputDataAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAgeproInputDataFileDialog();
        }

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
        
        private void launchAGEPROModelToolStripMenuItem_Click(object sender, EventArgs e)
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
            else if(File.Exists(Path.GetDirectoryName(inputData.general.inputFile) + "\\" + Path.GetFileName(inputData.bootstrap.bootstrapFile)))
            {
                File.Copy(Path.GetDirectoryName(inputData.general.inputFile) + "\\" + Path.GetFileName(inputData.bootstrap.bootstrapFile),
                    bsnFile, true);
            }
            //3. Else, Explictly locate the bootstrap file (via OpenFileDialog).
            else
            {
                OpenFileDialog openBootstrapFileDialog = new OpenFileDialog();

                openBootstrapFileDialog.InitialDirectory = "~";
                openBootstrapFileDialog.Filter = "AGEPRO bootstrap files (*.inp)|*.bsn|All Files (*.*)|*.*";
                openBootstrapFileDialog.FilterIndex = 1;
                openBootstrapFileDialog.RestoreDirectory = true;
                openBootstrapFileDialog.Title = "Open AGEPRO Bootstrap File";
                
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
                LaunchAgeproModel(inpFile);

                //crude method to search for AGEPRO output file
                string ageproOutfile = Directory.GetFiles(Path.GetDirectoryName(inpFile), "*.out").First();

                LaunchOutputViewerProgram(ageproOutfile, controlMiscOptions);

                //Open WorkPath directory for the user 
                Process.Start(ageproWorkPath); 
            }
            catch(Exception ex)
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
        private string OpenBootstrapFile()
        {
            OpenFileDialog openBootstrapFileDialog = new OpenFileDialog();

            openBootstrapFileDialog.InitialDirectory = "~";
            openBootstrapFileDialog.Filter = "AGEPRO bootstrap files (*.inp)|*.bsn|All Files (*.*)|*.*";
            openBootstrapFileDialog.FilterIndex = 1;
            openBootstrapFileDialog.RestoreDirectory = true;
            openBootstrapFileDialog.Title = "Open AGEPRO Bootstrap File";
            openBootstrapFileDialog.ShowDialog();

            return openBootstrapFileDialog.FileName;
        }

        static void LaunchAgeproModel(string inpFile)
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
                MessageBox.Show("An error occured when running the AGEPRO Model." + Environment.NewLine + ex,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
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
            controlRecruitment.SetDataGridSelectRecruitModels(controlRecruitment.numRecruitModels);
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
                getAgeproInputDataTable (controlBiological.fractionMortality, inpFile.biological.TSpawn);
            controlBiological.fractionMortalityTimeVarying = inpFile.biological.timeVarying;
            controlBiological.readFractionMortalityState = false;

            //Bootstrapping
            controlBootstrap.bootstrapFilename = inpFile.bootstrap.bootstrapFile;
            controlBootstrap.bootstrapIterations = inpFile.bootstrap.numBootstraps.ToString();
            controlBootstrap.bootstrapScaleFactors = inpFile.bootstrap.popScaleFactor.ToString();
            
            //Misc Options
            controlMiscOptions.miscOptionsSummaryReport = inpFile.options.enableSummaryReport;
            controlMiscOptions.miscOptionsAuxStochasticFiles = inpFile.options.enableAuxStochasticFiles;
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

        /// <summary>
        /// Generalized method to load Stochastic Data Parameters from AGEPRO Input Data files.
        /// </summary>
        /// <param name="ctl">AGEPRO Stochastic Parameter User Control and Values</param>
        /// <param name="inp">AGEPRO InputFile StochasticAge Parameters </param>
        /// <param name="generalOpt">AGEPRO InputFile General Options values</param>
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

        /// <summary>
        /// Generalized method to load Stochastic Weight of Age Parameters from AGEPRO Input Data Files.
        /// </summary>
        /// <param name="ctl">AGEPRO Stochastic Weight of Age User Control and Values</param>
        /// <param name="inp">AGEPRO InputFile Weight of Age Onject</param>
        /// <param name="generalOpt">AGEPRO InputFile General Options</param>
        /// <param name="fallbackNullDataTable">Option to generate a empty DataTable if Input File does not 
        /// provide one</param>
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
        /// Generalized Method to set the DataGridView's Data Sources from AGEPRO.CoreLib Input File Data Files 
        /// </summary>
        /// <param name="dgvTable">Control's DataGridView DataTable source</param>
        /// <param name="inpFileTable">DataTable from AGEPRO.CoreLib.AgeproInputFile DataTables</param>
        /// <returns>DataGridView DataTable</returns>
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
