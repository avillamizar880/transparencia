using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class itemForos
    {
        public string tema { get; set; }
        public string descripcion { get; set;}
        public string mensaje { get; set; }

        public int idUsuario { get; set; }
    }
}