using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.Vistas;
namespace StoreConev2.VistaModelo
{
    public class VMiniciarsesion : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _usuario;
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
        public string Usuario
        {
            get { return _usuario; }
            set { SetValue(ref _usuario, value); }
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
        public void SimularInicio()
        {
            if (Usuario == "papas" && Contrasena == "con ketchup")
            {
                IniciarSesion();
            }
            else
            {
                DisplayAlert("Alerta", "Algo no pusistes bien :D", "Ok lo intentare de nuevo");
            }
        }
        public async void IniciarSesion()
        {
            App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
            App.MasterDet.IsPresented = false;
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand BotonIniciarSesioncomand => new Command(SimularInicio);

        #endregion
    }
}
