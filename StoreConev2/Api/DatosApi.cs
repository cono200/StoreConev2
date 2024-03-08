using Newtonsoft.Json;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreConev2.ApiMetodos
{
    public class DatosApi
    {
        public async Task<ObservableCollection<Producto2>> ObtenerProductos()
        {
            Uri RequestUri = new Uri("http://www.StoreConev2.somee.com/Api/Producto/Listar");
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
    }
}
