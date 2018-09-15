namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccionesUsuario")]
    public partial class AccionesUsuario
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IdAccionesUsuario { get; set; }

        public int IdAccion { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? idGac { get; set; }

        [StringLength(15)]
        public string codigoBPIN { get; set; }

        public virtual Acciones Acciones { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}