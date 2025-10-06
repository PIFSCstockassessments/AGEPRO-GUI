using System;
using System.Linq;
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
      AllowUserToAddRows = false;
      AllowUserToResizeRows = false;
      ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
    }

    #region Component Designer generated code (InitializeComponent)

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      dgvMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
      menuCut = new System.Windows.Forms.ToolStripMenuItem();
      menuCopy = new System.Windows.Forms.ToolStripMenuItem();
      menuPaste = new System.Windows.Forms.ToolStripMenuItem();
      menuDelete = new System.Windows.Forms.ToolStripMenuItem();
      menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      menuFillWithZero = new System.Windows.Forms.ToolStripMenuItem();
      dgvMenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      SuspendLayout();
      // 
      // dgvMenuStrip
      // 
      dgvMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuCut,
            menuCopy,
            menuPaste,
            menuDelete,
            menuSeparator1,
            menuSelectAll,
            menuSeparator2,
            menuFillWithZero});
      dgvMenuStrip.Name = "dgvMenuStrip";
      dgvMenuStrip.Size = new System.Drawing.Size(165, 148);
      // 
      // menuCut
      // 
      menuCut.Name = "menuCut";
      menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      menuCut.Size = new System.Drawing.Size(164, 22);
      menuCut.Text = "Cut";
      menuCut.Click += new System.EventHandler(MenuCut_Click);
      // 
      // menuCopy
      // 
      menuCopy.Name = "menuCopy";
      menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      menuCopy.Size = new System.Drawing.Size(164, 22);
      menuCopy.Text = "Copy";
      menuCopy.Click += new System.EventHandler(MenuCopy_Click);
      // 
      // menuPaste
      // 
      menuPaste.Name = "menuPaste";
      menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      menuPaste.Size = new System.Drawing.Size(164, 22);
      menuPaste.Text = "Paste";
      menuPaste.Click += new System.EventHandler(MenuPaste_Click);
      // 
      // menuDelete
      // 
      menuDelete.Name = "menuDelete";
      menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      menuDelete.Size = new System.Drawing.Size(164, 22);
      menuDelete.Text = "Delete";
      menuDelete.Click += new System.EventHandler(MenuDelete_Click);
      // 
      // menuSeparator1
      // 
      menuSeparator1.Name = "menuSeparator1";
      menuSeparator1.Size = new System.Drawing.Size(161, 6);
      // 
      // menuSelectAll
      // 
      menuSelectAll.Name = "menuSelectAll";
      menuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      menuSelectAll.Size = new System.Drawing.Size(164, 22);
      menuSelectAll.Text = "Select All";
      menuSelectAll.Click += new System.EventHandler(MenuSelectAll_Click);
      // 
      // menuSeparator2
      // 
      menuSeparator2.Name = "menuSeparator2";
      menuSeparator2.Size = new System.Drawing.Size(161, 6);
      // 
      // menuFillWithZero
      // 
      menuFillWithZero.Name = "menuFillWithZero";
      menuFillWithZero.Size = new System.Drawing.Size(164, 22);
      menuFillWithZero.Text = "Fill Blank Cells";
      menuFillWithZero.Click += new System.EventHandler(MenuFillWithZero_Click);
      // 
      // NftDataGridView
      // 
      CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(NFTDataGridView_CellContextMenuStripNeeded);
      CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(NFTDataGridView_CellMouseClick);
      CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(NFTDataGridView_CellMouseDown);
      CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(NFTDataGridView_CellValidating);
      ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(NFTDataGridView_ColumnAdded);
      DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(NFTDataGridView_DataError);
      EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(NFTDataGridView_EditingControlShowing);
      dgvMenuStrip.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      ResumeLayout(false);

    }

    #endregion

    /// <summary>
    /// nftDataGridView specfic settings, including it's menuStrip, whenever the 
    /// 'read-only' option is set to true or false. The default is false. 
    /// </summary>
    public bool nftReadOnly
    {
      get { return _nftReadOnly; }
      set
      {
        _nftReadOnly = value;
        if (_nftReadOnly)
        {
          EditMode = DataGridViewEditMode.EditProgrammatically;
          menuCut.Enabled = false;
          menuPaste.Enabled = false;
          menuDelete.Enabled = false;
          menuFillWithZero.Enabled = false;
        }
        else //nftReadOnly is False
        {
          EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
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
      ContextMenuStrip = dgvMenuStrip;
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
      if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right)
      {
        DataGridViewCell dgvCell = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];

        if (dgvCell.Selected)
        {
          return;
        }
        dgvCell.DataGridView.ClearSelection();
        dgvCell.DataGridView.CurrentCell = dgvCell;
        dgvCell.Selected = true;

      }
    }

    /// <summary>
    /// Launches the contextMenuStrip when the right mouse button is clicked on any cell of the data grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void NFTDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        if (SelectedCells.Count > 0)
        {
          ContextMenuStrip = dgvMenuStrip;
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
    private void MenuCut_Click(object sender, EventArgs e)
    {
      try
      {
        OnCopy();
        OnDelete();
        ClearSelection();
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show(
          "An error occured." + Environment.NewLine + Environment.NewLine + ex.Message.ToString(), "",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Event when the "Copy" menu option is selected. this will copy the contents of the data grid 
    /// to the clipboard.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuCopy_Click(object sender, EventArgs e)
    {
      OnCopy();
    }

    /// <summary>
    /// Event when the "Paste" menu option is selected. This will attempt to paste the contents of the 
    /// clipboard to the data grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuPaste_Click(object sender, EventArgs e)
    {
      try
      {
        OnPaste();
        ClearSelection();
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show(
          "An error occured." + Environment.NewLine + Environment.NewLine + ex.Message.ToString(), "",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Event when the "Delete" menu option is selected. This will clear the selected values in this data grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuDelete_Click(object sender, EventArgs e)
    {
      OnDelete();
      ClearSelection();
    }

    /// <summary>
    /// Event when the "Select All" menu option is selected. This will select all the cells in this data grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuSelectAll_Click(object sender, EventArgs e)
    {
      OnSelectAll();
    }

    /// <summary>
    /// Event when the "Fill Blank Cells" menu option is selected. This will fill applicable blank cells with zero.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MenuFillWithZero_Click(object sender, EventArgs e)
    {
      FillDBNullsWithZero();
      ClearSelection();
    }


    /// <summary>
    /// Handles when data-parsing/validations would throw exceptions. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NFTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      _ = MessageBox.Show(
        "An error occured." + Environment.NewLine + Environment.NewLine + e.Exception.Message.ToString(), "",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
      if (CurrentCell.IsInEditMode)
      {
        DataObject cellsToCopy = GetClipboardContent();
        if (cellsToCopy != null)
        {
          //There may be instances where a cell is in edit mode and part
          //of a cell selection at the same time.
          Clipboard.SetDataObject(cellsToCopy);
        }
        else
        {
          Clipboard.SetDataObject(CurrentCell.EditedFormattedValue);
        }

      }
      else
      {
        Clipboard.SetDataObject(GetClipboardContent());
      }

    }


    /// <summary>
    /// Pastes the contents from the system clipboard to the data grid.
    /// </summary>
    public void OnPaste()
    {
      //throw error if no cells are selected
      if (SelectedCells.Count == 0)
      {
        _ = MessageBox.Show("No cells selected. Please select a cell", "Paste", MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
        return;
      }

      string clipboardString = Clipboard.GetText();
      string[] clipboardLines = clipboardString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      int irow = CurrentCell.RowIndex;
      int icol = CurrentCell.ColumnIndex;
      DataGridViewCell oCell;

      //'copy-and-paste-multiple-cells-within-datagridview'
      foreach (string line in clipboardLines)
      {
        string[] cellsToPaste = line.Split('\t');
        int numCellsSelected = cellsToPaste.Length;
        if (irow < Rows.Count)
        {
          for (int x = 0; x < numCellsSelected; x++)
          {
            if (icol + x < Columns.Count)
            {
              oCell = this[icol + x, irow];
              if (oCell is DataGridViewComboBoxCell)
              {
                _ = MessageBox.Show(
                  $"At Row {oCell.RowIndex}, Column {oCell.ColumnIndex}:" +
                  $"{Environment.NewLine}Pasting any values to this type of cell is not allowed.",
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
      var selected = SelectedCells.Cast<DataGridViewCell>().ToList();
      if (selected.Count == 0)
        return; // Or show a warning message

      //LINQ method to get start and end indexes
      int startRow = selected.Min(x => x.RowIndex);
      int startCol = selected.Min(x => x.ColumnIndex);
      int endRow = selected.Max(x => x.RowIndex);
      int endCol = selected.Max(x => x.ColumnIndex);

      //"Delete" selected cells (by assigning them empty strings)
      for (int irow = startRow; irow < (endRow + 1); irow++)
      {
        for (int jcol = startCol; jcol < (endCol + 1); jcol++)
        {
          Rows[irow].Cells[jcol].Value = DBNull.Value;
        }
      }

    }

    /// <summary>
    /// Selects all the cells in this data grid.
    /// </summary>
    public void OnSelectAll()
    {
      SelectAll();
    }


    /// <summary>
    /// Fills cells with blank or null values with a zero.
    /// </summary>
    private void FillDBNullsWithZero()
    {
      for (int irow = 0; irow < Rows.Count; irow++)
      {
        for (int jcol = 0; jcol < Columns.Count; jcol++)
        {
          if (Rows[irow].Cells[jcol].Value is DBNull)
          {
            Rows[irow].Cells[jcol].Value = 0;
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

      foreach (DataGridViewRow dgvRow in Rows)
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

    private void NFTDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {

    }
  }
}
