using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Recepcion oRecepcion { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }
    }
}