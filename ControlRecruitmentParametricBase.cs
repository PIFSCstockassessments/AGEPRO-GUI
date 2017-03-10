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
            Binding b = new Binding("Text", recruitDataObj, parameterName, true);
            //b.Format += new ConvertEventHandler(textBoxBinding_Format);
            //b.Parse += new ConvertEventHandler(textBoxBinding_Parse);
            txtCtl.DataBindings.Add(b);
        }

        /// <summary>
        /// How the data object gets formatted to the control is bounded to.  Object to control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void textBoxBinding_Format(object sender, ConvertEventArgs e)
        {
            Binding b = sender as Binding;
            if (b != null)
            {
                TextBox ctlTxt = (b.Control as TextBox);
                if (ctlTxt != null && e.Value == null)
                {
                    if (string.IsNullOrWhiteSpace(ctlTxt.Text))
                    {
                        //If control text wasn't initalized, just do it here.
                        e.Value = default(double);
                    }
                    else
                    {
                        e.Value = ctlTxt.Text;
                    }
                }
            }
        }

        /// <summary>
        /// How the control's formatted value is stored to that object its bounded to. Control to Object.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void textBoxBinding_Parse(object sender, ConvertEventArgs e)
        {
            Binding b = sender as Binding;
            string bindedObjName = b.BindingMemberInfo.BindingMember;
            if (b != null)
            {
                TextBox ctlTxt = b.Control as TextBox;
                if (ctlTxt != null)
                {
                    double val;
                    if (Double.TryParse(e.Value.ToString(), out val))
                    {
                        e.Value = new double?(val);
                    }
                    else
                    {
                        //Revert to binded object value, using reflection
                        var bindedVal = b.DataSource.GetType().GetProperty(bindedObjName).GetValue(b.DataSource, null);
                        MessageBox.Show("Blank or invalid input for " + bindedObjName +".","AGEPRO",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlTxt.Text = bindedVal.ToString();
                    }
                }
            }
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
