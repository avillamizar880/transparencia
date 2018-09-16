namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interventor")]
    public partial class Interventor
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        [StringLength(250)]
        public string NomInterventor { get; set; }

        [Required]
        [StringLength(250)]
        public string NomRepLegalInterventor { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NitInterventor { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Telefono { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
