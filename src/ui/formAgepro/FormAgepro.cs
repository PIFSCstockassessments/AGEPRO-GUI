using Nmfs.Agepro.CoreLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{

  public partial class FormAgepro : FormAgeproBase
  {
    public FormAgepro()
    {
      InitializeComponent();
      SetupStartupState();
      SetupPanelState();

      //Unsubcribe event handler in case previous one exists, before subcribing a new one
      controlGeneralOptions.SetGeneral -= new EventHandler(EventSetButton_CreateNewCase);
      controlGeneralOptions.SetGeneral += new EventHandler(EventSetButton_CreateNewCase);

    }

    /// <summary>
    /// Sets Up Navigation and main control collecton panels.
    /// </summary>
    private void SetupPanelState()
    {
      //Load General Options Controls to AGEPRO Parameter panel           
      panelAgeproParameter.Controls.Clear();
      controlGeneralOptions.Dock = DockStyle.Fill;
      panelAgeproParameter.Controls.Add(controlGeneralOptions);

      //Instatiate Startup State:
      //Disable Navigation Tree Panel, AGEPRO run options, etc...
      panelNavigation.Enabled = false;
      saveAGEPROInputDataAsToolStripMenuItem.Enabled = false;
    }

    /// <summary>
    /// Event when the "Create New Case" menu option is selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreateNewCaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Dialog box to ensure that the user intends to start over and "create a new case"
      DialogResult dlgResult = MessageBox.Show(
        $"Do you want to start over with a new case?{Environment.NewLine}New cases will discard current input data.",
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
        SetupPanelState();
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

        CreateAgeproModel();

        //Activate Naivagation Panel if in first-run/startup state.
        //Disable/'Do not load' parameters to Discard Weight and Discard Fraction if 
        //Discards are Present is not checked
        EnableNavigationPanel();

        _ = MessageBox.Show(
          $"General AGEPRO Projection Parameters set.{Environment.NewLine}{Environment.NewLine}" +
          $"Recruitment and Bootstrap file is required to save as AGEPRO input file or to launch AGEPRO model.",
          "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show($"Can not set AGEPRO general paraneters.{Environment.NewLine}{ex.Message}", "AGEPRO",
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

    }


    /// <summary>
    /// Calls the OpenFileDialog Window to retrive an existing AGEPRO Input file.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OpenExistingAGEPROInputDataFileToolStripMenuItem_Click(object sender, EventArgs e)
    {

      OpenFileDialog openAgeproInputFile = new OpenFileDialog
      {
        InitialDirectory = "~",
        Filter = "AGEPRO input files (*.inp)|*.inp|All Files (*.*)|*.*",
        FilterIndex = 1,
        RestoreDirectory = true
      };

      if (openAgeproInputFile.ShowDialog() == DialogResult.OK)
      {
        try
        {
          //CoreLib.geproInputFile's ReadInputFile
          inputData = new AgeproInputFile();
          inputData.ReadInputFile(openAgeproInputFile.FileName);

          LoadAgeproInputParameters(inputData);
          controlGeneralOptions.GeneralInputFile = openAgeproInputFile.FileName;

          //Activate Naivagation Panel if in first-run/startup state.
          EnableNavigationPanel();
        }
        catch (Exception ex)
        {
          _ = MessageBox.Show($"Error loading AGEPRO input file:{Environment.NewLine}{ex.Message}",
              "AGEPRO Input File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

      if (controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors)
      {
        controlMiscOptions.SetRetroAdjustmentFactorRowHeaders();
      }

      Console.WriteLine("Loaded AGEPRO Parameters ..");
    }

    /// <summary>
    /// Event when "Save AGEPRO Input Data As ..." menu option is selected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveAGEPROInputDataAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveAgeproInputDataFileDialog();
    }

    /// <summary>
    /// Saves data that is currently on the GUI to file. 
    /// </summary>
    private void SaveAgeproInputDataFileDialog()
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
            inputData.Rebuild.TargetPercent = controlHarvestScenario.Rebuilder.TargetPercent;
            inputData.Rebuild.TargetType = controlHarvestScenario.Rebuilder.TargetType;
          }

          //Misc options
          inputData.Options.EnableSummaryReport = controlMiscOptions.MiscOptionsEnableSummaryReport;
          inputData.Options.EnableExportR = controlMiscOptions.MiscOptionsEnableExportR;
          inputData.Options.EnableAuxStochasticFiles = controlMiscOptions.MiscOptionsEnableAuxStochasticFiles;
          inputData.Options.EnablePercentileReport = controlMiscOptions.MiscOptionsEnablePercentileReport;
          inputData.Options.EnableRefpoint = controlMiscOptions.MiscOptionsEnableRefpointsReport;
          inputData.Options.EnableScaleFactors = controlMiscOptions.MiscOptionsEnableScaleFactors;
          inputData.Options.EnableBounds = controlMiscOptions.MiscOptionsBounds;
          inputData.Options.EnableRetroAdjustmentFactors = controlMiscOptions.MiscOptionsEnableRetroAdjustmentFactors;
          
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
          inputData.RetroAdjustments.RetroAdjust = controlMiscOptions.MiscOptionsRetroAdjustmentFactorTable;

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
     *  LAUNCH TO AGEPRO CALCULATION ENGINE
     ****************************************************************************************/

    /// <summary>
    /// Programmicaly commit data in current active winform control.  
    /// </summary>
    private void CommitFocusedControl()
    {
      //If a cell is in edit mode, commit changes and end edit mode.
      Control ctlActive = FindFocusedControl(ActiveControl);
      if (ctlActive is DataGridViewTextBoxEditingControl txtCell)
      {
        txtCell.EditingControlDataGridView.EndEdit();
      }
      else if (ctlActive is TextBox)
      {
        //Take focus away from text box to force textBox validation.
        //use naviagation Tree workaround, since focusing on menuStrip isn't working
        _ = treeViewNavigation.Focus();
        _ = ctlActive.Focus(); //focus back to textBox.

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
    private void LaunchAGEPROModelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CommitFocusedControl();

      //Validate
      if (GetValidateControlInputs() == false)
      {
        return;
      }
      if (ValidateBootstrapFilename() == false)
      {
        return;
      }

      //If Input Data is Valid LaunchAgeproModel() 
      new AgeproCalculationLauncher(controlMiscOptions).LaunchAgeproModel(inputData, controlGeneralOptions.GeneralInputFile);
      //LaunchAgeproModel(inputData, controlGeneralOptions.GeneralInputFile);
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
      if (!File.Exists(controlBootstrap.BootstrapFilename))
      {
        if (File.Exists($"{Path.GetDirectoryName(inputData.General.InputFile)}\\{Path.GetFileName(inputData.Bootstrap.BootstrapFile)}"))
        {
          string inpFileDir = Path.GetDirectoryName(inputData.General.InputFile);
          string bsnFileName = Path.GetFileName(inputData.Bootstrap.BootstrapFile);
          bootstrapChoice = MessageBox.Show($"Bootstrap filename was not found.{Environment.NewLine}" +
            $"However, {bsnFileName} was found at {inpFileDir}{Environment.NewLine}{Environment.NewLine}Continue?",
            "AGEPRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

          if (bootstrapChoice == DialogResult.No)
          {
            return false;
          }

        }
        else
        {
          bootstrapChoice = MessageBox.Show(
              $"Bootstrap file not found at:{Environment.NewLine}{controlBootstrap.BootstrapFilename}{Environment.NewLine}" +
              $"Please select a new AGEPRO Bootstrap file to continue.{Environment.NewLine}{Environment.NewLine}Continue and load bootstrap file?",
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
      if (panelNavigation.Enabled == false)
      {
        panelNavigation.Enabled = true;
      }
      if (launchAGEPROModelToolStripMenuItem.Enabled == false)
      {
        launchAGEPROModelToolStripMenuItem.Enabled = true;
      }
      if (saveAGEPROInputDataAsToolStripMenuItem.Enabled == false)
      {
        saveAGEPROInputDataAsToolStripMenuItem.Enabled = true;
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
    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Terminate
      Close();
    }

    /// <summary>
    /// Method to find the current Active or Focused Control.
    /// </summary>
    /// <see cref="Https://stackoverflow.com/questions/435433/what-is-the-preferred-way-to-find-focused-control-in-winforms-app"/>
    /// <param name="control">Control object</param>
    /// <returns></returns>
    private static Control FindFocusedControl(Control control)
    {
      IContainerControl container = control as IContainerControl;
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
    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control ctlCut = FindFocusedControl(ActiveControl);

      if (ctlCut == null)
      {
        return;
      }

      //Note: Text Boxes data bonded to AGEPRO_CoreLib will still retain their value 
      //if nothing.
      if (ctlCut is TextBox textBoxToCut)
      {
        textBoxToCut.Cut();
      }
      else if (ctlCut is NftDataGridView dataCellsToCut)
      {
        dataCellsToCut.OnCopy();
        dataCellsToCut.OnDelete();
        dataCellsToCut.ClearSelection();
      }
    }

    /// <summary>
    /// Raises the Copy clipboard function from the "Copy" edit menu option.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control ctlCopy = FindFocusedControl(ActiveControl);
      if (ctlCopy == null)
      {
        return;
      }

      if (ctlCopy is TextBox textBoxToCopy)
      {
        textBoxToCopy.Copy();
      }
      else if (ctlCopy is NftDataGridView dataCellsToCopy)
      {
        dataCellsToCopy.OnCopy();
      }
    }

    /// <summary>
    /// Raises the Paste clipboard function from the "Paste" edit menu option.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control ctlPaste = FindFocusedControl(ActiveControl);
     
      if (ctlPaste == null)
      {
        return;
      }

      if (ctlPaste is TextBox textBoxToPaste)
      {
        textBoxToPaste.Paste();
      }
      else if (ctlPaste is NftDataGridView dataCellsToPaste)
      {
        dataCellsToPaste.OnPaste();
        dataCellsToPaste.ClearSelection();
      }
    }

    /// <summary>
    /// Raises the Delete clipboard command from the "Delete" edit menu option. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Control ctlDelete = FindFocusedControl(ActiveControl);

      if (ctlDelete == null)
      {
        return;
      }

      if (ctlDelete is TextBox textBoxTextToClear)
      {
        textBoxTextToClear.Clear();
      }
      else if (ctlDelete is NftDataGridView dataCellsToClear)
      {
        dataCellsToClear.OnDelete();
        dataCellsToClear.ClearSelection();
      }
    }

    /// TreeViewNavigation 

    /// <summary>
    /// Replaces an AGEPRO parameter user control in panelAgeproParmeter when a tree node from 
    /// treeViewNavigation is selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TreeViewNavigation_AfterSelect(object sender, TreeViewEventArgs e)
    {
      string selectedTreeNode = treeViewNavigation.SelectedNode.Name.ToString();

      //treeNode Action Dictionary
      Dictionary<string, Action> treeNodeDict =
          new Dictionary<string, Action> {

                {"treeNodeGeneral", SelectGeneralOptionsParameterPanel},
                {"treeNodeJan1", SelectJan1WeightsParameterPanel},
                {"treeNodeSSB", SelectSSBWeightsParameterPanel},
                {"treeNodeMidYear", SelectMidYearWeightsParameterPanel},
                {"treeNodeCatchWeight", SelectCatchWeightParameterPanel},
                {"treeNodeDiscardWeight", SelectDiscardWeightParameterPanel},
                {"treeNodeRecruitment",SelectRecruitmentParameterPanel},
                {"treeNodeFisherySelectivity", SelectFisherySelectivityParameterPanel},
                {"treeNodeDiscardFraction", SelectDiscardFractionParameterPanel},
                {"treeNodeNaturalMortality", SelectNaturalMortalityParameterPanel},
                {"treeNodeBiological", SelectBiologicalParameterPanel},
                {"treeNodeBootstrapping", SelectBootstrappingParameterPanel},
                {"treeNodeHarvestScenario", SelectHarvestScenarioParameterPanel},
                {"treeNodeMiscOptions", SelectMiscOptionsParameterPanel},

      };

      //If treeNode Action Dictionary key matches 'selectedTreeNode', then invoke the key's method
      if (treeNodeDict.ContainsKey(selectedTreeNode))
      {
        treeNodeDict[selectedTreeNode].Invoke();
      }

      //Panel naigation functions 
      void SelectGeneralOptionsParameterPanel()
      {
        SelectAgeproParameterPanel(controlGeneralOptions, true);
      }
      void SelectJan1WeightsParameterPanel()
      {
        SelectAgeproParameterPanel(controlJan1Weight);
      }
      void SelectSSBWeightsParameterPanel()
      {
        SelectAgeproParameterPanel(controlSSBWeight);
      }
      void SelectMidYearWeightsParameterPanel()
      {
        SelectAgeproParameterPanel(controlMidYearWeight);
      }
      void SelectCatchWeightParameterPanel()
      {
        SelectAgeproParameterPanel(controlCatchWeight);
      }
      void SelectDiscardWeightParameterPanel()
      {
        SelectAgeproParameterPanel(controlDiscardWeight);
      }
      void SelectFisherySelectivityParameterPanel()
      {
        SelectAgeproParameterPanel(controlFisherySelectivity);
      }
      void SelectDiscardFractionParameterPanel()
      {
        SelectAgeproParameterPanel(controlDiscardFraction);
      }
      void SelectNaturalMortalityParameterPanel()
      {
        SelectAgeproParameterPanel(controlNaturalMortality);
      }
      void SelectBiologicalParameterPanel()
      {
        SelectAgeproParameterPanel(controlBiological);
      }
      void SelectBootstrappingParameterPanel()
      {
        SelectAgeproParameterPanel(controlBootstrap);
      }
      void SelectHarvestScenarioParameterPanel()
      {
        SelectAgeproParameterPanel(controlHarvestScenario);
      }
      void SelectMiscOptionsParameterPanel()
      {
        SelectAgeproParameterPanel(controlMiscOptions, false);
      }
      void SelectRecruitmentParameterPanel()
      {
        SelectAgeproParameterPanel(controlRecruitment);
      }

    }


    /// <summary>
    /// Generalized method to set an AGEPRO Parameter User Control in the AGEPRO Parameter Panel
    /// </summary>
    /// <param name="ageproParameterControl">AGEPRO Parameter User Control</param>
    /// <param name="dockFill">Option to set Panel's Dock value to Dockstyle.Fill </param>
    private void SelectAgeproParameterPanel(UserControl ageproParameterControl, bool dockFill = true)
    {
      panelAgeproParameter.Controls.Clear();
      if (dockFill)
      {
        ageproParameterControl.Dock = DockStyle.Fill;
      }
      panelAgeproParameter.Controls.Add(ageproParameterControl);
    }

    /// <summary>
    /// Opens the "Age Structured Projection Model (AGEPRO)" help manual when the user
    /// clicks on the "Html Help" menu item under Help.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HtmlHelpToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Get location of the application's path.
      var loc = Path.GetDirectoryName(Application.ExecutablePath);

      //Append help html file and load it
      _ = Process.Start(loc + @"/doc/agepro_manual.html");
    }

    /// <summary>
    /// Launches Brodizak's "AGEPRO Reference Manual" when the user clicks on
    /// the "Reference Manual (Pdf)" menu item under Help.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ReferenceManualpdfToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //Get Location of Application Path
      var loc = Path.GetDirectoryName(Application.ExecutablePath);

      //Load Reference Manual from there
      string refManualPath = Path.Combine(loc, "doc", "AGEPRO_v4.2_Reference_Manual.pdf");
      if (!File.Exists(refManualPath))
      {
        throw new InvalidAgeproGuiParameterException("Reference Manual not found.");
      }

      _ = Process.Start(refManualPath);
    }

    /// <summary>
    /// Opens the AGEPRO About Dialog Box
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AboutAGEPROToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CommitFocusedControl();
      //About Box Dialog
      AboutAgepro aboutDialog = new AboutAgepro();
      _ = aboutDialog.ShowDialog();
    }


  }
}
