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
    public partial class ControlBiological : UserControl
    {
        //
        private ControlStochasticAge maturityAge;

        public ControlBiological()
        {
            InitializeComponent();

            maturityAge = new ControlStochasticAge();
            maturityAge.stochasticParameterLabel = "Maturity";
            maturityAge.isMultiFleet = false;
            maturityAge.Dock = DockStyle.Fill;
            
            tabMaturity.Controls.Add(maturityAge);
            
        }
        public bool timeVarying
        {
            get { return maturityAge.timeVarying; }
            set { maturityAge.timeVarying = value; }
        }
        public bool readInputFileState
        {
            get { return maturityAge.readInputFileState; }
            set { maturityAge.readInputFileState = value; }
        }
        public DataTable maturityAgeTable
        {
            get { return maturityAge.stochasticAgeTable; }
            set { maturityAge.stochasticAgeTable = value; }
        }
        public DataTable maturityCVTable
        {
            get { return maturityAge.stochasticCV; }
            set { maturityAge.stochasticCV = value; }
        }
        public string[] seqYears
        {
            get { return maturityAge.seqYears; }
            set { maturityAge.seqYears = value; }
        }
        public bool enableTimeVaryingCheckBox
        {
            get { return maturityAge.enableTimeVaryingCheckBox; }
            set { maturityAge.enableTimeVaryingCheckBox = value; }
        }
    }
}
