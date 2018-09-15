namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdjuntoHallazgo")]
    public partial class AdjuntoHallazgo
    {
        [Key]
        public int idAdjuntoHallazgo { get; set; }

        public int idHallazgo { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(1000)]
        public string lugar { get; set; }

        [StringLength(2000)]
        public string descripcion { get; set; }

        public int? idUsuario { get; set; }

        public virtual Hallazgo Hallazgo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
