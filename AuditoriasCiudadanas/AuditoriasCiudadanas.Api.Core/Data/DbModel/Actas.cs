using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Actas
    {
        [Key]
        public int idActa { get; set; }

        public int? idAudiencia { get; set; }

        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public DateTime? fecha { get; set; }

        public string descripcion { get; set; }

        [StringLength(200)]
        public string ruta { get; set; }

        public int? idUsuario { get; set; }

        public int? idTipoAudiencia { get; set; }

        [StringLength(15)]
        public string idDivipola { get; set; }

        public DateTime fecha_cre { get; set; }

        public int? idGac { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
