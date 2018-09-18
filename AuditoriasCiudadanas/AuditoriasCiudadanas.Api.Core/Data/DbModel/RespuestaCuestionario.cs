using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("RespuestaCuestionario")]
    public partial class RespuestaCuestionario
    {
        [Key]
        [Column(Order = 0)]
        public int idRespuesta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUsuario { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idpregunta { get; set; }

        public int? idOpcionRespuesta { get; set; }

        public string textoAbierta { get; set; }

        public bool procesado { get; set; }

        public DateTime? FechaRespuesta { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
