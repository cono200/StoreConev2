using Newtonsoft.Json;
using StoreConev2.Modelo;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class VMListaProductos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Producto> Productos { get; set; }
        public ObservableCollection<Producto> ProductosSeccionA { get; set; }

        public INavigation Navigation { get; }

        //public VMListaProductos()
        //{
        //    // Aquí cargarías tu lista de productos desde algún origen de datos
        //    Productos = await ObtenerProductos();
        //    ProductosSeccionA = ObtenerProductosSeccionA(); // Inicializar ProductosSeccionA
        //}
        public async Task Initialize()
        {
            Productos = await ObtenerProductos();
            ProductosSeccionA = ObtenerProductosSeccionA();
        }
        //public VMListaProductos(INavigation navigation)
        //{
        //    Navigation = navigation;
        //    Productos = await ObtenerProductos();
        //    ProductosSeccionA = ObtenerProductosSeccionA();
        //}

        public ObservableCollection<Producto> ObtenerProductosSeccionA()
        {
            return new ObservableCollection<Producto>(Productos.Where(p => p.Seccion == "A"));
               
        }

        public ObservableCollection<Producto> ObtenerProductosSeccionB()
        {
            return new ObservableCollection<Producto>(Productos.Where(p => p.Seccion == "B"));
        }

        public ObservableCollection<Producto> ObtenerProductosSeccionC()
        {
            return new ObservableCollection<Producto>(Productos.Where(p => p.Seccion == "C"));
        }

        public ObservableCollection<Producto> ObtenerProductosSeccionD()
        {
            return new ObservableCollection<Producto>(Productos.Where(p => p.Seccion == "D"));
        }

        //ObservableCollection<Producto> ObtenerProductos()
        //{
        //    // Aquí obtendrías tus productos de algún servicio o base de datos
        //    // Por ejemplo, podrías crear algunos productos de muestra aquí
        //    return new ObservableCollection<Producto>
        //    {
        //        new Producto { Codigo = "13015", Nombre = "Pintura Roja", Seccion = "A", ProveedorId = "Comex", Cantidad = 10, Descripcion = "Descripción del producto 1", Precio = 20 },
        //        new Producto { Codigo = "45052", Nombre = "Brochas", Seccion = "B", ProveedorId = "Brochero", Cantidad = 20, Descripcion = "Descripción del producto 2", Precio = 30 },
        //        new Producto { Codigo = "88888", Nombre = "Pintura Azul", Seccion = "A", ProveedorId = "Comex", Cantidad = 40, Descripcion = "Descripción del producto 3", Precio = 70 },
        //        new Producto { Codigo = "77777", Nombre = "Pintura Verde", Seccion = "A", ProveedorId = "Comex", Cantidad = 27, Descripcion = "Descripción del producto 4", Precio = 25 },
        //        new Producto { Codigo = "66666", Nombre = "Pintura Café", Seccion = "A", ProveedorId = "Comex", Cantidad = 18, Descripcion = "Descripción del producto 5", Precio = 60 },
        //        new Producto { Codigo = "84980", Nombre = "Leche Yaqui", Seccion = "C", ProveedorId = "Yaqui", Cantidad = 49, Descripcion = "Descripción del producto 5", Precio = 60 },
        //        new Producto { Codigo = "66640", Nombre = "Impermeabilizante", Seccion = "D", ProveedorId = "Comex", Cantidad = 18, Descripcion = "Descripción del producto 5", Precio = 60 }
        //        // Agrega más productos según sea necesario
        //    };
        //}
        public async Task<ObservableCollection<Producto>> ObtenerProductos()
        {
            Uri RequestUri = new Uri("http://www.ApiStore.somee.com/Api/Producto/Listar");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto>>(json);
                return new ObservableCollection<Producto>(productos);
            }
            else
            {
                // Manejo de errores
                return new ObservableCollection<Producto>();
            }
        }

    }
}
