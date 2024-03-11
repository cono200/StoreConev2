using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConev2.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notificaciones : ContentPage
    {
        public Notificaciones()
        {
            InitializeComponent();
            BindingContext = new VMNotificaciones(Navigation);
            //BindingContext = new VMRegistrarProducto(Navigation);
        }
    }
}