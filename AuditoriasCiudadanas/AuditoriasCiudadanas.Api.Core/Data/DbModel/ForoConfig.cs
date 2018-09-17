using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("ForoConfig")]
    public partial class ForoConfig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForoConfig()
        {
            Foros = new HashSet<Foros>();
        }

        [Key]
        public int idConfig { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreForo { get; set; }

        [Required]
        [StringLength(500)]
        public string DescripcionForo { get; set; }

        [StringLength(50)]
        public string idPerfilVer { get; set; }

        [StringLength(50)]
        public string idPerfilPublicar { get; set; }

        [StringLength(50)]
        public string idPerfilResponder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foros> Foros { get; set; }
    }
}
