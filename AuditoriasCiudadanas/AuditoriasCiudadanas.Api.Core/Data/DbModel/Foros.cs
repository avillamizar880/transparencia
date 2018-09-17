using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Foros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Foros()
        {
            ForoMensajes = new HashSet<ForoMensajes>();
        }

        [Key]
        public int idForo { get; set; }

        [Required]
        [StringLength(300)]
        public string tema { get; set; }

        public string descripcion { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int idUsuarioCrea { get; set; }

        public DateTime? fechaModif { get; set; }

        public int? estado { get; set; }

        public int idForoConfig { get; set; }

        public virtual ForoConfig ForoConfig { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForoMensajes> ForoMensajes { get; set; }
    }
}
