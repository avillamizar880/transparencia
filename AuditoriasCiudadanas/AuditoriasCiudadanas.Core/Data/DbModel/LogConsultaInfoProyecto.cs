namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogConsultaInfoProyecto")]
    public partial class LogConsultaInfoProyecto
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal idLog { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaConsulta { get; set; }

        [StringLength(100)]
        public string CodigoBPIN { get; set; }
    }
}
