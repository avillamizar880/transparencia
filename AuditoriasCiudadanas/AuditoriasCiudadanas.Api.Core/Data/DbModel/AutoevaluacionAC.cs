using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("AutoevaluacionAC")]
    public partial class AutoevaluacionAC
    {
        [Key]
        public int idAutoevaluacion { get; set; }

        public int idusuario { get; set; }

        public DateTime? FechaAutoevaluacion { get; set; }

        public int RevisarInfo { get; set; }

        [StringLength(500)]
        public string ObsRevisarInfo { get; set; }

        public int TratoAC { get; set; }

        [StringLength(500)]
        public string ObsTratoAC { get; set; }

        public int Compromisos { get; set; }

        [StringLength(500)]
        public string ObsCompromisos { get; set; }

        public int Capacitacion { get; set; }

        [StringLength(500)]
        public string ObsCapacitacion { get; set; }

        public int PertinenciaInfo { get; set; }

        [StringLength(500)]
        public string ObsPertinenciaInfo { get; set; }

        public int TratoEntidadEj { get; set; }

        [StringLength(500)]
        public string ObsTratoEntidadEj { get; set; }

        public int ComunicacionInterventor { get; set; }

        [StringLength(500)]
        public string ObsComunicacionInterventor { get; set; }

        public int TratoContratista { get; set; }

        [StringLength(500)]
        public string ObsTratoContratista { get; set; }

        public int ConvocatoriaAudiencias { get; set; }

        [StringLength(500)]
        public string ObsConvocatoriaAudiencias { get; set; }

        public int AnimoCiudadano { get; set; }

        [StringLength(500)]
        public string ObsAnimoCiudadano { get; set; }

        public int CondicionesSeguridad { get; set; }

        [StringLength(500)]
        public string ObsCondicionesSeguridad { get; set; }

        [Required]
        [StringLength(2)]
        public string ReunionesGA { get; set; }

        [StringLength(500)]
        public string ObsReunionesGA { get; set; }

        [Required]
        [StringLength(2)]
        public string LogroMetasGA { get; set; }

        [StringLength(500)]
        public string ObsLogroMetasGA { get; set; }

        [Required]
        [StringLength(500)]
        public string AprendizajeAC { get; set; }

        [Required]
        [StringLength(500)]
        public string DificultadAC { get; set; }

        [Required]
        [StringLength(500)]
        public string Sugerencias { get; set; }

        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
