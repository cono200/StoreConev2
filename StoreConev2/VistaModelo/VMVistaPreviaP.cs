using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Collections.Specialized.BitVector32;

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
        private int _precio;
        public Producto2 ProductoSeleccionado { get; set; }

        #endregion
        #region CONSTRUCTOR
        public VMVistaPreviaP(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Proveedor
        {
            get { return _Proveedor; }
            set { SetValue(ref _Proveedor, value); }
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
            if (Codigo == 0) // Codigo es de tipo long, no puede ser null. Puedes verificar si es 0.
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();

            ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Codigo);

            // Verificar que ProductoSeleccionado no sea null
            if (ProductoSeleccionado == null)
            {
                // Manejar el caso cuando ProductoSeleccionado es null
                await Application.Current.MainPage.DisplayAlert("Ventana", "No se encontró el producto", "cerrar");
                return;
            }

            // Asignar los datos devueltos a las propiedades de tu ViewModel
            Codigo = ProductoSeleccionado.Codigo;
            Nombre = ProductoSeleccionado.Nombre;
            Proveedor = ProductoSeleccionado.proveedor?.Nombre; // Usar el operador de propagación nula
            IdProveedor = ProductoSeleccionado.ProveedorId.ToString();
            // Asignar las demás propiedades...
        }





        public async Task BuscarEInsertar()
        {
            if (Codigo == null)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();

            // Buscar el producto por su código
            ProductoSeleccionado = await funcion.ObtenerProductobyCodigo(Codigo);

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
