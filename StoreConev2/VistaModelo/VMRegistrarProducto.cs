using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.VistaModelo;
using StoreConev2.Vistas;

namespace StoreConev2.VistaModelo
{
    public class VMRegistrarProducto : BaseViewModel
    {
        #region VARIABLES
        string _Texto;

        #endregion
        #region CONSTRUCTOR
        public VMRegistrarProducto(INavigation navigation)
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
        public async  Task IrNotificaciones()
        {
            await Navigation.PushAsync( new Notificaciones());
        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
