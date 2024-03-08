using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConev2.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProductos : ContentPage
    {
        public ListaProductos()
        {
            InitializeComponent();
            BindingContext = new VMListaProducto(Navigation);
        }

    }
}