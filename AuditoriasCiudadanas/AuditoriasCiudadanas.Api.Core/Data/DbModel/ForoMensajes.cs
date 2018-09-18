using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class ForoMensajes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForoMensajes()
        {
            ForoMensajes1 = new HashSet<ForoMensajes>();
        }

        [Key]
        public int idForoMensaje { get; set; }

        [Required]
        public string mensaje { get; set; }

        public int idForo { get; set; }

        public int? idMensajeRef { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int idUsuarioCrea { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForoMensajes> ForoMensajes1 { get; set; }

        public virtual ForoMensajes ForoMensajes2 { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Foros Foros { get; set; }
    }
}
