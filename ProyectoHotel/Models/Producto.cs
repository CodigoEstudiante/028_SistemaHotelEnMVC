using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public string PrecioTexto { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}