using Newtonsoft.Json;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

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
        //Metodo para insertar mermas con la api
        public async Task InsertarMerma(Merma mmerma)
        {
            
            Uri RequestUri = new
                Uri("http://www.StoreConev2.somee.com/Api/Mermas/Insertar");
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
    }

   
}
