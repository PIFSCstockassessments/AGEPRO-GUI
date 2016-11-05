using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
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

        public void SetHarvestCalcRebuilderControls
            (AGEPRO.CoreLib.RebuilderTargetCalculation rebuilderTarget, Panel panelHarvestCalcParam)
        {
            //Clear Previous Data Bindings
            this.textBoxRebuilderTargetYear.DataBindings.Clear();
            this.textBoxRebuilderTargetBiomass.DataBindings.Clear();
            this.textBoxRebuilderTargetPercent.DataBindings.Clear();
            this.comboBoxRebuilderTargetType.DataBindings.Clear();
            //Set Data Bindings 
            this.textBoxRebuilderTargetYear.DataBindings.Add("text", rebuilderTarget, "targetYear", true);
            this.textBoxRebuilderTargetBiomass.DataBindings.Add("text", rebuilderTarget, "targetValue", true);
            this.textBoxRebuilderTargetPercent.DataBindings.Add("text", rebuilderTarget, "targetPercent", true);
            this.comboBoxRebuilderTargetType.DataBindings.Add("ValueMember",rebuilderTarget,"targetType",true);

            panelHarvestCalcParam.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelHarvestCalcParam.Controls.Add(this);
        }

    }
}
