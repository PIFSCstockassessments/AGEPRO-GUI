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
    }
}
