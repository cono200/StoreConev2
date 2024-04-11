using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;

namespace StoreConev2.VistaModelo
{
    public class VMNotificaciones : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Historial> _historial;
        private INavigation navigation;
        private int _numItemsToShow = 10;  // MOSTRAR LOS 10 ULTIMOS

        public ObservableCollection<Historial> Productos
        {
            get { return _historial; }
            set
            {
                _historial = value;
                OnPropertyChanged(nameof(Productos));
            }
        }

        public int NumItemsToShow
        {
            get { return _numItemsToShow; }
            set
            {
                _numItemsToShow = value;
                OnPropertyChanged(nameof(NumItemsToShow));
                LoadHistorial();  // Recargar los datos cuando cambie el valor
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

            // Hacemos una copia de la lista
            var copiaProductos = new List<Historial>(productos);

            // Tomamos solo los últimos 10 elementos de la copia
            var ultimosDiez = copiaProductos.AsEnumerable().Reverse().Take(NumItemsToShow).ToList();

            for (int i = 0; i < ultimosDiez.Count; i++)
            {
                ultimosDiez[i].Index = i;
            }

            Productos = new ObservableCollection<Historial>(ultimosDiez);
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
