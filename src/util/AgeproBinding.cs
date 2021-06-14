using System;
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
      _converter = valueConverter;
      _converterCulture = culture;
      _converterParameter = converterParameter;
    }

    protected override void OnFormat(ConvertEventArgs cevent)
    {
      if (_converter == null)
      {
        base.OnFormat(cevent);
      }
      else
      {
        object convertedValue = _converter.Convert(cevent.Value, cevent.DesiredType, _converterParameter, _converterCulture);
        cevent.Value = convertedValue;
      }

    }


    protected override void OnParse(ConvertEventArgs cevent)
    {
      if (_converter == null)
      {
        base.OnParse(cevent);
      }
      else
      {
        object valueFromCtl = _converter.ConvertBack(cevent.Value, cevent.DesiredType, _converterParameter, _converterCulture);
        cevent.Value = valueFromCtl;
      }

    }
  }
}
