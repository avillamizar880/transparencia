using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class InfObservacionesDudas
    {
        [Key]
        public int idInfObservacionD { get; set; }

        public int idInforme { get; set; }

        [StringLength(1200)]
        public string Duda { get; set; }

        [StringLength(200)]
        public string Responsable { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public int? TipoDuda { get; set; }

        [StringLength(1200)]
        public string Conclusiones { get; set; }

        public virtual Informes Informes { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
