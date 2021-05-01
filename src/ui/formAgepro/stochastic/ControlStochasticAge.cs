using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{

  public partial class ControlStochasticAge : UserControl
  {
    protected ControlStochasticAgeDataGridTable controlStochasticParamAgeFromUser;
    protected ControlStochasticAgeFromFile controlStochasticParamAgeFromFile;
    protected bool SettingParameterForControl { get; set; }
    public string StochasticParameterLabel { get; set; }

    public ControlStochasticAge()
    {
      InitializeComponent();
      controlStochasticParamAgeFromUser = new ControlStochasticAgeDataGridTable();
      controlStochasticParamAgeFromFile = new ControlStochasticAgeFromFile();
      radioParameterFromUser.Checked = true; //User Specfied Option Selected by Default
      StochasticParameterLabel = "Stochastic Parameters"; //Default Fallback Text
      SettingParameterForControl = false;

      //By Default, Stochastic Parameters are fleet independent.
      FleetDependency = StochasticAgeFleetDependency.independent;

      controlStochasticParamAgeFromFile.TimeVaryingFileChecked +=
          new EventHandler(LinkTimeVaryingUserSpecAndFromFile);
      controlStochasticParamAgeFromUser.TimeVaryingCheckedChangedEvent +=
          new EventHandler(LinkTimeVaryingUserSpecAndFromFile);
    }

    public bool TimeVarying
    {
      get => controlStochasticParamAgeFromUser.TimeVarying;
      set => controlStochasticParamAgeFromUser.TimeVarying = value;
    }
    public bool ReadInputFileState
    {
      get => controlStochasticParamAgeFromUser.ReadInputFileState;
      set => controlStochasticParamAgeFromUser.ReadInputFileState = value;
    }
    public DataTable StochasticAgeTable
    {
      get => controlStochasticParamAgeFromUser.StochasticAgeTable;
      set => controlStochasticParamAgeFromUser.StochasticAgeTable = value;
    }
    public DataTable StochasticCV
    {
      get => controlStochasticParamAgeFromUser.StochasticCV;
      set => controlStochasticParamAgeFromUser.StochasticCV = value;
    }
    public string[] SeqYears
    {
      get => controlStochasticParamAgeFromUser.SeqYears;
      set => controlStochasticParamAgeFromUser.SeqYears = value;
    }
    public int NumFleets
    {
      get => controlStochasticParamAgeFromUser.NumFleets;
      set => controlStochasticParamAgeFromUser.NumFleets = value;
    }
    public string StochasticDataFile
    {
      get => controlStochasticParamAgeFromFile.StochasticDataFile;
      set => controlStochasticParamAgeFromFile.StochasticDataFile = value;
    }
    public bool IsMultiFleet
    {
      get => controlStochasticParamAgeFromUser.MultiFleetTable;
      set => controlStochasticParamAgeFromUser.MultiFleetTable = value;
    }
    public bool EnableTimeVaryingCheckBox
    {
      get => controlStochasticParamAgeFromUser.EnableTimeVaryingCheckBox;
      set => controlStochasticParamAgeFromUser.EnableTimeVaryingCheckBox = value;
    }
    public StochasticAgeFleetDependency FleetDependency
    {
      get => controlStochasticParamAgeFromUser.FleetDependent;
      set => controlStochasticParamAgeFromUser.FleetDependent = value;
    }


    protected void LinkTimeVaryingUserSpecAndFromFile(object sender, EventArgs e)
    {
      CheckBox timeVaryingControl = sender as CheckBox;
      if (timeVaryingControl.Name == "checkBoxTimeVaryingFile")
      {
        TimeVarying = timeVaryingControl.Checked;
      }
      else if (timeVaryingControl.Name == "checkBoxTimeVarying")
      {
        controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Checked = timeVaryingControl.Checked;

      }
    }

    protected override void OnLoad(EventArgs e)
    {
      //(Re)Set Stochastic Parameter Label/Options text 
      radioParameterFromUser.Text = "User Specified " + StochasticParameterLabel + " At Age";
      radioParameterFromFile.Text = "Read " + StochasticParameterLabel + " From File";
      controlStochasticParamAgeFromUser.StochasticParamAgeDataGridLabel = StochasticParameterLabel + " Of Age";
      controlStochasticParamAgeFromFile.stochasticParameterFileLabel = StochasticParameterLabel;

      //enforce 'Time Varying' value inbetween the 'User Specifed DataGrid Tables' & 'File Dialog' panels
      controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Checked = TimeVarying;
      controlStochasticParamAgeFromFile.checkBoxTimeVaryingFile.Enabled = EnableTimeVaryingCheckBox;
      //In cases where Stochastic Parameters has null data source (where the 'time varying' check box should 
      //be disabled), use that disabled state for the 'from file' panel.
      controlStochasticParamAgeFromFile.Enabled = EnableTimeVaryingCheckBox;

      base.OnLoad(e);
    }

    /// <summary>
    /// Generalized method to load Stochastic Data Parameters from AGEPRO Input Data files.
    /// </summary>
    /// <param name="inp">AGEPRO InputFile StochasticAge Parameters </param>
    /// <param name="generalOpt">AGEPRO InputFile General Options values</param>
    public void LoadStochasticAgeInputData(AgeproStochasticAgeTable inp,
        AgeproGeneral generalOpt)
    {
      ReadInputFileState = true;
      SeqYears = Array.ConvertAll(generalOpt.SeqYears(), element => element.ToString());
      NumFleets = generalOpt.NumFleets;
      TimeVarying = inp.TimeVarying;
      StochasticDataFile = inp.DataFile;
      StochasticAgeTable = inp.ByAgeData;
      StochasticCV = inp.ByAgeCV;

      EnableTimeVaryingCheckBox = StochasticAgeTable != null;
      ReadInputFileState = false;
    }

    protected virtual void RadioParameterFromUser_CheckedChanged(object sender, EventArgs e)
    {
      if (SettingParameterForControl)
      {
        return;
      }
      panelStochasticParameterAge.Controls.Clear();
      controlStochasticParamAgeFromUser.Dock = DockStyle.Fill;
      panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromUser);

    }

    protected virtual void RadioParameterFromFile_CheckedChanged(object sender, EventArgs e)
    {
      if (SettingParameterForControl)
      {
        return;
      }
      panelStochasticParameterAge.Controls.Clear();
      controlStochasticParamAgeFromFile.Dock = DockStyle.Fill;
      panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromFile);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inp"></param>
    public virtual void BindStochasticAgeData(AgeproStochasticAgeTable inp)
    {
      if (inp is null)
      {
        throw new ArgumentNullException(nameof(inp));
      }

      if (ReadInputFileState)
      {
        inp.FromFile = true;
        inp.TimeVarying = TimeVarying;
        inp.ByAgeData.Clear();
        inp.ByAgeCV.Clear();
      }
      else
      {
        inp.FromFile = false;
        inp.TimeVarying = TimeVarying;
        inp.ByAgeData = StochasticAgeTable;
        inp.ByAgeCV = StochasticCV;
      }

    }

    /// <summary>
    /// Creates a empty Data Table for the Stochastic Parameter Control based on the user inputs gathered 
    /// from the General Options control parameter.
    /// </summary>
    /// <param name="objNT">Object representing the Stochastic Parameter</param>
    /// <param name="genOpt">Paramters from the General Options Control</param>
    /// <param name="fleetDependent">Is this Stochastic Parameter dependent on the 
    /// nubmber of fleets? Default is false.</param>
    public void CreateStochasticParameterFallbackDataTable(
      AgeproStochasticAgeTable objNT,
      AgeproGeneral genOpt,
      StochasticAgeFleetDependency fleetDependent = StochasticAgeFleetDependency.independent)
    {
      NumFleets = Convert.ToInt32(genOpt.NumFleets);
      SeqYears = Array.ConvertAll(genOpt.SeqYears(), element => element.ToString());

      ReadInputFileState = true;

      //Reset Tables if they were used before
      if (StochasticAgeTable != null)
      {
        StochasticAgeTable.Reset();
        StochasticCV.Reset();
      }

      if (TimeVarying)
      {
        StochasticAgeTable = CreateFallbackAgeDataTable(
          genOpt.NumAges(),
          genOpt.SeqYears().Count(),
          NumFleets);
      }
      else
      {
        if (fleetDependent == StochasticAgeFleetDependency.dependent)
        {
          StochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, NumFleets);
          StochasticCV = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, NumFleets);
        }
        else
        {
          StochasticAgeTable = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, 1);
          StochasticCV = CreateFallbackAgeDataTable(genOpt.NumAges(), 1, 1);
        }

      }

      objNT.ByAgeData = StochasticAgeTable;
      objNT.ByAgeCV = StochasticCV;

      ReadInputFileState = false;

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

      DataTable fallbackTable = new DataTable();

      for (int icol = 0; icol < numAges; icol++)
      {
        _ = fallbackTable.Columns.Add("Age" + " " + (icol + 1));
      }
      for (int row = 0; row < numFleetYears; row++)
      {
        _ = fallbackTable.Rows.Add();
      }
      _ = Extensions.FillDBNullCellsWithZero(fallbackTable);

      return fallbackTable;
    }



    public virtual bool ValidateStochasticParameter(int numAges)
    {
      if (radioParameterFromUser.Checked)
      {
        //check if Data Grid has Blank or Null Cells 
        if (controlStochasticParamAgeFromUser.StochasticAgeDataGridTableContainMissingData())
        {
          _ = MessageBox.Show(StochasticParameterLabel + " At Age Data Table has " + "blank or missing values.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }
        if (controlStochasticParamAgeFromUser.StochasticCVDataGridTableContainMissingData())
        {
          _ = MessageBox.Show(StochasticParameterLabel + " CV Data Table has" + "blank or missing values.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }

      }
      else
      {
        //If the Stochastic Table Data File Doesn't Exist
        if (!System.IO.File.Exists(StochasticDataFile))
        {
          _ = MessageBox.Show(StochasticParameterLabel + " stochastic table file does not exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }

      }
      return true;
    }

    public virtual bool ValidateStochasticParameter(int numAges, double upperBounds)
    {
      if (ValidateStochasticParameter(numAges) == false)
      {
        return false;
      }

      //Get DataTables
      DataTable stochasticTableToCheckBounds;
      if (radioParameterFromUser.Checked)
      {
        stochasticTableToCheckBounds = StochasticAgeTable;
      }
      else
      {
        //Read in stochastic table file for validation.
        stochasticTableToCheckBounds =
            AgeproStochasticAgeTable.ReadStochasticTableFile(StochasticDataFile, numAges);
      }

      //Check if a cell/item has excceded the upper bound.     
      foreach (DataRow rowLines in stochasticTableToCheckBounds.Rows)
      {
        foreach (object item in rowLines.ItemArray)
        {
          if (Convert.ToDouble(item) > upperBounds)
          {
            _ = MessageBox.Show(StochasticParameterLabel + " at Age excceds the Upper Bound of " + upperBounds + Environment.NewLine + "Upper bounds limit for " + StochasticParameterLabel + " can be set in 'Misc. Options' panel.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
          }
        }
      }

      return true;
    }

  }
}
