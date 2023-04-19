using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.Models
{
    public class Recepcion
    {
        public int IdRecepcion { get; set; }
        public Persona oCliente { get; set; }
        public Habitacion oHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string FechaEntradaTexto { get; set; }
        public DateTime FechaSalida { get; set; }
        public string FechaSalidaTexto { get; set; }

        public DateTime FechaSalidaConfirmacion { get; set; }
        public string FechaSalidaConfirmacionTexto { get; set; }

        public decimal PrecioInicial { get; set; }
        public string PrecioIncialTexto { get; set; }


        public decimal Adelanto { get; set; }
        public string AdelantoTexto { get; set; }
        public decimal PrecioRestante { get; set; }
        public string PrecioRestanteTexto { get; set; }

        public decimal TotalPagado { get; set; }
        public string TotalPagadoTexto { get; set; }

        public decimal CostoPenalidad { get; set; }
        public string CostoPenalidadTexto { get; set; }

        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public List<Venta> oVenta { get; set; }
    }
}