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
        private int maxRandomSeed;
        public int maxRecruitModels { get; set; }

        public ControlGeneral()
        {
            InitializeComponent();
            
            //Set max constant
            maxRandomSeed = 2147483647;

            //Set Max Constants
            maxRecruitModels = 21;

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
        public bool generalDiscardsPresent
        {
            get { return checkBoxDiscards.Checked; }
            set { checkBoxDiscards.Checked = value; }
        }

        public void ValidateGeneralOptionsParameters()
        {
            
            Dictionary <string, string> generalOptionsList = new Dictionary<string,string> {
                {"First Year Of Projection", textBoxFirstYearProjection.Text},
                {"Last Year Of Projection", textBoxLastYearProjection.Text},
                {"First Age Class", spinBoxFirstAge.Value.ToString()},
                {"Last Age Class", textBoxLastAge.Text},
                {"Number Of Fleets", textBoxNumFleets.Text},
                {"Number Of Recruitment Models", textBoxNumRecruitModels.Text},
                {"Number Of Population Simulations", textBoxNumPopSim.Text},
                {"Random Number Seed", textBoxRandomSeed.Text},
       
            };

            //Check If Each General Param Controls (1) has a value and (2) that value is a whole (integer) number.
            foreach (KeyValuePair<string,string> param in generalOptionsList)
            {
                if (param.Value == "")
                {
                    throw new InvalidAgeproGuiParameterException( param.Key + " value must be specfied.");
                }
                if (IsNumeric(param.Value) == false)
                {
                    throw new InvalidAgeproGuiParameterException( "In " + param.Key + ": '" + param.Value + "' is not a whole number");
                }

            }

            //First Age Class: In case the spinBox(UpDownNumeric) control didn't catch the invalid value, catch it here.   
            if (spinBoxFirstAge.Value > 1 || spinBoxFirstAge.Value < 0)
            {
                throw new InvalidAgeproGuiParameterException("Invaild First Age Class Value: Should only be 0 or 1");
            }

            if (Math.Abs(Convert.ToInt32(textBoxRandomSeed.Text)) > maxRandomSeed)
            {
                throw new InvalidAgeproGuiParameterException("Random Number Seed " + textBoxRandomSeed.Text + 
                    Environment.NewLine + "Exceeds limit of " + maxRandomSeed + " or -" + maxRandomSeed );
            }


            //Use general options parameters to set inputFile parameters 
            int generalNumAges = NumAges();
            int generalNumYears = Convert.ToInt32(this.generalLastYearProjection) -
                Convert.ToInt32(this.generalFirstYearProjection) + 1;
          
            //Validate Number of Ages and Years
            if (generalNumAges < 1)
            {
                string exMessage = "Invaild Age Range - Is Last Age Class less than First Age Class?";
                throw new InvalidAgeproGuiParameterException(exMessage);
            }
            if (generalNumYears < 1)
            {
                string exMessage = "Invaild Year Range - Is Last Year Of Projection Earlier than First Year?";
                throw new InvalidAgeproGuiParameterException(exMessage);
            }

            if(Convert.ToInt32(generalNumberRecruitModels) > this.maxRecruitModels)
            {
                string exMessage = "Number of Recruitment Models exceed limit of " + this.maxRecruitModels + ".";
                throw new InvalidAgeproGuiParameterException(exMessage);
            }
            
        }

        private bool IsNumeric(string s)
        {
            int numberForm;
            bool isNumeric = int.TryParse(s, out numberForm);

            return isNumeric;
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

        /// <summary>
        /// Returns a sequence of years from First year of projection
        /// </summary>
        /// <returns>Returns a enuumerable string array from <paramref name="textBoxFirstYearProjection"/> 
        /// to <paramref name="textBoxLastYearProjection"/></returns>
        public string[] SeqYears()
        {
            int numYears = Math.Abs(Convert.ToInt32(textBoxLastYearProjection.Text) -
                Convert.ToInt32(textBoxFirstYearProjection.Text)) + 1;
            int[] enumYearArray = Enumerable.Range(Convert.ToInt32(textBoxFirstYearProjection.Text), numYears).ToArray();
            
            return Array.ConvertAll(enumYearArray, element => element.ToString());
        }

        /// <summary>
        /// Returns number of Ages in between <paramref name="spinBoxFirstAgeClass"/> and 
        /// <paramref name="textBoxLastAgeClass"/>
        /// </summary>
        /// <returns>Integer</returns>
        public int NumAges()
        {
            return (this.generalLastAgeClass - this.generalFirstAgeClass + 1);
        }

    }
}
