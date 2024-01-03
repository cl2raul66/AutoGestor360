using System.Globalization;

namespace AutoGestor360App.Tools;

public class StatusApiTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool status)
        {
            return status ? "Conectado" : "Desconectado";
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
