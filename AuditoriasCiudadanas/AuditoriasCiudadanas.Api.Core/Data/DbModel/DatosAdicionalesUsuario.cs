using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("DatosAdicionalesUsuario")]
    public partial class DatosAdicionalesUsuario
    {
        [Key]
        public int IdEncuestaCaracterizacion { get; set; }

        public int IdUsuario { get; set; }

        public DateTime? Fecha { get; set; }

        [StringLength(50)]
        public string Genero { get; set; }

        [StringLength(20)]
        public string RangoEdad { get; set; }

        [StringLength(200)]
        public string Ocupacion { get; set; }

        [StringLength(50)]
        public string LugarResidencia { get; set; }

        [StringLength(2)]
        public string PerteneceMinoria { get; set; }

        [StringLength(2)]
        public string PerteneceOrganizacionSocial { get; set; }

        [StringLength(250)]
        public string MecanismoHaParticipado { get; set; }

        [StringLength(10)]
        public string RecursosAlcaldia { get; set; }

        [StringLength(10)]
        public string AuditoriasVisiblesDNP { get; set; }

        [StringLength(50)]
        public string PlanAccion { get; set; }

        [StringLength(600)]
        public string EstrategiaHallazgos { get; set; }

        [StringLength(200)]
        public string GestionAutoridades { get; set; }

        [StringLength(550)]
        public string EstrategiaSeguimiento { get; set; }

        [StringLength(10)]
        public string RadicacionDerechoPeticion { get; set; }

        [StringLength(160)]
        public string FacilidadAccesoInfo { get; set; }

        [StringLength(40)]
        public string CambiosGestion { get; set; }

        [StringLength(180)]
        public string FrecuenciaSeguimiento { get; set; }

        [StringLength(1)]
        public string Estado { get; set; }

        [StringLength(2)]
        public string PercepcionSeguridad { get; set; }

        public DateTime? FechaPregunta { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
