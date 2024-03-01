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
    public class VMSeccionC : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        ObservableCollection<Producto> _lproducto;
        #endregion
        #region CONSTRUCTOR
        public VMSeccionC(INavigation navigation)
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
        public ObservableCollection<Producto> LProducto
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
        public void MostrarLista()
        {
            var funcion = new VMListaProductos();
            LProducto = funcion.ObtenerProductosSeccionC();



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