using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;

namespace StoreConev2.VistaModelo
{
    public class VMVistaPreviaP : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private int _cantidad=1;
        private long _codigo;
        private string _Nombre;
        private string _Proveedor;
        private string _Idproveedor;
        private string _seccion;
        private string _descripcion;
        private string _imagen= "https://i.ibb.co/dWR9GdP/papas3.png";
        private int _precio;
        private Scaner _pistola;
        private bool _isRefreshing = false;


        public Producto2 ProductoSeleccionado { get; set; }
        public ICommand RefreshCommand { get; }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged(nameof(IsRefreshing));
                }
            }
        }

        public VMVistaPreviaP()
        {
            RefreshCommand = new Command(async () => await RefreshDataAsync());
        }

        private async Task RefreshDataAsync()
        {
            IsRefreshing = true;

            // Aquí va tu lógica para actualizar los datos

            IsRefreshing = false;
        }

        #endregion
        #region CONSTRUCTOR
        public VMVistaPreviaP(INavigation navigation)
        {
            Navigation = navigation;
            LoadPistola();
        }
        #endregion
        #region OBJETOS
       
        public Scaner Pistola
        {
            get { return _pistola; }
            set { SetValue(ref _pistola, value); }
        }
        public string Seccion
        {
            get { return _seccion; }
            set { SetValue(ref _seccion, value); }
        }
        public string Proveedor
        {
            get { return _Proveedor; }
            set { SetValue(ref _Proveedor, value); }
        } public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { SetValue(ref _Nombre, value); }
        }
        public string IdProveedor
        {
            get { return _Idproveedor; }
            set { SetValue(ref _Idproveedor, value); }
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public long Codigo
        {
            get { return _codigo; }
            set { SetValue(ref _codigo, value); }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                var tempValue = value.ToString();
                if (tempValue.Length > 2)
                {
                    _cantidad = int.Parse(tempValue.Substring(0, 2));
                }
                else
                {
                    _cantidad = value;
                }
                OnPropertyChanged(nameof(Cantidad));
            }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        public async Task IrNotificaciones()
        {
            await Navigation.PushAsync(new Notificaciones());
        } 
        public async Task IrDetalles()
        {
            await Navigation.PushAsync(new ListaProductos());
        }
        public void SimularSumar()
        {
         DisplayAlert("Mensaje", "producto sumado", "Ok");
        }
        public async Task<bool> SimularResta()
        {
           return  await Application.Current.MainPage.DisplayAlert("Confirmar", "Desea eliminar este producto?", "Si","No");
        }

        public async Task LoadPistola()
        {

            var function = new DatosApi();
            Pistola = await function.ScanerPistola();

        }

        private async Task MensajeEliminar()
        {
            bool confirmacion = await SimularResta();
            if (confirmacion)
            {
                // Aquí puedes colocar la lógica para eliminar el producto
                // Por ejemplo: 
                // RealizarResta();
                // Luego notificar al usuario que el producto fue eliminado.
                await Application.Current.MainPage.DisplayAlert("Información", "Producto eliminado", "Ok");
            }
        }
        public async Task Buscar()
        {
            //if (Codigo == 0) 
            //{
            //    await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
            //    return;
            //}
            var funcion = new DatosApi();
            Pistola = await funcion.ScanerPistola();

            ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Pistola.CodigoPistola);

            if (ProductoSeleccionado == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "No se encontró el producto", "cerrar");
                return;
            }

            // Asignar los datos devueltos a las propiedades de tu ViewModel
            Pistola.CodigoPistola = ProductoSeleccionado.Codigo;
            Nombre = ProductoSeleccionado.Nombre;
            Seccion=ProductoSeleccionado.Seccion;
            Proveedor = ProductoSeleccionado.proveedor?.Nombre; 
            IdProveedor = ProductoSeleccionado.ProveedorId.ToString();
            Imagen= ProductoSeleccionado.Imagen;
        }





        public async Task BuscarEInsertar()
        {
            if (Pistola.CodigoPistola == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();

            // Buscar el producto por su código
            ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Pistola.CodigoPistola);

            // Crear un nuevo producto con los datos obtenidos
            var nuevoProducto = new Producto2
            {
                Codigo = ProductoSeleccionado.Codigo,
                Nombre = ProductoSeleccionado.Nombre,
                ProveedorId = ProductoSeleccionado.ProveedorId,
                Seccion = ProductoSeleccionado.Seccion,
                Descripcion = ProductoSeleccionado.Descripcion,
                Precio = ProductoSeleccionado.Precio,
                Caducidad = DateTime.Now,
                Imagen = ProductoSeleccionado.Imagen,
                proveedor= ProductoSeleccionado.proveedor
            };

            await funcion.InsertarProducto(nuevoProducto);
        }


        #endregion
        #region COMANDOS
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
      //  public ICommand IrDetallescomand => new Command(async () => await IrDetalles());
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
      //  public ICommand SimularSumarcomand => new Command(SimularSumar);
        public ICommand SimularRestacomand => new Command(async () => await MensajeEliminar());

        public ICommand SearchProductocomand => new Command(async () => await Buscar());
        public ICommand InsertProductocomand => new Command(async () => await BuscarEInsertar());



        #endregion
    }
}
