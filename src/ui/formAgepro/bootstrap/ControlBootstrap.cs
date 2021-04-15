using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlBootstrap : UserControl
    {
        public ControlBootstrap()
        {
            InitializeComponent();

            bootstrapIterations = "0";
            bootstrapScaleFactors = "0";
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


        /// <summary>
        /// Intializes the control's values and data bindings to the AgeproBootstrap object
        /// </summary>
        /// <param name="bootstrapOpt">AGEPRO CoreLib Bootstrap object</param>
        public void SetBootstrapControls(Nmfs.Agepro.CoreLib.AgeproBootstrap bootstrapOpt)
        {

            //Clear any existing bindings before creating new ones.
            this.textBoxBootstrapFile.DataBindings.Clear();
            this.textBoxNumBootstrapIterations.DataBindings.Clear();
            this.textBoxPopScaleFactors.DataBindings.Clear();
            this.textBoxBootstrapFile.DataBindings.Add("Text", bootstrapOpt, "bootstrapFile", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxNumBootstrapIterations.DataBindings.Add("Text", bootstrapOpt, "numBootstraps", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxPopScaleFactors.DataBindings.Add("Text", bootstrapOpt, "popScaleFactor", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxNumBootstrapIterations.PrevValidValue = this.bootstrapIterations;
            this.textBoxPopScaleFactors.PrevValidValue = this.bootstrapScaleFactors;
        }

        /// <summary>
        /// Handles File Dialog events after user presses the "Load File".
        /// </summary>
        /// <returns></returns>
        public static OpenFileDialog SetBootstrapOpenFileDialog()
        {
            OpenFileDialog openBootstrapFileDialog = new OpenFileDialog();

            openBootstrapFileDialog.InitialDirectory = "~";
            openBootstrapFileDialog.Filter = "AGEPRO bootstrap files (*.BSN)|*.bsn|All Files (*.*)|*.*";
            openBootstrapFileDialog.FilterIndex = 1;
            openBootstrapFileDialog.RestoreDirectory = true;
            openBootstrapFileDialog.Title = "Open AGEPRO Bootstrap File";

            return openBootstrapFileDialog;
        }

        

        /// <summary>
        /// Input Validation
        /// </summary>
        /// <param name="validateFilename">Check existance of bootstrap file in system</param>
        /// <returns>Returns false on the first invalid object found. Otherwise true.</returns>
        public bool ValidateBootstrapInput(bool validateFilename = false)
        {
            List<string> errorMsgList = new List<string>();
            if (string.IsNullOrWhiteSpace(this.bootstrapIterations))
            {
                errorMsgList.Add("Missing Number of Bootstraps.");
            }
            if (string.IsNullOrWhiteSpace(this.bootstrapScaleFactors))
            {
                errorMsgList.Add("Missing Number of Bootstrap Scale Factors.");
            }

            if (validateFilename)
            {
                if (System.IO.File.Exists(this.bootstrapFilename) == false)
                {
                    errorMsgList.Add("Bootstrap File not found in system.");
                }
            }

            var results = Nmfs.Agepro.CoreLib.ValidatableExtensions.EnumerateValidationResults(errorMsgList);
                       
            if (results.IsValid == false)
            {
                MessageBox.Show("Invalid Bootstrap values found: " + Environment.NewLine 
                    + results.Message, "AGEPRO Bootstrap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Handles events that occur when user clicks the "Load File" Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                OpenFileDialog bootstrapFileDialog = SetBootstrapOpenFileDialog();
                if (bootstrapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bootstrapFilename = bootstrapFileDialog.FileName;                    
                }
            }
        }

        /// <summary>
        /// Pop Scale Factor Validating Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPopScaleFactors_Validating(object sender, CancelEventArgs e)
        {
            double scaleFactor;
            NftTextBox txtBootFac = sender as NftTextBox;
            if (double.TryParse(txtBootFac.Text, out scaleFactor))
            {
                if (scaleFactor < 0)
                {
                    MessageBox.Show("Bootsrap Population Scale Factors must be a positive number.", "AGEPRO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBootFac.Text = txtBootFac.PrevValidValue;
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bootstrap Population Scale Factors must be a numeric value.", "AGEPRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBootFac.Text = txtBootFac.PrevValidValue;
                e.Cancel = true;
                return;
            }
        }


    }
}
