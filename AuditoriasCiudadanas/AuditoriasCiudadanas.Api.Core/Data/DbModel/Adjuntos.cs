using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Adjuntos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idAdjunto { get; set; }

        public int? idTipoAdjunto { get; set; }

        [StringLength(1000)]
        public string url { get; set; }

        public DateTime? fechaCreacion { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        public int? idUsuario { get; set; }

        public virtual TiposAdjunto TiposAdjunto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
