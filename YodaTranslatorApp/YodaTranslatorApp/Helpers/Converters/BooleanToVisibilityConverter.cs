using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace YodaTranslatorApp.Helpers.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Visibility.Hidden;

            if (value is bool)
            {
                var boolValue = (bool)value;
                var s = parameter as string;
                if (s != null && s == "invert")
                {
                    boolValue = !boolValue;
                }

                result = boolValue ? Visibility.Visible : Visibility.Hidden;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
