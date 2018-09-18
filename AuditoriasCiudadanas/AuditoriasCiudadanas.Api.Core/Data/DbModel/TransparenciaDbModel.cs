using System.Data.Entity;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class TransparenciaDbModel : DbContext
    {
        public TransparenciaDbModel()
            : base("name=Transparencia")
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<AccionesGAC> AccionesGAC { get; set; }
        public virtual DbSet<AccionesUsuario> AccionesUsuario { get; set; }
        public virtual DbSet<Actas> Actas { get; set; }
        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<ActividadContrato> ActividadContrato { get; set; }
        public virtual DbSet<AdjuntoAudiencia> AdjuntoAudiencia { get; set; }
        public virtual DbSet<AdjuntoHallazgo> AdjuntoHallazgo { get; set; }
        public virtual DbSet<Adjuntos> Adjuntos { get; set; }
        public virtual DbSet<AdjuntosTarea> AdjuntosTarea { get; set; }
        public virtual DbSet<Ajuste> Ajuste { get; set; }
        public virtual DbSet<Asistentes> Asistentes { get; set; }
        public virtual DbSet<AsistentesCompromisos> AsistentesCompromisos { get; set; }
        public virtual DbSet<Audiencias> Audiencias { get; set; }
        public virtual DbSet<AutoevaluacionAC> AutoevaluacionAC { get; set; }
        public virtual DbSet<BuenasPracticas> BuenasPracticas { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Compromisos> Compromisos { get; set; }
        public virtual DbSet<CompromisosTarea> CompromisosTarea { get; set; }
        public virtual DbSet<ContactoContrato> ContactoContrato { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<CuentaCorreo> CuentaCorreo { get; set; }
        public virtual DbSet<Cuestionario> Cuestionario { get; set; }
        public virtual DbSet<DatosAdicionalesUsuario> DatosAdicionalesUsuario { get; set; }
        public virtual DbSet<DetalleRecursoMultimedia> DetalleRecursoMultimedia { get; set; }
        public virtual DbSet<DiarioNotasTarea> DiarioNotasTarea { get; set; }
        public virtual DbSet<Divipola> Divipola { get; set; }
        public virtual DbSet<Encuesta> Encuesta { get; set; }
        public virtual DbSet<EnvioCorreo> EnvioCorreo { get; set; }
        public virtual DbSet<EvalCapacitacionUsuario> EvalCapacitacionUsuario { get; set; }
        public virtual DbSet<EvaluacionCapacitacion> EvaluacionCapacitacion { get; set; }
        public virtual DbSet<EvaluarExperiencia> EvaluarExperiencia { get; set; }
        public virtual DbSet<ExperienciasGac> ExperienciasGac { get; set; }
        public virtual DbSet<FechasPropuestas> FechasPropuestas { get; set; }
        public virtual DbSet<ForoConfig> ForoConfig { get; set; }
        public virtual DbSet<ForoMensajes> ForoMensajes { get; set; }
        public virtual DbSet<Foros> Foros { get; set; }
        public virtual DbSet<FuentesFinanciacion> FuentesFinanciacion { get; set; }
        public virtual DbSet<Gac> Gac { get; set; }
        public virtual DbSet<GruposEstadistica> GruposEstadistica { get; set; }
        public virtual DbSet<Hallazgo> Hallazgo { get; set; }
        public virtual DbSet<IndicadoresProducto> IndicadoresProducto { get; set; }
        public virtual DbSet<InfObservacionesActividad> InfObservacionesActividad { get; set; }
        public virtual DbSet<InfObservacionesCompromisos> InfObservacionesCompromisos { get; set; }
        public virtual DbSet<InfObservacionesDudas> InfObservacionesDudas { get; set; }
        public virtual DbSet<InfObservacionesTarea> InfObservacionesTarea { get; set; }
        public virtual DbSet<Informes> Informes { get; set; }
        public virtual DbSet<InfoTecnicaDesc> InfoTecnicaDesc { get; set; }
        public virtual DbSet<InfoTecnicaProy> InfoTecnicaProy { get; set; }
        public virtual DbSet<Interventor> Interventor { get; set; }
        public virtual DbSet<InterventorContrato> InterventorContrato { get; set; }
        public virtual DbSet<LogConsultaInfoProyecto> LogConsultaInfoProyecto { get; set; }
        public virtual DbSet<MiembrosGac> MiembrosGac { get; set; }
        public virtual DbSet<ModificacionContrato> ModificacionContrato { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<ObjetivoEspecifico> ObjetivoEspecifico { get; set; }
        public virtual DbSet<Observaciones> Observaciones { get; set; }
        public virtual DbSet<OcadProyecto> OcadProyecto { get; set; }
        public virtual DbSet<OcadProyecto_NoCarga> OcadProyecto_NoCarga { get; set; }
        public virtual DbSet<opcionRespuestas> opcionRespuestas { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Parametrizacion> Parametrizacion { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }
        public virtual DbSet<preguntaCuestionario> preguntaCuestionario { get; set; }
        public virtual DbSet<PreguntasInforme> PreguntasInforme { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<RecCapacitacionUsuario> RecCapacitacionUsuario { get; set; }
        public virtual DbSet<RecursosCapacitacion> RecursosCapacitacion { get; set; }
        public virtual DbSet<RecursosMultimedia> RecursosMultimedia { get; set; }
        public virtual DbSet<Requisitos> Requisitos { get; set; }
        public virtual DbSet<RespuestaCuestionario> RespuestaCuestionario { get; set; }
        public virtual DbSet<RespuestasInforme> RespuestasInforme { get; set; }
        public virtual DbSet<ReunionPrevia> ReunionPrevia { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RutaReportes> RutaReportes { get; set; }
        public virtual DbSet<SolicInfoAdicional> SolicInfoAdicional { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<SupervisorContrato> SupervisorContrato { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
        public virtual DbSet<TemaCapacitacion> TemaCapacitacion { get; set; }
        public virtual DbSet<TipoCuestionario> TipoCuestionario { get; set; }
        public virtual DbSet<TipoMultimedia> TipoMultimedia { get; set; }
        public virtual DbSet<TipoPregunta> TipoPregunta { get; set; }
        public virtual DbSet<TipoRecurso> TipoRecurso { get; set; }
        public virtual DbSet<TipoReporte> TipoReporte { get; set; }
        public virtual DbSet<TiposAdjunto> TiposAdjunto { get; set; }
        public virtual DbSet<TiposAsistente> TiposAsistente { get; set; }
        public virtual DbSet<TiposAudiencia> TiposAudiencia { get; set; }
        public virtual DbSet<TiposAuditor> TiposAuditor { get; set; }
        public virtual DbSet<TiposEstadistica> TiposEstadistica { get; set; }
        public virtual DbSet<TiposTarea> TiposTarea { get; set; }
        public virtual DbSet<tipoValidacion> tipoValidacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioXProyecto> UsuarioXProyecto { get; set; }
        public virtual DbSet<Valoracion> Valoracion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acciones>()
                .Property(e => e.Tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Acciones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Acciones>()
                .HasMany(e => e.AccionesGAC)
                .WithRequired(e => e.Acciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Acciones>()
                .HasMany(e => e.AccionesUsuario)
                .WithRequired(e => e.Acciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AccionesGAC>()
                .Property(e => e.IdAccionesGAC)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccionesUsuario>()
                .Property(e => e.IdAccionesUsuario)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccionesUsuario>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Actas>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Actas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Actas>()
                .Property(e => e.ruta)
                .IsUnicode(false);

            modelBuilder.Entity<Actas>()
                .Property(e => e.idDivipola)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.NomActividad)
                .IsUnicode(false);

            modelBuilder.Entity<ActividadContrato>()
                .Property(e => e.NomActividadCon)
                .IsUnicode(false);

            modelBuilder.Entity<ActividadContrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ActividadContrato>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.NumDoc)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.CodOCAD)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.NomOCAD)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.DisminucionBenef)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.ReduccionMeta)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.ModificacionFuentesFin)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.IncrementosValor)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.DisminucionValor)
                .IsUnicode(false);

            modelBuilder.Entity<Ajuste>()
                .Property(e => e.CambioAlcance)
                .IsUnicode(false);

            modelBuilder.Entity<Audiencias>()
                .Property(e => e.idDivipola)
                .IsUnicode(false);

            modelBuilder.Entity<Audiencias>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Audiencias>()
                .HasMany(e => e.AdjuntoAudiencia)
                .WithRequired(e => e.Audiencias)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Audiencias>()
                .HasMany(e => e.Asistentes)
                .WithOptional(e => e.Audiencias)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Audiencias>()
                .HasMany(e => e.AsistentesCompromisos)
                .WithOptional(e => e.Audiencias)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Audiencias>()
                .HasMany(e => e.EvaluarExperiencia)
                .WithRequired(e => e.Audiencias)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AutoevaluacionAC>()
                .Property(e => e.ReunionesGA)
                .IsUnicode(false);

            modelBuilder.Entity<AutoevaluacionAC>()
                .Property(e => e.LogroMetasGA)
                .IsUnicode(false);

            modelBuilder.Entity<AutoevaluacionAC>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<BuenasPracticas>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Chat>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<Chat>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Compromisos>()
                .Property(e => e.responsable)
                .IsUnicode(false);

            modelBuilder.Entity<Compromisos>()
                .Property(e => e.compromiso)
                .IsUnicode(false);

            modelBuilder.Entity<Compromisos>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Compromisos>()
                .Property(e => e.ruta_img)
                .IsUnicode(false);

            modelBuilder.Entity<ContactoContrato>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ContactoContrato>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactoContrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.ValorCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NomTipoCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NomModalidad)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.ObjetoCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NombresCttista)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NombreRepLegalCttista)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.NitCttista)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Contrato>()
                .Property(e => e.PorcParticipacion)
                .HasPrecision(9, 3);

            modelBuilder.Entity<Contrato>()
                .HasMany(e => e.ActividadContrato)
                .WithRequired(e => e.Contrato)
                .HasForeignKey(e => new { e.NumCtto, e.CodigoBPIN });

            modelBuilder.Entity<CuentaCorreo>()
                .Property(e => e.UsuarioCor)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaCorreo>()
                .Property(e => e.PasswordCor)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaCorreo>()
                .Property(e => e.PuertoCor)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaCorreo>()
                .Property(e => e.UrlCor)
                .IsUnicode(false);

            modelBuilder.Entity<CuentaCorreo>()
                .HasMany(e => e.EnvioCorreo)
                .WithRequired(e => e.CuentaCorreo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cuestionario>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Cuestionario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Cuestionario>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.Genero)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.RangoEdad)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.Ocupacion)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.LugarResidencia)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.PerteneceMinoria)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.PerteneceOrganizacionSocial)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.RecursosAlcaldia)
                .IsUnicode(false);

            modelBuilder.Entity<DatosAdicionalesUsuario>()
                .Property(e => e.AuditoriasVisiblesDNP)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleRecursoMultimedia>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Divipola>()
                .Property(e => e.idDivipola)
                .IsUnicode(false);

            modelBuilder.Entity<Divipola>()
                .Property(e => e.codigoCiudad)
                .IsUnicode(false);

            modelBuilder.Entity<Divipola>()
                .Property(e => e.codigoDepto)
                .IsUnicode(false);

            modelBuilder.Entity<Divipola>()
                .Property(e => e.nombreCiudad)
                .IsUnicode(false);

            modelBuilder.Entity<Divipola>()
                .Property(e => e.nombreDepto)
                .IsUnicode(false);

            modelBuilder.Entity<EnvioCorreo>()
                .Property(e => e.NombreEnvioCor)
                .IsFixedLength();

            modelBuilder.Entity<EnvioCorreo>()
                .Property(e => e.TipoEnvioCor)
                .IsUnicode(false);

            modelBuilder.Entity<EnvioCorreo>()
                .Property(e => e.TextoEnvioCor)
                .IsUnicode(false);

            modelBuilder.Entity<EnvioCorreo>()
                .Property(e => e.HoraInicio)
                .IsUnicode(false);

            modelBuilder.Entity<EnvioCorreo>()
                .Property(e => e.MinutoInicio)
                .IsUnicode(false);

            modelBuilder.Entity<EvalCapacitacionUsuario>()
                .Property(e => e.porcentaje_aprob)
                .HasPrecision(5, 2);

            modelBuilder.Entity<EvaluacionCapacitacion>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluacionCapacitacion>()
                .HasMany(e => e.EvalCapacitacionUsuario)
                .WithRequired(e => e.EvaluacionCapacitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.TemasAudiencia)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.CiudadanoEntidadEj)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.CiudadanoSupervisor)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.CiudadanoInterventor)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.CiudadanoContratista)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.DestacarAudiencia)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.MejorarAudiencia)
                .IsUnicode(false);

            modelBuilder.Entity<EvaluarExperiencia>()
                .Property(e => e.ObsMejorarAudiencia)
                .IsUnicode(false);

            modelBuilder.Entity<ExperienciasGac>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ExperienciasGac>()
                .Property(e => e.rutaUrlAdjunto)
                .IsUnicode(false);

            modelBuilder.Entity<FechasPropuestas>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .Property(e => e.NombreForo)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .Property(e => e.DescripcionForo)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .Property(e => e.idPerfilVer)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .Property(e => e.idPerfilPublicar)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .Property(e => e.idPerfilResponder)
                .IsUnicode(false);

            modelBuilder.Entity<ForoConfig>()
                .HasMany(e => e.Foros)
                .WithRequired(e => e.ForoConfig)
                .HasForeignKey(e => e.idForoConfig)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ForoMensajes>()
                .HasMany(e => e.ForoMensajes1)
                .WithOptional(e => e.ForoMensajes2)
                .HasForeignKey(e => e.idMensajeRef);

            modelBuilder.Entity<Foros>()
                .HasMany(e => e.ForoMensajes)
                .WithRequired(e => e.Foros)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.CodEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.NomEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.CodFuenteFin)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.NomFuenteFin)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.Vigencia)
                .IsUnicode(false);

            modelBuilder.Entity<FuentesFinanciacion>()
                .Property(e => e.Valor)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Gac>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Gac>()
                .Property(e => e.MotivoCreacion)
                .IsUnicode(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.AccionesGAC)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.BuenasPracticas)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.ExperienciasGac)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.FechasPropuestas)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.MiembrosGac)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gac>()
                .HasMany(e => e.SolicInfoAdicional)
                .WithRequired(e => e.Gac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GruposEstadistica>()
                .Property(e => e.nom_grupo)
                .IsUnicode(false);

            modelBuilder.Entity<GruposEstadistica>()
                .HasMany(e => e.TiposEstadistica)
                .WithOptional(e => e.GruposEstadistica)
                .HasForeignKey(e => e.id_grupo);

            modelBuilder.Entity<Hallazgo>()
                .HasMany(e => e.AdjuntoHallazgo)
                .WithRequired(e => e.Hallazgo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.CodIndicador)
                .IsUnicode(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.NomIndicador)
                .IsUnicode(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.NomObjetivoEspecifico)
                .IsUnicode(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<IndicadoresProducto>()
                .Property(e => e.NomUnidadProducto)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesActividad>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesCompromisos>()
                .Property(e => e.Compromiso)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesCompromisos>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesCompromisos>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesCompromisos>()
                .Property(e => e.Cumplimiento)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesDudas>()
                .Property(e => e.Duda)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesDudas>()
                .Property(e => e.Responsable)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesDudas>()
                .Property(e => e.Conclusiones)
                .IsUnicode(false);

            modelBuilder.Entity<InfObservacionesTarea>()
                .Property(e => e.Porcentaje)
                .HasPrecision(5, 2);

            modelBuilder.Entity<InfObservacionesTarea>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Informes>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Informes>()
                .Property(e => e.informe)
                .IsUnicode(false);

            modelBuilder.Entity<Informes>()
                .HasMany(e => e.RespuestasInforme)
                .WithOptional(e => e.Informes)
                .WillCascadeOnDelete();

            modelBuilder.Entity<InfoTecnicaDesc>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaDesc>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaDesc>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaProy>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaProy>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaProy>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaProy>()
                .Property(e => e.IdAdjunto)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTecnicaProy>()
                .Property(e => e.UrlFoto)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.NomInterventor)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.NomRepLegalInterventor)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.NitInterventor)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Interventor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<InterventorContrato>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<InterventorContrato>()
                .Property(e => e.NitInterventor)
                .IsUnicode(false);

            modelBuilder.Entity<InterventorContrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<LogConsultaInfoProyecto>()
                .Property(e => e.idLog)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LogConsultaInfoProyecto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.CodTipoModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.NomTipoModificacion)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.UnidadTiempoModif)
                .IsUnicode(false);

            modelBuilder.Entity<ModificacionContrato>()
                .Property(e => e.ValorModif)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.tipo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.parametros)
                .IsUnicode(false);

            modelBuilder.Entity<ObjetivoEspecifico>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<ObjetivoEspecifico>()
                .Property(e => e.NombreObjetivoEspecifico)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.infoClara)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.infoCompleta)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.ComunidadBenef)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.dudas)
                .IsUnicode(false);

            modelBuilder.Entity<Observaciones>()
                .Property(e => e.infoFaltante)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto>()
                .Property(e => e.CodOcad)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto>()
                .Property(e => e.NumDocAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto_NoCarga>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto_NoCarga>()
                .Property(e => e.CodOcad)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto_NoCarga>()
                .Property(e => e.NumDocAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto_NoCarga>()
                .Property(e => e.errorCode)
                .IsUnicode(false);

            modelBuilder.Entity<OcadProyecto_NoCarga>()
                .Property(e => e.errorColumn)
                .IsUnicode(false);

            modelBuilder.Entity<opcionRespuestas>()
                .Property(e => e.etiquetaOpcion)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.CodConcepPago)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.NomConcepPago)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.CodFuenteFin)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.NomFuenteFin)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.NitBeneficiario)
                .IsUnicode(false);

            modelBuilder.Entity<Pagos>()
                .Property(e => e.Valor)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Parametrizacion>()
                .Property(e => e.ValTexto)
                .IsUnicode(false);

            modelBuilder.Entity<Parametrizacion>()
                .Property(e => e.Llave)
                .IsUnicode(false);

            modelBuilder.Entity<Parametrizacion>()
                .Property(e => e.DescParam)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.NombrePerfil)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.idPoliza)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.nomTipoAmparo)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.IdAseguradora)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.nombreAseguradora)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.numeroAmparo)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.beneficiario)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.tomador)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.TDocAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Poliza>()
                .Property(e => e.NumAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.textoPregunta)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.textoExplicativo)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.textoJustificacion)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.MensajeErrorValida)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.EtiquetaMin)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.EtiquetaMax)
                .IsUnicode(false);

            modelBuilder.Entity<preguntaCuestionario>()
                .Property(e => e.Obligatoria)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NombreProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.UnidadProducto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CantidadProducto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Producto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Objeto)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NomSector)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NomSectorReclasif)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NitEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NomEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.CodEntidad)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.PorEjecucionFisica)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.PorEjecucionFinanc)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NomEstado)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.IdRepLegal)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.NomRepLegal)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.ActividadContrato)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.BuenasPracticas)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.ExperienciasGac)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.FechasPropuestas)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.IndicadoresProducto)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.ObjetivoEspecifico)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.SolicInfoAdicional)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.UsuarioXProyecto)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Divipola)
                .WithMany(e => e.Proyecto)
                .Map(m => m.ToTable("ProyectoXEntidadTerritorial").MapLeftKey("codigoBPIN").MapRightKey("idDivipola"));

            modelBuilder.Entity<RecursosCapacitacion>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<RecursosCapacitacion>()
                .Property(e => e.estado)
                .IsFixedLength();

            modelBuilder.Entity<RecursosCapacitacion>()
                .HasMany(e => e.RecCapacitacionUsuario)
                .WithRequired(e => e.RecursosCapacitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RecursosMultimedia>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<RecursosMultimedia>()
                .Property(e => e.Publicado)
                .IsUnicode(false);

            modelBuilder.Entity<RecursosMultimedia>()
                .HasMany(e => e.DetalleRecursoMultimedia)
                .WithRequired(e => e.RecursosMultimedia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisitos>()
                .Property(e => e.NomRequisito)
                .IsUnicode(false);

            modelBuilder.Entity<Requisitos>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<RespuestaCuestionario>()
                .Property(e => e.textoAbierta)
                .IsUnicode(false);

            modelBuilder.Entity<ReunionPrevia>()
                .Property(e => e.idDivipola)
                .IsUnicode(false);

            modelBuilder.Entity<ReunionPrevia>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.NombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<RutaReportes>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<RutaReportes>()
                .Property(e => e.ruta)
                .IsUnicode(false);

            modelBuilder.Entity<SolicInfoAdicional>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<SolicInfoAdicional>()
                .Property(e => e.respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.NomSupervisor)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.NitSupervisor)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.CodDependencia)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.NomDependencia)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.CodCargo)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.NomCargo)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<SupervisorContrato>()
                .Property(e => e.NumCtto)
                .IsUnicode(false);

            modelBuilder.Entity<SupervisorContrato>()
                .Property(e => e.NitSupervisor)
                .IsUnicode(false);

            modelBuilder.Entity<SupervisorContrato>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Tareas>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Tareas>()
                .HasMany(e => e.AdjuntosTarea)
                .WithOptional(e => e.Tareas)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TemaCapacitacion>()
                .Property(e => e.TituloCapacitacion)
                .IsUnicode(false);

            modelBuilder.Entity<TemaCapacitacion>()
                .Property(e => e.DetalleCapacitacion)
                .IsUnicode(false);

            modelBuilder.Entity<TemaCapacitacion>()
                .Property(e => e.Activo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TemaCapacitacion>()
                .HasMany(e => e.EvaluacionCapacitacion)
                .WithRequired(e => e.TemaCapacitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TemaCapacitacion>()
                .HasMany(e => e.RecursosCapacitacion)
                .WithRequired(e => e.TemaCapacitacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoCuestionario>()
                .Property(e => e.nomTipoCuestionario)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCuestionario>()
                .HasMany(e => e.Cuestionario)
                .WithRequired(e => e.TipoCuestionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoMultimedia>()
                .Property(e => e.nomTipoMedio)
                .IsUnicode(false);

            modelBuilder.Entity<TipoMultimedia>()
                .HasMany(e => e.DetalleRecursoMultimedia)
                .WithRequired(e => e.TipoMultimedia)
                .HasForeignKey(e => e.idTipoMedio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoMultimedia>()
                .HasMany(e => e.RecursosCapacitacion)
                .WithOptional(e => e.TipoMultimedia)
                .HasForeignKey(e => e.IdTipoMultimedia);

            modelBuilder.Entity<TipoPregunta>()
                .Property(e => e.nomTipoPregunta)
                .IsUnicode(false);

            modelBuilder.Entity<TipoRecurso>()
                .Property(e => e.nomTipoRecurso)
                .IsUnicode(false);

            modelBuilder.Entity<TipoRecurso>()
                .HasMany(e => e.RecursosMultimedia)
                .WithRequired(e => e.TipoRecurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoReporte>()
                .HasMany(e => e.RutaReportes)
                .WithRequired(e => e.TipoReporte1)
                .HasForeignKey(e => e.TipoReporte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposAsistente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TiposAsistente>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposAsistente>()
                .HasMany(e => e.AsistentesCompromisos)
                .WithOptional(e => e.TiposAsistente)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TiposAudiencia>()
                .HasMany(e => e.Audiencias)
                .WithOptional(e => e.TiposAudiencia)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TiposAudiencia>()
                .HasMany(e => e.FechasPropuestas)
                .WithRequired(e => e.TiposAudiencia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposEstadistica>()
                .Property(e => e.nom_tipo_estadistica)
                .IsUnicode(false);

            modelBuilder.Entity<tipoValidacion>()
                .Property(e => e.NomtipoValidacion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Celular)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.hash_clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.idDivipola)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.cod_verifica)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.AccionesUsuario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.AutoevaluacionAC)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.BuenasPracticas)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.idUsuAprueba);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.BuenasPracticas1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Chat)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idDestinatario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Chat1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.idRemitente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Compromisos)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cuestionario)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.idUsuarioCrea);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cuestionario1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuarioModif);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.DatosAdicionalesUsuario)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.DatosAdicionalesUsuario1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.DetalleRecursoMultimedia)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.DetalleRecursoMultimedia1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuarioModif);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.EvaluarExperiencia)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.ExperienciasGac)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.idUsuAprueba);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.ExperienciasGac1)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.FechasPropuestas)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.ForoMensajes)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuarioCrea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Hallazgo)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.InfoTecnicaDesc)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.InfoTecnicaDesc1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuarioModif);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.MiembrosGac)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.RecursosMultimedia)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.RecursosMultimedia1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuarioModif);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.RespuestaCuestionario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.SolicInfoAdicional)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuarioXProyecto)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsuarioXProyecto>()
                .Property(e => e.CodigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.codigoBPIN)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP1)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP2)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP3)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP4)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP5)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP1)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP2)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3GAC)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3Int)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3Sup)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3Con)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3Eje)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP3Ent)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4GAC)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4Int)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4Sup)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4Con)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4Eje)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP4Ent)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP5)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.AudP6)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.GacP1)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.GacP2)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.GacP3)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP3Cual)
                .IsUnicode(false);

            modelBuilder.Entity<Valoracion>()
                .Property(e => e.ProyP3Op)
                .IsFixedLength();
        }
    }
}
