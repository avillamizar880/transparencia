using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class InfObservacionesCompromisos
    {
        [Key]
        public int idInfObservacionC { get; set; }

        public int idInforme { get; set; }

        [StringLength(1200)]
        public string Compromiso { get; set; }

        [StringLength(200)]
        public string Responsable { get; set; }

        [StringLength(1200)]
        public string Observacion { get; set; }

        [StringLength(2)]
        public string Cumplimiento { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public virtual Informes Informes { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
