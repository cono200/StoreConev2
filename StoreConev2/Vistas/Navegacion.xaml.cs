using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConev2.VistaModelo;
using StoreConev2.Vistas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navegacion : ContentPage
    {
        public Navegacion()
        {
            InitializeComponent();
            BindingContext = new VMNavegacion(Navigation);

        }

        //void OnPage1Clicked(object sender, EventArgs e)
        //{
        //    App.MasterDet.Detail = new NavigationPage(new VistaPreviaProducto());
        //    App.MasterDet.IsPresented = false; // Cierra el menú lateral
        //}

        //void OnPage2Clicked(object sender, EventArgs e)
        //{
        //    // Navegar a Page2
        //    (Application.Current.MainPage as MainPage).Detail = new NavigationPage(new Page2());
        //    (Application.Current.MainPage as MainPage).IsPresented = false;
        //}


    }
}