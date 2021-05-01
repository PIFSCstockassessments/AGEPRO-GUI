using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{

  public partial class ControlStochasticWeightAge : ControlStochasticAge
  {
    public int IndexWeightOption { get; set; }
    public StochasticWeightOfAge WeightAgeType { get; set; }
    public RadioButton RadioWeightsFromCatch { get; set; }
    public RadioButton RadioWeightsFromMidYear { get; set; }
    public RadioButton RadioWeightsFromSSB { get; set; }
    public RadioButton RadioWeightsFromJan1 { get; set; }
    public int[] ValidWeightAgeOpt { get; set; }
    public Dictionary<int, RadioButton> WeightOptionDictionary { get; set; }

    public bool ShowJan1WeightsOption
    {
      get => RadioWeightsFromJan1.Visible;
      set => RadioWeightsFromJan1.Visible = value;
    }
    public bool ShowSSBWeightsOption
    {
      get => RadioWeightsFromSSB.Visible;
      set => RadioWeightsFromSSB.Visible = value;
    }
    public bool showMidYearWeightsOption
    {
      get => RadioWeightsFromMidYear.Visible;
      set => RadioWeightsFromMidYear.Visible = value;
    }
    public bool ShowCatchWeightsOption
    {
      get => RadioWeightsFromCatch.Visible;
      set => RadioWeightsFromCatch.Visible = value;
    }

    public ControlStochasticWeightAge(int[] weightAgeOptions)
    {
      InitializeComponent();

      StochasticParameterLabel = "Weights";
      ValidWeightAgeOpt = weightAgeOptions;

      //Add Controls to Layout Programmically 
      SuspendLayout();
      tableLayoutStochasticAgePanel.RowStyles[1].SizeType = SizeType.Percent;
      tableLayoutStochasticAgePanel.RowStyles[1].Height = 19;
      tableLayoutStochasticAgePanel.RowStyles[2].SizeType = SizeType.Percent;
      tableLayoutStochasticAgePanel.RowStyles[2].Height = 81;

      RadioWeightsFromJan1 = new RadioButton();
      RadioWeightsFromSSB = new RadioButton();
      RadioWeightsFromMidYear = new RadioButton();
      RadioWeightsFromCatch = new RadioButton();

      groupOptions.Size = new Size(733, 89);

      // 
      // radioWeightsFromJan1
      // 
      RadioWeightsFromJan1.AutoSize = true;
      RadioWeightsFromJan1.Location = new Point(25, 44);
      RadioWeightsFromJan1.Name = "radioWeightsFromJan1";
      RadioWeightsFromJan1.Size = new Size(154, 17);
      RadioWeightsFromJan1.TabIndex = 2;
      RadioWeightsFromJan1.TabStop = true;
      RadioWeightsFromJan1.Text = "Use JAN-1 Weights At Age";
      RadioWeightsFromJan1.UseVisualStyleBackColor = true;
      RadioWeightsFromJan1.CheckedChanged += new EventHandler(RadioWeightsFromJan1_CheckedChanged);
      // 
      // radioWeightsFromSSB
      // 
      RadioWeightsFromSSB.AutoSize = true;
      RadioWeightsFromSSB.Location = new Point(301, 44);
      RadioWeightsFromSSB.Name = "radioWeightsFromSSB";
      RadioWeightsFromSSB.Size = new Size(146, 17);
      RadioWeightsFromSSB.TabIndex = 3;
      RadioWeightsFromSSB.TabStop = true;
      RadioWeightsFromSSB.Text = "Use SSB Weights At Age";
      RadioWeightsFromSSB.UseVisualStyleBackColor = true;
      RadioWeightsFromSSB.CheckedChanged += new EventHandler(RadioWeightsFromSSB_CheckedChanged);
      // 
      // radioWeightsFromMidYear
      // 
      RadioWeightsFromMidYear.AutoSize = true;
      RadioWeightsFromMidYear.Location = new Point(25, 68);
      RadioWeightsFromMidYear.Name = "radioWeightsFromMidYear";
      RadioWeightsFromMidYear.Size = new Size(166, 17);
      RadioWeightsFromMidYear.TabIndex = 4;
      RadioWeightsFromMidYear.TabStop = true;
      RadioWeightsFromMidYear.Text = "Use Mid-Year Weights At Age";
      RadioWeightsFromMidYear.UseVisualStyleBackColor = true;
      RadioWeightsFromMidYear.CheckedChanged += new EventHandler(RadioWeightsFromMidYear_CheckedChanged);
      // 
      // radioWeightsFromCatch
      // 
      RadioWeightsFromCatch.AutoSize = true;
      RadioWeightsFromCatch.Location = new Point(301, 68);
      RadioWeightsFromCatch.Name = "radioWeightsFromCatch";
      RadioWeightsFromCatch.Size = new Size(152, 17);
      RadioWeightsFromCatch.TabIndex = 5;
      RadioWeightsFromCatch.TabStop = true;
      RadioWeightsFromCatch.Text = "Use Catch Weights At Age";
      RadioWeightsFromCatch.UseVisualStyleBackColor = true;
      RadioWeightsFromCatch.CheckedChanged += new EventHandler(RadioWeightsFromCatch_CheckedChanged);


      //Add to optionsGroupBox
      groupOptions.Controls.Add(RadioWeightsFromJan1);
      groupOptions.Controls.Add(RadioWeightsFromSSB);
      groupOptions.Controls.Add(RadioWeightsFromMidYear);
      groupOptions.Controls.Add(RadioWeightsFromCatch);

      ResumeLayout();

      WeightOptionDictionary = new Dictionary<int, RadioButton>
      {
        { 0, radioParameterFromUser },
        { 1, radioParameterFromFile },
        { -1, RadioWeightsFromJan1 },
        { -2, RadioWeightsFromSSB },
        { -3, RadioWeightsFromMidYear },
        { -4, RadioWeightsFromCatch }
      };
    }

    protected override void OnLoad(EventArgs e)
    {
      if (WeightOptionDictionary.ContainsKey(IndexWeightOption))
      {
        WeightOptionDictionary[IndexWeightOption].Checked = true;
      }

      base.OnLoad(e);
    }

    protected override void RadioParameterFromUser_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = 0;
      base.RadioParameterFromUser_CheckedChanged(sender, e);
    }

    protected override void RadioParameterFromFile_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = 1;
      base.RadioParameterFromFile_CheckedChanged(sender, e);
    }

    private void RadioWeightsFromJan1_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = -1;
      panelStochasticParameterAge.Controls.Clear();
    }

    private void RadioWeightsFromSSB_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = -2;
      panelStochasticParameterAge.Controls.Clear();
    }

    private void RadioWeightsFromMidYear_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = -3;
      panelStochasticParameterAge.Controls.Clear();
    }

    private void RadioWeightsFromCatch_CheckedChanged(object sender, EventArgs e)
    {
      IndexWeightOption = -4;
      panelStochasticParameterAge.Controls.Clear();
    }

    /// <summary>
    /// Bind Stochastic Data Object data to interface values. Other (negative) weight age 
    /// </summary>
    /// <param name="inp"></param>
    public override void BindStochasticAgeData(AgeproStochasticAgeTable inp)
    {
      if (inp is null)
      {
        throw new ArgumentNullException(nameof(inp));
      }

      AgeproWeightAgeTable inpWeight = inp as AgeproWeightAgeTable;
      inpWeight.weightOpt = IndexWeightOption;
      inpWeight.validOpt = ValidWeightAgeOpt;

      if (!ValidWeightAgeOpt.Contains(IndexWeightOption))
      {
        throw new InvalidAgeproGuiParameterException("Invalid weight of at Age option.");
      }

      if (IndexWeightOption == 0)
      {
        inpWeight.FromFile = false;
        inpWeight.TimeVarying = TimeVarying;
        inpWeight.ByAgeData = StochasticAgeTable;
        inpWeight.ByAgeCV = StochasticCV;

      }
      else if (IndexWeightOption == 1)
      {
        inpWeight.FromFile = true;
        inpWeight.TimeVarying = TimeVarying;
        inpWeight.ByAgeData.Clear();
        inpWeight.ByAgeCV.Clear();
      }


    }

    /// <summary>
    /// Generalized method to load Stochastic Weight of Age Parameters from AGEPRO Input Data Files.
    /// </summary>
    /// <param name="inp">AGEPRO InputFile Weight of Age Onject</param>
    /// <param name="generalOpt">AGEPRO InputFile General Options</param>
    public void LoadStochasticWeightAgeInputData(AgeproWeightAgeTable inp, AgeproGeneral generalOpt)
    {

      IndexWeightOption = inp.weightOpt;
      //Call StochasticAgeInputData 
      LoadStochasticAgeInputData(inp, generalOpt);


      //For Discard weight, if "Discards are Present" is not selected, exit the function
      //(to prevent fallback data table to be generated.)
      if (WeightAgeType == StochasticWeightOfAge.DiscardWeight && generalOpt.HasDiscards == false)
      {
        return;
      }

      //Check for Valid Weight Ooption
      if (!ValidWeightAgeOpt.Contains(IndexWeightOption))
      {
        _ = MessageBox.Show("Invalid weight of at Age option.",
            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      //Create a empty DataTable (& CV table) if input file DataTable is Null 
      if (StochasticAgeTable == null)
      {
        CreateStochasticParameterFallbackDataTable(inp, generalOpt, FleetDependency);
        EnableTimeVaryingCheckBox = true;
      }
    }




    public override bool ValidateStochasticParameter(int numAges, double upperBounds)
    {
      //if (weightOptionDictionary.ContainsKey(indexWeightOption))
      if (!ValidWeightAgeOpt.Contains(IndexWeightOption))
      {
        _ = MessageBox.Show("Invalid weight of at Age option.",
            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
     
      if (IndexWeightOption == 0 || IndexWeightOption == 1)
      {
        return base.ValidateStochasticParameter(numAges, upperBounds);
      }

      //Valid "Use Stochastic weight age"
      return true;
    }


  }
}
