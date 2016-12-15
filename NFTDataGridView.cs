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
        private bool _nftReadOnly;

        //Constructing Context Menu fo DataGridView
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip dgvMenuStrip;
        private ToolStripMenuItem menuCut;
        private ToolStripMenuItem menuCopy;
        private ToolStripMenuItem menuPaste;
        private ToolStripMenuItem menuDelete;
        private ToolStripSeparator menuSeparator1;
        private ToolStripSeparator menuSeparator2;
        private ToolStripMenuItem menuFillWithZero;
        private ToolStripMenuItem menuSelectAll;
        
  
        

        public NFTDataGridView()
        {
            InitializeComponent(); //Component Designer generated Code

            nftReadOnly = false; //False by default
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
                    menuCopy.Enabled = false;
                    menuPaste.Enabled = false;
                }
                else //nftReadOnly is False
                {
                    this.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    menuCut.Enabled = true;
                    menuCopy.Enabled = true;
                    menuPaste.Enabled = true;
                }
            }
            
        }

        private void NFTDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            this.ContextMenuStrip = dgvMenuStrip; 
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
                  
            }
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCopy_Click(object sender, EventArgs e)
        {
            OnCopy();
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
            this.ClearSelection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            
        }

        private void menuFillWithZero_Click(object sender, EventArgs e)
        {
            FillDBNullsWithZero();
            this.ClearSelection();
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnCopy()
        {
            if (this.CurrentCell.IsInEditMode)
            {
                Clipboard.SetDataObject(this.CurrentCell.EditedFormattedValue);
            }
            else
            {
                Clipboard.SetDataObject(this.GetClipboardContent());
            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void OnPaste()
        {
            //throw error if no cells are selected
            if (this.SelectedCells.Count == 0)
            {
                MessageBox.Show("No cells selected. Please select a cell", "Paste",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clipboardString = Clipboard.GetText();
            string[] clipboardLines = clipboardString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int irow = this.CurrentCell.RowIndex;
            int icol = this.CurrentCell.ColumnIndex;
            DataGridViewCell oCell;

            //copy-and-paste-multiple-cells-within-datagridview
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
        /// 
        /// </summary>
        private void OnDelete()
        {
            //Get Selection Range
            //DataGridViewSelectedCellCollection doesn't implement a generic IEnumerable<DataGridViewCell>, just IEnumerable.
            //To enumerate the values when they are of type 'Object', .Cast<DataGridViewCell>
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
        /// 
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





    }
}
