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
    public partial class ControlStochasticAge : UserControl
    {
        private ControlStochasticAgeDataGridTable controlStochasticParamAgeFromUser;
        private ControlStochasticAgeFromFile controlStochasticParamAgeFromFile;

        public ControlStochasticAge(string paramName="Stochastic Parameter")
        {
            InitializeComponent();
            controlStochasticParamAgeFromUser = new ControlStochasticAgeDataGridTable();
            controlStochasticParamAgeFromFile = new ControlStochasticAgeFromFile();
            radioParameterFromUser.Checked = true; //User Specfied Option Selected by Default

            string stochasticParameter = paramName;
            radioParameterFromUser.Text = "User Specified " + stochasticParameter + " At Age";
            radioParameterFromFile.Text = "Read "+ stochasticParameter + " From File";
            controlStochasticParamAgeFromUser.stochasticParamAgeDataGridLabel = stochasticParameter + " Of Age";
        }

        

        private void radioParameterFromUser_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromUser);
        }

        private void radioParameterFromFile_CheckedChanged(object sender, EventArgs e)
        {
            panelStochasticParameterAge.Controls.Clear();
            panelStochasticParameterAge.Controls.Add(controlStochasticParamAgeFromFile);
        }
    }
}
