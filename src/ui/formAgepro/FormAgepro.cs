﻿using System;
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
      controlBiological = new ControlBiological(new string[] { string.Empty });
      controlJan1Weight = new ControlStochasticWeightAge(new int[] { 0, 1 });
      controlSSBWeight = new ControlStochasticWeightAge(new int[] { 0, 1, -1 });
      controlMidYearWeight = new ControlStochasticWeightAge(new int[] { 0, 1, -1, -2 });
      controlCatchWeight = new ControlStochasticWeightAge(new int[] { 0, 1, -1, -2, -3 });
      controlDiscardWeight = new ControlStochasticWeightAge(new int[] { 0, 1, -1, -2, -3, -4 });
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
      controlGeneralOptions.GeneralInputFile = "";
      controlGeneralOptions.GeneralModelId = "untitled";
      this.inputData.General.InputFile = "";
      this.inputData.CaseID = controlGeneralOptions.GeneralModelId;

      //initially set Number of Ages
      int initalNumAges = controlGeneralOptions.GeneralFirstAgeClass; //Spinbox Value

      //Biological Stochastic Options
      controlFisherySelectivity.StochasticParameterLabel = "Fishery Selectivity";
      controlFisherySelectivity.IsMultiFleet = true;
      controlFisherySelectivity.FleetDependency = StochasticAgeFleetDependency.dependent;
      controlDiscardFraction.StochasticParameterLabel = "Discard Fraction";
      controlDiscardFraction.IsMultiFleet = true;
      controlDiscardFraction.FleetDependency = StochasticAgeFleetDependency.dependent;
      controlNaturalMortality.StochasticParameterLabel = "Natural Mortality";
      controlNaturalMortality.IsMultiFleet = false;
      controlNaturalMortality.FleetDependency = StochasticAgeFleetDependency.independent;



      //Weight Age Options
      controlJan1Weight.IsMultiFleet = false;
      controlJan1Weight.FleetDependency = StochasticAgeFleetDependency.independent;
      controlSSBWeight.IsMultiFleet = false;
      controlSSBWeight.FleetDependency = StochasticAgeFleetDependency.independent;
      controlMidYearWeight.IsMultiFleet = false;
      controlMidYearWeight.FleetDependency = StochasticAgeFleetDependency.independent;
      controlCatchWeight.IsMultiFleet = true;
      controlCatchWeight.FleetDependency = StochasticAgeFleetDependency.dependent;
      controlDiscardWeight.IsMultiFleet = true;
      controlDiscardWeight.FleetDependency = StochasticAgeFleetDependency.dependent;

      controlJan1Weight.WeightAgeType = StochasticWeightOfAge.Jan1Weight;
      controlSSBWeight.WeightAgeType = StochasticWeightOfAge.SSBWeight;
      controlMidYearWeight.WeightAgeType = StochasticWeightOfAge.MidYearWeight;
      controlCatchWeight.WeightAgeType = StochasticWeightOfAge.CatchWeight;
      controlDiscardWeight.WeightAgeType = StochasticWeightOfAge.DiscardWeight;

      controlJan1Weight.ShowJan1WeightsOption = false;
      controlJan1Weight.ShowSSBWeightsOption = false;
      controlJan1Weight.showMidYearWeightsOption = false;
      controlJan1Weight.ShowCatchWeightsOption = false;
      controlSSBWeight.ShowSSBWeightsOption = false;
      controlSSBWeight.showMidYearWeightsOption = false;
      controlSSBWeight.ShowCatchWeightsOption = false;
      controlMidYearWeight.showMidYearWeightsOption = false;
      controlMidYearWeight.ShowCatchWeightsOption = false;
      controlCatchWeight.ShowCatchWeightsOption = false;

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
      else if (dlgResult == DialogResult.Yes)
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

        //New Cases references version included in AGEPRO Reference Manual
        inputData.Version = "AGEPRO VERSION 4.0";

        //Save General Options input to CoreLib Input Data Object
        inputData.General.ProjYearStart = Convert.ToInt32(controlGeneralOptions.GeneralFirstYearProjection);
        inputData.General.ProjYearEnd = Convert.ToInt32(controlGeneralOptions.GeneralLastYearProjection);
        inputData.General.AgeBegin = controlGeneralOptions.GeneralFirstAgeClass;
        inputData.General.AgeEnd = controlGeneralOptions.GeneralLastAgeClass;
        inputData.General.NumFleets = Convert.ToInt32(controlGeneralOptions.GeneralNumberFleets);
        inputData.General.NumRecModels = Convert.ToInt32(controlGeneralOptions.GeneralNumberRecruitModels);
        inputData.General.NumPopSims = Convert.ToInt32(controlGeneralOptions.GeneralNumberPopulationSimuations);
        inputData.General.Seed = Convert.ToInt32(controlGeneralOptions.GeneralRandomSeed);
        inputData.General.HasDiscards = controlGeneralOptions.GeneralDiscardsPresent;
        //Store CASEID to input data object
        inputData.CaseID = controlGeneralOptions.GeneralModelId;

        //Check for AGEPRO parameter data that has already been loaded/set 
        controlMiscOptions.miscOptionsNAges = controlGeneralOptions.NumAges();
        controlMiscOptions.miscOptionsFirstAge = controlGeneralOptions.GeneralFirstAgeClass;

        //Retro Adjustment Factors
        if (controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors)
        {
          if (controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable != null)
          {
            //In case NumAges is larger than previous row count, "reset" dataGridView 
            if (controlGeneralOptions.NumAges() >
                controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable.Rows.Count)
            {
              controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable.Reset();
            }
          }
          controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable =
              controlMiscOptions.GetRetroAdjustmentFallbackTable(controlMiscOptions.miscOptionsNAges);
          controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
        }

        //Set Stochastic Paramaeter DataGrids           
        controlJan1Weight.CreateStochasticParameterFallbackDataTable(inputData.Jan1StockWeight, inputData.General, StochasticAgeFleetDependency.independent);
        controlSSBWeight.CreateStochasticParameterFallbackDataTable(inputData.SSBWeight, inputData.General, StochasticAgeFleetDependency.independent);
        controlMidYearWeight.CreateStochasticParameterFallbackDataTable(inputData.MeanWeight, inputData.General, StochasticAgeFleetDependency.independent);
        controlCatchWeight.CreateStochasticParameterFallbackDataTable(inputData.CatchWeight, inputData.General,
            StochasticAgeFleetDependency.dependent);
        controlFisherySelectivity.CreateStochasticParameterFallbackDataTable(inputData.Fishery, inputData.General,
            StochasticAgeFleetDependency.dependent);

        controlNaturalMortality.CreateStochasticParameterFallbackDataTable(inputData.NaturalMortality, inputData.General, StochasticAgeFleetDependency.independent);
        controlBiological.maturityAge.CreateStochasticParameterFallbackDataTable(inputData.BiologicalMaturity, inputData.General, StochasticAgeFleetDependency.independent);

        //Show Discard DataTables if Discards options is checked
        if (controlGeneralOptions.GeneralDiscardsPresent == true)
        {
          controlDiscardFraction.CreateStochasticParameterFallbackDataTable(inputData.DiscardFraction, inputData.General,
              StochasticAgeFleetDependency.dependent);
          controlDiscardWeight.CreateStochasticParameterFallbackDataTable(inputData.DiscardWeight, inputData.General, StochasticAgeFleetDependency.independent);

        }
        else
        {   //Otherwise remove ("reset") any dataGridView existing data. 
          if (controlDiscardFraction.StochasticAgeTable != null)
          {
            controlDiscardFraction.StochasticAgeTable.Reset();
            controlDiscardFraction.StochasticCV.Reset();
          }
          if (controlDiscardWeight.StochasticAgeTable != null)
          {
            controlDiscardWeight.StochasticAgeTable.Reset();
            controlDiscardWeight.StochasticCV.Reset();
          }
        }

        //(Biological) Fraction Mortality
        inputData.BiologicalTSpawn.CreateFallbackTSpawnTable(controlGeneralOptions.SeqYears());
        controlBiological.TSpawnPanel.SeqYears = Array.ConvertAll(inputData.General.SeqYears(), element => element.ToString());
        controlBiological.TSpawnPanel.TSpawnTable = inputData.BiologicalTSpawn.TSpawn;
        controlBiological.TSpawnPanel.TimeVarying = inputData.BiologicalTSpawn.TimeVarying;

        //Recruitment
        int nrecruit = Convert.ToInt32(controlGeneralOptions.GeneralNumberRecruitModels);
        inputData.Recruitment.NewCaseRecruitment(nrecruit, controlGeneralOptions.SeqYears());
        controlRecruitment.SetupControlRecruitment(nrecruit, inputData.Recruitment);


        //Harvest Scenario
        //Set harvest calculations to "Harvest Scenario"/None by Default
        controlHarvestScenario.SeqYears = controlGeneralOptions.SeqYears();
        inputData.HarvestScenario.AnalysisType = HarvestScenarioAnalysis.HarvestScenario;
        controlHarvestScenario.SetHarvestScenarioCalcControls(inputData);
        DataTable userGenBasedHarvestScenarioTable = AgeproHarvestScenario.NewHarvestTable(
            controlHarvestScenario.SeqYears.Count(),
            Convert.ToInt32(controlGeneralOptions.GeneralNumberFleets));
        controlHarvestScenario.SetHarvestScenarioInputDataTable(userGenBasedHarvestScenarioTable);
        inputData.HarvestScenario.HarvestScenarioTable = userGenBasedHarvestScenarioTable;

        //Bootstrap
        controlBootstrap.SetBootstrapControls(inputData.Bootstrap);

        //Activate Naivagation Panel if in first-run/startup state.
        //Disable/'Do not load' parameters to Discard Weight and Discard Fraction if 
        //Discards are Present is not checked
        EnableNavigationPanel();

        MessageBox.Show("General AGEPRO Projection Parameters set." + Environment.NewLine + Environment.NewLine +
        "Recruitment and Bootstrap file is required to save as AGEPRO input file or " +
        "to launch AGEPRO model.", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

          controlGeneralOptions.GeneralInputFile = openAgeproInputFile.FileName;

          LoadAgeproInputParameters(this.inputData);

          //Activate Naivagation Panel if in first-run/startup state.
          EnableNavigationPanel();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error loading AGEPRO input file:" + Environment.NewLine + ex.Message,
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
          if (ValidateControlInputs == false)
          {
            throw new InvalidAgeproParameterException("Unable to save AGEPRO Input Data due to invalid input.");
          }

          //Case Id
          this.inputData.CaseID = controlGeneralOptions.GeneralModelId;

          //Natural Mortality
          controlJan1Weight.BindStochasticAgeData(this.inputData.Jan1StockWeight);
          controlSSBWeight.BindStochasticAgeData(this.inputData.SSBWeight);
          controlMidYearWeight.BindStochasticAgeData(this.inputData.MeanWeight);
          controlCatchWeight.BindStochasticAgeData(this.inputData.CatchWeight);
          controlBiological.maturityAge.BindStochasticAgeData(this.inputData.BiologicalMaturity);
          controlFisherySelectivity.BindStochasticAgeData(this.inputData.Fishery);
          controlNaturalMortality.BindStochasticAgeData(this.inputData.NaturalMortality);

          inputData.BiologicalTSpawn.TimeVarying = controlBiological.TSpawnPanel.TSpawnTableTimeVarying;

          if (this.inputData.General.HasDiscards == true)
          {
            controlDiscardWeight.BindStochasticAgeData(this.inputData.DiscardWeight);
            controlDiscardFraction.BindStochasticAgeData(this.inputData.DiscardFraction);
          }

          //Harvest Scenario: Rebuilder/PStar
          if (controlHarvestScenario.CalcType == HarvestScenarioAnalysis.PStar)
          {
            this.inputData.HarvestScenario.AnalysisType = controlHarvestScenario.CalcType;
            this.inputData.PStar.AnalysisType = controlHarvestScenario.CalcType;
            this.inputData.PStar.PStarLevels = controlHarvestScenario.PStar.PStarLevels;
            this.inputData.PStar.PStarF = controlHarvestScenario.PStar.PStarF;
            this.inputData.PStar.TargetYear = controlHarvestScenario.PStar.TargetYear;
            this.inputData.PStar.PStarTable = controlHarvestScenario.PStar.PStarTable;
          }
          else if (controlHarvestScenario.CalcType == HarvestScenarioAnalysis.Rebuilder)
          {
            this.inputData.HarvestScenario.AnalysisType = controlHarvestScenario.CalcType;
            this.inputData.Rebuild.AnalysisType = controlHarvestScenario.CalcType;
            this.inputData.Rebuild.TargetYear = controlHarvestScenario.Rebuilder.TargetYear;
            this.inputData.Rebuild.TargetPercent = controlHarvestScenario.Rebuilder.TargetPercent;
            this.inputData.Rebuild.TargetType = controlHarvestScenario.Rebuilder.TargetType;
          }

          //Misc options
          this.inputData.Options.EnableSummaryReport = controlMiscOptions.MiscOptionsEnableSummaryReport;
          this.inputData.Options.EnableExportR = controlMiscOptions.MiscOptionsEnableExportR;
          this.inputData.Options.EnableAuxStochasticFiles = controlMiscOptions.MiscOptionsEnableAuxStochasticFiles;
          this.inputData.Options.EnablePercentileReport = controlMiscOptions.MiscOptionsEnablePercentileReport;
          this.inputData.Options.EnableRefpoint = controlMiscOptions.MiscOptionsEnableRefpointsReport;
          this.inputData.Options.EnableScaleFactors = controlMiscOptions.MiscOptionsEnableScaleFactors;
          this.inputData.Options.EnableBounds = controlMiscOptions.MiscOptionsBounds;
          this.inputData.Options.EnableRetroAdjustmentFactors = controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors;

          this.inputData.Refpoint.RefSpawnBio = Double.Parse(controlMiscOptions.MiscOptionsRefSpawnBiomass);
          this.inputData.Refpoint.RefJan1Bio = Double.Parse(controlMiscOptions.MiscOptionsRefJan1Biomass);
          this.inputData.Refpoint.RefMeanBio = Double.Parse(controlMiscOptions.MiscOptionsRefMeanBiomass);
          this.inputData.Refpoint.RefFMort = Double.Parse(controlMiscOptions.MiscOptionsRefFishingMortality);

          this.inputData.ReportPercentile.Percentile = controlMiscOptions.MiscOptionsReportPercentile;

          this.inputData.Scale.ScaleBio = Double.Parse(controlMiscOptions.MiscOptionsScaleFactorBiomass);
          this.inputData.Scale.ScaleRec = Double.Parse(controlMiscOptions.MiscOptionsScaleFactorRecruits);
          this.inputData.Scale.ScaleStockNum = Double.Parse(controlMiscOptions.MiscOptionsScaleFactorStockNumbers);

          this.inputData.RetroAdjustments.RetroAdjust = controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable;

          this.inputData.WriteInputFile(saveAgeproInputFile.FileName);

          //Set filename to generalOptions Input File textbox
          this.controlGeneralOptions.GeneralInputFile = saveAgeproInputFile.FileName;

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
      controlGeneralOptions.GeneralModelId = inpFile.CaseID;
      controlGeneralOptions.GeneralFirstYearProjection = inpFile.General.ProjYearStart.ToString();
      controlGeneralOptions.GeneralLastYearProjection = inpFile.General.ProjYearEnd.ToString();
      controlGeneralOptions.GeneralFirstAgeClass = inpFile.General.AgeBegin;
      controlGeneralOptions.GeneralLastAgeClass = inpFile.General.AgeEnd;
      controlGeneralOptions.GeneralNumberFleets = inpFile.General.NumFleets.ToString();
      controlGeneralOptions.GeneralNumberRecruitModels = inpFile.General.NumRecModels.ToString();
      controlGeneralOptions.GeneralNumberPopulationSimuations = inpFile.General.NumPopSims.ToString();
      controlGeneralOptions.GeneralRandomSeed = inpFile.General.Seed.ToString();
      controlGeneralOptions.GeneralDiscardsPresent = inpFile.General.HasDiscards;

      //JAN-1
      controlJan1Weight.LoadStochasticWeightAgeInputData(inpFile.Jan1StockWeight, inpFile.General);

      //SSB
      controlSSBWeight.LoadStochasticWeightAgeInputData(inpFile.SSBWeight, inpFile.General);

      //Mid-Year (Mean)
      controlMidYearWeight.LoadStochasticWeightAgeInputData(inpFile.MeanWeight, inpFile.General);

      //Catch Weight
      controlCatchWeight.LoadStochasticWeightAgeInputData(inpFile.CatchWeight, inpFile.General);

      //Discard Weight
      controlDiscardWeight.LoadStochasticWeightAgeInputData(inpFile.DiscardWeight, inpFile.General);

      //Recruitment
      controlRecruitment.SetupControlRecruitment(inpFile.General.NumRecModels, inpFile.Recruitment);

      //Fishery Selectivity
      controlFisherySelectivity.LoadStochasticAgeInputData(inpFile.Fishery, inpFile.General);

      //Discard Fraction
      controlDiscardFraction.LoadStochasticAgeInputData(inpFile.DiscardFraction, inpFile.General);

      //Natural Mortality
      controlNaturalMortality.LoadStochasticAgeInputData(inpFile.NaturalMortality, inpFile.General);

      //Fraction Mortality Prior To Spawning (Biological)
      controlBiological = new ControlBiological(controlGeneralOptions.SeqYears());
      controlBiological.TSpawnPanel.TSpawnTableTimeVarying = inpFile.BiologicalTSpawn.TimeVarying;
      controlBiological.TSpawnPanel.TSpawnTable = inpFile.BiologicalTSpawn.TSpawn;

      //Maturity (Biological)
      controlBiological.maturityAge.LoadStochasticAgeInputData(inpFile.BiologicalMaturity, inpFile.General);

      //Harvest Scenario
      if (inpFile.HarvestScenario.AnalysisType == HarvestScenarioAnalysis.Rebuilder)
      {
        controlHarvestScenario.Rebuilder = inpFile.Rebuild;
      }
      else if (inpFile.HarvestScenario.AnalysisType == HarvestScenarioAnalysis.PStar)
      {
        controlHarvestScenario.PStar = inpFile.PStar;
      }
      controlHarvestScenario.SeqYears = inpFile.Recruitment.ObservationYears.Select(x => x.ToString()).ToArray();
      controlHarvestScenario.SetHarvestScenarioInputDataTable(inpFile.HarvestScenario.HarvestScenarioTable);
      controlHarvestScenario.SetHarvestScenarioCalcControls(inpFile);


      //Bootstrapping
      controlBootstrap.BootstrapFilename = inpFile.Bootstrap.BootstrapFile;
      controlBootstrap.BootstrapIterations = inpFile.Bootstrap.NumBootstraps.ToString();
      controlBootstrap.BootstrapScaleFactors = inpFile.Bootstrap.PopScaleFactor.ToString();

      //Misc Options
      controlMiscOptions.MiscOptionsEnableSummaryReport = inpFile.Options.EnableSummaryReport;
      controlMiscOptions.MiscOptionsEnableAuxStochasticFiles = inpFile.Options.EnableAuxStochasticFiles;
      controlMiscOptions.MiscOptionsEnableExportR = inpFile.Options.EnableExportR;
      controlMiscOptions.MiscOptionsEnablePercentileReport = inpFile.Options.EnablePercentileReport;
      controlMiscOptions.MiscOptionsReportPercentile = Convert.ToDouble(inpFile.ReportPercentile.Percentile);

      controlMiscOptions.MiscOptionsEnableRefpointsReport = inpFile.Options.EnableRefpoint;
      controlMiscOptions.MiscOptionsRefSpawnBiomass = inpFile.Refpoint.RefSpawnBio.ToString();
      controlMiscOptions.MiscOptionsRefJan1Biomass = inpFile.Refpoint.RefJan1Bio.ToString();
      controlMiscOptions.MiscOptionsRefMeanBiomass = inpFile.Refpoint.RefMeanBio.ToString();
      controlMiscOptions.MiscOptionsRefFishingMortality = inpFile.Refpoint.RefFMort.ToString();

      controlMiscOptions.MiscOptionsEnableScaleFactors = inpFile.Options.EnableScaleFactors;
      controlMiscOptions.MiscOptionsScaleFactorBiomass = inpFile.Scale.ScaleBio.ToString();
      controlMiscOptions.MiscOptionsScaleFactorRecruits = inpFile.Scale.ScaleRec.ToString();
      controlMiscOptions.MiscOptionsScaleFactorStockNumbers = inpFile.Scale.ScaleStockNum.ToString();

      controlMiscOptions.MiscOptionsBounds = inpFile.Options.EnableBounds;
      controlMiscOptions.MiscOptionsBoundsMaxWeight = inpFile.Bounds.MaxWeight.ToString();
      controlMiscOptions.MiscOptionsBoundsNaturalMortality = inpFile.Bounds.MaxNatMort.ToString();

      controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors = inpFile.Options.EnableRetroAdjustmentFactors;
      controlMiscOptions.miscOptionsNAges = inpFile.General.NumAges();
      controlMiscOptions.miscOptionsFirstAge = inpFile.General.AgeBegin;

      controlMiscOptions.LoadRetroAdjustmentsFactorTable(inpFile);

      if (controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors == true)
      {
        controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
      }

      Console.WriteLine("Loaded AGEPRO Parameters ..");
    }


    /*****************************************************************************************
     *  LAUNCH TO AGEPRO CALCULATION ENGINE
     ****************************************************************************************/

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
      if (ValidateControlInputs == false)
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
      if (string.IsNullOrWhiteSpace(controlGeneralOptions.GeneralInputFile))
      {
        ageproModelJobName = "untitled_";
        jobDT = string.Format(ageproModelJobName + "_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
      }
      else
      {
        ageproModelJobName = Path.GetFileNameWithoutExtension(controlGeneralOptions.GeneralInputFile);
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
      if (File.Exists(inputData.Bootstrap.BootstrapFile))
      {
        File.Copy(inputData.Bootstrap.BootstrapFile, bsnFile, true);
      }
      //2. If not, in the same directory as the AGEPRO Input File
      else if (File.Exists(Path.GetDirectoryName(inputData.General.InputFile) + "\\" + Path.GetFileName(inputData.Bootstrap.BootstrapFile)))
      {
        File.Copy(Path.GetDirectoryName(inputData.General.InputFile) + "\\" + Path.GetFileName(inputData.Bootstrap.BootstrapFile),
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
      string originalBSNFile = inputData.Bootstrap.BootstrapFile;

      try
      {
        //Set bootstrap filename to copied workDir version
        inputData.Bootstrap.BootstrapFile = bsnFile;

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
        inputData.Bootstrap.BootstrapFile = originalBSNFile;
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
      if (outputOptions.AgeproOutputViewer == "System Default")
      {
        //open a program that is associated by its file type.
        //If no association exists, system will ask user for a program. 
        Process.Start(outfile);
      }
      else if (outputOptions.AgeproOutputViewer == "Notepad")
      {
        Process.Start("notepad.exe", outfile);
      }

    }


    /*****************************************************************************************
     *  VALAIDATION
     ****************************************************************************************/

    /// <summary>
    /// AGEPRO GUI Control input validation. 
    /// </summary>
    /// <returns>
    /// If all control inputs pass validation checks, a dialog message will 
    /// verify so and return true. 
    /// The first invaild case will exit validation, a dialog message of the type of 
    /// invalidation, and return false.
    /// </returns>
    private bool ValidateControlInputs
    {
      get
      {
        double boundsMaxWeight;
        double boundsNaturalMortality;
        int numAges = controlGeneralOptions.NumAges();
        //Default values for bounds
        double defaultMaxWeightBound = 10.0;
        double defaultNatualMortalityBound = 1.0;

        //Enforce Bounds defaults if option is unchecked
        switch (controlMiscOptions.MiscOptionsBounds)
        {
          case false:
            boundsMaxWeight = defaultMaxWeightBound;
            boundsNaturalMortality = defaultMaxWeightBound;
            break;
          default:
            //Check Bounds text if they are empty. If so, use default value and inform the user about this.
            if (string.IsNullOrWhiteSpace(controlMiscOptions.MiscOptionsBoundsMaxWeight))
            {
              MessageBox.Show("Missing max weight bound. Using default value of " + defaultMaxWeightBound
                  + ".", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              boundsMaxWeight = defaultMaxWeightBound;
            }
            else
            {
              boundsMaxWeight = Convert.ToDouble(controlMiscOptions.MiscOptionsBoundsMaxWeight);
            }

            if (string.IsNullOrWhiteSpace(controlMiscOptions.MiscOptionsBoundsNaturalMortality))
            {
              MessageBox.Show("Missing max natural mortality Bound. Using default value of " +
                  defaultNatualMortalityBound + ".", "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              boundsNaturalMortality = defaultNatualMortalityBound;
            }
            else
            {
              boundsNaturalMortality = Convert.ToDouble(
                  controlMiscOptions.MiscOptionsBoundsNaturalMortality);
            }

            break;
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
        //(Biological) Fraction Mortality (TSpawn) Prior to Spawning 
        if (controlBiological.TSpawnPanel.ValidateTSpawnDataGrid() == false)
        {
          return false;
        }
        //Fishery Selectivity
        if (controlFisherySelectivity.ValidateStochasticParameter(numAges) == false)
        {
          return false;
        }
        if (this.controlGeneralOptions.GeneralDiscardsPresent)
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
        int numBootstraps = Convert.ToInt32(this.controlBootstrap.BootstrapIterations);
        int numSims = Convert.ToInt32(this.controlGeneralOptions.GeneralNumberPopulationSimuations);
        int numYears = this.controlGeneralOptions.SeqYears().Count();
        //size equals timeHorizon * numRealizations, which numRealizations is numBootstraps * numSims
        int auxFileRowSize = numBootstraps * numSims * numYears;
        if (this.controlMiscOptions.CheckOutputFileRowSize(auxFileRowSize) == false)
        {
          return false;
        }

        return true;
      }
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
      if (!File.Exists(this.controlBootstrap.BootstrapFilename))
      {
        if (File.Exists(Path.GetDirectoryName(inputData.General.InputFile) + "\\"
            + Path.GetFileName(inputData.Bootstrap.BootstrapFile)))
        {
          string inpFileDir = Path.GetDirectoryName(inputData.General.InputFile);
          string bsnFileName = Path.GetFileName(inputData.Bootstrap.BootstrapFile);
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
      if (this.launchAGEPROModelToolStripMenuItem.Enabled == false)
      {
        this.launchAGEPROModelToolStripMenuItem.Enabled = true;
      }
      if (this.saveAGEPROInputDataAsToolStripMenuItem.Enabled == false)
      {
        this.saveAGEPROInputDataAsToolStripMenuItem.Enabled = true;
      }
      //if "Discards are Present" is not checked, disable the discard parameters panels.
      controlDiscardWeight.Enabled = controlGeneralOptions.GeneralDiscardsPresent;
      controlDiscardFraction.Enabled = controlGeneralOptions.GeneralDiscardsPresent;

      //Setup Data Binding for Parameter Controls  
      if (inputData != null)
      {
        controlBootstrap.SetBootstrapControls(inputData.Bootstrap);
        controlMiscOptions.SetupRefpointDataBindings(inputData.Refpoint);
        controlMiscOptions.SetupScaleFactorsDataBindings(inputData.Scale);
        controlMiscOptions.SetupBoundsDataBindings(inputData.Bounds);
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
