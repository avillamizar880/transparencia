using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class EntityForo
    {
        public int IdForo { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string FechaCreacionStr { get; set; }
        public int IdForoConfig { get; set; }
    }
}