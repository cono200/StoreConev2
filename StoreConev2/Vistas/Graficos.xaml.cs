using Microcharts;
using SkiaSharp;
using StoreConev2.ApiMetodos;
using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreConev2.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graficos : ContentPage
    {
        public Graficos(ObservableCollection<Merma> productos)
        {
            InitializeComponent();
            CargarDatos();
        }

        public async void CargarDatos()
        {
            var funcion = new DatosApi();
            var productos = await funcion.ObtenerMermas();
            Displaychart(productos);
        }

        public void Displaychart(ObservableCollection<Merma> productos)
        {
            // Crear un diccionario para contar las mermas por producto
            var mermaCounts = new Dictionary<string, int>();

            foreach (var producto in productos)
            {
                if (!mermaCounts.ContainsKey(producto.Nombre_producto))
                {
                    mermaCounts[producto.Nombre_producto] = 0;
                }
                mermaCounts[producto.Nombre_producto]++;
            }

            var entries = new List<ChartEntry>();

            foreach (var mermaCount in mermaCounts)
            {
                // Generar un color aleatorio para cada entrada
                Random ran = new Random();
                SKColor randomColor = SKColor.FromHsv(ran.Next(256), ran.Next(256), ran.Next(256));

                var entry = new ChartEntry(mermaCount.Value)
                {
                    TextColor = randomColor,
                    Label = mermaCount.Key,
                    ValueLabel = mermaCount.Value.ToString(),
                    Color = randomColor,
                    ValueLabelColor = randomColor,
                };

                entries.Add(entry);
            }

            var donutchart = new DonutChart()
            {
                Entries = entries,
                LabelTextSize = 25,
            };
            var barchart = new BarChart()
            {
                Entries = entries,
                LabelTextSize = 25,
            };

            this.PastelChart.Chart = donutchart;
            this.BarrasChart.Chart = barchart;

        }
    }
}