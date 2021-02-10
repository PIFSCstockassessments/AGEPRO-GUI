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
    public partial class ControlStochasticAgeFromFile : UserControl
    {
        public event EventHandler timeVaryingFileChecked;
        public String stochasticParameterFileLabel;

        public ControlStochasticAgeFromFile()
        {
            InitializeComponent();
            stochasticParameterFileLabel = "Stochastic Parameter";
        }
        public string stochasticDataFile
        {
            get { return textBoxDataFile.Text; }
            set { textBoxDataFile.Text = value; }
        }

        public void checkBoxTimeVaryingFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.timeVaryingFileChecked != null)
            {
                this.timeVaryingFileChecked(sender, e);
            }
            
        }

        private void buttonLoadDataFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openStochasticDataFile = new OpenFileDialog();

            openStochasticDataFile.InitialDirectory = @"~";
            openStochasticDataFile.Title = "Open " + this.stochasticParameterFileLabel + " Data File";
            openStochasticDataFile.Filter = "All Files (*.*)|*.*";
            openStochasticDataFile.FilterIndex = 1;
            openStochasticDataFile.RestoreDirectory = true;

            if (openStochasticDataFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.textBoxDataFile.Text = openStochasticDataFile.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not load AGEPRO Stochastic Data File." + Environment.NewLine + ex.Message, 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
