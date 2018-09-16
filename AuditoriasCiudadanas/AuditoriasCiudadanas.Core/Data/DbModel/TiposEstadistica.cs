namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TiposEstadistica")]
    public partial class TiposEstadistica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tipo_estadistica { get; set; }

        [Required]
        public string nom_tipo_estadistica { get; set; }

        public int filtros_fecha { get; set; }

        public int? id_grupo { get; set; }

        public virtual GruposEstadistica GruposEstadistica { get; set; }
    }
}
