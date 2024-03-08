using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConev2.Modelo
{
    public class Merma
    {
        public long Codigo { get; set; }
        public string Tipo_de_merma { get; set; }
        public DateTime? Fecha_ingreso { get; set; }
        public string Nombre_producto { get; set; } 
    }
}
