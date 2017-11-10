using System;
using System.Globalization;
using System.Windows.Data;

namespace YodaTranslatorApp.Converters
{
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringData = value as string;

            return !(string.IsNullOrEmpty(stringData) || string.IsNullOrWhiteSpace(stringData));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
