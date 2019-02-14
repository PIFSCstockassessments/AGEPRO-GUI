using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nmfs.Agepro.CoreLib;

namespace Nmfs.Agepro.Gui
{
    public partial class ControlRecruitmentParametricBase : UserControl
    {
        public List<RecruitmentModel> collectionAgeproRecruitmentModels { get; set; }
        public int collectionSelectedIndex { get; set; }
        public bool isAutocorrelated { get; set; }
        protected ParametricType typeOfParmetric { get; set; }


        public ControlRecruitmentParametricBase()
        {
            InitializeComponent();
            isAutocorrelated = false;
        }

        public virtual void SetParametricRecruitmentControls(ParametricRecruitment currentRecruit,
            Panel panelRecruitModelParameter)
        {

            panelRecruitModelParameter.Controls.Clear();
            this.Dock = DockStyle.Fill;
            panelRecruitModelParameter.Controls.Add(this);
        }


        /// <summary>
        /// Procedure to initalize AGEPRO text box control's data binding for Parametric recruitment parameters. 
        /// </summary>
        /// <param name="txtCtl"></param>
        /// <param name="recruitDataObj"></param>
        /// <param name="parameterName"></param>
        protected void DataBindTextBox(TextBox txtCtl, ParametricRecruitment recruitDataObj, string parameterName)
        {
            Binding b = new Binding("Text", recruitDataObj, parameterName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtCtl.DataBindings.Add(b);
        }


        /// <summary>
        /// Paramertic Parameter input data validation. Invalid data is reverted to previous valid value the NftTextBox 
        /// object stored.
        /// </summary>
        /// <remarks>
        /// For consistent validation with nullable and non-nullable data bounded objects, <code>DataSourceUpdateMode</code> 
        /// should be set that to default, <code>OnValidation</code>.
        /// </remarks>
        /// <param name="txtParam"></param>
        /// <param name="e"></param>
        protected void ValidateParamerticParameter(NftTextBox txtParam, CancelEventArgs e)
        {
            double parametricVal;
            if (!(double.TryParse(txtParam.Text, out parametricVal)))
            {
                MessageBox.Show("Invalid input for " + txtParam.ParamName + ": Must be a numeric value.", "AGEPRO",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtParam.Text = txtParam.PrevValidValue;
                e.Cancel = true;
                return;
            }
        }


    }
}
