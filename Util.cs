using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGEPRO.GUI
{
    class Util
    {
        static public string GetAgeproUserDataPath()
        {
            string appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDir = System.IO.Path.Combine(appDir, System.Windows.Forms.Application.ProductName);
            if (!System.IO.Directory.Exists(appDir))
            {
                System.IO.Directory.CreateDirectory(appDir);
            }
            return appDir;
        }

        //create temp
    }
}
