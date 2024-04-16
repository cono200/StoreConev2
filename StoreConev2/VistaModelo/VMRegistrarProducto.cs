using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.VistaModelo;
using StoreConev2.Vistas;
using System.ComponentModel;
using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System.Collections.ObjectModel;
using Plugin.Media;
using System.IO;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarProducto : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private long _codigo;
        private string _imagen;
        private string _nombre = string.Empty;
        private string _seccion =string.Empty;
        private string _proveedor = string.Empty;
        private string _descripcion;
        private int _precio ;
        private bool _boleano =false;
        private List<string> _seccionlist;
        private ObservableCollection<Proveedor> _Lproveedores;
        public Proveedor ProveedorSeleccionado { get; set; }


        #endregion
        #region CONSTRUCTOR

        public VMRegistrarProducto(INavigation navigation)
        {
            Navigation = navigation;
            SeccionList = new List<string> { "1A", "2A", "3A", "4A", "1B", "2B", "3B", "4B","1C", "2C", "3C", "4C", "1D", "2D", "3D", "4D" };
            LoadProveedor();
        }

        #endregion
        #region OBJETOS
        private bool _areFieldsNotEmpty;
        public List<string> SeccionList
        {
            get { return _seccionlist; }
            set { SetValue(ref _seccionlist, value); }
        }
        public ObservableCollection<Proveedor> Lproveedores
        {
            get { return _Lproveedores; }
            set
            {
                _Lproveedores = value;
                OnPropertyChanged(nameof(Lproveedores));
            }
        }
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
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
    
        public bool boleano
        {
            get { return _boleano; }
            set
            {
                SetValue(ref _boleano, value);
                OnPropertyChanged();
            }
        }
        public long Codigo
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
       
        public int Precio
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
            if (Codigo != null && Nombre != string.Empty && Seccion != string.Empty && 
                Precio != null)
            {
                boleano=true;
            }
            else
            {
                boleano = false;
            }
        }
        private async Task RefreshCodigo()
        {
            var funcion = new DatosApi();
            var scaner = await funcion.ScanerPistola();
            if (scaner != null)
            {
                Codigo = scaner.CodigoPistola; // Usa CodigoPistola en lugar de Codigo
            }
        }
        public async Task Insertar()
        {
            if ((Codigo==null))
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }

            var funcion = new DatosApi();
            var parametros = new ProductoParaInsertar();
            parametros.Codigo = _codigo;
            parametros.Nombre = _nombre;
            parametros.Seccion = _seccion;
            parametros.ProveedorId =ProveedorSeleccionado.Id;
            parametros.Descripcion = _descripcion;
            parametros.Precio = _precio;
          parametros.Imagen = _imagen;
            
            await funcion.InsertarProducto2(parametros);
        }

       



        public void LimpiarCampos()
        {
            Codigo = 0;
            Nombre = null;
            Seccion = null;
            ProveedorSeleccionado = null;
            Descripcion = null;
            Precio = 0;
            Imagen = null;
        }
        public void Intento()
        {
            Insertar();
            LimpiarCampos();
        }


        public async Task LoadProveedor()
        {
            var funcion = new DatosApi();
            Lproveedores = await funcion.ObtenerProveedor();
        }
        public void SimularBoton()
        {
            DisplayAlert("Mensaje", "Producto añadido ", "Ok");
            //ASDADASDADD
        }
        private async Task PickImage()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", "La selección de fotos no está soportada!", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                var base64 = Convert.ToBase64String(memoryStream.ToArray());
                Imagen = base64;
            }
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand InsertProductocomand => new Command(Intento);
        public ICommand SimularBotoncomand => new Command(SimularBoton);
        public ICommand PickImageCommand => new Command(async () => await PickImage());
        public ICommand RefreshCodigoCommand => new Command(async () => await RefreshCodigo());
        #endregion
    }
}
