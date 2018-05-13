using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class ModelDataRecurso
    {
        public int totalNumber { get; set; }
        public int totalPages { get; set; }
        public int pagesNumber { get; set; }
        
        public List<itemRecurso> recursos { get; set; }
        
        public DataTable dtRecursos { get; set; }

        public DataTable detalle { get; set; }

        public string tipoRecurso { get; set; }
    }
}