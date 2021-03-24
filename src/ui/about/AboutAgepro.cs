using System;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace Nmfs.Agepro.Gui
{
  partial class AboutAgepro : Form
  {
    public AboutAgepro()
    {
      InitializeComponent();
      Text = string.Format("About {0}", AssemblyTitle);
      labelProductName.Text = AssemblyProduct;
      labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
      labelCopyright.Text = AssemblyCopyright;
      labelCompanyName.Text = AssemblyCompany;
      textBoxDescription.Text = AssemblyDescription;

      //NMFS Licensing
      string nmfsLicenseFile =
          Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LICENSE.md");

      if (!File.Exists(nmfsLicenseFile))
      {
        nmfsLicense = null;
      }
      else
      {
        nmfsLicense = string.Join(" ", File.ReadAllLines(nmfsLicenseFile));
      }
    }

    private string _nmfsLicense;


    #region Assembly Attribute Accessors

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
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

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

    public string nmfsLicense { get => _nmfsLicense; set => _nmfsLicense = value; }
    #endregion

    /// <summary>
    /// Used to override default WinForms About Box AssemblyDescription text. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AboutAgepro_Load(object sender, EventArgs e)
    {
      //textBoxDescription: Override AssemblyDescription with this text.
      textBoxDescription.Text = "Interface Version: " + AssemblyVersion + Environment.NewLine +
          "Calcuation Engine Version: 4.0" + Environment.NewLine + Environment.NewLine +
          nmfsLicense;
    }
  }
}
