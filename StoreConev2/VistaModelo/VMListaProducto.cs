using Newtonsoft.Json;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace StoreConev2.VistaModelo
{
    public class VMListaProducto
    {

        public async Task<List<Producto>> ObtenerProductos()
        {
            Uri RequestUri = new Uri("http://www.ApiStore.somee.com/Api/Producto/Listar");
            var client = new HttpClient();
            var response = await client.GetAsync(RequestUri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var proveedores = JsonConvert.DeserializeObject<List<Producto>>(json);
                return proveedores;
            }
            else
            {
                // Manejo de errores
                return null;
            }
        }
        public async Task<List<Producto2>> GetProductosAsync()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("http://www.ApiStore.somee.com/Api/Producto/Listar");
            var productos = JsonConvert.DeserializeObject<List<Producto2>>(response);
            return productos;
        }


    }
}
