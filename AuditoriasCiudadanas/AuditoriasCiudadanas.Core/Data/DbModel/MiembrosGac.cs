namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MiembrosGac")]
    public partial class MiembrosGac
    {
        public int idGac { get; set; }

        public int idUsuario { get; set; }

        public int? estado { get; set; }

        [Key]
        public int idMiembroGac { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public virtual Gac Gac { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
