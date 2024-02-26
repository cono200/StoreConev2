using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.VistaModelo;
using StoreConev2.Vistas;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarProducto : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _codigo;
        private string _nombre;
        private string _seccion;
        private string _proveedor;
        private int _cantidad;
        private string _descripcion;
        private decimal _precio;


        #endregion
        #region CONSTRUCTOR
        public VMRegistrarProducto(INavigation navigation)
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
        public string Codigo
        {
            get { return _codigo; }
            set { SetValue(ref _codigo, value); }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }
        public string Seccion
        {
            get { return _seccion; }
            set { SetValue(ref _seccion, value); }
        }
        public string Proveedor
        {
            get { return _proveedor; }
            set { SetValue(ref _proveedor, value); }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value); }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { SetValue(ref _cantidad, value); }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { SetValue(ref _precio, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task IrNotificaciones()
        {
            await Navigation.PushAsync(new Notificaciones());
        }
        public void procesoSimple()
        {

        }
        public void SimularBoton()
        {
            DisplayAlert("Mensaje", "Producto añadido ", "Ok");
            //ASDADASDADD
        }
        //public void IrNotificaciones()
        //{
        //    Device.BeginInvokeOnMainThread(async () =>
        //    {
        //        await Navigation.PushModalAsync(new Notificaciones());
        //    });
        //}
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SimularBotoncomand => new Command(SimularBoton);
        // public ICommand IrNotificacionescomand => new Command(IrNotificaciones);

        #endregion
    }
}
