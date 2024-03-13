using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreConev2.VistaModelo
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _items;
        private bool _isRefreshing;
        public INavigation Navigation { get; set; } // Agrega esta línea

        public MyViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoadData(); // Cambia LoadProductos() a LoadData()
        }

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await LoadData();

                    IsRefreshing = false;
                });
            }
        }

        public async Task LoadData()
        {
            await Task.Delay(18000); // Simula un retraso

            // Carga algunos datos de texto
            Items = new ObservableCollection<string>(new List<string> { "Texto 1", "Texto 2", "Texto 3", "Texto 4", "Texto 5" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
