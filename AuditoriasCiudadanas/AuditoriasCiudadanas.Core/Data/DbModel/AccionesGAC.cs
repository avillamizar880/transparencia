namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccionesGAC")]
    public partial class AccionesGAC
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IdAccionesGAC { get; set; }

        public int IdAccion { get; set; }

        public int IdGAC { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Acciones Acciones { get; set; }

        public virtual Gac Gac { get; set; }
    }
}
