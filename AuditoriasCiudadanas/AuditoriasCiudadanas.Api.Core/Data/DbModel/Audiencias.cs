using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Audiencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Audiencias()
        {
            AdjuntoAudiencia = new HashSet<AdjuntoAudiencia>();
            Asistentes = new HashSet<Asistentes>();
            AsistentesCompromisos = new HashSet<AsistentesCompromisos>();
            EvaluarExperiencia = new HashSet<EvaluarExperiencia>();
        }

        [Key]
        public int idAudiencia { get; set; }

        public int? estado { get; set; }

        [StringLength(15)]
        public string idDivipola { get; set; }

        public int? idTipoAudiencia { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        public int? acta { get; set; }

        public int? numeroAsistentes { get; set; }

        public int? usuarioCrea { get; set; }

        public int? idGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntoAudiencia> AdjuntoAudiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistentes> Asistentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsistentesCompromisos> AsistentesCompromisos { get; set; }

        public virtual Divipola Divipola { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual TiposAudiencia TiposAudiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluarExperiencia> EvaluarExperiencia { get; set; }
    }
}
