namespace AGEPRO.GUI
{
    partial class FormAgepro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("JAN-1");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("SSB");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Mid-Year (Mean)");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Catch");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Discard");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Weights At Age", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Recruitment");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Biological");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Fishery Selectivity");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Discard Fraction");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Natural Mortality");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Harvest Scenario");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Bootstrapping");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Misc. Options");
            this.menuStripAgeproForm = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExistingAGEPROInputDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAGEPROInputDataAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchAGEPROModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.commandWindowStaysOpenDurningRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceManualpdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutAGEPROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewNavigation = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelAgeproParameter = new System.Windows.Forms.Panel();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.menuStripAgeproForm.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripAgeproForm
            // 
            this.menuStripAgeproForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.runToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripAgeproForm.Location = new System.Drawing.Point(0, 0);
            this.menuStripAgeproForm.Name = "menuStripAgeproForm";
            this.menuStripAgeproForm.Size = new System.Drawing.Size(1132, 24);
            this.menuStripAgeproForm.TabIndex = 0;
            this.menuStripAgeproForm.Text = "menuStripAgeproForm";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewCaseToolStripMenuItem,
            this.openExistingAGEPROInputDataFileToolStripMenuItem,
            this.saveAGEPROInputDataAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewCaseToolStripMenuItem
            // 
            this.createNewCaseToolStripMenuItem.Name = "createNewCaseToolStripMenuItem";
            this.createNewCaseToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.createNewCaseToolStripMenuItem.Text = "Create New Case";
            // 
            // openExistingAGEPROInputDataFileToolStripMenuItem
            // 
            this.openExistingAGEPROInputDataFileToolStripMenuItem.Name = "openExistingAGEPROInputDataFileToolStripMenuItem";
            this.openExistingAGEPROInputDataFileToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.openExistingAGEPROInputDataFileToolStripMenuItem.Text = "Open Existing AGEPRO Input Data File";
            this.openExistingAGEPROInputDataFileToolStripMenuItem.Click += new System.EventHandler(this.openExistingAGEPROInputDataFileToolStripMenuItem_Click);
            // 
            // saveAGEPROInputDataAsToolStripMenuItem
            // 
            this.saveAGEPROInputDataAsToolStripMenuItem.Name = "saveAGEPROInputDataAsToolStripMenuItem";
            this.saveAGEPROInputDataAsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveAGEPROInputDataAsToolStripMenuItem.Text = "Save AGEPRO Input Data As ...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchAGEPROModelToolStripMenuItem,
            this.toolStripSeparator2,
            this.commandWindowStaysOpenDurningRunToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // launchAGEPROModelToolStripMenuItem
            // 
            this.launchAGEPROModelToolStripMenuItem.Enabled = false;
            this.launchAGEPROModelToolStripMenuItem.Name = "launchAGEPROModelToolStripMenuItem";
            this.launchAGEPROModelToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.launchAGEPROModelToolStripMenuItem.Text = "Launch AGEPRO model ...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(271, 6);
            // 
            // commandWindowStaysOpenDurningRunToolStripMenuItem
            // 
            this.commandWindowStaysOpenDurningRunToolStripMenuItem.Checked = true;
            this.commandWindowStaysOpenDurningRunToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.commandWindowStaysOpenDurningRunToolStripMenuItem.Name = "commandWindowStaysOpenDurningRunToolStripMenuItem";
            this.commandWindowStaysOpenDurningRunToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.commandWindowStaysOpenDurningRunToolStripMenuItem.Text = "Command window stays open durning run";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.htmlHelpToolStripMenuItem,
            this.referenceManualpdfToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutAGEPROToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // htmlHelpToolStripMenuItem
            // 
            this.htmlHelpToolStripMenuItem.Name = "htmlHelpToolStripMenuItem";
            this.htmlHelpToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.htmlHelpToolStripMenuItem.Text = "Html Help";
            // 
            // referenceManualpdfToolStripMenuItem
            // 
            this.referenceManualpdfToolStripMenuItem.Name = "referenceManualpdfToolStripMenuItem";
            this.referenceManualpdfToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.referenceManualpdfToolStripMenuItem.Text = "Reference Manual (pdf)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // aboutAGEPROToolStripMenuItem
            // 
            this.aboutAGEPROToolStripMenuItem.Name = "aboutAGEPROToolStripMenuItem";
            this.aboutAGEPROToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.aboutAGEPROToolStripMenuItem.Text = "About AGEPRO";
            this.aboutAGEPROToolStripMenuItem.Click += new System.EventHandler(this.aboutAGEPROToolStripMenuItem_Click);
            // 
            // treeViewNavigation
            // 
            this.treeViewNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewNavigation.Location = new System.Drawing.Point(0, 0);
            this.treeViewNavigation.Name = "treeViewNavigation";
            treeNode46.Name = "treeNodeGeneral";
            treeNode46.Text = "General";
            treeNode47.Name = "treeNodeJan1";
            treeNode47.Text = "JAN-1";
            treeNode48.Name = "treeNodeSSB";
            treeNode48.Text = "SSB";
            treeNode49.Name = "treeNodeMidYear";
            treeNode49.Text = "Mid-Year (Mean)";
            treeNode50.Name = "treeNodeCatchWeight";
            treeNode50.Text = "Catch";
            treeNode51.Name = "treeNodeDiscardWeight";
            treeNode51.Text = "Discard";
            treeNode52.Name = "treeNodeWeightAge";
            treeNode52.Text = "Weights At Age";
            treeNode53.Name = "treeNodeRecruitment";
            treeNode53.Text = "Recruitment";
            treeNode54.Name = "treeNodeBiological";
            treeNode54.Text = "Biological";
            treeNode55.Name = "treeNodeFisherySelectivity";
            treeNode55.Text = "Fishery Selectivity";
            treeNode56.Name = "treeNodeDiscardFraction";
            treeNode56.Text = "Discard Fraction";
            treeNode57.Name = "treeNodeNaturalMortality";
            treeNode57.Text = "Natural Mortality";
            treeNode58.Name = "treeNodeHarvestScenario";
            treeNode58.Text = "Harvest Scenario";
            treeNode59.Name = "treeNodeBootstrapping";
            treeNode59.Text = "Bootstrapping";
            treeNode60.Name = "treeNodeMiscOptions";
            treeNode60.Text = "Misc. Options";
            this.treeViewNavigation.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59,
            treeNode60});
            this.treeViewNavigation.Size = new System.Drawing.Size(200, 536);
            this.treeViewNavigation.TabIndex = 1;
            this.treeViewNavigation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewNavigation_AfterSelect);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1132, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelAgeproParameter
            // 
            this.panelAgeproParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAgeproParameter.AutoScroll = true;
            this.panelAgeproParameter.AutoScrollMinSize = new System.Drawing.Size(910, 520);
            this.panelAgeproParameter.Location = new System.Drawing.Point(206, 24);
            this.panelAgeproParameter.Name = "panelAgeproParameter";
            this.panelAgeproParameter.Size = new System.Drawing.Size(926, 539);
            this.panelAgeproParameter.TabIndex = 3;
            // 
            // panelNavigation
            // 
            this.panelNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelNavigation.Controls.Add(this.treeViewNavigation);
            this.panelNavigation.Location = new System.Drawing.Point(0, 24);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(200, 536);
            this.panelNavigation.TabIndex = 4;
            // 
            // FormAgepro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 585);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelAgeproParameter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripAgeproForm);
            this.MainMenuStrip = this.menuStripAgeproForm;
            this.Name = "FormAgepro";
            this.Text = "AGEPRO";
            this.menuStripAgeproForm.ResumeLayout(false);
            this.menuStripAgeproForm.PerformLayout();
            this.panelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripAgeproForm;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExistingAGEPROInputDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAGEPROInputDataAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchAGEPROModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem commandWindowStaysOpenDurningRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem htmlHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceManualpdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutAGEPROToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewNavigation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelAgeproParameter;
        private System.Windows.Forms.Panel panelNavigation;
    }
}

