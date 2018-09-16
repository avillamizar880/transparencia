namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecCapacitacionUsuario")]
    public partial class RecCapacitacionUsuario
    {
        [Key]
        public int idRCapUsu { get; set; }

        public int idRCap { get; set; }

        public int? idUsuario { get; set; }

        public DateTime fechaVisto { get; set; }

        public virtual RecursosCapacitacion RecursosCapacitacion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
