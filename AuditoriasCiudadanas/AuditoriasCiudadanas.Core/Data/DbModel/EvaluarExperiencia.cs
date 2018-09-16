namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EvaluarExperiencia")]
    public partial class EvaluarExperiencia
    {
        [Key]
        public int IdEvaluarAudiencia { get; set; }

        public int Idusuario { get; set; }

        public int IdAudiencia { get; set; }

        public DateTime? FechaEvaluacion { get; set; }

        [StringLength(2)]
        public string TemasAudiencia { get; set; }

        [StringLength(500)]
        public string ObsTemasAudiencia { get; set; }

        public int? ConvocatoriaAudiencia { get; set; }

        [StringLength(500)]
        public string ObsConvocatoriaAudiencia { get; set; }

        public int? AccesoInfo { get; set; }

        [StringLength(500)]
        public string ObsAccesoInfo { get; set; }

        public int? DesarrolloAdecuado { get; set; }

        [StringLength(500)]
        public string ObsDesarrolloAdecuado { get; set; }

        [StringLength(25)]
        public string CiudadanoEntidadEj { get; set; }

        [StringLength(25)]
        public string CiudadanoSupervisor { get; set; }

        [StringLength(25)]
        public string CiudadanoInterventor { get; set; }

        [StringLength(25)]
        public string CiudadanoContratista { get; set; }

        [StringLength(500)]
        public string DestacarAudiencia { get; set; }

        [StringLength(2)]
        public string MejorarAudiencia { get; set; }

        [StringLength(500)]
        public string ObsMejorarAudiencia { get; set; }

        public virtual Audiencias Audiencias { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
