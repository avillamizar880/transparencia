namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ObjetivoEspecifico")]
    public partial class ObjetivoEspecifico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdObjetivoEspecifico { get; set; }

        [Required]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        [Required]
        public string NombreObjetivoEspecifico { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
