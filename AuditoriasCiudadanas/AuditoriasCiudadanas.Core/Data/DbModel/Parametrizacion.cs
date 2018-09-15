namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parametrizacion")]
    public partial class Parametrizacion
    {
        [Key]
        public int idParametrizacion { get; set; }

        public string ValTexto { get; set; }

        [Required]
        [StringLength(200)]
        public string Llave { get; set; }

        public int? ValNum { get; set; }

        public DateTime? ValFecha { get; set; }

        [StringLength(400)]
        public string DescParam { get; set; }
    }
}