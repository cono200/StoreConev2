using StoreConev2.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ejemplo2 : ContentPage
    {
        public Ejemplo2()
        {
            InitializeComponent();
            BindingContext = new VMListaProduct(Navigation);
        }
    }
}