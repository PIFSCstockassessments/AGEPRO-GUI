using Nmfs.Agepro.CoreLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nmfs.Agepro.Gui
{
  public class AgeproCalculationLauncher
  {
    public ControlMiscOptions AgeproUserOptions { get; private set; }

    public AgeproCalculationLauncher(ControlMiscOptions options)
    {
      AgeproUserOptions = options;
    }

    /// <summary>
    /// Launches the AGEPRO Calcuation Engine Program
    /// </summary>
    /// <param name="inpFile"></param>
    static void LaunchAgeproCalcEngineProgram(string inpFile)
    {
      _ = Path.GetPathRoot(Environment.SystemDirectory);

      ProcessStartInfo ageproEngine = new ProcessStartInfo
      {
        WorkingDirectory = Application.StartupPath,
        FileName = "AGEPRO.exe",  // "AGEPRO40.exe",
        Arguments = "\"\"" + inpFile + "\"\"",
        WindowStyle = ProcessWindowStyle.Normal
      };

      try
      {
        using (Process exeProcess = Process.Start(ageproEngine))
        {
          exeProcess.WaitForExit();
        }
        _ = MessageBox.Show("AGEPRO Done. Can be Found at:" + Environment.NewLine + Path.GetDirectoryName(inpFile), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show("An error occured when running the AGEPRO Model." + Environment.NewLine + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    /// <summary>
    /// Launches a program to view the AGEPRO calcuation engine output file
    /// </summary>
    /// <param name="outfile">AGEPRO calcuation engine output file</param>
    /// <param name="outputOptions"></param>
    static void LaunchOutputViewerProgram(string outfile, ControlMiscOptions outputOptions)
    {

      if (!File.Exists(outfile)) 
      { 
        throw new FileNotFoundException($"The AGEPRO output file was not found at: {outfile}");
      }

      if (string.IsNullOrEmpty(outfile))
      {
        throw new ArgumentException($"'{nameof(outfile)}' cannot be null or empty.", nameof(outfile));
      }

      if (outputOptions is null)
      {
        throw new ArgumentNullException(nameof(outputOptions));
      }

      if (outputOptions.AgeproOutputViewer == "System Default")
      {
        //open a program that is associated by its file type.
        //If no association exists, system will ask user for a program. 
        _ = Process.Start(outfile);
      }
      else if (outputOptions.AgeproOutputViewer == "Notepad")
      {
        _ = Process.Start("notepad.exe", outfile);
      }

    }

    /// <summary>
    /// This gathers the bootstrap file, and stores it with the the GUI input under the "AGEPRO" subdirectory
    /// in the desginagted user document directory. After the calcuation engine is done, the function will 
    /// attempt to display the AGEPRO calcuation engine output file (if requested) and the directory the
    /// outputs were written to.       
    /// </summary>
    public void LaunchAgeproModel(AgeproInputFile ageproData, string inputFile = "")
    {
      string ageproModelJobName;
      string jobDT;

      //Set the user data work directory  
      if (string.IsNullOrWhiteSpace(inputFile))
      {
        ageproModelJobName = "untitled_";
        jobDT = string.Format(ageproModelJobName + "_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
      }
      else
      {
        ageproModelJobName = Path.GetFileNameWithoutExtension(inputFile);
        //Remove potential invalid filename characters 
        foreach (char c in Path.GetInvalidFileNameChars())
        {
          ageproModelJobName = ageproModelJobName.Replace(c.ToString(), "");
        }
        jobDT = string.Format(ageproModelJobName + "_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
      }
      string ageproWorkPath = Path.Combine(Util.GetAgeproUserDataPath(), jobDT);
      string inpFile = Path.Combine(ageproWorkPath, ageproModelJobName + ".INP");
      string bsnFile = Path.Combine(ageproWorkPath, ageproModelJobName + ".BSN");

      if (!Directory.Exists(ageproWorkPath))
      {
        _ = Directory.CreateDirectory(ageproWorkPath);
      }

      //check for bootstrap file
      //1. File Exists from the bootstrap parameter
      if (File.Exists(ageproData.Bootstrap.BootstrapFile))
      {
        File.Copy(ageproData.Bootstrap.BootstrapFile, bsnFile, true);
      }
      //2. If not, in the same directory as the AGEPRO Input File
      else if (File.Exists($"{Path.GetDirectoryName(ageproData.General.InputFile)}\\{Path.GetFileName(ageproData.Bootstrap.BootstrapFile)}"))
      {
        File.Copy($"{Path.GetDirectoryName(ageproData.General.InputFile)}\\{Path.GetFileName(ageproData.Bootstrap.BootstrapFile)}",
            bsnFile, true);
      }
      //3. Else, Explictly locate the bootstrap file (via OpenFileDialog).
      else
      {
        OpenFileDialog openBootstrapFileDialog = ControlBootstrap.SetBootstrapOpenFileDialog();

        if (openBootstrapFileDialog.ShowDialog() == DialogResult.OK)
        {
          File.Copy(openBootstrapFileDialog.FileName, bsnFile, true);
        }
        else
        {
          Console.WriteLine("Cancel Launch AGEPRO Model");
          //If user declines (Cancel), do not Launch AGEPRO Calc Engine
          return;
        }
      }
      //Store original bootstrap filename in case of error
      string originalBSNFile = ageproData.Bootstrap.BootstrapFile;

      try
      {
        //TODO:Split TryCatch to accomdate (pre) launch AGEPRO and (post) output proccessing errors.

        //Set bootstrap filename to copied workDir version
        ageproData.Bootstrap.BootstrapFile = bsnFile;

        //Write Interface Inputs to file
        ageproData.WriteInputFile(inpFile);

        //use command line to open AGEPRO.exe //AGEPRO40.exe
        LaunchAgeproCalcEngineProgram(inpFile);

        //crude method to create AGEPRO Calcuation Engine output file
        string ageproOutfile = Path.ChangeExtension(inpFile,".out");

        LaunchOutputViewerProgram(ageproOutfile, AgeproUserOptions);

        //Open WorkPath directory for the user 
        _ = Process.Start(ageproWorkPath);
      }
      catch (Exception ex)
      {
        _ = MessageBox.Show("An error occured when Launching the AGEPRO Model." + Environment.NewLine + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        //reset original bootstrap filename 
        ageproData.Bootstrap.BootstrapFile = originalBSNFile;
      }
    }
  }
}