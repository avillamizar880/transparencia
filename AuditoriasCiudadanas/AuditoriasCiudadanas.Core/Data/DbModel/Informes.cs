namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Informes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Informes()
        {
            InfObservacionesActividad = new HashSet<InfObservacionesActividad>();
            InfObservacionesCompromisos = new HashSet<InfObservacionesCompromisos>();
            InfObservacionesDudas = new HashSet<InfObservacionesDudas>();
            InfObservacionesTarea = new HashSet<InfObservacionesTarea>();
            RespuestasInforme = new HashSet<RespuestasInforme>();
        }

        [Key]
        public int idInforme { get; set; }

        public int? idusuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public int? idGac { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        [StringLength(200)]
        public string informe { get; set; }

        public int? idTipoAudiencia { get; set; }

        public virtual Gac Gac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesActividad> InfObservacionesActividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesCompromisos> InfObservacionesCompromisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesDudas> InfObservacionesDudas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesTarea> InfObservacionesTarea { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RespuestasInforme> RespuestasInforme { get; set; }
    }
}
