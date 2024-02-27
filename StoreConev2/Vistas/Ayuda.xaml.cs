using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ayuda : ContentPage
    {
        public Ayuda()
        {
            InitializeComponent();
            var htmlconent = new HtmlWebViewSource();
            htmlconent.Html = "<html><head> </head><body>" +
                "<iframe width=\'560\' height=\'315\' src=\'https://www.youtube.com/embed/PyoRdu-i0AQ?si=kpr8bx_LEQZk5i6B\' title=\'YouTube video player\' frameborder=\'0\' allow=\'accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\'allowfullscreen></iframe>" + "</body></html>";
            Video.Source = htmlconent;

        }
    }
}