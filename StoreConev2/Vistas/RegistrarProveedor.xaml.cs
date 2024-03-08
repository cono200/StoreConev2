﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConev2.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarProveedor : ContentPage
    {
        public RegistrarProveedor()
        {
            InitializeComponent();
            BindingContext = new VMproveedor(Navigation);
        }
    }
}