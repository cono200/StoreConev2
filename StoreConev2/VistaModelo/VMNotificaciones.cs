﻿using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace StoreConev2.VistaModelo
{
    public class VMNotificaciones : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Historial> _historial;
        private INavigation navigation;

        public ObservableCollection<Historial> Productos
        {
            get { return _historial; }
            set
            {
                _historial = value;
                OnPropertyChanged(nameof(Productos));
            }
        }
      
        public VMNotificaciones(INavigation navigation)
        {
            this.navigation = navigation;
            LoadHistorial();

        }

        public async Task LoadHistorial()
        {
            var funcion = new DatosApi();
            var productos = await funcion.ObtenerHistorial();

            for (int i = 0; i < productos.Count; i++)
            {
                productos[i].Index = i;
            }

            Productos = new ObservableCollection<Historial>(productos);
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}