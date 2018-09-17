using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("ObjetivoEspecifico")]
    public partial class ObjetivoEspecifico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdObjetivoEspecifico { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        public string NombreObjetivoEspecifico { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
