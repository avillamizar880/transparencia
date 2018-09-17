using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Compromisos
    {
        [Key]
        public int idCompromiso { get; set; }

        public DateTime? fecha { get; set; }

        public int idUsuario { get; set; }

        [StringLength(400)]
        public string responsable { get; set; }

        [StringLength(1000)]
        public string compromiso { get; set; }

        public int? cumplimiento { get; set; }

        [StringLength(1000)]
        public string observaciones { get; set; }

        [StringLength(1000)]
        public string observacionesCierre { get; set; }

        public DateTime? fechaCierre { get; set; }

        public int? idAudiencia { get; set; }

        [StringLength(200)]
        public string ruta_img { get; set; }

        public DateTime? fecha_cre { get; set; }

        public int? idGac { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
