using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("SolicInfoAdicional")]
    public partial class SolicInfoAdicional
    {
        [Key]
        public int idSolicInfoAdicional { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaCreacion { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public int idGac { get; set; }

        public string respuesta { get; set; }

        public DateTime? fechaRespuesta { get; set; }

        [Required]
        [StringLength(1000)]
        public string detalle { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
