using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class EntityMensaje
    {
        public int IdChat { get; set; }
        public int IdRemitente { get; set; }
        public int IdDestinatario { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}