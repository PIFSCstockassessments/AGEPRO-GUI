using System;
using System.Data;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlHarvestScenario : UserControl
  {
    public string[] SeqYears { get; set; }
    public RebuilderTargetCalculation Rebuilder { get; set; }
    public PStarCalculation PStar { get; set; }
    public HarvestScenarioAnalysis CalcType { get; set; }
    public ControlHarvestCalcPStar ControlHarvestPStar { get; set; }
    public ControlHarvestCalcRebuilder ControlHarvestRebuilder { get; set; }
    public DataGridViewComboBoxColumn ColumnHarvestSpecification { get; set; }

    public ControlHarvestScenario()
    {
      InitializeComponent();
      ControlHarvestRebuilder = new ControlHarvestCalcRebuilder();
      ControlHarvestPStar = new ControlHarvestCalcPStar();
      CalcType = HarvestScenarioAnalysis.HarvestScenario;
      Rebuilder = new RebuilderTargetCalculation();
      PStar = new PStarCalculation();
      SeqYears = new string[1] { "1" };

    }

    public DataTable HarvestScenarioTable
    {
      get => (DataTable)dataGridHarvestScenarioTable.DataSource;
      set => dataGridHarvestScenarioTable.DataSource = value;
    }




    /// <summary>
    /// Action that When the 'None' radio buttion is selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RadioNone_CheckedChanged(object sender, EventArgs e)
    {
      panelAltCalcParameters.Controls.Clear();
      CalcType = HarvestScenarioAnalysis.HarvestScenario;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RadioPStar_CheckedChanged(object sender, EventArgs e)
    {
      if (!(sender is RadioButton rb))
      {
        return;
      }
      if (rb.Checked)
      {
        if (PStar == null)
        {
          //Create new instance of PStar with AGEPRO Model's Observed Years
          PStar = new PStarCalculation
          {
            ObsYears = Array.ConvertAll(SeqYears, int.Parse)
          };
        }
        CalcType = HarvestScenarioAnalysis.PStar;
        ControlHarvestPStar.SetHarvestCalcPStarControls(PStar, panelAltCalcParameters);
      }

    }
    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RadioRebuilderTarget_CheckedChanged(object sender, EventArgs e)
    {
      if (!(sender is RadioButton rb))
      {
        return;
      }
      if (rb.Checked)
      {
        if (Rebuilder == null)
        {
          //Create new instance of Rebuilder with AGEPRO Model's Observed Years
          Rebuilder = new RebuilderTargetCalculation
          {
            ObsYears = Array.ConvertAll(SeqYears, int.Parse)
          };
        }
        CalcType = HarvestScenarioAnalysis.Rebuilder;
        ControlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, panelAltCalcParameters);
      }
      
    }

    public void SetHarvestSpecificationColumn()
    {

      ColumnHarvestSpecification = new DataGridViewComboBoxColumn
      {
        HeaderText = "Harvest Specfication",
        //'DataPropertyName' references harvest spec column in input data's Harvest Scenario DataTable 
        DataPropertyName = "Harvest Spec",
        Width = 100,
        //Get Data Source from List<HarvestSpecification> Class
        DataSource = HarvestSpecification.GetHarvestSpec(),
        //Do not need 'ValueMember', because 'DataPropertyNameInstead' is referenced 
        DisplayMember = "HarvestScenario"
      };
      _ = dataGridHarvestScenarioTable.Columns.Add(ColumnHarvestSpecification);
      dataGridHarvestScenarioTable.RowHeadersWidth = 70;


    }

    /// <summary>
    /// Sets up the Harvest Scenario Data Grid View Table, including the Harvest Specification combo box
    /// column.
    /// </summary>
    /// <param name="inpFileTable">Harvest Scenario Data Table Source</param>
    public void SetHarvestScenarioInputDataTable(DataTable inpFileTable)
    {
      if (HarvestScenarioTable != null)
      {
        HarvestScenarioTable.Reset();
      }
      SetHarvestSpecificationColumn();

      HarvestScenarioTable = inpFileTable;
    }


    /// <summary>
    /// Sets Harvest Calculation option from when setting user specifed General Options or loading a 
    /// existing AGEPRO input file. 
    /// </summary>
    /// <param name="inputData"></param>
    public void SetHarvestScenarioCalcControls(AgeproInputFile inpData)
    {
      CalcType = inpData.HarvestScenario.AnalysisType;

      //SetHarvestCalculationRadioButtonOption
      if (CalcType == HarvestScenarioAnalysis.HarvestScenario)
      {
        radioNone.Checked = true;
      }
      else if (CalcType == HarvestScenarioAnalysis.PStar)
      {
        //Create Defaluts if Pstar is null
        if (PStar == null)
        {
          //CreateNewPStarSpecs(inpData.General.SeqYears());
          PStar = new PStarCalculation
          {
            //Retain Input Data's Observed Years 
            ObsYears = inpData.General.SeqYears()
          };
        }
        else
        {
          PStar = inpData.PStar;
          radioPStar.Checked = true;
        }

        ControlHarvestPStar.SetHarvestCalcPStarControls(PStar, panelAltCalcParameters);
      }
      else if (CalcType == HarvestScenarioAnalysis.Rebuilder)
      {
        //If Rebuilder has no data, create an empty/default set. 
        if (Rebuilder == null)
        {
          //Retain Input Data's Observed Years
          Rebuilder = new RebuilderTargetCalculation
          {
            ObsYears = inpData.General.SeqYears()
          };
        }
        else
        {
          Rebuilder = inpData.Rebuild;
          radioRebuilderTarget.Checked = true;
          Rebuilder.ObsYears = Array.ConvertAll(SeqYears, int.Parse);
        }

        ControlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, panelAltCalcParameters);
      }
    }

    /// <summary>
    /// Data Validation. 
    /// </summary>
    /// <returns></returns>
    public bool ValidateHarvestScenario(int[] ObsYears)
    {
      if (dataGridHarvestScenarioTable.HasBlankOrNullCells())
      {
        _ = MessageBox.Show("Harvest Scenario Data Table has blank or missing values.", "Harvest Scenario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }

      if (radioRebuilderTarget.Checked)
      {
        Rebuilder.ObsYears = ObsYears;
        ValidationResult rebuilderCheck = Rebuilder.ValidationCheck();

        if (rebuilderCheck.IsValid == false)
        {
          _ = MessageBox.Show("Invalid Rebuilder target parameters: "
                              + Environment.NewLine
                              + rebuilderCheck.Message, "Rebuilder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return false;
        }

      }
      else if (radioPStar.Checked)
      {
        PStar.ObsYears = ObsYears;
        ValidationResult pstarCheck = PStar.ValidationCheck();
        if (pstarCheck.IsValid == false)
        {
          _ = MessageBox.Show("Invalid P-Star parameters: "
                              + Environment.NewLine
                              + pstarCheck.Message, "PStar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return false;
        }
        //Check Harvest Scenario Table to see Harvest Specification is "REMOVALS" on 
        //the target year.
        int indexTargetYr = Array.IndexOf(SeqYears, PStar.TargetYear.ToString());
        if (HarvestScenarioTable.Rows[indexTargetYr][0].Equals("REMOVALS") == false)
        {
          _ = MessageBox.Show("Invalid Harvest Scenario Specification for P-Star Target Year "
                              + PStar.TargetYear
                              + ".", "PStar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return false;
        }

      }// Passed Harvest Scenario/Pstar/Rebuilder validations
      return true;
    }

    /// <summary>
    /// Cell Formmetting event event used to customise Harvest Scnario Data Grid View Headers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataGridHarvestScenarioTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridHarvestScenarioTable.Rows[e.RowIndex].HeaderCell;

      if (header.Value == null)
      {
        //set HarvestScenarioTable RowHeaders
        int iyear = 0;
        foreach (DataGridViewRow yearRow in dataGridHarvestScenarioTable.Rows)
        {
          yearRow.HeaderCell.Value = SeqYears[iyear];
          iyear++;
        }

      }
    }



  }
}
