namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pagos
    {
        [Key]
        public int IdPago { get; set; }

        [StringLength(50)]
        public string NumCtto { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [StringLength(40)]
        public string CodConcepPago { get; set; }

        [StringLength(1000)]
        public string NomConcepPago { get; set; }

        public DateTime Fecha { get; set; }

        [StringLength(15)]
        public string CodFuenteFin { get; set; }

        [StringLength(200)]
        public string NomFuenteFin { get; set; }

        [StringLength(50)]
        public string NitBeneficiario { get; set; }

        public decimal? Valor { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
