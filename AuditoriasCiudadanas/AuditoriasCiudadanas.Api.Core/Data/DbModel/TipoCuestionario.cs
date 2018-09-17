using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TipoCuestionario")]
    public partial class TipoCuestionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoCuestionario()
        {
            Cuestionario = new HashSet<Cuestionario>();
        }

        [Key]
        public int idTipoCuestionario { get; set; }

        [StringLength(200)]
        public string nomTipoCuestionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuestionario> Cuestionario { get; set; }
    }
}
