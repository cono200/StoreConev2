using StoreConev2.VistaModelo;
using StoreConev2.Vistas;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2
{

    public partial class App : Application
    {
        public static NavigationPage NavigationPage { get; private set; }
        public static MasterDetailPage MasterDet { get; private set; }

        public App()
        {
            InitializeComponent();

            // Inicializa MasterDet y NavigationPage
            MasterDet = new MasterDetailPage
            {
                Master = new Navegacion(),
            };
            NavigationPage = new NavigationPage();

            if (Application.Current.Properties.ContainsKey("usuario"))
            {
                // El usuario ya ha iniciado sesión, así que vamos directamente a la página principal
                NavigationPage.Navigation.PushAsync(new VistaPreviaProducto());
            }
            else
            {
                // El usuario no ha iniciado sesión, así que mostramos la página de inicio de sesión
                NavigationPage.Navigation.PushAsync(new IniciarSesion());
            }

            MasterDet.Detail = NavigationPage;
            MainPage = MasterDet;
        }
    }








}