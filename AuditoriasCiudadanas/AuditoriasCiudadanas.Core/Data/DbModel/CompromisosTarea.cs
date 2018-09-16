namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompromisosTarea")]
    public partial class CompromisosTarea
    {
        [Key]
        public int compromisoTareaId { get; set; }

        public int? idTarea { get; set; }

        [StringLength(200)]
        public string nombre { get; set; }

        [StringLength(200)]
        public string responsable { get; set; }

        public DateTime? fecha { get; set; }

        public virtual Tareas Tareas { get; set; }
    }
}
