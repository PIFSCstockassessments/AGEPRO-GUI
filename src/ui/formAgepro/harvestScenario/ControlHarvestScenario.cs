using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlHarvestScenario : UserControl
  {
    private DataGridViewComboBoxColumn columnHarvestSpecification;
    private ControlHarvestCalcRebuilder controlHarvestRebuilder;
    private ControlHarvestCalcPStar controlHarvestPStar;
    public string[] seqYears { get; set; }
    public Nmfs.Agepro.CoreLib.RebuilderTargetCalculation Rebuilder { get; set; }
    public Nmfs.Agepro.CoreLib.PStarCalculation PStar { get; set; }
    public Nmfs.Agepro.CoreLib.HarvestScenarioAnalysis calcType { get; set; }

    public ControlHarvestScenario()
    {
      InitializeComponent();
      controlHarvestRebuilder = new ControlHarvestCalcRebuilder();
      controlHarvestPStar = new ControlHarvestCalcPStar();
      this.calcType = HarvestScenarioAnalysis.HarvestScenario;
      this.Rebuilder = new Nmfs.Agepro.CoreLib.RebuilderTargetCalculation();
      this.PStar = new Nmfs.Agepro.CoreLib.PStarCalculation();
      this.seqYears = new string[1] { "1" };

      //PStar Defaults
      this.controlHarvestPStar.PstarLevels = 1;
      this.controlHarvestPStar.TargetYear = "0";
      this.controlHarvestPStar.OverfishingF = "0.0";
      //Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(this.controlHarvestPStar.pstarLevelsTable);

      //Rebuilder Defaults
      this.controlHarvestRebuilder.RebuilderTargetYear = "0";
      this.controlHarvestRebuilder.RebuilderBiomass = "0.0";
      this.controlHarvestRebuilder.RebuilderPercentConfidence = "0.0";
      this.controlHarvestRebuilder.RebuilderType = 0;
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
      this.calcType = HarvestScenarioAnalysis.HarvestScenario;
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
            PStar.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
            //Create PStar Table
            PStar.PStarTable = PStar.CreateNewPStarTable();
            PStar.PStarTable.Rows.Add();
            Nmfs.Agepro.CoreLib.Extensions.FillDBNullCellsWithZero(PStar.PStarTable);
          }
          this.calcType = HarvestScenarioAnalysis.PStar;
          controlHarvestPStar.SetHarvestCalcPStarControls(this.PStar, this.panelAltCalcParameters);
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
          if (this.Rebuilder == null)
          {
            Rebuilder = new RebuilderTargetCalculation();
            Rebuilder.TargetYear = 0;
            Rebuilder.TargetValue = 0;
            Rebuilder.TargetType = 0;
            Rebuilder.TargetPercent = 0;
            Rebuilder.obsYears = Array.ConvertAll(this.seqYears, int.Parse);
          }
          this.calcType = HarvestScenarioAnalysis.Rebuilder;
          controlHarvestRebuilder.SetHarvestCalcRebuilderControls(this.Rebuilder, this.panelAltCalcParameters);
        }
      }
    }

    public void SetHarvestSpecificationColumn()
    {

      columnHarvestSpecification = new DataGridViewComboBoxColumn();
      columnHarvestSpecification.HeaderText = "Harvest Specfication";
      //'DataPropertyName' references harvest spec column in input data's Harvest Scenario DataTable 
      columnHarvestSpecification.DataPropertyName = "Harvest Spec";
      columnHarvestSpecification.Width = 100;
      //Get Data Source from List<HarvestSpecification> Class
      columnHarvestSpecification.DataSource = HarvestSpecification.GetHarvestSpec();
      //Do not need 'ValueMember', because 'DataPropertyNameInstead' is referenced 
      columnHarvestSpecification.DisplayMember = "HarvestScenario";
      dataGridHarvestScenarioTable.Columns.Add(columnHarvestSpecification);
      dataGridHarvestScenarioTable.RowHeadersWidth = 70;


    }

    /// <summary>
    /// Sets up the Harvest Scenario Data Grid View Table, including the Harvest Specification combo box
    /// column.
    /// </summary>
    /// <param name="inpFileTable">Harvest Scenario Data Table Source</param>
    public void SetHarvestScenarioInputDataTable(DataTable inpFileTable)
    {
      if (this.HarvestScenarioTable != null)
      {
        this.HarvestScenarioTable.Reset();
      }
      SetHarvestSpecificationColumn();

      this.HarvestScenarioTable = inpFileTable;
    }


    /// <summary>
    /// Sets Harvest Calculation option from when setting user specifed General Options or loading a 
    /// existing AGEPRO input file. 
    /// </summary>
    /// <param name="inputData"></param>
    public void SetHarvestScenarioCalcControls(Nmfs.Agepro.CoreLib.AgeproInputFile inpData)
    {
      this.calcType = inpData.HarvestScenario.AnalysisType;

      //Clean out any previous instances of pstar and/or rebuilder. 
      if (this.PStar != null)
      {
        PStar = null;
      }
      if (this.Rebuilder != null)
      {
        Rebuilder = null;
      }

      //SetHarvestCalculationRadioButtonOption
      if (calcType == HarvestScenarioAnalysis.HarvestScenario)
      {
        radioNone.Checked = true;
      }
      else if (calcType == HarvestScenarioAnalysis.PStar)
      {
        this.PStar = inpData.PStar;
        radioPStar.Checked = true;

        //Create Defaluts if Pstar is null
        if (PStar == null)
        {
          PStar = new PStarCalculation();
          this.PStar.obsYears = inpData.General.SeqYears();
        }

        controlHarvestPStar.SetHarvestCalcPStarControls(this.PStar, this.panelAltCalcParameters);
      }
      else if (calcType == HarvestScenarioAnalysis.Rebuilder)
      {
        this.Rebuilder = inpData.Rebuild;
        radioRebuilderTarget.Checked = true;
        this.Rebuilder.obsYears = Array.ConvertAll(this.seqYears, int.Parse);

        //If Rebuilder has no data, create an empty/default set. 
        if (this.Rebuilder == null)
        {
          this.Rebuilder = new RebuilderTargetCalculation();
          this.Rebuilder.obsYears = inpData.General.SeqYears();
        }

        controlHarvestRebuilder.SetHarvestCalcRebuilderControls(this.Rebuilder, this.panelAltCalcParameters);
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
      if (this.dataGridHarvestScenarioTable.HasBlankOrNullCells())
      {
        MessageBox.Show("Harvest Scenario Data Table has blank or missing values.",
            "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }

      if (this.radioRebuilderTarget.Checked == true)
      {
        bool validRebuilder = true;
        ValidationResult rebuilderCheck = this.Rebuilder.ValidationCheck();

        if (rebuilderCheck.IsValid == false)
        {
          MessageBox.Show("Invalid Rebuilder target parameters: " + Environment.NewLine +
              rebuilderCheck.Message, "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          validRebuilder = false;
        }

        return validRebuilder;
      }
      else if (this.radioPStar.Checked == true)
      {
        bool validPStar = true;
        ValidationResult pstarCheck = this.PStar.ValidationCheck();
        if (pstarCheck.IsValid == false)
        {
          MessageBox.Show("Invalid P-Star parameters: " + Environment.NewLine + pstarCheck.Message,
              "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          validPStar = false;
        }
        //Check Harvest Scenario Table to see Harvest Specification is "REMOVALS" on 
        //the target year.
        int indexTargetYr = Array.IndexOf(this.seqYears, this.PStar.TargetYear.ToString());
        if (this.HarvestScenarioTable.Rows[indexTargetYr][0].Equals("REMOVALS") == false)
        {
          MessageBox.Show("Invalid Harvest Scenario Specification for P-Star Target Year "
              + this.PStar.TargetYear + ".",
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
          yearRow.HeaderCell.Value = seqYears[iyear];
          iyear++;
        }

      }
    }



  }
}
