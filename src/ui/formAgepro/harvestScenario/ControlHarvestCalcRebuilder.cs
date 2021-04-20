using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlHarvestCalcRebuilder : UserControl
  {

    private readonly BindingList<RebuilderTargetType> typeList = new BindingList<RebuilderTargetType>();

    public ControlHarvestCalcRebuilder()
    {
      InitializeComponent();

      typeList.Add(new RebuilderTargetType { index = 0, rebuilderTargetTypeName = "Spawning Stock Biomass" });
      typeList.Add(new RebuilderTargetType { index = 1, rebuilderTargetTypeName = "JAN-1 Biomass " });
      typeList.Add(new RebuilderTargetType { index = 2, rebuilderTargetTypeName = "Mid-Year Biomass" });

      comboBoxRebuilderTargetType.ValueMember = "index";
      comboBoxRebuilderTargetType.DisplayMember = "rebuilderTargetTypeName";
      comboBoxRebuilderTargetType.DataSource = typeList;

    }

    public string rebuilderTargetYear
    {
      get { return textBoxRebuilderTargetYear.Text; }
      set { textBoxRebuilderTargetYear.Text = value; }
    }

    public string rebuilderBiomass
    {
      get { return textBoxRebuilderTargetBiomass.Text; }
      set { textBoxRebuilderTargetBiomass.Text = value; }
    }
    public string rebuilderPercentConfidence
    {
      get { return textBoxRebuilderTargetPercent.Text; }
      set { textBoxRebuilderTargetPercent.Text = value; }
    }
    public int rebuilderType
    {
      get { return comboBoxRebuilderTargetType.SelectedIndex; }
      set { comboBoxRebuilderTargetType.SelectedIndex = value; }
    }

    public void SetHarvestCalcRebuilderControls
        (Nmfs.Agepro.CoreLib.RebuilderTargetCalculation rebuilderTarget, Panel panelHarvestCalcParam)
    {
      //Clear Previous Data Bindings
      this.textBoxRebuilderTargetYear.DataBindings.Clear();
      this.textBoxRebuilderTargetBiomass.DataBindings.Clear();
      this.textBoxRebuilderTargetPercent.DataBindings.Clear();
      this.comboBoxRebuilderTargetType.DataBindings.Clear();
      //Set Data Bindings 
      this.textBoxRebuilderTargetYear.DataBindings.Add("text", rebuilderTarget, "targetYear", true, DataSourceUpdateMode.OnPropertyChanged);
      this.textBoxRebuilderTargetBiomass.DataBindings.Add("text", rebuilderTarget, "targetValue", true, DataSourceUpdateMode.OnPropertyChanged);
      this.textBoxRebuilderTargetPercent.DataBindings.Add("text", rebuilderTarget, "targetPercent", true, DataSourceUpdateMode.OnPropertyChanged);
      this.comboBoxRebuilderTargetType.DataBindings.Add("SelectedIndex", rebuilderTarget, "targetType", true, DataSourceUpdateMode.OnPropertyChanged);

      panelHarvestCalcParam.Controls.Clear();
      this.Dock = DockStyle.Fill;
      panelHarvestCalcParam.Controls.Add(this);
    }

  }
}
