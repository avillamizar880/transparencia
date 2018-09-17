using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("DiarioNotasTarea")]
    public partial class DiarioNotasTarea
    {
        public int diarioNotasTareaId { get; set; }

        public int? idTarea { get; set; }

        public DateTime? fechaCumplimiento { get; set; }

        [Required]
        [StringLength(1000)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(1000)]
        public string reflexion { get; set; }

        public virtual Tareas Tareas { get; set; }
    }
}
