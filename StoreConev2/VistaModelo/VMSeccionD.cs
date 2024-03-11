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

namespace StoreConev2.VistaModelo
{
    public class VMSeccionD : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Producto2> _lproducto;
        #endregion
        #region CONSTRUCTOR
        public VMSeccionD(INavigation navigation)
        {
            Navigation = navigation;
            MostrarLista();
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public ObservableCollection<Producto2> LProducto
        {
            get { return _lproducto; }
            set
            {
                SetValue(ref _lproducto, value);
                OnpropertyChanged();
                // OnpropertyChanged Lo que hace es observar si hay un cambio y actualizar!
            }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public async Task MostrarLista()
        {
            var funcion = new DatosApi();
            LProducto = await funcion.ObtenerProductosSeccionD();



        }
    
        public void procesoSimple()
        {

        }
        public async Task IrSeccionA()
        {
            await Navigation.PushAsync(new SeccionA());
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SA => new Command(async () => await IrSeccionA());

        #endregion
    }
}