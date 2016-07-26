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
    public partial class ControlStochasticAgeFromFile : UserControl
    {
        public ControlStochasticAgeFromFile()
        {
            InitializeComponent();
        }
        public string stochasticDataFile
        {
            get { return textBoxDataFile.Text; }
            set { textBoxDataFile.Text = value; }
        }
    }
}
