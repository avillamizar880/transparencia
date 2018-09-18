using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TiposAsistente")]
    public partial class TiposAsistente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiposAsistente()
        {
            AsistentesCompromisos = new HashSet<AsistentesCompromisos>();
        }

        [Key]
        public int idTipoAsistente { get; set; }

        [StringLength(200)]
        public string nombre { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsistentesCompromisos> AsistentesCompromisos { get; set; }
    }
}
