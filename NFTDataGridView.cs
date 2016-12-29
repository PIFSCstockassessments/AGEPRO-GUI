using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
    public class NftDataGridView : DataGridView
    {

        private bool _nftReadOnly;

        //Context Menu Strip for DataGridView
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip dgvMenuStrip;
        private ToolStripMenuItem menuCut;
        private ToolStripMenuItem menuCopy;
        private ToolStripMenuItem menuPaste;
        private ToolStripMenuItem menuDelete;
        private ToolStripSeparator menuSeparator1;
        private ToolStripMenuItem menuSelectAll;
        private ToolStripSeparator menuSeparator2;
        private ToolStripMenuItem menuFillWithZero;

       

        public NftDataGridView()
        {
            InitializeComponent(); //Component Designer generated Code

            nftReadOnly = false; //False by default
            this.AllowUserToAddRows = false;
            this.AllowUserToResizeRows = false;
            this.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
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
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFillWithZero = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMenuStrip
            // 
            this.dgvMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuDelete,
            this.menuSeparator1,
            this.menuSelectAll,
            this.menuSeparator2,
            this.menuFillWithZero});
            this.dgvMenuStrip.Name = "dgvMenuStrip";
            this.dgvMenuStrip.Size = new System.Drawing.Size(157, 148);
            // 
            // menuCut
            // 
            this.menuCut.Name = "menuCut";
            this.menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuCut.Size = new System.Drawing.Size(156, 22);
            this.menuCut.Text = "Cut";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(156, 22);
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(156, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(156, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuSelectAll.Size = new System.Drawing.Size(156, 22);
            this.menuSelectAll.Text = "Select All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            this.menuSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // menuFillWithZero
            // 
            this.menuFillWithZero.Name = "menuFillWithZero";
            this.menuFillWithZero.Size = new System.Drawing.Size(156, 22);
            this.menuFillWithZero.Text = "Fill Blank Cells";
            this.menuFillWithZero.Click += new System.EventHandler(this.menuFillWithZero_Click);
            // 
            // NFTDataGridView
            // 
            this.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.NFTDataGridView_CellContextMenuStripNeeded);
            this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NFTDataGridView_CellMouseClick);
            this.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NFTDataGridView_CellMouseDown);
            this.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.NFTDataGridView_ColumnAdded);
            this.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.NFTDataGridView_DataError);
            this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.NFTDataGridView_EditingControlShowing);
            this.dgvMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// nftDataGridView specfic settings, including it's menuStrip, whenever the 
        /// 'read-only' option is set to true or false. The default is false. 
        /// </summary>
        public bool nftReadOnly
        {
            get { return this._nftReadOnly; }
            set
            {
                this._nftReadOnly = value;
                if (this._nftReadOnly == true)
                {
                    this.EditMode = DataGridViewEditMode.EditProgrammatically;
                    menuCut.Enabled = false;
                    menuPaste.Enabled = false;
                    menuDelete.Enabled = false;
                    menuFillWithZero.Enabled = false;
                }
                else //nftReadOnly is False
                {
                    this.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    menuCut.Enabled = true;
                    menuPaste.Enabled = true;
                    menuDelete.Enabled = true;
                    menuFillWithZero.Enabled = true;
                }
            }
            
        }

        /// <summary>
        /// Raises NFTDataGridView's context menu strip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.ContextMenuStrip = dgvMenuStrip; 
        }

        /// <summary>
        /// Sets the 'CurrentCell' location to the right-clicked selected cell. Behavior simliar to Excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //'right-click-context-menu-for-datagridview'        
            //Check if the user has right-clicked on the any cell of this Data Grid
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridViewCell dgvCell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                
                if (!dgvCell.Selected)
                {
                    dgvCell.DataGridView.ClearSelection();
                    dgvCell.DataGridView.CurrentCell = dgvCell;
                    dgvCell.Selected = true;
                }
                  
            }
        }

        /// <summary>
        /// Launches the contextMenuStrip when the right mouse button is clicked on any cell of the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Overrides system's default Context menu with the NFTDataGridView's context menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenuStrip = dgvMenuStrip;
        }

        /// <summary>
        /// Event when the "cut" menu option is selected. This will attempt to cut the contents of the data
        /// grid to the clipboad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCut_Click(object sender, EventArgs e)
        {
            try
            {
                OnCopy();
                OnDelete();
                this.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured." + Environment.NewLine + Environment.NewLine +
                ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event when the "Copy" menu option is selected. this will copy the contents of the data grid 
        /// to the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCopy_Click(object sender, EventArgs e)
        {
            OnCopy();
        }

        /// <summary>
        /// Event when the "Paste" menu option is selected. This will attempt to paste the contents of the 
        /// clipboard to the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPaste_Click(object sender, EventArgs e)
        {
            try
            {
                OnPaste();
                this.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured." + Environment.NewLine + Environment.NewLine +
                ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        /// <summary>
        /// Event when the "Delete" menu option is selected. This will clear the selected values in this data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
            this.ClearSelection();
        }

        /// <summary>
        /// Event when the "Select All" menu option is selected. This will select all the cells in this data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            OnSelectAll();
        }

        /// <summary>
        /// Event when the "Fill Blank Cells" menu option is selected. This will fill applicable blank cells with zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFillWithZero_Click(object sender, EventArgs e)
        {
            FillDBNullsWithZero();
            this.ClearSelection();
        }


        /// <summary>
        /// Handles when data-parsing/validations would throw exceptions. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("An error occured." +
                Environment.NewLine + Environment.NewLine +
                e.Exception.Message.ToString(),
                "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// When columns are added to NFTDataGridView, they will not be sortable by default. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NFTDataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }




        /// <summary>
        /// Copies the contents of the data grid to the system clipboard.
        /// </summary>
        public void OnCopy()
        {
            if (this.CurrentCell.IsInEditMode)
            {
                DataObject cellsToCopy = this.GetClipboardContent();
                if (cellsToCopy != null)
                {
                    //There may be instances where a cell is in edit mode and part
                    //of a cell selection at the same time.
                    Clipboard.SetDataObject(cellsToCopy);
                }
                else
                {
                    Clipboard.SetDataObject(this.CurrentCell.EditedFormattedValue);
                }
                
            }
            else
            {
                Clipboard.SetDataObject(this.GetClipboardContent());
            }

        }


        /// <summary>
        /// Pastes the contents from the system clipboard to the data grid.
        /// </summary>
        public void OnPaste()
        {
            //throw error if no cells are selected
            if (this.SelectedCells.Count == 0)
            {
                MessageBox.Show("No cells selected. Please select a cell", "Paste",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clipboardString = Clipboard.GetText();
            string[] clipboardLines = clipboardString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int irow = this.CurrentCell.RowIndex;
            int icol = this.CurrentCell.ColumnIndex;
            DataGridViewCell oCell;

            //'copy-and-paste-multiple-cells-within-datagridview'
            foreach (string line in clipboardLines)
            {
                string[] cellsToPaste = line.Split('\t');
                int numCellsSelected = cellsToPaste.Length;
                if (irow < this.Rows.Count)
                {
                    for (int x = 0; x < numCellsSelected; x++)
                    {
                        if (icol + x < this.Columns.Count)
                        {
                            oCell = this[icol + x, irow];
                            if (oCell is DataGridViewComboBoxCell) 
                            {
                               MessageBox.Show("At Row Index " + oCell.RowIndex + ", Column Index " + oCell.ColumnIndex + ":" + 
                                   Environment.NewLine + "Pasting any values to this type of cell is not allowed.",
                                    "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                oCell.Value = cellsToPaste[x];
                            }      
                        }
                        else
                        {
                            break;
                        }
                    }
                    irow++;    
                }
                else
                {
                    break;
                }
            }
        }//end OnPaste

        /// <summary>
        /// Clears the values of the selected cells. 
        /// </summary>
        public void OnDelete()
        {
            //Get Selection Range
            ///DataGridViewSelectedCellCollection (selectedCells) doesn't implement a generic 
            ///IEnumerable<DataGridViewCell>, just IEnumerable.
            ///To enumerate the values when they are of type 'Object', .Cast<DataGridViewCell>
            var selected = this.SelectedCells.Cast<DataGridViewCell>().ToList();
            //LINQ method to get start and end indexes
            int startRow = selected.Min(x => x.RowIndex);
            int startCol = selected.Min(x => x.ColumnIndex);
            int endRow = selected.Max(x => x.RowIndex);
            int endCol = selected.Max(x => x.ColumnIndex);

            //"Delete" selected cells (by assigning them empty strings)
            for (int irow = startRow; irow < (endRow+1); irow++)
            {
                for (int jcol = startCol; jcol < (endCol+1); jcol++)
                {
                    this.Rows[irow].Cells[jcol].Value = DBNull.Value;
                }
            }
            
        }

        /// <summary>
        /// Selects all the cells in this data grid.
        /// </summary>
        public void OnSelectAll()
        {
            this.SelectAll();
        }


        /// <summary>
        /// Fills cells with blank or null values with a zero.
        /// </summary>
        private void FillDBNullsWithZero()
        {
            for (int irow = 0; irow < this.Rows.Count; irow++)
            {
                for(int jcol =0; jcol < this.Columns.Count; jcol++)
                {
                    if(this.Rows[irow].Cells[jcol].Value is DBNull)
                    {
                        this.Rows[irow].Cells[jcol].Value = 0;
                    }
                }
            }
           
        }

        /// <summary>
        /// Checks if this Data Grid has any cell that may be blank, null, or with only white-space 
        /// characters.
        /// </summary>
        /// <returns>If the function finds an single instance of a blank/null/white-space only cell,
        /// then it will return true. Otherwise, false.</returns>
        public bool HasBlankOrNullCells()
        {
            bool blankNullsExist = false;

            foreach (DataGridViewRow dgvRow in this.Rows)
            {
                for (int i = 0; i < dgvRow.Cells.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(dgvRow.Cells[i].EditedFormattedValue.ToString()))
                    {
                        blankNullsExist = true;
                    }
                }
            }

            return blankNullsExist;
        }
       
    }
}
