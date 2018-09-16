namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hallazgo")]
    public partial class Hallazgo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hallazgo()
        {
            AdjuntoHallazgo = new HashSet<AdjuntoHallazgo>();
        }

        [Key]
        public int idHallazgo { get; set; }

        [StringLength(1000)]
        public string detalle { get; set; }

        public int? idGac { get; set; }

        [StringLength(1000)]
        public string respuesta { get; set; }

        public DateTime fechaGeneracion { get; set; }

        public DateTime? fechaRespuesta { get; set; }

        public int? estado { get; set; }

        public int idUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntoHallazgo> AdjuntoHallazgo { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
