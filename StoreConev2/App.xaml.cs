using StoreConev2.Vistas;
using System;
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

            App.MasterDet = new MasterDetailPage
            {
                Master = new Navegacion(),
                Detail = new NavigationPage(new IniciarSesion())
            };

            MainPage = App.MasterDet;
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
