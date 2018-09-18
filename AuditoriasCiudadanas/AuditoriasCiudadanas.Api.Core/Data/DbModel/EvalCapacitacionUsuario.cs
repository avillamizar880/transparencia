using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("EvalCapacitacionUsuario")]
    public partial class EvalCapacitacionUsuario
    {
        [Key]
        public int idECapUsu { get; set; }

        public int idECap { get; set; }

        public int? idUsuario { get; set; }

        public DateTime fechaEval { get; set; }

        [Required]
        [StringLength(30)]
        public string Calificacion { get; set; }

        public int? intento { get; set; }

        public int? totalResp { get; set; }

        public int? correctas { get; set; }

        public int? incorrectas { get; set; }

        public decimal? porcentaje_aprob { get; set; }

        public virtual EvaluacionCapacitacion EvaluacionCapacitacion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
