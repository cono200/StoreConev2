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

            // Crear instancia de VMListaProductos para obtener los productos
            //VMListaProductos vmListaProductos = new VMListaProductos();

            //// Crear una instancia de Graficos pasando la lista de productos como argumento
            //Graficos graficosPage = new Graficos(vmListaProductos.Productos);

            SeccionA iniciar = new SeccionA();

            // Configurar la página maestra y de detalle
            App.MasterDet = new MasterDetailPage
            {
                Master = new Navegacion(),
                Detail = new NavigationPage(iniciar)
            };

            MainPage = App.MasterDet;
        }

        protected override void OnStart()
        {
            // Manejar inicio de la aplicación
        }

        protected override void OnSleep()
        {
            // Manejar suspensión de la aplicación
        }

        protected override void OnResume()
        {
            // Manejar reanudación de la aplicación
        }
    }
}