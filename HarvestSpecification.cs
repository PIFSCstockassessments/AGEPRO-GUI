using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGEPRO.GUI
{
    /// <summary>
    /// This represents the various specifications avialable for the Harvest Specification Basis column
    /// of the Harvest Scenario Table. 
    /// 
    /// This can be used in used for populating comboBoxes. They are used to set the "Harvest Specification" 
    /// DataGridViewComboBoxColumn of the HarvestScenarioTable in AGEPRO.GUI.ControlHarvestScenario.
    /// 
    /// (Not implemented yet, the HarvestScenarioTable class can use HarvestSpecification)  
    /// </summary>
    public class HarvestSpecification
    {
        public int Index { get; set; }
        public string HarvestScenario { get; set; }

        public HarvestSpecification(int i, string spec)
        {
            Index = i;
            HarvestScenario = spec;
        }

        private static readonly List<HarvestSpecification> harvestSpec = new List<HarvestSpecification>
        {
            { new HarvestSpecification(0, "F-MULT") },
            { new HarvestSpecification(1, "LANDINGS") },
            { new HarvestSpecification(2, "REMOVALS") }
        };
        
        public static List<HarvestSpecification> GetHarvestSpec()
        {
            return harvestSpec;
        }

    }
}
