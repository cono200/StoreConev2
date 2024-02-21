using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StoreConev2.Vistas;
namespace StoreConev2.VistaModelo
{ 
public class VMiniciarsesion : BaseViewModel
{
    #region VARIABLES
    string _Texto;

    #endregion
    #region CONSTRUCTOR
    public VMiniciarsesion(INavigation navigation)
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
    public async void IniciarSesion()
        {
            await Navigation.PushAsync(new VistaPreviaProducto());
        }
    #endregion
    #region COMANDOS
    public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
    public ICommand ProcesoSimpcomand => new Command(procesoSimple);
    public ICommand BotonIniciarSesioncomand => new Command(IniciarSesion);

        #endregion
    }
}
