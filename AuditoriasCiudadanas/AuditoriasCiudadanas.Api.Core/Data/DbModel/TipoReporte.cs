using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("TipoReporte")]
    public partial class TipoReporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoReporte()
        {
            RutaReportes = new HashSet<RutaReportes>();
        }

        [Key]
        [Column("TipoReporte")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoReporte1 { get; set; }

        [StringLength(1000)]
        public string nombre { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RutaReportes> RutaReportes { get; set; }
    }
}
