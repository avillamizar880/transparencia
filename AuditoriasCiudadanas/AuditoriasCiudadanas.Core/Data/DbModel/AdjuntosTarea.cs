namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdjuntosTarea")]
    public partial class AdjuntosTarea
    {
        [Key]
        public int idAdjuntoTarea { get; set; }

        public int? idTarea { get; set; }

        public int? idTipoAdjunto { get; set; }

        [StringLength(1000)]
        public string url { get; set; }

        public DateTime? fechaCreacion { get; set; }

        [StringLength(1000)]
        public string descripcion { get; set; }

        public int? idMiembroGac { get; set; }

        [StringLength(100)]
        public string responsable { get; set; }

        [StringLength(200)]
        public string lugar { get; set; }

        public virtual Tareas Tareas { get; set; }
    }
}
