namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactoContrato")]
    public partial class ContactoContrato
    {
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string email { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Key]
        public int idcontacto { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
