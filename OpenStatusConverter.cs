using System;
using System.Globalization;
using System.Windows.Data;

namespace TistoryCategoryManager
{
    public class OpenStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Y")
            {
                return "공개";
            }
            else
            {
                return "비공개";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
