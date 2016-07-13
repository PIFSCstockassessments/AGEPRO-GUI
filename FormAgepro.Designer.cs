namespace AGEPRO_GUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.runToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 585);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
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
    }
}

