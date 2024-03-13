using StoreConev2.Modelo;
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
    public partial class ejemploR : ContentPage
    {

        public ejemploR()
        {
            InitializeComponent();
            BindingContext = new MyViewModel(Navigation);
        }

        
    }


}