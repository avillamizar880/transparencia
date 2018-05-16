using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class itemRecurso
    {
        public int idRecurso { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string ruta_url { get; set; }
        public int tipo_recurso { get; set; }
    }
}