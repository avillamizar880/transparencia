namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("preguntaCuestionario")]
    public partial class preguntaCuestionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public preguntaCuestionario()
        {
            opcionRespuestas = new HashSet<opcionRespuestas>();
        }

        [Key]
        public int idPregunta { get; set; }

        public int idTipoPregunta { get; set; }

        public int idCuestionario { get; set; }

        [Required]
        [StringLength(200)]
        public string textoPregunta { get; set; }

        [Required]
        [StringLength(200)]
        public string textoExplicativo { get; set; }

        [StringLength(200)]
        public string textoJustificacion { get; set; }

        public int? idTipoValidacion { get; set; }

        [StringLength(200)]
        public string MensajeErrorValida { get; set; }

        public int? RangoValidacion { get; set; }

        public int? CantMinima { get; set; }

        public int? CantMaxima { get; set; }

        [StringLength(100)]
        public string EtiquetaMin { get; set; }

        [StringLength(100)]
        public string EtiquetaMax { get; set; }

        [StringLength(1)]
        public string Obligatoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<opcionRespuestas> opcionRespuestas { get; set; }

        public virtual TipoPregunta TipoPregunta { get; set; }

        public virtual tipoValidacion tipoValidacion { get; set; }
    }
}
