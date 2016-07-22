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
    public partial class ControlBootstrap : UserControl
    {
        public ControlBootstrap()
        {
            InitializeComponent();
        }
        public string bootstrapFilename
        {
            get { return textBoxBootstrapFile.Text; }
            set { textBoxBootstrapFile.Text = value; }
        }
        public string bootstrapIterations
        {
            get { return textBoxNumBootstrapIterations.Text; }
            set { textBoxNumBootstrapIterations.Text = value; }
        }
        public string bootstrapScaleFactors
        {
            get { return textBoxPopScaleFactors.Text; }
            set { textBoxPopScaleFactors.Text = value; }
        }

        //TODO:buttonLoadFile action
    }
}
