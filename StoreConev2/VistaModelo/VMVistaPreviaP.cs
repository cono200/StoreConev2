using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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
        private int _cantidad;
        private long _codigo;
        private string _Nombre;
        private string _Proveedor;
        private string _Idproveedor;
        private string _seccion;
        private string _descripcion;
        private string _imagen= "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";
        private int _precio;
        private Scaner _pistola;
        private bool _isRefreshing = false;
        private string ProductoId;
        private DateTime _Fecha_caducidad;

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
        public DateTime Fecha_Caducidad
        {
            get { return _Fecha_caducidad; }
            set { SetValue(ref _Fecha_caducidad, value); }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    OnPropertyChanged(nameof(Cantidad));
                }
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
                
                await Application.Current.MainPage.DisplayAlert("Información", "Producto eliminado", "Ok");
            }
        }
        public async Task Buscar()
        {
            
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
            ProductoId = ProductoSeleccionado.Id;
            Fecha_Caducidad = ProductoSeleccionado.Caducidad;
        }

        public async Task BuscarEInsertar()
        {
            if (Pistola.CodigoPistola == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();

            ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Pistola.CodigoPistola);

            // Crear un nuevo producto con los datos obtenidos
            for (int i = 0; i <= Cantidad-1; i++)
            {
                var nuevoProducto = new ProductoParaInsertar
                {
                    Codigo = ProductoSeleccionado.Codigo,
                    Nombre = ProductoSeleccionado.Nombre,
                    ProveedorId = ProductoSeleccionado.ProveedorId,
                    Seccion = ProductoSeleccionado.Seccion,
                    Descripcion = ProductoSeleccionado.Descripcion,
                    Precio = ProductoSeleccionado.Precio,
                    Caducidad = Fecha_Caducidad,
                    Imagen = ProductoSeleccionado.Imagen,
                    proveedor = ProductoSeleccionado.proveedor,
                    
                     
                   
                };

                bool resultado = await funcion.InsertarProducto2(nuevoProducto);

                if (!resultado) 
                {
                    return;
                }
            }
            await Application.Current.MainPage.DisplayAlert("Mensaje", "Producto registrado con éxito", "OK");

        }

        public async Task EliminarProducto()
        {
            var funcion = new DatosApi();

            for (int i = 0; i < Cantidad; i++)
            {
                if (Pistola.CodigoPistola == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                    return;
                }

                ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Pistola.CodigoPistola);

                if (ProductoSeleccionado != null)
                {
                    await funcion.EliminarProducto(ProductoSeleccionado.Id);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Mensaje", "No se encontró ningún producto con el código especificado.", "OK");
                    break;
                }
            }
            await Application.Current.MainPage.DisplayAlert("Mensaje", "Producto eliminado con éxito", "OK");

        }
        #endregion
        #region COMANDOS
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SimularRestacomand => new Command(async () => await MensajeEliminar());
        public ICommand SearchProductocomand => new Command(async () => await Buscar());
        public ICommand InsertProductocomand => new Command(async () => await BuscarEInsertar());
        public ICommand EliminarProductocomand => new Command(async () => await EliminarProducto());
        #endregion
    }
}
