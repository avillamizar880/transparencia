namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ajuste")]
    public partial class Ajuste
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string NumDoc { get; set; }

        public DateTime? FechaDoc { get; set; }

        [StringLength(15)]
        public string CodOCAD { get; set; }

        [StringLength(200)]
        public string NomOCAD { get; set; }

        [StringLength(200)]
        public string DisminucionBenef { get; set; }

        [StringLength(200)]
        public string ReduccionMeta { get; set; }

        [StringLength(200)]
        public string ModificacionFuentesFin { get; set; }

        [StringLength(200)]
        public string IncrementosValor { get; set; }

        [StringLength(200)]
        public string DisminucionValor { get; set; }

        [StringLength(200)]
        public string CambioAlcance { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
