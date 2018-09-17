using System;
using System.ComponentModel.DataAnnotations;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    public partial class BuenasPracticas
    {
        [Key]
        public int idBuenaPractica { get; set; }

        [Required]
        public string hecho { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public int idUsuario { get; set; }

        public int idGac { get; set; }

        public DateTime fechaCrea { get; set; }

        public int? aprobada { get; set; }

        public DateTime? fechaAprobacion { get; set; }

        public int? idUsuAprueba { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
