using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Observaciones
    {
        [Key]
        public int idObservacion { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        [StringLength(200)]
        public string infoClara { get; set; }

        [StringLength(200)]
        public string infoCompleta { get; set; }

        [StringLength(200)]
        public string ComunidadBenef { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        [StringLength(200)]
        public string dudas { get; set; }

        public int? idGac { get; set; }

        [StringLength(200)]
        public string infoFaltante { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
