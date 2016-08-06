﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGEPRO.GUI
{
    public partial class ControlBiological : UserControl
    {
        
        public ControlStochasticAge maturityAge;
        
        public ControlBiological()
        {
            InitializeComponent();

            maturityAge = new ControlStochasticAge();
            maturityAge.stochasticParameterLabel = "Maturity";
            maturityAge.isMultiFleet = false;
            maturityAge.Dock = DockStyle.Fill;
            
            tabMaturity.Controls.Add(maturityAge);

            
            
        }
        public DataTable fractionMortality
        {
            get { return (DataTable)dataGridFractionMortality.DataSource; }
            set { dataGridFractionMortality.DataSource = value; }
        }
        public bool fractionMortalityTimeVarying
        {
            get { return checkBoxFractionMortalityTimeVarying.Checked; }
            set { checkBoxFractionMortalityTimeVarying.Checked = value; }
        }
        

        private void dataGridFractionMortality_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRowHeaderCell header = dataGridFractionMortality.Rows[e.RowIndex].HeaderCell;

            if (header.Value == null)
            {
                dataGridFractionMortality.Rows[0].HeaderCell.Value = "Fraction F Prior to Spawn";
                dataGridFractionMortality.Rows[1].HeaderCell.Value = "Fraction M Prior to Spawn";
            }
        }

        private void checkBoxFractionMortalityTimeVarying_CheckedChanged(object sender, EventArgs e)
        {


        }
        
    }
}
