using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TipoPregunta")]
    public partial class TipoPregunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoPregunta()
        {
            preguntaCuestionario = new HashSet<preguntaCuestionario>();
        }

        [Key]
        public int idTipoPregunta { get; set; }

        [StringLength(200)]
        public string nomTipoPregunta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preguntaCuestionario> preguntaCuestionario { get; set; }
    }
}
