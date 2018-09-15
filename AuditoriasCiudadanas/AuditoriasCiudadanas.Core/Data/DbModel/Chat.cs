namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chat")]
    public partial class Chat
    {
        [Key]
        public int idChat { get; set; }

        public int idRemitente { get; set; }

        public int idDestinatario { get; set; }

        [Required]
        [StringLength(500)]
        public string mensaje { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public DateTime fechaCreacion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
