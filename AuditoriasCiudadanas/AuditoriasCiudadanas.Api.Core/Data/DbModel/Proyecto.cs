using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Proyecto")]
    public partial class Proyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto()
        {
            Actividad = new HashSet<Actividad>();
            ActividadContrato = new HashSet<ActividadContrato>();
            Ajuste = new HashSet<Ajuste>();
            Audiencias = new HashSet<Audiencias>();
            AutoevaluacionAC = new HashSet<AutoevaluacionAC>();
            BuenasPracticas = new HashSet<BuenasPracticas>();
            ContactoContrato = new HashSet<ContactoContrato>();
            Contrato = new HashSet<Contrato>();
            ExperienciasGac = new HashSet<ExperienciasGac>();
            FechasPropuestas = new HashSet<FechasPropuestas>();
            FuentesFinanciacion = new HashSet<FuentesFinanciacion>();
            Gac = new HashSet<Gac>();
            IndicadoresProducto = new HashSet<IndicadoresProducto>();
            Informes = new HashSet<Informes>();
            InfoTecnicaDesc = new HashSet<InfoTecnicaDesc>();
            InfoTecnicaProy = new HashSet<InfoTecnicaProy>();
            Interventor = new HashSet<Interventor>();
            InterventorContrato = new HashSet<InterventorContrato>();
            ModificacionContrato = new HashSet<ModificacionContrato>();
            ObjetivoEspecifico = new HashSet<ObjetivoEspecifico>();
            Observaciones = new HashSet<Observaciones>();
            OcadProyecto = new HashSet<OcadProyecto>();
            Pagos = new HashSet<Pagos>();
            Poliza = new HashSet<Poliza>();
            Producto = new HashSet<Producto>();
            Requisitos = new HashSet<Requisitos>();
            ReunionPrevia = new HashSet<ReunionPrevia>();
            SolicInfoAdicional = new HashSet<SolicInfoAdicional>();
            Supervisor = new HashSet<Supervisor>();
            SupervisorContrato = new HashSet<SupervisorContrato>();
            Tareas = new HashSet<Tareas>();
            UsuarioXProyecto = new HashSet<UsuarioXProyecto>();
            Valoracion = new HashSet<Valoracion>();
            Divipola = new HashSet<Divipola>();
        }

        [Key]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        public string Objeto { get; set; }

        public int? IdSector { get; set; }

        [StringLength(200)]
        public string NomSector { get; set; }

        [StringLength(200)]
        public string NomSectorReclasif { get; set; }

        [StringLength(50)]
        public string NitEntidad { get; set; }

        [StringLength(500)]
        public string NomEntidad { get; set; }

        [StringLength(50)]
        public string CodEntidad { get; set; }

        [StringLength(10)]
        public string PorEjecucionFisica { get; set; }

        [StringLength(10)]
        public string PorEjecucionFinanc { get; set; }

        public decimal? VlrTotalProyecto { get; set; }

        public long? NumeroBeneficiarios { get; set; }

        [StringLength(10)]
        public string CodEstado { get; set; }

        [StringLength(50)]
        public string NomEstado { get; set; }

        [StringLength(100)]
        public string IdRepLegal { get; set; }

        [StringLength(201)]
        public string NomRepLegal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActividadContrato> ActividadContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ajuste> Ajuste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Audiencias> Audiencias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoevaluacionAC> AutoevaluacionAC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuenasPracticas> BuenasPracticas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactoContrato> ContactoContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienciasGac> ExperienciasGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FechasPropuestas> FechasPropuestas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuentesFinanciacion> FuentesFinanciacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gac> Gac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndicadoresProducto> IndicadoresProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informes> Informes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoTecnicaDesc> InfoTecnicaDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoTecnicaProy> InfoTecnicaProy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Interventor> Interventor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterventorContrato> InterventorContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModificacionContrato> ModificacionContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjetivoEspecifico> ObjetivoEspecifico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observaciones> Observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OcadProyecto> OcadProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pagos> Pagos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poliza> Poliza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requisitos> Requisitos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReunionPrevia> ReunionPrevia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicInfoAdicional> SolicInfoAdicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supervisor> Supervisor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupervisorContrato> SupervisorContrato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tareas> Tareas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioXProyecto> UsuarioXProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valoracion> Valoracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Divipola> Divipola { get; set; }
    }
}
