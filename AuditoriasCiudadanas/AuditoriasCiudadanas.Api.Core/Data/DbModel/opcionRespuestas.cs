using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
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
