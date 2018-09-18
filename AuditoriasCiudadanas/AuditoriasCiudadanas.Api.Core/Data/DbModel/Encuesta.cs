using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Encuesta")]
    public partial class Encuesta
    {
        [Key]
        public int idEncuesta { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime? fechaCorte { get; set; }
    }
}
