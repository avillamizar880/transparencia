namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asistentes
    {
        [Key]
        public int idAsistente { get; set; }

        public int cedula { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string cargo { get; set; }

        [StringLength(100)]
        public string cantidad { get; set; }

        [StringLength(100)]
        public string telefono { get; set; }

        [StringLength(100)]
        public string correo { get; set; }

        public int? idAudiencia { get; set; }

        public virtual Audiencias Audiencias { get; set; }
    }
}
