namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tipoValidacion")]
    public partial class tipoValidacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipoValidacion()
        {
            preguntaCuestionario = new HashSet<preguntaCuestionario>();
        }

        [Key]
        public int idTipoValidacion { get; set; }

        [StringLength(200)]
        public string NomtipoValidacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preguntaCuestionario> preguntaCuestionario { get; set; }
    }
}
