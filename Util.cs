using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmfs.Agepro.Gui
{
    class Util
    {
        static public string GetAgeproUserDataPath()
        {
            string appDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            appDir = System.IO.Path.Combine(appDir, "AGEPRO");
            if (!System.IO.Directory.Exists(appDir))
            {
                System.IO.Directory.CreateDirectory(appDir);
            }
            return appDir;
        }

        /// <summary>
        /// Generalized Method to set the DataGridView's Data Sources from Nmfs.Agepro.CoreLib Input File Data Files 
        /// </summary>
        /// <param name="dgvTable">Control's DataGridView DataTable source</param>
        /// <param name="inpFileTable">DataTable from Nmfs.Agepro.CoreLib.AgeproInputFile DataTables</param>
        /// <returns>DataGridView DataTable</returns>
        public static System.Data.DataTable GetAgeproInputDataTable(System.Data.DataTable dgvTable, 
            System.Data.DataTable inpFileTable)
        {
            if (dgvTable != null)
            {
                dgvTable.Reset();
            }
            dgvTable = inpFileTable;
            return dgvTable;
        }
    }
}
