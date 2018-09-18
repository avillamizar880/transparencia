using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TiposAdjunto")]
    public partial class TiposAdjunto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiposAdjunto()
        {
            AdjuntoAudiencia = new HashSet<AdjuntoAudiencia>();
            Adjuntos = new HashSet<Adjuntos>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTipoAdjunto { get; set; }

        [StringLength(1000)]
        public string nombre { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntoAudiencia> AdjuntoAudiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjuntos> Adjuntos { get; set; }
    }
}
