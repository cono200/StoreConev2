﻿using StoreConev2.VistaModelo;
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
    public partial class RegistrarProducto : ContentPage
    {
        public RegistrarProducto()
        {
            InitializeComponent();
            BindingContext = new VMRegistrarProducto(Navigation);
        }
    }
}