namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tareas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tareas()
        {
            AdjuntosTarea = new HashSet<AdjuntosTarea>();
            CompromisosTarea = new HashSet<CompromisosTarea>();
            DiarioNotasTarea = new HashSet<DiarioNotasTarea>();
            InfObservacionesTarea = new HashSet<InfObservacionesTarea>();
        }

        [Key]
        public int idTarea { get; set; }

        public int? idTipoTarea { get; set; }

        [StringLength(1000)]
        public string detalle { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(1000)]
        public string observaciones { get; set; }

        [StringLength(1000)]
        public string Resultado { get; set; }

        public DateTime? fechaResultado { get; set; }

        public int? estado { get; set; }

        [StringLength(1000)]
        public string ObservacionAuditor { get; set; }

        public DateTime? FechaObservacionAuditor { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public DateTime? fechaCierreTarea { get; set; }

        [StringLength(1000)]
        public string funcionarioAcompanaVisita { get; set; }

        [StringLength(1000)]
        public string actividadesVisitaCampo { get; set; }

        public int? idGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntosTarea> AdjuntosTarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompromisosTarea> CompromisosTarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiarioNotasTarea> DiarioNotasTarea { get; set; }

        public virtual Gac Gac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesTarea> InfObservacionesTarea { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual TiposTarea TiposTarea { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
