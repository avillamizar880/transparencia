namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
