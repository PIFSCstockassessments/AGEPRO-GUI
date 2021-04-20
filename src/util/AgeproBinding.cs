using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Nmfs.Agepro.Gui
{
  public interface IValueConverter
  {
    object Convert(object value, Type targetType, object parameter, CultureInfo culture);
    object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
  }

  public class AgeproBinding : Binding
  {
    private readonly IValueConverter _converter;
    private readonly object _converterParameter;
    private readonly CultureInfo _converterCulture;


    public AgeproBinding(string propertyName, object dataSource, string dataMember, IValueConverter valueConverter, object converterParameter = null)
        : this(propertyName, dataSource, dataMember, valueConverter, System.Threading.Thread.CurrentThread.CurrentUICulture, converterParameter)
    {

    }

    public AgeproBinding(string propertyName, object dataSource, string dataMember, IValueConverter valueConverter, CultureInfo culture, object converterParameter = null)
        : base(propertyName, dataSource, dataMember, true)
    {
      this._converter = valueConverter;
      this._converterCulture = culture;
      this._converterParameter = converterParameter;
    }

    protected override void OnFormat(ConvertEventArgs cevent)
    {
      if (this._converter != null)
      {
        var convertedValue = this._converter.Convert(cevent.Value, cevent.DesiredType, this._converterParameter, this._converterCulture);
        cevent.Value = convertedValue;
      }
      else
      {
        base.OnFormat(cevent);
      }

    }


    protected override void OnParse(ConvertEventArgs cevent)
    {
      if (this._converter != null)
      {
        var valueFromCtl = this._converter.ConvertBack(cevent.Value, cevent.DesiredType, this._converterParameter, this._converterCulture);
        cevent.Value = valueFromCtl;
      }
      else
      {
        base.OnParse(cevent);
      }

    }
  }
}
