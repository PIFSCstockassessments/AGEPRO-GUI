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
            string appDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            appDir = System.IO.Path.Combine(appDir, "AGEPRO");
            if (!System.IO.Directory.Exists(appDir))
            {
                System.IO.Directory.CreateDirectory(appDir);
            }
            return appDir;
        }

        //create temp
    }
}
