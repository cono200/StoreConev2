using System.Globalization;
using System;
using Xamarin.Forms;

public class ActionColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var action = (string)value;
        switch (action)
        {
            case "Registro":
                return Color.LightGreen;
            case "Mermas":
                return Color.LightBlue;
            case "Eliminación":
                return Color.LightSalmon;
            default:
                return Color.Gray;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
