using System;
using System.Globalization;
using Xamarin.Forms;

namespace StoreConev2.Triggers
{
    public class LineasColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var action = (string)value;
            switch (action)
            {
                case "Registrado":
                    return Color.LightGreen;
                case "mermado":
                    return Color.LightBlue;
                case "Eliminado":
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
}
