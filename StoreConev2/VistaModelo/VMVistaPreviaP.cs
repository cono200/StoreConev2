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


        #endregion
        #region COMANDOS
        public ICommand IrNotificacionescomand => new Command(async () => await IrNotificaciones());
        public ICommand IrDetallescomand => new Command(async () => await IrDetalles());
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand SimularSumarcomand => new Command(SimularSumar);
        public ICommand SimularRestacomand => new Command(async () => await MensajeEliminar());



        #endregion
    }
}
