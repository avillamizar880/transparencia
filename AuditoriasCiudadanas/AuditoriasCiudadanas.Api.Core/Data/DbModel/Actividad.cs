using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            InfObservacionesActividad = new HashSet<InfObservacionesActividad>();
        }

        [Key]
        public int IdActividad { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        public string NomActividad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInicial { get; set; }

        public decimal? ValorUnitario { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? ValorUnitarioCtto { get; set; }

        public decimal? CantidadCtto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCtto { get; set; }

        public decimal? ValorUnitarioEje { get; set; }

        public decimal? CantidadEje { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaEje { get; set; }

        public int? CodActividad { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesActividad> InfObservacionesActividad { get; set; }
    }
}
