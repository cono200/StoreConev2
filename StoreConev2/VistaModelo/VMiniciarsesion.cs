using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.Vistas;
using StoreConev2.ApiMetodos;
using Xamarin.Essentials;
using System.Linq;
namespace StoreConev2.VistaModelo
{
    public class VMiniciarsesion : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _NombreUsuario;
        private string _contrasena;

        #endregion
        #region CONSTRUCTOR
        public VMiniciarsesion(INavigation navigation)
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
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { SetValue(ref _NombreUsuario, value); }
        }
        public string Contrasena
        {
            get { return _contrasena; }
            set { SetValue(ref _contrasena, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }

        //public async Task IniciarSesion()
        //{
        //    DatosApi datosApi = new DatosApi();  // Crea una nueva instancia de DatosApi aquí
        //    var usuarios = await datosApi.ObtenerUsuarios();
        //    var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == _NombreUsuario && u.Contrasena == _contrasena);
        //    if (usuario != null)
        //    {
        //        // Guardar el estado de la sesión en la caché local
        //        Application.Current.Properties["isLogged"] = true;
        //        Application.Current.Properties["usuario"] = NombreUsuario;
        //        await Application.Current.SavePropertiesAsync();

        //        // Navegar a la página principal
        //        App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
        //        App.MasterDet.IsPresented = false;
        //    }
        //    else
        //    {
        //        // Manejo de errores
        //        DisplayAlert("Mensaje", "No se pudo ai", "Ok");
        //        _Texto = "Nombre de usuario o contraseña incorrectos";
        //    }
        //}

        public async Task IniciarSesion()
        {
            DatosApi datosApi = new DatosApi();  // Crea una nueva instancia de DatosApi aquí
            var usuarios = await datosApi.ObtenerUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == _NombreUsuario && u.Contrasena == _contrasena);
            if (usuario != null)
            {
                // Guardar el estado de la sesión en la caché local
                Application.Current.Properties["isLogged"] = true;
                Application.Current.Properties["usuario"] = NombreUsuario;
                await Application.Current.SavePropertiesAsync();

                // Navegar a la página principal
                App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
                App.MasterDet.IsPresented = false;
            }
            else
            {
                // Manejo de errores
                await Application.Current.MainPage.DisplayAlert("Mensaje", "No se pudo iniciar sesión", "Ok");
                _Texto = "Nombre de usuario o contraseña incorrectos";
            }
        }







        //public async void IniciarSesion()
        //{
        //    App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
        //    App.MasterDet.IsPresented = false;
        //}
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand BotonIniciarSesioncomand => new Command(async () => await IniciarSesion());
       // public ICommand BotonIniciarSesioncomand => new Command(async () => await SimularInicio());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
       // public ICommand BotonIniciarSesioncomand => new Command(SimularInicio);

        #endregion
    }
}
