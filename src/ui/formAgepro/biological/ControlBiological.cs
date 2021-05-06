using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public partial class ControlBiological : UserControl
  {
    public bool readFractionMortalityState;
    public ControlStochasticAge maturityAge;
    public ControlTSpawnPanel TSpawnPanel;

    public double DefaultCellValue { get; set; }
    public ControlBiological(string[] obsYears)
    {
      InitializeComponent();

      maturityAge = new ControlStochasticAge
      {
        StochasticParameterLabel = "Maturity",
        IsMultiFleet = false,
        Dock = DockStyle.Fill
      };

      TSpawnPanel = new ControlTSpawnPanel()
      {
        SeqYears = obsYears
      };
      
      tabMaturity.Controls.Add(maturityAge);
      tabTSpawn.Controls.Add(TSpawnPanel);
      DefaultCellValue = 0;

    }

  }
}
