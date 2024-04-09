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
using System.Windows.Input;

namespace StoreConev2.VistaModelo
{
    public class VMListaProducto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Producto2> _productos;
        private ObservableCollection<Merma> _merma;
        private bool _isRefreshing; // Agrega esta línea
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
        public ObservableCollection<Merma> Mermas
        {
            get { return _merma; }
            set
            {
                _merma = value;
                OnPropertyChanged(nameof(Productos));
            }
        }

        public bool IsRefreshing // Agrega esta propiedad
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
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

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await LoadProductos();

                    IsRefreshing = false;
                });
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
