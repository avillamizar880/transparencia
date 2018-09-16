namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupervisorContrato")]
    public partial class SupervisorContrato
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NumCtto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NitSupervisor { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
