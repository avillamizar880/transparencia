namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class opcionRespuestas
    {
        [Key]
        public int idOpcionRespuestas { get; set; }

        public int idPregunta { get; set; }

        [StringLength(200)]
        public string etiquetaOpcion { get; set; }

        public int? rptaCorrecta { get; set; }

        public virtual preguntaCuestionario preguntaCuestionario { get; set; }
    }
}
