namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModificacionContrato")]
    public partial class ModificacionContrato
    {
        [StringLength(50)]
        public string NumCtto { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [StringLength(15)]
        public string CodTipoModificacion { get; set; }

        [StringLength(500)]
        public string NomTipoModificacion { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaModificacion { get; set; }

        [StringLength(50)]
        public string UnidadTiempoModif { get; set; }

        public int? CantidadTiempoModif { get; set; }

        public decimal? ValorModif { get; set; }

        [Key]
        public int idModificacion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
