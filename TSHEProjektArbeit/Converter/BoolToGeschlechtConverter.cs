using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
namespace TSHEProjektArbeit.Converter
{
    class BoolToGeschlechtConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return "XX";
                }
            }
            return "XY";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals("XX"))
            {
                {
                    return true;
                }
            }
            return false;
        }
    }
}



