namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notificacion")]
    public partial class Notificacion
    {
        [Key]
        public int idNotificacion { get; set; }

        public int idUsuario { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        [Required]
        [StringLength(500)]
        public string mensaje { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public DateTime fechaCreacion { get; set; }

        [Required]
        [StringLength(500)]
        public string parametros { get; set; }
    }
}