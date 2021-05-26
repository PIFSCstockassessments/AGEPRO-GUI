using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  class ControlInputValidation
  {
    private bool GetValidateControlInputs(FormAgepro form)
    {
      int numAges = form.controlGeneralOptions.NumAges();
      double boundsMaxWeight;
      double boundsNaturalMortality;

      //Default values for bounds
      double defaultMaxWeightBound = 10.0;
      double defaultNatualMortalityBound = 1.0;

      //Enforce Bounds defaults if option is unchecked
      switch (form.controlMiscOptions.MiscOptionsBounds)
      {
        case false:
          boundsMaxWeight = defaultMaxWeightBound;
          boundsNaturalMortality = defaultMaxWeightBound;
          break;
        default:
          //Check Bounds text if they are empty. If so, use default value and inform the user about this.
          if (string.IsNullOrWhiteSpace(form.controlMiscOptions.MiscOptionsBoundsMaxWeight))
          {
            _ = MessageBox.Show($"Missing max weight bound. Using default value of {defaultMaxWeightBound}.", "AGEPRO",
              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            boundsMaxWeight = defaultMaxWeightBound;
          }
          else
          {
            boundsMaxWeight = Convert.ToDouble(form.controlMiscOptions.MiscOptionsBoundsMaxWeight);
          }

          if (string.IsNullOrWhiteSpace(form.controlMiscOptions.MiscOptionsBoundsNaturalMortality))
          {
            _ = MessageBox.Show($"Missing max natural mortality Bound. Using default value of {defaultNatualMortalityBound}.",
              "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            boundsNaturalMortality = defaultNatualMortalityBound;
          }
          else
          {
            boundsNaturalMortality = Convert.ToDouble(
                form.controlMiscOptions.MiscOptionsBoundsNaturalMortality);
          }

          break;
      }

      //Aux Stochastic Output File Size Check 
      int numBootstraps = Convert.ToInt32(form.controlBootstrap.BootstrapIterations);
      int numSims = Convert.ToInt32(form.controlGeneralOptions.GeneralNumberPopulationSimuations);
      int numYears = form.controlGeneralOptions.SeqYears().Count();
      //size equals timeHorizon * numRealizations, which numRealizations is numBootstraps * numSims
      int auxFileRowSize = numBootstraps * numSims * numYears;
      //Check if AuxFileRowSize isvalid and 
      return form.controlMiscOptions.CheckOutputFileRowSize(auxFileRowSize)
        && ValidateAgeproParameterInterfaceInput(form, numAges, boundsMaxWeight, boundsNaturalMortality);
    }

    private static bool ValidateAgeproParameterInterfaceInput(FormAgepro form, int numAges, double boundsMaxWeight, double boundsNaturalMortality)
    {
      //JAN-1 Weights (Stock Weights)
      if (form.controlJan1Weight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
      {
        return false;
      }
      //SSB Weights
      if (form.controlSSBWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
      {
        return false;
      }
      //Mean Weights
      if (form.controlMidYearWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
      {
        return false;
      }
      //Catch Weight
      if (form.controlCatchWeight.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
      {
        return false;
      }
      //Natural Mortality
      if (form.controlNaturalMortality.ValidateStochasticParameter(numAges, boundsNaturalMortality) == false)
      {
        return false;
      }
      //(Biological) Maturity
      if (form.controlBiological.maturityAge.ValidateStochasticParameter(numAges) == false)
      {
        return false;
      }
      //(Biological) Fraction Mortality (TSpawn) Prior to Spawning 
      if (form.controlBiological.TSpawnPanel.ValidateTSpawnDataGrid() == false)
      {
        return false;
      }
      //Fishery Selectivity
      if (form.controlFisherySelectivity.ValidateStochasticParameter(numAges) == false)
      {
        return false;
      }
      if (form.controlGeneralOptions.GeneralDiscardsPresent)
      {
        //Discard Weight
        if (form.controlDiscardWeight.ValidateStochasticParameter(numAges) == false)
        {
          return false;
        }
        //Discard Fraction
        if (form.controlDiscardFraction.ValidateStochasticParameter(numAges, boundsMaxWeight) == false)
        {
          return false;
        }
      }

      //Recruitment
      if (form.controlRecruitment.ValidateRecruitmentData() == false)
      {
        return false;
      }

      //Bootstrap
      if (form.controlBootstrap.ValidateBootstrapInput() == false)
      {
        return false;
      }
      //Bootstrap Filename validtion via this.ValidateBootstrapFilename()

      //Harvest Scenario (this includes Rebuilder and P-Star options)
      if (form.controlHarvestScenario.ValidateHarvestScenario() == false)
      {
        return false;
      }

      //Misc Options: Reference Points, Retro Adjustment Factors, Bounds.
      if (form.controlMiscOptions.ValidateMiscOptions() == false)
      {
        return false;
      }

      return true;
    }
  }
}
