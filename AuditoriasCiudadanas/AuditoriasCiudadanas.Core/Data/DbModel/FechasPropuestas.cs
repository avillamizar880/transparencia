namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FechasPropuestas
    {
        [Key]
        public int idPropuestaAudienciaFecha { get; set; }

        public DateTime fecha { get; set; }

        public int idTipoAudiencia { get; set; }

        public int idUsuario { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public int idGac { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual TiposAudiencia TiposAudiencia { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
