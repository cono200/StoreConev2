using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.Modelo;
//libreria de Json para que jale la api
using Newtonsoft.Json;


namespace StoreConev2.VistaModelo
{
    public class VMproveedor : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Id;
        string _Name;
        int _Telefono;
        string _Correo;
        string _Producto;

        #endregion
        #region CONSTRUCTOR
        public VMproveedor(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }
        }
        public string Nombre
        {
            get { return _Name; }
            set { SetValue(ref _Name, value); }
        }
        public int Telefono
        {
            get { return _Telefono; }
            set { SetValue(ref _Telefono, value); }
        }
        public string Correo
        {
            get { return _Correo; }
            set { SetValue(ref _Correo, value); }
        }
        public string Producto
        {
            get { return _Producto; }
            set { SetValue(ref _Producto, value); }
        }

        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task Insertar()
        {
            Proveedor mcorredor = new Proveedor
            {
                //  Id = Id, no debes poner id
                Nombre = Nombre,
                Telefono = Telefono,
                Correo = Correo,
                Producto = Producto

            };
            Uri RequestUri = new
                Uri("http://www.ApiStore.somee.com/Api/Proveedor/Create");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mcorredor);
            var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri,
                contenJson);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                await DisplayAlert("Mensaje", "Registrado", "Ok");
            }
            else
            {
                await DisplayAlert("Mensaje", "No se registro", "Ok");
            }

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand InsertarProveedor => new Command(async () => await Insertar());

        #endregion
    }
}
