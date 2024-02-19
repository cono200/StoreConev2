using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class VMNavegacion : BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        #endregion
        #region CONSTRUCTOR
        public VMNavegacion(INavigation navigation)
        {
            Navigation = navigation;

        }
        public async Task Inicio()
        {
            App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
            App.MasterDet.IsPresented = false;
        }
        public async Task MListaProductos()
        {
            App.MasterDet.Detail = new NavigationPage(new ListaProductos());
            App.MasterDet.IsPresented = false;
        }
        
        public async Task RegistrarProducto()
        {
            App.MasterDet.Detail = new NavigationPage(new RegistrarProducto());
            App.MasterDet.IsPresented = false;
        }
        public async Task RegistroMermas()
        {
            App.MasterDet.Detail = new NavigationPage(new RegistroMermas());
            App.MasterDet.IsPresented = false;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand Iniciocomand => new Command(async () => await Inicio());
        public ICommand MenuListaProductoscomand => new Command(async () => await MListaProductos());
        public ICommand RegistrarProductoCommand => new Command(async () => await RegistrarProducto());
        public ICommand RegistroMermasCommand => new Command(async () => await RegistroMermas());


        #endregion
    }
}
