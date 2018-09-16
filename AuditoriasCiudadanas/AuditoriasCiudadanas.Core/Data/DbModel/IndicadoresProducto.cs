namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndicadoresProducto")]
    public partial class IndicadoresProducto
    {
        [Key]
        public int idIndicadorProducto { get; set; }

        [Required]
        [StringLength(15)]
        public string CodIndicador { get; set; }

        [Required]
        [StringLength(250)]
        public string NomIndicador { get; set; }

        public int? IdObjetivoEspecifico { get; set; }

        public string NomObjetivoEspecifico { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public int? IdProducto { get; set; }

        public string NombreProducto { get; set; }

        [StringLength(1000)]
        public string NomUnidadProducto { get; set; }

        public double? CantidadProducto { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public double ValorMeta { get; set; }

        public int? Anio { get; set; }

        public int? Mes { get; set; }

        public double? ValorEjecutado { get; set; }

        public double? PorEjecutado { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
