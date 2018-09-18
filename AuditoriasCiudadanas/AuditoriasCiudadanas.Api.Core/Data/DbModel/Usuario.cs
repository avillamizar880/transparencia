using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            AccionesUsuario = new HashSet<AccionesUsuario>();
            Actas = new HashSet<Actas>();
            AdjuntoAudiencia = new HashSet<AdjuntoAudiencia>();
            AdjuntoHallazgo = new HashSet<AdjuntoHallazgo>();
            Adjuntos = new HashSet<Adjuntos>();
            AutoevaluacionAC = new HashSet<AutoevaluacionAC>();
            BuenasPracticas = new HashSet<BuenasPracticas>();
            BuenasPracticas1 = new HashSet<BuenasPracticas>();
            Chat = new HashSet<Chat>();
            Chat1 = new HashSet<Chat>();
            Compromisos = new HashSet<Compromisos>();
            Cuestionario = new HashSet<Cuestionario>();
            Cuestionario1 = new HashSet<Cuestionario>();
            DatosAdicionalesUsuario = new HashSet<DatosAdicionalesUsuario>();
            DatosAdicionalesUsuario1 = new HashSet<DatosAdicionalesUsuario>();
            DetalleRecursoMultimedia = new HashSet<DetalleRecursoMultimedia>();
            DetalleRecursoMultimedia1 = new HashSet<DetalleRecursoMultimedia>();
            EvalCapacitacionUsuario = new HashSet<EvalCapacitacionUsuario>();
            EvaluarExperiencia = new HashSet<EvaluarExperiencia>();
            ExperienciasGac = new HashSet<ExperienciasGac>();
            ExperienciasGac1 = new HashSet<ExperienciasGac>();
            FechasPropuestas = new HashSet<FechasPropuestas>();
            ForoMensajes = new HashSet<ForoMensajes>();
            Hallazgo = new HashSet<Hallazgo>();
            InfObservacionesActividad = new HashSet<InfObservacionesActividad>();
            InfObservacionesCompromisos = new HashSet<InfObservacionesCompromisos>();
            InfObservacionesDudas = new HashSet<InfObservacionesDudas>();
            InfObservacionesTarea = new HashSet<InfObservacionesTarea>();
            Informes = new HashSet<Informes>();
            InfoTecnicaDesc = new HashSet<InfoTecnicaDesc>();
            InfoTecnicaDesc1 = new HashSet<InfoTecnicaDesc>();
            InfoTecnicaProy = new HashSet<InfoTecnicaProy>();
            MiembrosGac = new HashSet<MiembrosGac>();
            Observaciones = new HashSet<Observaciones>();
            RecCapacitacionUsuario = new HashSet<RecCapacitacionUsuario>();
            RecursosMultimedia = new HashSet<RecursosMultimedia>();
            RecursosMultimedia1 = new HashSet<RecursosMultimedia>();
            RespuestaCuestionario = new HashSet<RespuestaCuestionario>();
            SolicInfoAdicional = new HashSet<SolicInfoAdicional>();
            Tareas = new HashSet<Tareas>();
            UsuarioXProyecto = new HashSet<UsuarioXProyecto>();
            Valoracion = new HashSet<Valoracion>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(400)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [StringLength(15)]
        public string Celular { get; set; }

        [Required]
        [StringLength(200)]
        public string hash_clave { get; set; }

        public int? puntaje { get; set; }

        public int? IdPerfil { get; set; }

        [StringLength(15)]
        public string idDivipola { get; set; }

        public int? idTipoAuditor { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        public DateTime? FCambioPwd { get; set; }

        public DateTime? FechaPregEnc { get; set; }

        [StringLength(64)]
        public string cod_verifica { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccionesUsuario> AccionesUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actas> Actas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntoAudiencia> AdjuntoAudiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdjuntoHallazgo> AdjuntoHallazgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjuntos> Adjuntos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoevaluacionAC> AutoevaluacionAC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuenasPracticas> BuenasPracticas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuenasPracticas> BuenasPracticas1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compromisos> Compromisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuestionario> Cuestionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuestionario> Cuestionario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosAdicionalesUsuario> DatosAdicionalesUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosAdicionalesUsuario> DatosAdicionalesUsuario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRecursoMultimedia> DetalleRecursoMultimedia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRecursoMultimedia> DetalleRecursoMultimedia1 { get; set; }

        public virtual Divipola Divipola { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvalCapacitacionUsuario> EvalCapacitacionUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvaluarExperiencia> EvaluarExperiencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienciasGac> ExperienciasGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienciasGac> ExperienciasGac1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FechasPropuestas> FechasPropuestas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ForoMensajes> ForoMensajes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hallazgo> Hallazgo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesActividad> InfObservacionesActividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesCompromisos> InfObservacionesCompromisos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesDudas> InfObservacionesDudas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfObservacionesTarea> InfObservacionesTarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informes> Informes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoTecnicaDesc> InfoTecnicaDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoTecnicaDesc> InfoTecnicaDesc1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoTecnicaProy> InfoTecnicaProy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MiembrosGac> MiembrosGac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observaciones> Observaciones { get; set; }

        public virtual Perfil Perfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecCapacitacionUsuario> RecCapacitacionUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecursosMultimedia> RecursosMultimedia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecursosMultimedia> RecursosMultimedia1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RespuestaCuestionario> RespuestaCuestionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicInfoAdicional> SolicInfoAdicional { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tareas> Tareas { get; set; }

        public virtual TiposAuditor TiposAuditor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioXProyecto> UsuarioXProyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Valoracion> Valoracion { get; set; }
    }
}
