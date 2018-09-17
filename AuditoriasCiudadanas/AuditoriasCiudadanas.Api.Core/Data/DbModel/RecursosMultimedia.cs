using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("RecursosMultimedia")]
    public partial class RecursosMultimedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RecursosMultimedia()
        {
            DetalleRecursoMultimedia = new HashSet<DetalleRecursoMultimedia>();
        }

        [Key]
        public int idRecurso { get; set; }

        [Required]
        public string titulo { get; set; }

        public string descripcion { get; set; }

        public int idTipoRecurso { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int? idUsuarioModif { get; set; }

        [Required]
        [StringLength(300)]
        public string rutaUrl { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(1)]
        public string Publicado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRecursoMultimedia> DetalleRecursoMultimedia { get; set; }

        public virtual TipoRecurso TipoRecurso { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
