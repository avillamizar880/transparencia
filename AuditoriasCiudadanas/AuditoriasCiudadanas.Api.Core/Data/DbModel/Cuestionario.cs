using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Cuestionario")]
    public partial class Cuestionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuestionario()
        {
            EvaluacionCapacitacion = new HashSet<EvaluacionCapacitacion>();
        }

        [Key]
        public int idCuestionario { get; set; }

        public int idTipoCuestionario { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int? idUsuarioCrea { get; set; }

        [StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int? idUsuarioModif { get; set; }

        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public virtual TipoCuestionario TipoCuestionario { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluacionCapacitacion> EvaluacionCapacitacion { get; set; }
    }
}
