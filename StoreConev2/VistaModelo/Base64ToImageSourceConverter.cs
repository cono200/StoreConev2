using System;
using Xamarin.Forms;
using System.IO;
using System.Globalization;

namespace StoreConev2.VistaModelo
{
    public class Base64ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            // Convierte la cadena base64 en un array de bytes
            byte[] imageBytes = System.Convert.FromBase64String((string)value);

            // Convierte el array de bytes en un Stream
            Stream stream = new MemoryStream(imageBytes);

            // Crea una nueva ImageSource a partir del Stream y devuélvela
            return ImageSource.FromStream(() => stream);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
