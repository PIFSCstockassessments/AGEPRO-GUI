using Nmfs.Agepro.CoreLib;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public class FormAgeproBase : Form
  {
    internal AgeproInputFile inputData;
    internal ControlGeneral controlGeneralOptions;
    internal ControlMiscOptions controlMiscOptions;
    internal ControlBootstrap controlBootstrap;
    internal ControlStochasticAge controlFisherySelectivity;
    internal ControlStochasticAge controlDiscardFraction;
    internal ControlStochasticAge controlNaturalMortality;
    internal ControlBiological controlBiological;
    internal ControlStochasticWeightAge controlJan1Weight;
    internal ControlStochasticWeightAge controlSSBWeight;
    internal ControlStochasticWeightAge controlMidYearWeight;
    internal ControlStochasticWeightAge controlCatchWeight;
    internal ControlStochasticWeightAge controlDiscardWeight;
    internal ControlHarvestScenario controlHarvestScenario;
    internal ControlRecruitment controlRecruitment;



    /// <summary>
    /// Initiates the Control's "Startup State" or the "Uninitialized Model" phase.
    /// </summary>
    protected void SetupStartupState()
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

      //Set General Options Controls (to handle "New Cases")
      controlGeneralOptions.GeneralInputFile = "";
      controlGeneralOptions.GeneralModelId = "untitled";
      inputData.General.InputFile = "";
      inputData.CaseID = controlGeneralOptions.GeneralModelId;
      controlGeneralOptions.GeneralInpfileFormatTextBoxString = inputData.Version;

      //initially set Number of Ages
      _ = controlGeneralOptions.GeneralFirstAgeClass; //Spinbox Value

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

      //Set WeightAgeType 
      controlJan1Weight.WeightAgeType = StochasticWeightOfAge.Jan1Weight;
      controlSSBWeight.WeightAgeType = StochasticWeightOfAge.SSBWeight;
      controlMidYearWeight.WeightAgeType = StochasticWeightOfAge.MidYearWeight;
      controlCatchWeight.WeightAgeType = StochasticWeightOfAge.CatchWeight;
      controlDiscardWeight.WeightAgeType = StochasticWeightOfAge.DiscardWeight;

      //Weights Option
      controlJan1Weight.ShowJan1WeightsOption = false;
      controlJan1Weight.ShowSSBWeightsOption = false;
      controlJan1Weight.showMidYearWeightsOption = false;
      controlJan1Weight.ShowCatchWeightsOption = false;
      //SSB
      controlSSBWeight.ShowSSBWeightsOption = false;
      controlSSBWeight.showMidYearWeightsOption = false;
      controlSSBWeight.ShowCatchWeightsOption = false;
      //Mid-Year
      controlMidYearWeight.showMidYearWeightsOption = false;
      controlMidYearWeight.ShowCatchWeightsOption = false;
      //Catch-weight
      controlCatchWeight.ShowCatchWeightsOption = false;

    }

    /// <summary>
    /// Generates an Agepro Model based from user inputs made from the ControlGeneral panel 
    /// </summary>
    protected void SetAgeproModelFromUserInput()
    {
      //New Cases references version included in AGEPRO Reference Manual
      inputData.Version = CoreLib.Resources.Version.INP_VersionString; // "AGEPRO VERSION 4.25"

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
      controlMiscOptions.miscOptionsNumAges = controlGeneralOptions.NumAges();
      controlMiscOptions.MiscOptionsInpfileFormat = inputData.Version;
      controlMiscOptions.miscOptionsFirstAge = controlGeneralOptions.GeneralFirstAgeClass;
      controlMiscOptions.SetupGroupSummaryStockFlag(inputData.Options);

      //Retro Adjustment Factors
      if (controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors)
      {
        controlMiscOptions.SetupRetroAdjustmentControl(controlGeneralOptions);
      }

      //Set Stochastic Paramaeter DataGrids           
      controlJan1Weight.CreateStochasticParameterFallbackDataTable(inputData.Jan1StockWeight, inputData.General, StochasticAgeFleetDependency.independent);
      controlSSBWeight.CreateStochasticParameterFallbackDataTable(inputData.SSBWeight, inputData.General, StochasticAgeFleetDependency.independent);
      controlMidYearWeight.CreateStochasticParameterFallbackDataTable(inputData.MeanWeight, inputData.General, StochasticAgeFleetDependency.independent);
      controlCatchWeight.CreateStochasticParameterFallbackDataTable(inputData.CatchWeight, inputData.General, StochasticAgeFleetDependency.dependent);
      controlFisherySelectivity.CreateStochasticParameterFallbackDataTable(inputData.Fishery, inputData.General, StochasticAgeFleetDependency.dependent);

      controlNaturalMortality.CreateStochasticParameterFallbackDataTable(inputData.NaturalMortality, inputData.General, StochasticAgeFleetDependency.independent);
      controlBiological.maturityAge.CreateStochasticParameterFallbackDataTable(inputData.BiologicalMaturity, inputData.General, StochasticAgeFleetDependency.independent);

      //Show Discard DataTables if Discards options is checked
      if (controlGeneralOptions.GeneralDiscardsPresent)
      {
        controlDiscardFraction.CreateStochasticParameterFallbackDataTable(inputData.DiscardFraction, inputData.General, StochasticAgeFleetDependency.dependent);
        controlDiscardWeight.CreateStochasticParameterFallbackDataTable(inputData.DiscardWeight, inputData.General, StochasticAgeFleetDependency.independent);
      }
      else //Otherwise remove ("reset") any dataGridView existing data. 
      {
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
      //Set harvest calculations to "Harvest Scenario" None by Default
      controlHarvestScenario.SeqYears = controlGeneralOptions.SeqYears();
      inputData.HarvestScenario.AnalysisType = HarvestScenarioAnalysis.HarvestScenario;
      controlHarvestScenario.SetHarvestScenarioCalcControls(inputData);
      DataTable userGenBasedHarvestScenarioTable = AgeproHarvestScenario.NewHarvestTable(
        controlHarvestScenario.SeqYears.Count(), Convert.ToInt32(controlGeneralOptions.GeneralNumberFleets));
      controlHarvestScenario.SetHarvestScenarioInputDataTable(userGenBasedHarvestScenarioTable);
      inputData.HarvestScenario.HarvestScenarioTable = userGenBasedHarvestScenarioTable;

      //Bootstrap
      controlBootstrap.SetBootstrapControls(inputData.Bootstrap);
      controlGeneralOptions.SetupInpfileFormatTextBoxDataBindings(inputData);
    }

    /// <summary>
    /// Load AGEPRO InputFile data into AGEPRO Parameter Controls. 
    /// 
    /// Input version format check is done previously by "ReadInputFile"
    /// </summary>
    /// <param name="inpFile">AGEPRO CoreLib InputFile</param>
    protected void LoadAgeproModelFromInputFile(AgeproInputFile inpFile)
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
      controlGeneralOptions.GeneralInputFile = inpFile.General.InputFile;
      controlGeneralOptions.GeneralInpfileFormatTextBoxString = inpFile.Version;

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
      controlMiscOptions.MiscOptionsInpfileFormat = inpFile.Version;
      controlMiscOptions.SetupControlFromFile(inpFile);

      Console.WriteLine("Loaded AGEPRO Parameters ..");
    }

    /// <summary>
    /// Saves data that is currently on the GUI to file. 
    /// </summary>
    protected void SaveAgeproInputDataFileDialog()
    {
      SaveFileDialog saveAgeproInputFile = new SaveFileDialog
      {
        InitialDirectory = "~",
        Filter = "AGEPRO input files (*.inp)|*.inp|All Files (*.*)|*.*",
        FilterIndex = 1,
        RestoreDirectory = true
      };

      if (saveAgeproInputFile.ShowDialog() == DialogResult.OK)
      {

        try
        {
          //Validate
          if (GetValidateControlInputs() == false)
          {
            throw new InvalidAgeproParameterException("Unable to save AGEPRO Input Data due to invalid input.");
          }

          //Case Id
          inputData.CaseID = controlGeneralOptions.GeneralModelId;

          //Weights of Age 
          controlJan1Weight.BindStochasticAgeData(inputData.Jan1StockWeight);
          controlSSBWeight.BindStochasticAgeData(inputData.SSBWeight);
          controlMidYearWeight.BindStochasticAgeData(inputData.MeanWeight);
          controlCatchWeight.BindStochasticAgeData(inputData.CatchWeight);

          //Fishery Selectivity
          controlFisherySelectivity.BindStochasticAgeData(inputData.Fishery);

          //Natural Mortality
          controlBiological.maturityAge.BindStochasticAgeData(inputData.BiologicalMaturity);
          controlNaturalMortality.BindStochasticAgeData(inputData.NaturalMortality);
          inputData.BiologicalTSpawn.TimeVarying = controlBiological.TSpawnPanel.TSpawnTableTimeVarying;

          if (inputData.General.HasDiscards)
          {
            controlDiscardWeight.BindStochasticAgeData(inputData.DiscardWeight);
            controlDiscardFraction.BindStochasticAgeData(inputData.DiscardFraction);
          }

          //Harvest Scenario: Rebuilder/PStar
          if (controlHarvestScenario.CalcType == HarvestScenarioAnalysis.PStar)
          {
            inputData.HarvestScenario.AnalysisType = controlHarvestScenario.CalcType;
            inputData.PStar.AnalysisType = controlHarvestScenario.CalcType;
            inputData.PStar.PStarLevels = controlHarvestScenario.PStar.PStarLevels;
            inputData.PStar.PStarF = controlHarvestScenario.PStar.PStarF;
            inputData.PStar.TargetYear = controlHarvestScenario.PStar.TargetYear;
            inputData.PStar.PStarTable = controlHarvestScenario.PStar.PStarTable;
          }
          else if (controlHarvestScenario.CalcType == HarvestScenarioAnalysis.Rebuilder)
          {
            inputData.HarvestScenario.AnalysisType = controlHarvestScenario.CalcType;
            inputData.Rebuild.AnalysisType = controlHarvestScenario.CalcType;
            inputData.Rebuild.TargetYear = controlHarvestScenario.Rebuilder.TargetYear;
            inputData.Rebuild.TargetValue = controlHarvestScenario.Rebuilder.TargetValue;
            inputData.Rebuild.TargetType = controlHarvestScenario.Rebuilder.TargetType;
            inputData.Rebuild.TargetPercent = controlHarvestScenario.Rebuilder.TargetPercent;
          }

          //Misc options
          inputData.Options.EnableExportR = controlMiscOptions.MiscOptionsEnableExportR;
          inputData.Options.EnableAuxStochasticFiles = controlMiscOptions.MiscOptionsEnableAuxStochasticFiles;
          inputData.Options.EnablePercentileReport = controlMiscOptions.MiscOptionsEnablePercentileReport;
          inputData.Options.EnableRefpoint = controlMiscOptions.MiscOptionsEnableRefpointsReport;
          inputData.Options.EnableScaleFactors = controlMiscOptions.MiscOptionsEnableScaleFactors;
          inputData.Options.EnableBounds = controlMiscOptions.MiscOptionsBounds;
          inputData.Options.EnableRetroAdjustmentFactors = controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors;


          if (controlMiscOptions.MiscOptionsEnableVer40Format)
          {
            //Misc Options: Enable Summary Report (AGEPRO VERSION 4.0)
            inputData.Options.EnableSummaryReport = Convert.ToBoolean((int)controlMiscOptions.SummaryAuxFileOutputFlag);
            inputData.Version = CoreLib.Resources.Version.INP_AGEPRO40_VersionString;
            controlGeneralOptions.GeneralInpfileFormatTextBoxString = inputData.Version;
          }
          else
          {
            //Misc Options: Auxilary Output Flag (AGEPRO VERSION 4.25+)
            inputData.Options.OutputSummaryReport = (int)controlMiscOptions.SummaryAuxFileOutputFlag;
            //Points to the current Input file format version string in INP_VersionString
            inputData.Version = CoreLib.Resources.Version.INP_VersionString;
            controlGeneralOptions.GeneralInpfileFormatTextBoxString = inputData.Version;
          }

            

          //Misc Options: Refpoint
          inputData.Refpoint.RefSpawnBio = double.Parse(controlMiscOptions.MiscOptionsRefSpawnBiomass);
          inputData.Refpoint.RefJan1Bio = double.Parse(controlMiscOptions.MiscOptionsRefJan1Biomass);
          inputData.Refpoint.RefMeanBio = double.Parse(controlMiscOptions.MiscOptionsRefMeanBiomass);
          inputData.Refpoint.RefFMort = double.Parse(controlMiscOptions.MiscOptionsRefFishingMortality);

          //Misc Options: Report Percentile
          inputData.ReportPercentile.Percentile = controlMiscOptions.MiscOptionsReportPercentile;

          //Misc Options: Scale Factors
          inputData.Scale.ScaleBio = double.Parse(controlMiscOptions.MiscOptionsScaleFactorBiomass);
          inputData.Scale.ScaleRec = double.Parse(controlMiscOptions.MiscOptionsScaleFactorRecruits);
          inputData.Scale.ScaleStockNum = double.Parse(controlMiscOptions.MiscOptionsScaleFactorStockNumbers);

          //Misc Options: Retro Adjustment Factors
          inputData.RetroAdjustment.RetroAdjust = controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable;

          inputData.WriteInputFile(saveAgeproInputFile.FileName);

          //Set filename to generalOptions Input File textbox
          controlGeneralOptions.GeneralInputFile = saveAgeproInputFile.FileName;

          _ = MessageBox.Show($"AGEPRO Input Data was saved at{Environment.NewLine}{saveAgeproInputFile.FileName}", "",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
          _ = MessageBox.Show($"AGEPRO input file was not saved.{Environment.NewLine}{ex.Message}", "",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
      }

    }



    /*****************************************************************************************
     * VALAIDATION
     * ****************************************************************************************/
    /// <summary>
    /// AGEPRO GUI Control input validation. 
    /// </summary>
    /// <returns>
    /// If all control inputs pass validation checks, a dialog message will 
    /// verify so and return true. 
    /// The first invaild case will exit validation, a dialog message of the type of 
    /// invalidation, and return false.
    /// </returns>
    protected bool GetValidateControlInputs()
    {
      int numAges = controlGeneralOptions.NumAges();
      double boundsMaxWeight;
      double boundsNaturalMortality;

      //Default values for bounds
      double defaultMaxWeightBound = 10.0;
      double defaultNatualMortalityBound = 1.0;

      controlHarvestScenario.SeqYears = controlGeneralOptions.SeqYears();

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
            _ = MessageBox.Show($"Missing max weight bound. Using default value of {defaultMaxWeightBound}.", "AGEPRO",
              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            boundsMaxWeight = defaultMaxWeightBound;
          }
          else
          {
            boundsMaxWeight = Convert.ToDouble(controlMiscOptions.MiscOptionsBoundsMaxWeight);
          }

          if (string.IsNullOrWhiteSpace(controlMiscOptions.MiscOptionsBoundsNaturalMortality))
          {
            _ = MessageBox.Show($"Missing max natural mortality Bound. Using default value of {defaultNatualMortalityBound}.",
              "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
      if (controlGeneralOptions.GeneralDiscardsPresent)
      {
        //Discard Weight
        if (controlDiscardWeight.ValidateStochasticParameter(numAges) == false)
        {
          return false;
        }
        //Discard Fraction
        if (controlDiscardFraction.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
        {
          return false;
        }
      }


      //Recruitment
      if (controlRecruitment.ValidateRecruitmentData() == false)
      {
        return false;
      }

      //Bootstrap
      if (controlBootstrap.ValidateBootstrapInput() == false)
      {
        return false;
      }
      //Bootstrap Filename validtion via this.ValidateBootstrapFilename()

      //Harvest Scenario (this includes Rebuilder and P-Star options)
      if (controlHarvestScenario.ValidateHarvestScenario(controlGeneralOptions) == false)
      {
        return false;
      }

      //Misc Options: Reference Points, Retro Adjustment Factors, Bounds.
      if (controlMiscOptions.ValidateMiscOptions() == false)
      {
        return false;
      }

      //Aux Stochastic Output File Size Check 
      int numBootstraps = Convert.ToInt32(controlBootstrap.BootstrapIterations);
      int numSims = Convert.ToInt32(controlGeneralOptions.GeneralNumberPopulationSimuations);
      int numYears = controlGeneralOptions.SeqYears().Count();
      //size equals timeHorizon * numRealizations, which numRealizations is numBootstraps * numSims
      int auxFileRowSize = numBootstraps * numSims * numYears;
      if (controlMiscOptions.CheckOutputFileRowSize(auxFileRowSize) == false)
      {
        return false;
      }

      return true;
    }

    
  }
}