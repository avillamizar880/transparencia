namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExperienciasGac")]
    public partial class ExperienciasGac
    {
        [Key]
        public int idExperiencia { get; set; }

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

        [StringLength(500)]
        public string rutaUrlAdjunto { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
