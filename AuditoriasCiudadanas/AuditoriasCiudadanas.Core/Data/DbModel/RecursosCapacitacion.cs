namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecursosCapacitacion")]
    public partial class RecursosCapacitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RecursosCapacitacion()
        {
            RecCapacitacionUsuario = new HashSet<RecCapacitacionUsuario>();
        }

        [Key]
        public int idRCap { get; set; }

        public int idCap { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int? modulo { get; set; }

        public int? IdTipoMultimedia { get; set; }

        [StringLength(200)]
        public string Titulo { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int? idUsuarioModif { get; set; }

        [StringLength(300)]
        public string URL { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecCapacitacionUsuario> RecCapacitacionUsuario { get; set; }

        public virtual TemaCapacitacion TemaCapacitacion { get; set; }

        public virtual TipoMultimedia TipoMultimedia { get; set; }
    }
}
