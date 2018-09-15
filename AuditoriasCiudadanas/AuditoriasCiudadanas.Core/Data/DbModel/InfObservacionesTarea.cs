namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InfObservacionesTarea")]
    public partial class InfObservacionesTarea
    {
        [Key]
        public int idInfObservacionT { get; set; }

        public int idInforme { get; set; }

        public int idTarea { get; set; }

        public decimal? Porcentaje { get; set; }

        [StringLength(1200)]
        public string Observacion { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public virtual Informes Informes { get; set; }

        public virtual Tareas Tareas { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
