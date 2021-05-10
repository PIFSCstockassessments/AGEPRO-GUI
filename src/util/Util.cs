using System;

namespace Nmfs.Agepro.Gui
{
  class Util
  {
    /// <summary>
    /// Platform-indpendnent method to get AGEPRO subdirectory to user's 'My Documents' path. If
    /// the subdirectory doesn't exist may create one. 
    /// </summary>
    /// <returns>Filename string path of AGEPRO subdirectory.</returns>
    static public string GetAgeproUserDataPath()
    {
      string appDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      appDir = System.IO.Path.Combine(appDir, "AGEPRO");
      if (!System.IO.Directory.Exists(appDir))
      {
        //TODO: ASK USER TO CREATE DIRECTORY
        _ = System.IO.Directory.CreateDirectory(appDir);
      }
      return appDir;
    }

  }
}
