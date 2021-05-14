using System;
using System.Data;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlRecruitmentEmpiricalTwoStage : ControlRecruitmentEmpirical
  {

    public int Lv1NumObservations
    {
      get { return Convert.ToInt32(spinBoxLv1NumObservations.Value); }
      set { spinBoxLv1NumObservations.Value = value; }
    }
    public int Lv2NumObservations
    {
      get { return Convert.ToInt32(spinBoxLv2NumObservations.Value); }
      set { spinBoxLv2NumObservations.Value = value; }
    }

    public DataTable Lv1Observations
    {
      get { return (DataTable)dataGridLv1ObservationTable.DataSource; }
      set { dataGridLv1ObservationTable.DataSource = value; }
    }
    public DataTable Lv2Observations
    {
      get { return (DataTable)dataGridLv2ObservationTable.DataSource; }
      set { dataGridLv2ObservationTable.DataSource = value; }
    }

    private Label labelLv1NumObservations;
    private NumericUpDown spinBoxLv1NumObservations;
    private Label labelLv2NumObservations;
    private NumericUpDown spinBoxLv2NumObservations;
    private Label labelSSBBreakValue;
    private TextBox textBoxSSBBreakValue;
    private Label labelLv1ObservationTable;
    private Label labelLv2ObservationTable;
    private NftDataGridView dataGridLv1ObservationTable;
    private NftDataGridView dataGridLv2ObservationTable;


    public ControlRecruitmentEmpiricalTwoStage()
    {
      InitializeComponent();

      //Programmically Add Controls
      labelLv1NumObservations = new Label();
      spinBoxLv1NumObservations = new NumericUpDown();
      labelLv2NumObservations = new Label();
      spinBoxLv2NumObservations = new NumericUpDown();
      labelSSBBreakValue = new Label();
      textBoxSSBBreakValue = new TextBox();
      labelLv1ObservationTable = new Label();
      labelLv2ObservationTable = new Label();
      dataGridLv1ObservationTable = new NftDataGridView();
      dataGridLv2ObservationTable = new NftDataGridView();
      //this.groupEmpiricalParameters.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(spinBoxLv1NumObservations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(spinBoxLv2NumObservations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(dataGridLv1ObservationTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(dataGridLv2ObservationTable)).BeginInit();
      SuspendLayout();

      labelNumObservations.Visible = false;
      spinBoxNumObservations.Visible = false;
      dataGridRecruitTable.Visible = false;
      labelObservations.Visible = false;
      // 
      // labelLv1NumObservations
      // 
      labelLv1NumObservations.AutoSize = true;
      labelLv1NumObservations.Location = new System.Drawing.Point(18, 16);
      labelLv1NumObservations.Name = "labelLv1NumObservations";
      labelLv1NumObservations.Size = new System.Drawing.Size(123, 13);
      labelLv1NumObservations.TabIndex = 0;
      labelLv1NumObservations.Text = "Level 1 Number Of Observations";
      // 
      // spinBoxLv1NumObservations
      // 
      spinBoxLv1NumObservations.Location = new System.Drawing.Point(225, 14);
      spinBoxLv1NumObservations.Name = "spinBoxLv1NumObservations";
      spinBoxLv1NumObservations.Size = new System.Drawing.Size(120, 20);
      spinBoxLv1NumObservations.TabIndex = 1;
      spinBoxLv1NumObservations.Value = 0;
      // 
      // labelLv2NumObservations
      // 
      labelLv2NumObservations.AutoSize = true;
      labelLv2NumObservations.Location = new System.Drawing.Point(18, 43);
      labelLv2NumObservations.Name = "labelLv2NumObservations";
      labelLv2NumObservations.Size = new System.Drawing.Size(123, 13);
      labelLv2NumObservations.TabIndex = 2;
      labelLv2NumObservations.Text = "Level 2 Number Of Observations";
      // 
      // spinBoxLv2NumObservations
      // 
      spinBoxLv2NumObservations.Location = new System.Drawing.Point(225, 40);
      spinBoxLv2NumObservations.Name = "spinBoxLv1NumObservations";
      spinBoxLv2NumObservations.Size = new System.Drawing.Size(120, 20);
      spinBoxLv2NumObservations.TabIndex = 3;
      spinBoxLv2NumObservations.Value = 0;
      // 
      // labelSSBBreakValue
      // 
      labelSSBBreakValue.AutoSize = true;
      labelSSBBreakValue.Location = new System.Drawing.Point(18, 69);
      labelSSBBreakValue.Name = "labelSSBBreakValue";
      labelSSBBreakValue.Size = new System.Drawing.Size(89, 13);
      labelSSBBreakValue.TabIndex = 5;
      labelSSBBreakValue.Text = "SSB Break Value (MT)";
      // 
      // textBoxSSBBreakValue
      // 
      textBoxSSBBreakValue.Location = new System.Drawing.Point(225, 66);
      textBoxSSBBreakValue.Name = "textBoxSSBBreakValue";
      textBoxSSBBreakValue.Size = new System.Drawing.Size(120, 20);
      textBoxSSBBreakValue.TabIndex = 6;
      // 
      // labelLv1ObservationTable
      // 
      labelLv1ObservationTable.AutoSize = true;
      labelLv1ObservationTable.Location = new System.Drawing.Point(-3, 101);
      labelLv1ObservationTable.Name = "labelLv1Observations";
      labelLv1ObservationTable.Size = new System.Drawing.Size(69, 13);
      labelLv1ObservationTable.TabIndex = 8;
      labelLv1ObservationTable.Text = "Level 1 Observations";
      // 
      // dataGridLv1ObservationTable
      // 
      dataGridLv1ObservationTable.AllowUserToAddRows = false;
      dataGridLv1ObservationTable.AllowUserToDeleteRows = false;
      dataGridLv1ObservationTable.Anchor = ((AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
      | System.Windows.Forms.AnchorStyles.Left))));
      dataGridLv1ObservationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridLv1ObservationTable.Location = new System.Drawing.Point(0, 117);
      dataGridLv1ObservationTable.Name = "dataGridLv1Observations";
      dataGridLv1ObservationTable.Size = new System.Drawing.Size(328, 223);
      dataGridLv1ObservationTable.TabIndex = 8;
      dataGridLv1ObservationTable.RowHeadersWidth = 70;
      dataGridLv1ObservationTable.CellFormatting -= new DataGridViewCellFormattingEventHandler(dataGridLv1ObservationTable_CellFormatting);
      dataGridLv1ObservationTable.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridLv1ObservationTable_CellFormatting);
      // 
      // labelLv2ObservationTable
      // 
      labelLv2ObservationTable.AutoSize = true;
      labelLv2ObservationTable.Location = new System.Drawing.Point(447, 101);
      labelLv2ObservationTable.Name = "labelLv2Observations";
      labelLv2ObservationTable.Size = new System.Drawing.Size(69, 13);
      labelLv2ObservationTable.TabIndex = 9;
      labelLv2ObservationTable.Text = "Level 2 Observations";
      // 
      // dataGridLv2ObservationTable
      // 
      dataGridLv2ObservationTable.AllowUserToAddRows = false;
      dataGridLv2ObservationTable.AllowUserToDeleteRows = false;
      dataGridLv2ObservationTable.Anchor = ((AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
      | System.Windows.Forms.AnchorStyles.Left))));
      dataGridLv2ObservationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridLv2ObservationTable.Location = new System.Drawing.Point(450, 117);
      dataGridLv2ObservationTable.Name = "dataGridLv1Observations";
      dataGridLv2ObservationTable.Size = new System.Drawing.Size(328, 223);
      dataGridLv2ObservationTable.TabIndex = 9;
      dataGridLv2ObservationTable.RowHeadersWidth = 70;
      dataGridLv2ObservationTable.CellFormatting -= new DataGridViewCellFormattingEventHandler(dataGridLv2ObservationTable_CellFormatting);
      dataGridLv2ObservationTable.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridLv2ObservationTable_CellFormatting);


      buttonSetParameters.TabIndex = 7;
      groupEmpiricalParameters.Controls.Add(labelLv1NumObservations);
      groupEmpiricalParameters.Controls.Add(spinBoxLv1NumObservations);
      groupEmpiricalParameters.Controls.Add(labelLv2NumObservations);
      groupEmpiricalParameters.Controls.Add(spinBoxLv2NumObservations);
      groupEmpiricalParameters.Controls.Add(labelSSBBreakValue);
      groupEmpiricalParameters.Controls.Add(textBoxSSBBreakValue);
      groupEmpiricalParameters.Size = new System.Drawing.Size(574, 94);

      Controls.Add(labelLv1ObservationTable);
      Controls.Add(dataGridLv1ObservationTable);
      Controls.Add(labelLv2ObservationTable);
      Controls.Add(dataGridLv2ObservationTable);

      ((System.ComponentModel.ISupportInitialize)(spinBoxLv1NumObservations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(spinBoxLv2NumObservations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(dataGridLv1ObservationTable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(dataGridLv2ObservationTable)).EndInit();
      ResumeLayout(false);
      PerformLayout();

    }
  
    protected override void ButtonSetParameters_Click(object sender, EventArgs e)
    {
      try
      {
        int newNumLv1Obs = Convert.ToInt32(spinBoxLv1NumObservations.Value);
        int newNumLv2Obs = Convert.ToInt32(spinBoxLv2NumObservations.Value);

        if (newNumLv1Obs > MaxNumObservations)
        {
          throw new InvalidAgeproParameterException(
              "Number of Level 1 Observations exceed maximum limit of " + MaxNumObservations + ".");
        }
        if (newNumLv2Obs > MaxNumObservations)
        {
          throw new InvalidAgeproParameterException(
              "Number of Level 2 Observations exceed maximum limit of " + MaxNumObservations + ".");
        }

        Lv1Observations = ControlRecruitment.ResizeDataGridTable(Lv1Observations, newNumLv1Obs);
        Lv2Observations = ControlRecruitment.ResizeDataGridTable(Lv2Observations, newNumLv2Obs);

        ((EmpiricalTwoStageRecruitment)
            CollectionAgeproRecruitmentModels[CollectionSelectedIndex]).Lv1NumObs = newNumLv1Obs;
        ((EmpiricalTwoStageRecruitment)
            CollectionAgeproRecruitmentModels[CollectionSelectedIndex]).Lv2NumObs = newNumLv2Obs;
        ((EmpiricalTwoStageRecruitment)
            CollectionAgeproRecruitmentModels[CollectionSelectedIndex]).SSBBreakVal
            = Convert.ToInt32(textBoxSSBBreakValue.Text);
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show("Can not resize number of Observation(s)." + Environment.NewLine + ex.Message,
            "AGEPRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    public void SetTwoStageEmpiricalRecruitmentControls(EmpiricalTwoStageRecruitment currentRecruit,
        Panel panelRecruitModelParameter)
    {

      //Set Defaults for null Obs Values 
      if (currentRecruit.Lv1Obs == null)
      {
        currentRecruit.Lv1Obs = currentRecruit.SetNewObsTable(0);
      }
      if (currentRecruit.Lv2Obs == null)
      {
        currentRecruit.Lv2Obs = currentRecruit.SetNewObsTable(0);
      }

      //Load TwoStage Controls
      _ = spinBoxLv1NumObservations.DataBindings.Add("value", currentRecruit, "Lv1NumObs", true,
          DataSourceUpdateMode.OnPropertyChanged);
      _ = spinBoxLv2NumObservations.DataBindings.Add("value", currentRecruit, "Lv2NumObs", true,
          DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxSSBBreakValue.DataBindings.Add("text", currentRecruit, "SSBBreakVal", false,
          DataSourceUpdateMode.OnPropertyChanged, "");


      Lv1Observations = currentRecruit.Lv1Obs;
      Lv2Observations = currentRecruit.Lv2Obs;

      panelRecruitModelParameter.Controls.Clear();
      Dock = DockStyle.Fill;
      panelRecruitModelParameter.Controls.Add(this);
    }

    private void dataGridLv1ObservationTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridLv1ObservationTable.Rows[e.RowIndex].HeaderCell;
      if (header.Value == null)
      {
        SetEmpiricalRowHeadsers(dataGridLv1ObservationTable);
      }
    }

    private void dataGridLv2ObservationTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      DataGridViewRowHeaderCell header = dataGridLv2ObservationTable.Rows[e.RowIndex].HeaderCell;
      if (header.Value == null)
      {
        SetEmpiricalRowHeadsers(dataGridLv2ObservationTable);
      }
    }
  }
}
