using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{
    
    public partial class ControlGeneral : UserControl
    {
        public event EventHandler SetGeneral;

        public ControlGeneral()
        {
            InitializeComponent();
        }
        
        public string generalModelId
        {
            get { return textBoxModelID.Text; }
            set { textBoxModelID.Text = value;  }
        }
        public string generalInputFile
        {
            get { return textBoxInputFile.Text; }
            set { textBoxInputFile.Text = value; }
        }
        public string generalFirstYearProjection 
        {
            get { return textBoxFirstYearProjection.Text; }
            set { textBoxFirstYearProjection.Text = value; }
        }
        public string generalLastYearProjection
        {
            get { return textBoxLastYearProjection.Text; }
            set { textBoxLastYearProjection.Text = value; }
        }
        public int generalFirstAgeClass
        {
            get { return Convert.ToInt32(spinBoxFirstAge.Value); }
            set { spinBoxFirstAge.Value = value; }
        }
        public int generalLastAgeClass
        {
            get { return Convert.ToInt32(textBoxLastAge.Text); }
            set { textBoxLastAge.Text = value.ToString();  }
        }
        public string generalNumberFleets
        {
            get { return textBoxNumFleets.Text; }
            set { textBoxNumFleets.Text = value; }
        }
        public string generalNumberRecruitModels
        {
            get { return textBoxNumRecruitModels.Text; }
            set { textBoxNumRecruitModels.Text = value; }
        }
        public string generalNumberPopulationSimuations
        {
            get { return textBoxNumPopSim.Text; }
            set { textBoxNumPopSim.Text = value; }
        }
        public string generalRandomSeed
        {
            get { return textBoxRandomSeed.Text; }
            set { textBoxRandomSeed.Text = value; }
        }
        public bool generalDiscards
        {
            get { return checkBoxDiscards.Checked; }
            set { checkBoxDiscards.Checked = value; }
        }

        private void buttonSetGeneral_Click(object sender, EventArgs e)
        {
            //Transfer general option values to input file class
            //Null check to make sure main page attached to event.
            if (this.SetGeneral != null)
            {
                this.SetGeneral(sender, e);
            }

        }
    }
}
