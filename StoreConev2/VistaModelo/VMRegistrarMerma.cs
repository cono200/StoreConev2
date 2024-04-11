using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarMerma : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        long _Codigo;
        string _Tipo_de_merma;
        DateTime _Fecha_ingreso;
        string _Nombre_producto;
        List<string> _Merma;
        private ObservableCollection<Producto2> _LProducto;
        //public Producto2 ProductoSeleccionado { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMRegistrarMerma(INavigation navigation)
        {
            Navigation = navigation;
            TiposMerma = new List<string> {"Robo","Caducidad","Defectuoso"};
            LoadProducto();
        }
        #endregion
        #region OBJETOS
        //AKI MERO
     
        public List<string> TiposMerma
        {
            get { return _Merma; }
            set { SetValue(ref _Merma, value); }
        }
        public ObservableCollection<Producto2> LProducto
        {
            get { return _LProducto; }
            set
            {
                _LProducto = value;
                OnPropertyChanged(nameof(LProducto));
            }
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public long Codigo
        {
            get { return _Codigo; }
            set { SetValue(ref _Codigo, value); }
        }
        public string Tipo_de_merma
        {
            get { return _Tipo_de_merma; }
            set { SetValue(ref _Tipo_de_merma, value); }
        }
        public DateTime Fecha_ingreso
        {
            get { return _Fecha_ingreso; }
            set { SetValue(ref _Fecha_ingreso, value); }
        }
        public string Nombre_producto
        {
            get { return _Nombre_producto; }
            set { SetValue(ref _Nombre_producto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task LoadProducto()
        {
            var funcion = new DatosApi();
            LProducto = await funcion.ObtenerProductos();
        }
        public async Task Insertar()
        {
            if (Codigo==0)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();
            var parametros = new Merma();
            parametros.Codigo = ProductoSeleccionado.Codigo;
            parametros.Fecha_ingreso = DateTime.Now;
            parametros.Tipo_de_merma = _Tipo_de_merma;
            parametros.Nombre_producto = ProductoSeleccionado.Nombre;
            await funcion.InsertarMerma(parametros);
            
        }
        private Producto2 _productoSeleccionado;
        public Producto2 ProductoSeleccionado
        {
            get { return _productoSeleccionado; }
            set
            {
                _productoSeleccionado = value;
                OnPropertyChanged(nameof(ProductoSeleccionado));
                // Cuando cambia el producto seleccionado, actualiza el código.
                if (_productoSeleccionado != null)
                {
                    Codigo = _productoSeleccionado.Codigo;
                }
            }
        }
        public void procesoSimple()
        {

        }
        public void SimularBoton()
        {
            DisplayAlert("Mensaje", "Merma añadida ", "Ok");
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand InsertMermacomand => new Command(async () => await Insertar());

        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
