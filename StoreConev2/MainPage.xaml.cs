using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StoreConev2.Vistas;


namespace StoreConev2
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            
            Master = new Navegacion();
            Detail = new NavigationPage(new IniciarSesion());
            Detail = new NavigationPage(new VistaPreviaProducto());
            Detail = new NavigationPage(new ListaProductos());

        }



    }

}
    

