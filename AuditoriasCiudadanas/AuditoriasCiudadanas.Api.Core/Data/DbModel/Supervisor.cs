using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Supervisor")]
    public partial class Supervisor
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        [StringLength(200)]
        public string NomSupervisor { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NitSupervisor { get; set; }

        [StringLength(15)]
        public string CodDependencia { get; set; }

        [StringLength(255)]
        public string NomDependencia { get; set; }

        [StringLength(15)]
        public string CodCargo { get; set; }

        [StringLength(200)]
        public string NomCargo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Telefono { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
