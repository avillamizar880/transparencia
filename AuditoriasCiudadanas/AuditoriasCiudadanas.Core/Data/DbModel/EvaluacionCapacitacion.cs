namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvaluacionCapacitacion")]
    public partial class EvaluacionCapacitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvaluacionCapacitacion()
        {
            EvalCapacitacionUsuario = new HashSet<EvalCapacitacionUsuario>();
        }

        [Key]
        public int idECap { get; set; }

        public int idCap { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int? IdCuestionario { get; set; }

        [StringLength(200)]
        public string Titulo { get; set; }

        public virtual Cuestionario Cuestionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalCapacitacionUsuario> EvalCapacitacionUsuario { get; set; }

        public virtual TemaCapacitacion TemaCapacitacion { get; set; }
    }
}
