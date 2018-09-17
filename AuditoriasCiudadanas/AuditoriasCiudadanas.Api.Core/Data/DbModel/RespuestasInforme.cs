using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("RespuestasInforme")]
    public partial class RespuestasInforme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRespuestaInforme { get; set; }

        public int? idInforme { get; set; }

        public int? idPreguntaInforme { get; set; }

        [StringLength(1000)]
        public string respuesta { get; set; }

        public int? idMiembroGac { get; set; }

        public virtual Informes Informes { get; set; }
    }
}
