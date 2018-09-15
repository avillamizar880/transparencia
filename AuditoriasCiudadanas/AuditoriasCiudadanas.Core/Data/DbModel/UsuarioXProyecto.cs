namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioXProyecto")]
    public partial class UsuarioXProyecto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRol { get; set; }

        public int Estado { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}