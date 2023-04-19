using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.Models
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public string PrecioTexto { get; set; }
        public Piso oPiso { get; set; }
        public Categoria oCategoria { get; set; }
        public EstadoHabitacion oEstadoHabitacion { get; set; }
        public bool Estado { get; set; }

    }
}