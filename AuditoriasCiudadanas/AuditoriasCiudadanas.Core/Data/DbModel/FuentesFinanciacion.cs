namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FuentesFinanciacion")]
    public partial class FuentesFinanciacion
    {
        [Key]
        public int idFuenteFin { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        [StringLength(15)]
        public string CodEntidad { get; set; }

        [Required]
        [StringLength(1000)]
        public string NomEntidad { get; set; }

        [StringLength(15)]
        public string CodFuenteFin { get; set; }

        [StringLength(1000)]
        public string NomFuenteFin { get; set; }

        [StringLength(6)]
        public string Vigencia { get; set; }

        public decimal Valor { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
