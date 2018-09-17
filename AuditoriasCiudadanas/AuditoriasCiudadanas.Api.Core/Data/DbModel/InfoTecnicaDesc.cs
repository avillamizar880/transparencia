using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("InfoTecnicaDesc")]
    public partial class InfoTecnicaDesc
    {
        [Key]
        public int idInfoDesc { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaCreacion { get; set; }

        [Required]
        [StringLength(500)]
        public string titulo { get; set; }

        [Required]
        public string descripcion { get; set; }

        public int? idUsuarioModif { get; set; }

        public DateTime? fechaModif { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
