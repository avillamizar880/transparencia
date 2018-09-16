namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Poliza")]
    public partial class Poliza
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string idPoliza { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string NumCtto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string CodigoBPIN { get; set; }

        public int? tipoAmparo { get; set; }

        [StringLength(100)]
        public string nomTipoAmparo { get; set; }

        [StringLength(50)]
        public string IdAseguradora { get; set; }

        [StringLength(150)]
        public string nombreAseguradora { get; set; }

        [StringLength(50)]
        public string numeroAmparo { get; set; }

        [StringLength(150)]
        public string beneficiario { get; set; }

        [StringLength(150)]
        public string tomador { get; set; }

        public double? numeroCubrimientos { get; set; }

        public DateTime? fechaExpedicion { get; set; }

        public int? CodTDocAprobacion { get; set; }

        [StringLength(100)]
        public string TDocAprobacion { get; set; }

        public DateTime? FechaDocAprobacion { get; set; }

        [StringLength(100)]
        public string NumAprobacion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
