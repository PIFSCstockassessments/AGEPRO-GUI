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

        public FormAgepro()
        {
            InitializeComponent();
            //AGEPRO Input Data, If any
            inputData = new AgeproInputFile();

            //Load User Controls
            controlGeneralOptions = new ControlGeneral();
            controlMiscOptions = new ControlMiscOptions();
            controlBootstrap = new ControlBootstrap();
            controlFisherySelectivity = new ControlStochasticAge("Fishery Selectivity");
            controlFisherySelectivity.isMultiFleet = true;

            controlGeneralOptions.SetGeneral += new EventHandler(StartupStateEvent_SetGeneralButton);

            //Load General Options Controls to AGEPRO Parameter panel
            this.panelAgeproParameter.Controls.Clear();
            this.panelAgeproParameter.Controls.Add(controlGeneralOptions);

            //initially set Number of Ages
            int initalNumAges = controlGeneralOptions.generalFirstAgeClass;
         
            //Instatiate Startup State:
            //Disable Navigation Tree Panel, AGEPRO run options, etc...
            this.panelNavigation.Enabled = false;
        }
          

        public void StartupStateEvent_SetGeneralButton(object sender, EventArgs e)
        {
            try
            {
                //TODO TODO TODO: Validate GeneralOption Parameters

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
            
            //TODO
            switch (selectedTreeNode)
            {
                case "treeNodeGeneral":
                    panelAgeproParameter.Controls.Clear();
                    panelAgeproParameter.Controls.Add(controlGeneralOptions);
                    break;
                case "treeNodeMiscOptions":
                    panelAgeproParameter.Controls.Clear();
                    panelAgeproParameter.Controls.Add(controlMiscOptions);
                    break;
                case "treeNodeBootstrapping":
                    panelAgeproParameter.Controls.Clear();
                    panelAgeproParameter.Controls.Add(controlBootstrap);
                    break;
                case "treeNodeFisherySelectivity":
                    panelAgeproParameter.Controls.Clear();
                    controlFisherySelectivity.Dock = DockStyle.Fill;
                    panelAgeproParameter.Controls.Add(controlFisherySelectivity);
                    break;
                default:
                    break;
            }
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
                    MessageBox.Show("Can not load AGEPRO input file."+ Environment.NewLine + ex);
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
            controlGeneralOptions.generalDiscards = inpFile.general.hasDiscards;

            //Fishery Selectivity
            controlFisherySelectivity.readInputFileState = true;
            controlFisherySelectivity.seqYears = Array.ConvertAll(inpFile.general.SeqYears(), element => element.ToString());
            controlFisherySelectivity.numFleets = inpFile.general.numFleets;
            controlFisherySelectivity.isMultiFleet = true;
            controlFisherySelectivity.timeVarying = inpFile.fishery.timeVarying;
            controlFisherySelectivity.stochasticDataFile = inpFile.fishery.dataFile;
            controlFisherySelectivity.stochasticAgeTable =
                setAgeproDataTable(controlFisherySelectivity.stochasticAgeTable, inpFile.fishery.byAgeData);
            controlFisherySelectivity.stochasticCV =
                setAgeproDataTable(controlFisherySelectivity.stochasticCV, inpFile.fishery.byAgeCV);
            controlFisherySelectivity.readInputFileState = false;

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
                setAgeproDataTable(controlMiscOptions.miscOptionsRetroAdjustmentFactorTable, inpFile.retroAdjustOption.retroAdjust);
                      
            if (controlMiscOptions.miscOptionsRetroAdjustmentFactors == true)
            {
                controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
            }

            
            
            
            Console.WriteLine("DEBUG: End Load AGEPRO Parameters");
        }

        private DataTable setAgeproDataTable (DataTable dgvTable, DataTable inpFileTable)
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
