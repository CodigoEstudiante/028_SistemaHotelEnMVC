using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public TipoPersona oTipoPersona { get; set; }
        public bool Estado { get; set; }
    }
}