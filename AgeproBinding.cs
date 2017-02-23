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
        public AgeproBinding(string propertyName, object dataSource, string dataMember) 
            : base(propertyName, dataSource, dataMember, true)
        {

        }

        
    }
}
