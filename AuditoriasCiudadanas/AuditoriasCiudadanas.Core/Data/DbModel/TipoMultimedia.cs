namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoMultimedia")]
    public partial class TipoMultimedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMultimedia()
        {
            DetalleRecursoMultimedia = new HashSet<DetalleRecursoMultimedia>();
            RecursosCapacitacion = new HashSet<RecursosCapacitacion>();
        }

        [Key]
        public int idMedio { get; set; }

        [Required]
        [StringLength(50)]
        public string nomTipoMedio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRecursoMultimedia> DetalleRecursoMultimedia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecursosCapacitacion> RecursosCapacitacion { get; set; }
    }
}
