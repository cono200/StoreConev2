using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConev2.Modelo
{
    public class Producto2
    {
    //    public string Id { get; set; }
        public string Nombre { get; set; }
        public long Codigo { get; set; }
        public string Seccion { get; set; }
        public string ProveedorId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }
        public DateTime Caducidad { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
