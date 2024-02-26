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
        ///AAAAAAAAA
        #endregion
        #region CONSTRUCTOR
        public VMRegistrarMerma(INavigation navigation)
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
        public void SimularBoton()
        {
            DisplayAlert("Mensaje", "Merma añadida ", "Ok");
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SimularBotoncomand => new Command(SimularBoton);
        #endregion
    }
}
