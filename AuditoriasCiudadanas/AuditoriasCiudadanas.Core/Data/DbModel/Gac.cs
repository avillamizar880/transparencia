namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gac")]
    public partial class Gac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gac()
        {
            AccionesGAC = new HashSet<AccionesGAC>();
            BuenasPracticas = new HashSet<BuenasPracticas>();
            ExperienciasGac = new HashSet<ExperienciasGac>();
            FechasPropuestas = new HashSet<FechasPropuestas>();
            Hallazgo = new HashSet<Hallazgo>();
            Informes = new HashSet<Informes>();
            MiembrosGac = new HashSet<MiembrosGac>();
            Observaciones = new HashSet<Observaciones>();
            RutaReportes = new HashSet<RutaReportes>();
            SolicInfoAdicional = new HashSet<SolicInfoAdicional>();
            Tareas = new HashSet<Tareas>();
        }

        [Key]
        public int idGac { get; set; }

        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [StringLength(500)]
        public string MotivoCreacion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? PuntajeGrupo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccionesGAC> AccionesGAC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuenasPracticas> BuenasPracticas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienciasGac> ExperienciasGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FechasPropuestas> FechasPropuestas { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hallazgo> Hallazgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informes> Informes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiembrosGac> MiembrosGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observaciones> Observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RutaReportes> RutaReportes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicInfoAdicional> SolicInfoAdicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}
