using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
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
        #endregion
        #region CONSTRUCTOR
        public VMRegistrarMerma(INavigation navigation)
        {
            Navigation = navigation;
            TiposMerma = new List<string> {"Robo","Caducidad","Defectuoso"};
        }
        #endregion
        #region OBJETOS

     
        public List<string> TiposMerma
        {
            get { return _Merma; }
            set { SetValue(ref _Merma, value); }
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
        public async Task Insertar()
        {
            if (Codigo==0)
            {
                await Application.Current.MainPage.DisplayAlert("Ventana", "El campo de Codigo es Obligatorio", "cerrar");
                return;
            }
            var funcion = new DatosApi();
            var parametros = new Merma();
            parametros.Codigo = _Codigo;
            parametros.Fecha_ingreso = DateTime.Now;
            parametros.Tipo_de_merma = _Tipo_de_merma;
            parametros.Nombre_producto = _Nombre_producto;
            await funcion.InsertarMerma(parametros);
            
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
