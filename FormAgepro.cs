using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGEPRO.CoreLib;

namespace AGEPRO.GUI
{

    public partial class FormAgepro : Form
    {
        private AgeproInputFile inputData;
        private ControlGeneral generalOptions;
        private ControlMiscOptions miscOptions;

        public FormAgepro()
        {
            InitializeComponent();
            //AGEPRO Input Data, If any
            inputData = new AgeproInputFile();

            //Load User Controls
            generalOptions = new ControlGeneral();
            miscOptions = new ControlMiscOptions();

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
            string selectedTreeNode = treeViewNavigation.SelectedNode.Name.ToString();
            

            //TODO
            switch (selectedTreeNode)
            {
                case "treeNodeGeneral":
                    panelAgeproParameter.Controls.Clear();
                    panelAgeproParameter.Controls.Add(generalOptions);
                    break;
                case "treeNodeMiscOptions":
                    panelAgeproParameter.Controls.Clear();
                    panelAgeproParameter.Controls.Add(miscOptions);
                    break;
                default:
                    break;
            }
        }

        private void openExistingAGEPROInputDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Console.WriteLine("FOO");
            //Use AGEPRO.CoreLib.AgeproInputFile.ReadInputFile
            OpenFileDialog openAgeproInputFile = new OpenFileDialog();

            openAgeproInputFile.InitialDirectory = "~";
            openAgeproInputFile.Filter = "AGEPRO input files (*.inp)|*.inp|All Files (*.*)|*.*";
            openAgeproInputFile.FilterIndex = 1;
            openAgeproInputFile.RestoreDirectory = true;
            openAgeproInputFile.ShowDialog();
        }

        
   

    }
}
