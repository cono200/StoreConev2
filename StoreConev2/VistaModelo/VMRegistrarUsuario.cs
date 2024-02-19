using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.VistaModelo;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarUsuario : BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        #endregion
        #region CONSTRUCTOR
        public VMRegistrarUsuario(INavigation navigation)
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
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        //public ICommand Iniciocomand => new Command(async () => await Inicio());
        //public ICommand MenuListaProductoscomand => new Command(async () => await MListaProductos());


        #endregion
    }
}
