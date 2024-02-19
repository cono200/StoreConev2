using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConev2.Modelo
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Seccion { get; set; }
        public string Proveedor { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
