using System.Globalization;

namespace AutoGestor360App.Tools;

public class StatusApiColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool status)
        {
            Application.Current!.Resources.TryGetValue("Primary", out var primary);
            Color primaryColor = (Color)primary;
            return status ? primaryColor : Colors.Red;
        }

        return Colors.Gray;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
