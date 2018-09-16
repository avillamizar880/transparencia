namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Acciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acciones()
        {
            AccionesGAC = new HashSet<AccionesGAC>();
            AccionesUsuario = new HashSet<AccionesUsuario>();
        }

        [Key]
        public int IdAccion { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        public int? Puntaje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccionesGAC> AccionesGAC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccionesUsuario> AccionesUsuario { get; set; }
    }
}
