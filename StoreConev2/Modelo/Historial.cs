using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConev2.Modelo
{
    public class Historial
    {
        public DateTime Fecha {  get; set; }
        public string Accion { get; set; } 
        public string Producto { get; set; }
        public string Detalles { get; set; }
        public string ProductoId { get; set; }
    }
}
