using StoreConev2.Modelo;
using StoreConev2.VistaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((VMListaProductos)BindingContext).Initialize();
        }
        public static ObservableCollection<Producto> Productos { get; internal set; }
    }
}