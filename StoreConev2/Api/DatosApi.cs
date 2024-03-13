using Newtonsoft.Json;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace StoreConev2.ApiMetodos
{
    public class DatosApi
    {
        //Lista de los Productos
        public ObservableCollection<Producto2> Productos { get; set; }
        public async Task<ObservableCollection<Historial>> ObtenerHistorial()
        {
            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Historial/Listar");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var historial = JsonConvert.DeserializeObject<List<Historial>>(json);
                return new ObservableCollection<Historial>(historial);
            }
            else
            {
                // Manejo de errores
                return new ObservableCollection<Historial>();
            }
        }
       public static HttpClient client = new HttpClient(); //Al hacerlo estatico, mejora el rendimiento de la aplicacion

        public async Task<ObservableCollection<Producto2>> ObtenerProductos()
        {
            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Producto/Listar");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto2>>(json);
                return new ObservableCollection<Producto2>(productos);
            }
            else
            {
                // Manejo de errores
                return new ObservableCollection<Producto2>();
            }
        }
        public async Task<ObservableCollection<Proveedor>> ObtenerProveedor()
        {
            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Proveedor/Listar");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var proveedor = JsonConvert.DeserializeObject<List<Proveedor>>(json);
                return new ObservableCollection<Proveedor>(proveedor);
            }
            else
            {
                // Manejo de errores
                return new ObservableCollection<Proveedor>();
            }
        }
        public async Task<Scaner> ScanerPistola()
        {
            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Pistola/ultimo");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pistola = JsonConvert.DeserializeObject<Scaner>(json);
                return pistola;
            }
            else
            {
                // Manejo de errores
                return null;
            }
        }

        public async Task<Producto2> ObtenerProductobyCodigo(long codigo)
        {
            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Producto/BuscarPorCodigo");
            var client = new HttpClient();

            var jsonContent = codigo.ToString();
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(RequestUri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto2>(json);
                return producto;
            }
            else
            {
                // Manejo de errores
                return null;
            }
        }


        public async Task<ObservableCollection<Producto2>> ObtenerProductosSeccionA()
        {
            var AllProductos = await ObtenerProductos();
            var productiosSeccionA = new ObservableCollection<Producto2>
                (AllProductos.Where(p => p.Seccion == "1A" || p.Seccion == "2A" || p.Seccion == "3A"
                || p.Seccion == "4A"));
            return productiosSeccionA;
        }

        public async Task <ObservableCollection<Producto2>>ObtenerProductosSeccionB()
        {
            var AllProductos = await ObtenerProductos();
            var productiosSeccionB= new ObservableCollection<Producto2>
                (AllProductos.Where(p=>p.Seccion=="1B" || p.Seccion=="2B" || p.Seccion == "3B"
                || p.Seccion=="4B"));
            return productiosSeccionB;
        }
        public async Task<ObservableCollection<Producto2>> ObtenerProductosSeccionC()
        {
            var AllProductos = await ObtenerProductos();
            var productiosSeccionC = new ObservableCollection<Producto2>
                (AllProductos.Where(p => p.Seccion == "1C" || p.Seccion == "2C" || p.Seccion == "3C"
                || p.Seccion == "4C"));
            return productiosSeccionC;
        }
        public async Task<ObservableCollection<Producto2>> ObtenerProductosSeccionD()
        {
            var AllProductos = await ObtenerProductos();
            var productiosSeccionD = new ObservableCollection<Producto2>
                (AllProductos.Where(p => p.Seccion == "1D" || p.Seccion == "2D" || p.Seccion == "3D"
                || p.Seccion == "4D"));
            return productiosSeccionD;
        }

        //Metodo para insertar mermas con la api
        public async Task InsertarMerma(Merma mmerma)
        {
            
            Uri RequestUri = new
                Uri("http://www.StoreConev3.somee.com/Api/Mermas/Insertar");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mmerma);
            var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri,
                contenJson);
            if (response.StatusCode == HttpStatusCode.Created)
            {
             await   Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Merma registrada con éxito.", "OK");

            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Error al registrar.", "OK");

            }

        }
        public async Task InsertarProducto(Producto2 producto)
        {

            Uri RequestUri = new Uri("http://www.StoreConev3.somee.com/Api/Producto/Crear");

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(producto);
            var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri,
                contenJson);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Producto registrado con éxito.", "OK");

            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Error al registrar.", "OK");

            }

        }

    }

   
}
