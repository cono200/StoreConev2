using Microcharts;
using SkiaSharp;
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
        public Graficos(ObservableCollection<Producto> productos)
        {
            InitializeComponent();
            Displaychart(productos);
        }

        public void Displaychart(ObservableCollection<Producto> productos)
        {
            var entries = new List<ChartEntry>();

            foreach (var producto in productos)
            {
                // Generar un color aleatorio para cada entrada
                Random ran = new Random();
                SKColor randomColor = SKColor.FromHsv(ran.Next(256), ran.Next(256), ran.Next(256));

                var entry = new ChartEntry(producto.Cantidad)
                {
                    TextColor = randomColor,
                    Label = producto.Nombre,
                    ValueLabel = producto.Cantidad.ToString(),
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