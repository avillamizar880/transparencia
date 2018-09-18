using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
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
