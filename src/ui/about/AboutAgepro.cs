using System;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Nmfs.Agepro.Gui
{
  partial class AboutAgepro : Form
  {
    public string NmfsLicense { get; set; }
    
    public AboutAgepro()
    {
      InitializeComponent();
      Text = string.Format("About {0}", AssemblyTitle);
      labelProductName.Text = AssemblyProduct;
      labelVersion.Text = string.Format("AGEPRO-GUI {0}", AssemblyVersion);
      labelCopyright.Text = AssemblyCopyright;
      labelCompanyName.Text = AssemblyCompany;
      textBoxDescription.Text = AssemblyDescription;

      //NMFS Licensing
      string nmfsLicenseFile =
          Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                       "LICENSE.md");

      NmfsLicense = File.Exists(nmfsLicenseFile) ? string.Join(" ", File.ReadAllLines(nmfsLicenseFile)) : null;
    }

    #region Assembly Attribute Accessors
    
    /// <summary>
    /// Attribute used for About dialog title.
    /// </summary>
    public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "")
          {
            return titleAttribute.Title;
          }
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    /// <summary>
    /// Attribute for AGEPRO (GUI) version
    /// </summary>
    public string AssemblyVersion
    {
      get
      {
        //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        return Resources.AgeproStrings.GUI_Version;
      }
    }

    /// <summary>
    /// Attribute to get AGEPRO descripton
    /// </summary>
    public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    /// <summary>
    /// Attribute to get product name AGEPRO
    /// </summary>
    public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    /// <summary>
    /// Copyright/Attribution 
    /// </summary>
    public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    /// <summary>
    /// Org/Company
    /// </summary>
    public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }

    #endregion

    /// <summary>
    /// Used to override default WinForms About Box AssemblyDescription text. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AboutAgepro_Load(object sender, EventArgs e)
    {
      //textBoxDescription: Override AssemblyDescription with this text.
      textBoxDescription.Text = $"GUI Version {AssemblyVersion}{Environment.NewLine}" +
        $"AGEPRO Calcuation Engine Version {Resources.AgeproStrings.AGEPRO_Version}{Environment.NewLine}" +
        $"{Environment.NewLine}" +
        $"AGEPRO Calculation Engine is built by Jon Brodziak.{Environment.NewLine}" +
        $"{Environment.NewLine}" +
        $"{NmfsLicense}";
    }
  }
}
