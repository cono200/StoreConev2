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
	public partial class SeccionD : ContentPage
	{
		public SeccionD ()
		{
			InitializeComponent ();
            BindingContext = new VMSeccionD(Navigation);

        }
    }
}