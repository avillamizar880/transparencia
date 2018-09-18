using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Contrato")]
    public partial class Contrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato()
        {
            ActividadContrato = new HashSet<ActividadContrato>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NumCtto { get; set; }

        public DateTime? FechaSuscripcion { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFinalCtto { get; set; }

        public DateTime? FechaFinalRealCtto { get; set; }

        [StringLength(50)]
        public string ValorCtto { get; set; }

        public double? CodTipoCtto { get; set; }

        [StringLength(200)]
        public string NomTipoCtto { get; set; }

        public int? CodModalidad { get; set; }

        [StringLength(200)]
        public string NomModalidad { get; set; }

        [StringLength(2000)]
        public string ObjetoCtto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [StringLength(200)]
        public string NombresCttista { get; set; }

        [StringLength(200)]
        public string NombreRepLegalCttista { get; set; }

        [StringLength(100)]
        public string NitCttista { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Telefono { get; set; }

        public decimal? PorcParticipacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActividadContrato> ActividadContrato { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
