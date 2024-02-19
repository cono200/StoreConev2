using StoreConev2.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace StoreConev2.VistaModelo
{
    public class VMListaProductos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Modelo.Producto> Productos { get; set; }

        public VMListaProductos()
        {
            // Aquí cargarías tu lista de productos desde algún origen de datos
            Productos = ObtenerProductos();
        }

        ObservableCollection <Producto> ObtenerProductos()
        {
            // Aquí obtendrías tus productos de algún servicio o base de datos
            // Por ejemplo, podrías crear algunos productos de muestra aquí
            return new ObservableCollection<Producto>
        {
            new Producto { Codigo = "13015", Nombre = "Pintura Roja", Seccion = "A", Proveedor = "Comex", Cantidad = 10, Descripcion = "Descripción del producto 1", Precio = 20 },
            new Producto { Codigo = "45052", Nombre = "Brochas", Seccion = "B", Proveedor = "Brochero", Cantidad = 20, Descripcion = "Descripción del producto 2", Precio = 30 },
            new Producto { Codigo = "99999", Nombre = "Pintura Azul", Seccion = "A", Proveedor = "Comex", Cantidad = 15, Descripcion = "Descripción del producto 2", Precio = 30 },

            // Agrega más productos según sea necesario
        };
        }
    }
}