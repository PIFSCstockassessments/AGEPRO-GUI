using System.ComponentModel;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlHarvestCalcRebuilder : UserControl
  {

    private readonly BindingList<RebuilderTargetType> typeList = new BindingList<RebuilderTargetType>();

    public ControlHarvestCalcRebuilder()
    {
      InitializeComponent();

      typeList.Add(new RebuilderTargetType { Index = 0, RebuilderTargetTypeName = "Spawning Stock Biomass" });
      typeList.Add(new RebuilderTargetType { Index = 1, RebuilderTargetTypeName = "JAN-1 Biomass " });
      typeList.Add(new RebuilderTargetType { Index = 2, RebuilderTargetTypeName = "Mid-Year Biomass" });

      comboBoxRebuilderTargetType.ValueMember = "index";
      comboBoxRebuilderTargetType.DisplayMember = "rebuilderTargetTypeName";
      comboBoxRebuilderTargetType.DataSource = typeList;

      //Rebuilder Defaults
      RebuilderTargetYear = "0";
      RebuilderBiomass = "0.0";
      RebuilderPercentConfidence = "0.0";
      RebuilderType = 0;

    }

    public string RebuilderTargetYear
    {
      get => textBoxRebuilderTargetYear.Text;
      set => textBoxRebuilderTargetYear.Text = value;
    }

    public string RebuilderBiomass
    {
      get => textBoxRebuilderTargetBiomass.Text;
      set => textBoxRebuilderTargetBiomass.Text = value;
    }
    public string RebuilderPercentConfidence
    {
      get => textBoxRebuilderTargetPercent.Text;
      set => textBoxRebuilderTargetPercent.Text = value;
    }
    public int RebuilderType
    {
      get => comboBoxRebuilderTargetType.SelectedIndex;
      set => comboBoxRebuilderTargetType.SelectedIndex = value;
    }

    public void SetHarvestCalcRebuilderControls
        (CoreLib.RebuilderTargetCalculation rebuilderTarget, Panel panelHarvestCalcParam)
    {
      //Clear Previous Data Bindings
      textBoxRebuilderTargetYear.DataBindings.Clear();
      textBoxRebuilderTargetBiomass.DataBindings.Clear();
      textBoxRebuilderTargetPercent.DataBindings.Clear();
      comboBoxRebuilderTargetType.DataBindings.Clear();
      //Set Data Bindings 
      _ = textBoxRebuilderTargetYear.DataBindings.Add("text", rebuilderTarget, "targetYear", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxRebuilderTargetBiomass.DataBindings.Add("text", rebuilderTarget, "targetValue", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = textBoxRebuilderTargetPercent.DataBindings.Add("text", rebuilderTarget, "targetPercent", true, DataSourceUpdateMode.OnPropertyChanged);
      _ = comboBoxRebuilderTargetType.DataBindings.Add("SelectedIndex", rebuilderTarget, "targetType", true, DataSourceUpdateMode.OnPropertyChanged);

      panelHarvestCalcParam.Controls.Clear();
      Dock = DockStyle.Fill;
      panelHarvestCalcParam.Controls.Add(this);
    }

  }
}
