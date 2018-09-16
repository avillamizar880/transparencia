namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InfObservacionesActividad")]
    public partial class InfObservacionesActividad
    {
        [Key]
        public int idInfObservacionA { get; set; }

        public int idInforme { get; set; }

        public int idActividad { get; set; }

        [StringLength(1200)]
        public string Observacion { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        public virtual Actividad Actividad { get; set; }

        public virtual Informes Informes { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
