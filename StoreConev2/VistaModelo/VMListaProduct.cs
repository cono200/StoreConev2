using Newtonsoft.Json;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StoreConev2.VistaModelo;
using System.Collections.ObjectModel;
using StoreConev2.Api;
namespace StoreConev2.VistaModelo
{
    public class VMListaProduct : INotifyPropertyChanged
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

       

        public VMListaProduct(INavigation navigation)
        {
            this.navigation = navigation;
            LoadProductos();

        }

        public async Task LoadProductos()
        {
            var funcion = new MetodosApi();
            Productos = await funcion.ObtenerProductos();
        }

        // Aquí iría tu método GetProductosAsync()...
        //AKI ESTUBO EL CONO
        //public async Task<List<Producto2>> GetProductosAsync()
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetStringAsync("http://www.ApiStore.somee.com/Api/Producto/Listar");
        //    var productos = JsonConvert.DeserializeObject<List<Producto2>>(response);
        //    return productos;
        //}
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
