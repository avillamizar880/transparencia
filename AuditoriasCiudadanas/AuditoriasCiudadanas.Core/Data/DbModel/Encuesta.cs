namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Encuesta")]
    public partial class Encuesta
    {
        [Key]
        public int idEncuesta { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime? fechaCorte { get; set; }
    }
}
