using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

      //PStar Defaults
      ControlHarvestPStar.PstarLevels = 1;
      ControlHarvestPStar.TargetYear = "0";
      ControlHarvestPStar.OverfishingF = "0.0";
      //Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(this.controlHarvestPStar.pstarLevelsTable);

      //Rebuilder Defaults
      ControlHarvestRebuilder.RebuilderTargetYear = "0";
      ControlHarvestRebuilder.RebuilderBiomass = "0.0";
      ControlHarvestRebuilder.RebuilderPercentConfidence = "0.0";
      ControlHarvestRebuilder.RebuilderType = 0;
    }

    public DataTable HarvestScenarioTable
    {
      get { return (DataTable)dataGridHarvestScenarioTable.DataSource; }
      set { dataGridHarvestScenarioTable.DataSource = value; }
    }




    /// <summary>
    /// Action that When the 'None' radio buttion is selected.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioNone_CheckedChanged(object sender, EventArgs e)
    {
      panelAltCalcParameters.Controls.Clear();
      CalcType = HarvestScenarioAnalysis.HarvestScenario;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioPStar_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton rb = sender as RadioButton;
      if (rb != null)
      {
        if (rb.Checked)
        {
          if (PStar == null)
          {
            PStar = new PStarCalculation();
            PStar.PStarLevels = 1;
            PStar.PStarF = 0;
            PStar.TargetYear = 0;
            PStar.obsYears = Array.ConvertAll(SeqYears, int.Parse);
            //Create PStar Table
            PStar.PStarTable = PStar.CreateNewPStarTable();
            PStar.PStarTable.Rows.Add();
            Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(PStar.PStarTable);
          }
          CalcType = HarvestScenarioAnalysis.PStar;
          ControlHarvestPStar.SetHarvestCalcPStarControls(PStar, panelAltCalcParameters);
        }
      }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void radioRebuilderTarget_CheckedChanged(object sender, EventArgs e)
    {
      RadioButton rb = sender as RadioButton;
      if (rb != null)
      {
        if (rb.Checked)
        {
          if (Rebuilder == null)
          {
            Rebuilder = new RebuilderTargetCalculation();
            Rebuilder.TargetYear = 0;
            Rebuilder.TargetValue = 0;
            Rebuilder.TargetType = 0;
            Rebuilder.TargetPercent = 0;
            Rebuilder.obsYears = Array.ConvertAll(SeqYears, int.Parse);
          }
          CalcType = HarvestScenarioAnalysis.Rebuilder;
          ControlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, panelAltCalcParameters);
        }
      }
    }

    public void SetHarvestSpecificationColumn()
    {

      ColumnHarvestSpecification = new DataGridViewComboBoxColumn();
      ColumnHarvestSpecification.HeaderText = "Harvest Specfication";
      //'DataPropertyName' references harvest spec column in input data's Harvest Scenario DataTable 
      ColumnHarvestSpecification.DataPropertyName = "Harvest Spec";
      ColumnHarvestSpecification.Width = 100;
      //Get Data Source from List<HarvestSpecification> Class
      ColumnHarvestSpecification.DataSource = HarvestSpecification.GetHarvestSpec();
      //Do not need 'ValueMember', because 'DataPropertyNameInstead' is referenced 
      ColumnHarvestSpecification.DisplayMember = "HarvestScenario";
      dataGridHarvestScenarioTable.Columns.Add(ColumnHarvestSpecification);
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

      //Clean out any previous instances of pstar and/or rebuilder. 
      if (PStar != null)
      {
        PStar = null;
      }
      if (Rebuilder != null)
      {
        Rebuilder = null;
      }

      //SetHarvestCalculationRadioButtonOption
      if (CalcType == HarvestScenarioAnalysis.HarvestScenario)
      {
        radioNone.Checked = true;
      }
      else if (CalcType == HarvestScenarioAnalysis.PStar)
      {
        PStar = inpData.PStar;
        radioPStar.Checked = true;

        //Create Defaluts if Pstar is null
        if (PStar == null)
        {
          PStar = new PStarCalculation();
          PStar.obsYears = inpData.General.SeqYears();
        }

        ControlHarvestPStar.SetHarvestCalcPStarControls(PStar, panelAltCalcParameters);
      }
      else if (CalcType == HarvestScenarioAnalysis.Rebuilder)
      {
        Rebuilder = inpData.Rebuild;
        radioRebuilderTarget.Checked = true;
        Rebuilder.obsYears = Array.ConvertAll(SeqYears, int.Parse);

        //If Rebuilder has no data, create an empty/default set. 
        if (Rebuilder == null)
        {
          Rebuilder = new RebuilderTargetCalculation();
          Rebuilder.obsYears = inpData.General.SeqYears();
        }

        ControlHarvestRebuilder.SetHarvestCalcRebuilderControls(Rebuilder, panelAltCalcParameters);
      }
    }

    /// <summary>
    /// Helper Method to emumerate invalidation errors messages .
    /// </summary>
    /// <param name="invalidRowList"></param>
    /// <returns></returns>
    private bool EnumerateInvalidRebuilderRangeRows(List<string> invalidRowList)
    {
      string overflowMsg = ".";
      if (invalidRowList != null && invalidRowList.Count > 50)
      {
        invalidRowList = invalidRowList.Take(50).ToList();
        overflowMsg = "... (First 50 shown).";
      }
      var results = invalidRowList.EnumerateValidationResults();

      if (results.IsValid == false)
      {
        string rowResults = results.Message.Replace(Environment.NewLine, ", ");


        MessageBox.Show("Invalid Harvest Specification for Rebuilder Range at row(s) "
            + rowResults + overflowMsg, "AGEPRO",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      return true;
    }

    /// <summary>
    /// Data Validation. 
    /// </summary>
    /// <returns></returns>
    public bool ValidateHarvestScenario()
    {
      if (dataGridHarvestScenarioTable.HasBlankOrNullCells())
      {
        MessageBox.Show("Harvest Scenario Data Table has blank or missing values.",
            "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }

      if (radioRebuilderTarget.Checked == true)
      {
        bool validRebuilder = true;
        ValidationResult rebuilderCheck = Rebuilder.ValidationCheck();

        if (rebuilderCheck.IsValid == false)
        {
          MessageBox.Show("Invalid Rebuilder target parameters: " + Environment.NewLine +
              rebuilderCheck.Message, "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          validRebuilder = false;
        }

        return validRebuilder;
      }
      else if (radioPStar.Checked == true)
      {
        bool validPStar = true;
        ValidationResult pstarCheck = PStar.ValidationCheck();
        if (pstarCheck.IsValid == false)
        {
          MessageBox.Show("Invalid P-Star parameters: " + Environment.NewLine + pstarCheck.Message,
              "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          validPStar = false;
        }
        //Check Harvest Scenario Table to see Harvest Specification is "REMOVALS" on 
        //the target year.
        int indexTargetYr = Array.IndexOf(SeqYears, PStar.TargetYear.ToString());
        if (HarvestScenarioTable.Rows[indexTargetYr][0].Equals("REMOVALS") == false)
        {
          MessageBox.Show("Invalid Harvest Scenario Specification for P-Star Target Year "
              + PStar.TargetYear + ".",
              "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          validPStar = false;
        }
        return validPStar;
      }


      return true;
    }

    /// <summary>
    /// Cell Formmetting event event used to customise Harvest Scnario Data Grid View Headers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dataGridHarvestScenarioTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridHarvestScenarioTable.Rows[e.RowIndex].HeaderCell;

      if (!(header.Value != null))
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
