using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TemaCapacitacion")]
    public partial class TemaCapacitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TemaCapacitacion()
        {
            EvaluacionCapacitacion = new HashSet<EvaluacionCapacitacion>();
            RecursosCapacitacion = new HashSet<RecursosCapacitacion>();
        }

        [Key]
        public int idCap { get; set; }

        [StringLength(200)]
        public string TituloCapacitacion { get; set; }

        [StringLength(2000)]
        public string DetalleCapacitacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluacionCapacitacion> EvaluacionCapacitacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecursosCapacitacion> RecursosCapacitacion { get; set; }
    }
}
