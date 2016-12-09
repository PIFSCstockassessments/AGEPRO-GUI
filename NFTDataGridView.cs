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
        private int maxRows {get; set;}
        private int maxColumns {get; set;}

        //Constructing Context Menu fo DataGridView
        private ContextMenuStrip dgvMenuStrip;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem menuCopy;
        private ToolStripMenuItem menuPaste;
        private ToolStripMenuItem menuCut;
        

        public NFTDataGridView()
        {
            InitializeComponent();

            this.maxRows = 9999;
            this.maxColumns = 9999;
        }

        #region Component Designer generated code (InitializeComponent)

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMenuStrip
            // 
            this.dgvMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste});
            this.dgvMenuStrip.Name = "dgvMenuStrip";
            this.dgvMenuStrip.Size = new System.Drawing.Size(140, 70);
            // 
            // menuCut
            // 
            this.menuCut.Name = "menuCut";
            this.menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuCut.Size = new System.Drawing.Size(139, 22);
            this.menuCut.Text = "Cut";
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(139, 22);
            this.menuCopy.Text = "Copy";
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(139, 22);
            this.menuPaste.Text = "Paste";
            // 
            // NFTDataGridView
            // 
            this.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.NFTDataGridView_CellContextMenuStripNeeded);
            this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NFTDataGridView_CellMouseClick);
            this.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NFTDataGridView_CellMouseDown);
            this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.NFTDataGridView_EditingControlShowing);
            this.dgvMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void NFTDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
        }

        //right-click-context-menu-for-datagridview
        private void NFTDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Check if the user has right-clicked on the any cell of this Data Grid
            if (e.ColumnIndex != -1 && e.RowIndex != 1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell dgvCell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                //This will force the 'CurrentCell' to the right-clicked selected cell. Simliar to Excel.
                if (!dgvCell.Selected)
                {
                    dgvCell.DataGridView.ClearSelection();
                    dgvCell.DataGridView.CurrentCell = dgvCell;
                    dgvCell.Selected = true;
                }
                this.ContextMenuStrip = dgvMenuStrip;   
            }
        }

        public void NFTDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.SelectedCells.Count > 0)
                {
                    this.ContextMenuStrip = dgvMenuStrip;
                }
            }
        }

        /// <summary>
        /// Override the default Context menu with the NFTDataGridView's context menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenuStrip = dgvMenuStrip;
        }

        //void menuPaste_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //void menuCopy_Click(object sender, EventArgs e)
        //{
        //    Clipboard.SetDataObject(dataGridHarvestScenarioTable.GetClipboardContent());
        //}

    }
}
