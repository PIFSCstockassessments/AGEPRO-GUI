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
    public partial class ControlRecruitmentMarkovMatrix : UserControl
    {

        public List<RecruitmentModel> collectionAgeproRecruitModels { get; set; }
        public int collectionSelectedIndex { get; set; }

        public ControlRecruitmentMarkovMatrix()
        {
            InitializeComponent();
        }

        public void SetRecruitmentControls(MarkovMatrixRecruitment currentRecruit, Panel panelRecruitModelParameter)
        {
            if (!(currentRecruit.markovRecruitment.Tables["Recruitment"] != null))
            {

            }
        }
    }
}