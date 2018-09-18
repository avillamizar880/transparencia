using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class Requisitos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodRequisito { get; set; }

        public string NomRequisito { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
