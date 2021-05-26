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

    private void CreateAgeproModel()
    {
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
        //In case NumAges is larger than previous row count, "reset" dataGridView 
        if (controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable != null
          && controlGeneralOptions.NumAges() > controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable.Rows.Count)
        {
          controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable.Reset();
        }
        controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable =
            controlMiscOptions.GetRetroAdjustmentFallbackTable(controlMiscOptions.miscOptionsNAges);
        controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
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
      if (controlHarvestScenario.ValidateHarvestScenario() == false)
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