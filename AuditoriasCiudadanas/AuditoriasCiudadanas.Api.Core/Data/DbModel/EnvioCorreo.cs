using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("EnvioCorreo")]
    public partial class EnvioCorreo
    {
        [Key]
        public int IdEnvioCor { get; set; }

        [StringLength(10)]
        public string NombreEnvioCor { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoEnvioCor { get; set; }

        [Required]
        public string TextoEnvioCor { get; set; }

        [StringLength(2)]
        public string HoraInicio { get; set; }

        [StringLength(2)]
        public string MinutoInicio { get; set; }

        public int? Intervalo { get; set; }

        public int? Veces { get; set; }

        public int IdCuentaCor { get; set; }

        public virtual CuentaCorreo CuentaCorreo { get; set; }
    }
}
