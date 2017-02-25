using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmfs.Agepro.Gui
{
    public class NullableDoubleStringValueConverter : IValueConverter
    {
        //custom-winforms-data-binding-with-converter-not-working-on-nullable-type-double
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? ((double)value).ToString(culture) : string.Empty;
        }

        public Object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var textVal = value != null ? ((string)value).Trim() : null;
            return !string.IsNullOrEmpty(textVal) ? (object)double.Parse(textVal, System.Globalization.NumberStyles.Any, culture) : null;
            
        }
    }

    public class ScaleFactorStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((double)value > 0)
            {
                return ((double)value).ToString(culture);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Data object returned invaild Scale Factor. Default to 1.");
                return 1;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                double factorVal;
                string textVal = ((string)value).Trim();

                if (double.TryParse(textVal, out factorVal))
                {
                    if (factorVal > 0)
                    {
                        return (object)factorVal;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(parameter.ToString() 
                            + " should be a positive, non-zero number.",
                            "AGEPRO",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(parameter.ToString() 
                        + " is not a vaild double numeric data type.",
                        "AGEPRO",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);                 
                }
            }
            return null; //failstate
        }
    }
}
