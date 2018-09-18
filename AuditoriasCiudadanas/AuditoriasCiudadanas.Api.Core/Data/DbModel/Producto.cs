using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; }

        public string UnidadProducto { get; set; }

        public decimal? CantidadProducto { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
