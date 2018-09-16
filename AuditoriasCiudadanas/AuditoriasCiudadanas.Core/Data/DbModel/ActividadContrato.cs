namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActividadContrato")]
    public partial class ActividadContrato
    {
        [Key]
        public int IdActividadCon { get; set; }

        public int CodActividadCon { get; set; }

        public string NomActividadCon { get; set; }

        public decimal? ValorUnitario { get; set; }

        public decimal? Cantidad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCtto { get; set; }

        public decimal? ValorCtto { get; set; }

        public decimal? CantidadEje { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaEje { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        [StringLength(50)]
        public string NumCtto { get; set; }

        public virtual Contrato Contrato { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
