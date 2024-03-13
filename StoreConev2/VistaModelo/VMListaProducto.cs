using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace StoreConev2.VistaModelo
{
    public class VMListaProducto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Producto2> _productos;
        private INavigation navigation;

        public ObservableCollection<Producto2> Productos
        {
            get { return _productos; }
            set
            {
                _productos = value;
                OnPropertyChanged(nameof(Productos));
            }
        }



        public VMListaProducto(INavigation navigation)
        {
            this.navigation = navigation;
            LoadProductos();

        }

        public async Task LoadProductos()
        {
            var funcion = new DatosApi();
            Productos = await funcion.ObtenerProductos();
        }

       
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
