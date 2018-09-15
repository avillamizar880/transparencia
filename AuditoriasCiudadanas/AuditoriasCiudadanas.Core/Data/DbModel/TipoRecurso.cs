namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoRecurso")]
    public partial class TipoRecurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoRecurso()
        {
            RecursosMultimedia = new HashSet<RecursosMultimedia>();
        }

        [Key]
        public int idTipoRecurso { get; set; }

        [Required]
        [StringLength(50)]
        public string nomTipoRecurso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecursosMultimedia> RecursosMultimedia { get; set; }
    }
}
