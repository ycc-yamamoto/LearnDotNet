using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp;

public sealed class DateTimeToStringConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text)
        {
            if (DateTime.TryParse(text, out var dateTime))
            {
                return dateTime;
            }
        }
        
        return Binding.DoNothing;
    }
}