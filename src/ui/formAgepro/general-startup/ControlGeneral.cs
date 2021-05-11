using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{

  public partial class ControlGeneral : UserControl
  {
    public event EventHandler SetGeneral;
    private readonly int MaxRandomSeed;
    public int MaxRecruitModels { get; set; }

    public string GeneralModelId
    {
      get => textBoxModelID.Text;
      set => textBoxModelID.Text = value;
    }
    public string GeneralInputFile
    {
      get => textBoxInputFile.Text;
      set => textBoxInputFile.Text = value;
    }
    public string GeneralFirstYearProjection
    {
      get => textBoxFirstYearProjection.Text;
      set => textBoxFirstYearProjection.Text = value;
    }
    public string GeneralLastYearProjection
    {
      get => textBoxLastYearProjection.Text;
      set => textBoxLastYearProjection.Text = value;
    }
    public int GeneralFirstAgeClass
    {
      get => Convert.ToInt32(spinBoxFirstAge.Value);
      set => spinBoxFirstAge.Value = value;
    }
    public int GeneralLastAgeClass
    {
      get => Convert.ToInt32(textBoxLastAge.Text);
      set => textBoxLastAge.Text = value.ToString();
    }
    public string GeneralNumberFleets
    {
      get => textBoxNumFleets.Text;
      set => textBoxNumFleets.Text = value;
    }
    public string GeneralNumberRecruitModels
    {
      get => textBoxNumRecruitModels.Text;
      set => textBoxNumRecruitModels.Text = value;
    }
    public string GeneralNumberPopulationSimuations
    {
      get => textBoxNumPopSim.Text;
      set => textBoxNumPopSim.Text = value;
    }
    public string GeneralRandomSeed
    {
      get => textBoxRandomSeed.Text;
      set => textBoxRandomSeed.Text = value;
    }
    public bool GeneralDiscardsPresent
    {
      get => checkBoxDiscards.Checked;
      set => checkBoxDiscards.Checked = value;
    }

    public ControlGeneral()
    {
      InitializeComponent();

      //Set max constant
      MaxRandomSeed = 2147483647;

      //Set Max Constants
      MaxRecruitModels = 21;

    }

    /// <summary>
    /// 
    /// </summary>
    public void ValidateGeneralOptionsParameters()
    {

      Dictionary<string, string> generalOptionsList = new Dictionary<string, string> {
        {"First Year Of Projection", textBoxFirstYearProjection.Text},
        {"Last Year Of Projection", textBoxLastYearProjection.Text},
        {"First Age Class", spinBoxFirstAge.Value.ToString()},
        {"Last Age Class", textBoxLastAge.Text},
        {"Number Of Fleets", textBoxNumFleets.Text},
        {"Number Of Recruitment Models", textBoxNumRecruitModels.Text},
        {"Number Of Population Simulations", textBoxNumPopSim.Text},
        {"Random Number Seed", textBoxRandomSeed.Text}
      };

      //Check If Each General Param Controls (1) has a value and (2) that value is a whole (integer) number.
      foreach (KeyValuePair<string, string> param in generalOptionsList)
      {
        if (param.Value == "")
        {
          throw new InvalidAgeproGuiParameterException($"{param.Key} value must be specfied.");
        }
        if (IsNumeric(param.Value) == false)
        {
          throw new InvalidAgeproGuiParameterException($"In {param.Key}: '{param.Value}' is not a whole number");
        }

      }

      //First Age Class: In case the spinBox(UpDownNumeric) control didn't catch the invalid value, catch it here.   
      if (spinBoxFirstAge.Value > 1 || spinBoxFirstAge.Value < 0)
      {
        throw new InvalidAgeproGuiParameterException("Invaild First Age Class Value: Should only be 0 or 1");
      }

      if (Math.Abs(Convert.ToInt32(textBoxRandomSeed.Text)) > MaxRandomSeed)
      {
        throw new InvalidAgeproGuiParameterException(
          $"Random Number Seed {textBoxRandomSeed.Text}{Environment.NewLine}Exceeds limit of {MaxRandomSeed} or -{MaxRandomSeed}");
      }


      //Use general options parameters to set inputFile parameters 
      int generalNumAges = NumAges();
      int generalNumYears = Convert.ToInt32(GeneralLastYearProjection) -
          Convert.ToInt32(GeneralFirstYearProjection) + 1;

      //Validate Number of Ages and Years
      if (generalNumAges < 1)
      {
        string exMessage = "Invaild Age Range - Is Last Age Class less than First Age Class?";
        throw new InvalidAgeproGuiParameterException(exMessage);
      }
      if (generalNumYears < 1)
      {
        string exMessage = "Invaild Year Range - Is Last Year Of Projection Earlier than First Year?";
        throw new InvalidAgeproGuiParameterException(exMessage);
      }

      if (Convert.ToInt32(GeneralNumberRecruitModels) > MaxRecruitModels)
      {
        string exMessage = $"Number of Recruitment Models exceed limit of {MaxRecruitModels}.";
        throw new InvalidAgeproGuiParameterException(exMessage);
      }

    }


    private bool IsNumeric(string s)
    {
      return int.TryParse(s, out _);
    }

    private void ButtonSetGeneral_Click(object sender, EventArgs e)
    {
      //Transfer general option values to input file class
      //Null check to make sure main page attached to event; if not null, invoke.
      SetGeneral?.Invoke(sender, e);

    }

    /// <summary>
    /// Returns a sequence of years from First year of projection
    /// </summary>
    /// <returns>Returns a enuumerable string array from <paramref name="textBoxFirstYearProjection"/> 
    /// to <paramref name="textBoxLastYearProjection"/></returns>
    public string[] SeqYears()
    {
      int numYears = Math.Abs(Convert.ToInt32(textBoxLastYearProjection.Text) -
          Convert.ToInt32(textBoxFirstYearProjection.Text)) + 1;
      int[] enumYearArray = Enumerable.Range(Convert.ToInt32(textBoxFirstYearProjection.Text), numYears).ToArray();

      return Array.ConvertAll(enumYearArray, element => element.ToString());
    }

    /// <summary>
    /// Returns number of Ages in between <paramref name="spinBoxFirstAgeClass"/> and 
    /// <paramref name="textBoxLastAgeClass"/>
    /// </summary>
    /// <returns>Integer</returns>
    public int NumAges()
    {
      return (GeneralLastAgeClass - GeneralFirstAgeClass + 1);
    }

  }
}
