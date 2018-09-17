using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("ReunionPrevia")]
    public partial class ReunionPrevia
    {
        [Key]
        public int idReunionPrevia { get; set; }

        public int? estado { get; set; }

        [StringLength(15)]
        public string idDivipola { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        [StringLength(100)]
        public string acta { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
