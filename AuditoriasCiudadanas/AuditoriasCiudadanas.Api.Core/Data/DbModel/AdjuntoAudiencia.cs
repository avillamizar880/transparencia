using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("AdjuntoAudiencia")]
    public partial class AdjuntoAudiencia
    {
        [Key]
        public int idAdjuntoAudiencia { get; set; }

        public int? idTipoAdjunto { get; set; }

        public int idAudiencia { get; set; }

        [StringLength(250)]
        public string url { get; set; }

        public DateTime? fecha { get; set; }

        public int? idUsuario { get; set; }

        public virtual Audiencias Audiencias { get; set; }

        public virtual TiposAdjunto TiposAdjunto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
