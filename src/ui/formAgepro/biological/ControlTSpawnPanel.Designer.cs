
namespace Nmfs.Agepro.Gui
{
  partial class ControlTSpawnPanel
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.dataGridTSpawn = new Nmfs.Agepro.Gui.NftDataGridView();
      this.checkBoxTSpawnTimeVarying = new System.Windows.Forms.CheckBox();
      this.LabelTSpawn = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridTSpawn)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridTSpawn
      // 
      this.dataGridTSpawn.AllowUserToAddRows = false;
      this.dataGridTSpawn.AllowUserToDeleteRows = false;
      this.dataGridTSpawn.AllowUserToResizeRows = false;
      this.dataGridTSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridTSpawn.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dataGridTSpawn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridTSpawn.Location = new System.Drawing.Point(27, 73);
      this.dataGridTSpawn.Name = "dataGridTSpawn";
      this.dataGridTSpawn.nftReadOnly = false;
      this.dataGridTSpawn.RowHeadersWidth = 180;
      this.dataGridTSpawn.Size = new System.Drawing.Size(840, 85);
      this.dataGridTSpawn.TabIndex = 2;
      this.dataGridTSpawn.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridTSpawn_CellFormatting);
      // 
      // checkBoxTSpawnTimeVarying
      // 
      this.checkBoxTSpawnTimeVarying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBoxTSpawnTimeVarying.AutoSize = true;
      this.checkBoxTSpawnTimeVarying.Location = new System.Drawing.Point(772, 50);
      this.checkBoxTSpawnTimeVarying.Name = "checkBoxTSpawnTimeVarying";
      this.checkBoxTSpawnTimeVarying.Size = new System.Drawing.Size(87, 17);
      this.checkBoxTSpawnTimeVarying.TabIndex = 3;
      this.checkBoxTSpawnTimeVarying.Text = "Time Varying";
      this.checkBoxTSpawnTimeVarying.UseVisualStyleBackColor = true;
      this.checkBoxTSpawnTimeVarying.CheckedChanged += new System.EventHandler(this.CheckBoxTSpawnTimeVarying_CheckedChanged);
      // 
      // LabelTSpawn
      // 
      this.LabelTSpawn.AutoSize = true;
      this.LabelTSpawn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LabelTSpawn.Location = new System.Drawing.Point(24, 51);
      this.LabelTSpawn.Name = "LabelTSpawn";
      this.LabelTSpawn.Size = new System.Drawing.Size(261, 13);
      this.LabelTSpawn.TabIndex = 4;
      this.LabelTSpawn.Text = "Fraction Mortality Prior to Spawning (tspawn)";
      // 
      // ControlTSpawnPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.LabelTSpawn);
      this.Controls.Add(this.checkBoxTSpawnTimeVarying);
      this.Controls.Add(this.dataGridTSpawn);
      this.MinimumSize = new System.Drawing.Size(900, 480);
      this.Name = "ControlTSpawnPanel";
      this.Size = new System.Drawing.Size(900, 480);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridTSpawn)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private NftDataGridView dataGridTSpawn;
    private System.Windows.Forms.CheckBox checkBoxTSpawnTimeVarying;
    private System.Windows.Forms.Label LabelTSpawn;
  }
}
