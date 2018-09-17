using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class RutaReportes
    {
        [Key]
        public int idRutaReportes { get; set; }

        public int? idGac { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public int TipoReporte { get; set; }

        [StringLength(1000)]
        public string ruta { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual TipoReporte TipoReporte1 { get; set; }
    }
}
