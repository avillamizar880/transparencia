namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleRecursoMultimedia")]
    public partial class DetalleRecursoMultimedia
    {
        [Key]
        public int idDetalleRecurso { get; set; }

        public int idRecurso { get; set; }

        public int idTipoMedio { get; set; }

        [Required]
        [StringLength(300)]
        public string rutaUrl { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaCreacion { get; set; }

        public int? idUsuarioModif { get; set; }

        public DateTime? fechaModif { get; set; }

        public virtual RecursosMultimedia RecursosMultimedia { get; set; }

        public virtual TipoMultimedia TipoMultimedia { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
