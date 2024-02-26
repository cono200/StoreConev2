using StoreConev2.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class VMVistaPreviaP : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        private int _cantidad=1;
        #endregion
        #region CONSTRUCTOR
        public VMVistaPreviaP(INavigation navigation)
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
        public void SimularSumar()
        {
            DisplayAlert("Mensaje", "producto sumado", "Ok");
        }
        public void SimularResta()
        {
            DisplayAlert("Mensaje", "producto quitado", "Ok");
        }
        public void Detalles()
        {
            DisplayAlert("Mensaje", "En la siguiente actualizacion karnal!", "Ok");
        }
        #endregion
        #region COMANDOS
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SimularSumarcomand => new Command(SimularSumar);
        public ICommand SimularRestacomand => new Command(SimularResta);
        public ICommand Detallescomand => new Command(Detalles);
        #endregion
    }
}
