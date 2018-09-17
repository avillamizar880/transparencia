using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Divipola")]
    public partial class Divipola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Divipola()
        {
            Audiencias = new HashSet<Audiencias>();
            Usuario = new HashSet<Usuario>();
            Proyecto = new HashSet<Proyecto>();
        }

        [Key]
        [StringLength(15)]
        public string idDivipola { get; set; }

        [StringLength(15)]
        public string codigoCiudad { get; set; }

        [StringLength(15)]
        public string codigoDepto { get; set; }

        [StringLength(100)]
        public string nombreCiudad { get; set; }

        [StringLength(100)]
        public string nombreDepto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Audiencias> Audiencias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
