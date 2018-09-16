namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PreguntasInforme")]
    public partial class PreguntasInforme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPreguntaInforme { get; set; }

        [StringLength(1000)]
        public string pregunta { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        public DateTime? fechaCreacion { get; set; }
    }
}
