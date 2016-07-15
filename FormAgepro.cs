using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{

    public partial class FormAgepro : Form
    {
        public FormAgepro()
        {
            InitializeComponent();
            
        }
        
           
        
        private void FormAgepro_Load(object sender, EventArgs e)
        {
            //Load User Controls
            ControlGeneral generalOptions = new ControlGeneral();

            generalOptions.SetGeneral += new EventHandler(StartupStateEvent_SetGeneralButton);

            //Load General Options Controls to AGEPRO Parameter panel
            this.panelAgeproParameter.Controls.Clear();
            this.panelAgeproParameter.Controls.Add(generalOptions);
            
            //Instatiate Startup State:
            //Disable Navigation Tree Panel, AGEPRO run options, etc...
            this.panelNavigation.Enabled = false;
        }

        public void StartupStateEvent_SetGeneralButton(object sender, EventArgs e)
        {

            //Activate Naivagation Panel if in first-run/startup state.
            if (this.panelNavigation.Enabled == false)
            {
                this.panelNavigation.Enabled = true;
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Terminate
            this.Close();
        }

        private void aboutAGEPROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About Box Dialog
            AboutAgepro aboutDialog = new AboutAgepro();
            aboutDialog.ShowDialog();
        }

        private void treeViewNavigation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selected = treeViewNavigation.SelectedNode.Name.ToString();

            //TODO
        }

        
   

    }
}
