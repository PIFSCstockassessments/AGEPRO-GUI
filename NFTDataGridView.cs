using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public class NFTDataGridView : DataGridView
    {
        //Constructing Context Menu fo DataGridView
        private ContextMenuStrip strip;
        private ToolStripMenuItem menuCut = new ToolStripMenuItem();
        private ToolStripMenuItem menuCopy = new ToolStripMenuItem();
        private ToolStripMenuItem menuPaste = new ToolStripMenuItem();


        public NFTDataGridView()
        {

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // NFTDataGridView
            // 
            this.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.NFTDataGridView_CellContextMenuStripNeeded);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void NFTDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (strip == null)
            {
                strip = new ContextMenuStrip();
                menuCut.Text = "Cut";
                menuCopy.Text = "Copy";
                menuPaste.Text = "Paste";
                strip.Items.Add(menuCut);
                strip.Items.Add(menuCopy);
                strip.Items.Add(new ToolStripSeparator());
                strip.Items.Add(menuPaste);
            }
            e.ContextMenuStrip = strip;
        }
    }
}
