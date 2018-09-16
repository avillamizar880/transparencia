namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
