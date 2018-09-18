using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class OcadProyecto_NoCarga
    {
        [Key]
        public int idacuerdo { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        [StringLength(15)]
        public string CodOcad { get; set; }

        [StringLength(200)]
        public string NomOcad { get; set; }

        public DateTime? FechaDocAprobacion { get; set; }

        [StringLength(100)]
        public string NumDocAprobacion { get; set; }

        [StringLength(100)]
        public string errorCode { get; set; }

        public string errorColumn { get; set; }
    }
}
