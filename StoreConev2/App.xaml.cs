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
        public static MasterDetailPage MasterDet { get; set; }

        public App()
        {
            InitializeComponent();

            // Inicializa MasterDet
            MasterDet = new MasterDetailPage
            {
                Master = new Navegacion(),
            };

            if (Application.Current.Properties.ContainsKey("usuario"))
            {
                // El usuario ya ha iniciado sesión, así que vamos directamente a la página principal
                MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
            }
            else
            {
                // El usuario no ha iniciado sesión, así que mostramos la página de inicio de sesión
                MasterDet.Detail = new NavigationPage(new IniciarSesion());
            }

            MainPage = MasterDet;
        }
    }






}