using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.VistaModelo;
using StoreConev2.Vistas;
using System.ComponentModel;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarProducto : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private string _codigo=string.Empty;
        private string _nombre = string.Empty;
        private string _seccion =string.Empty;
        private string _proveedor = string.Empty;
        private string _descripcion;
        private decimal? _precio =null;
        private bool _boleano =false;


        #endregion
        #region CONSTRUCTOR

        public VMRegistrarProducto(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        private bool _areFieldsNotEmpty;
        public bool AreFieldsNotEmpty
        {
            get { return _areFieldsNotEmpty; }
            set
            {
                _areFieldsNotEmpty = value;
                OnPropertyChanged(nameof(AreFieldsNotEmpty));
            }
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        //public bool boleano
        //{
        //    get => _boleano;
        //    set
        //    {
        //        _boleano = value;
        //        OnPropertyChanged();
        //    }
        //}
        public bool boleano
        {
            get { return _boleano; }
            set
            {
                SetValue(ref _boleano, value);
                OnPropertyChanged();
            }
        }
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                SetValue(ref _codigo, value);
                CheckFields(); // Agrega esta línea para verificar los campos cada vez que 'Codigo' cambie.
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value);
                CheckFields();
            }
        }
        public string Seccion
        {
            get { return _seccion; }
            set { SetValue(ref _seccion, value);
                CheckFields();
            }
        }
        public string Proveedor
        {
            get { return _proveedor; }
            set { SetValue(ref _proveedor, value);
                CheckFields();
            }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetValue(ref _descripcion, value); }
        }
       
        public decimal? Precio
        {
            get { return _precio; }
            set { SetValue(ref _precio, value);
                CheckFields();
            }
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
        public void CheckFields()
        {
            if (Codigo != string.Empty && Nombre != string.Empty && Seccion != string.Empty && Proveedor != string.Empty &&
                Precio != null)
            {
                boleano=true;
            }
            else
            {
                boleano = false;
            }
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
