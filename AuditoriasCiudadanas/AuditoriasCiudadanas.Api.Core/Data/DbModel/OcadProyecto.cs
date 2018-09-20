using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("OcadProyecto")]
    public partial class OcadProyecto
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string CodOcad { get; set; }

        [StringLength(200)]
        public string NomOcad { get; set; }

        public DateTime? FechaDocAprobacion { get; set; }

        [StringLength(100)]
        public string NumDocAprobacion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}