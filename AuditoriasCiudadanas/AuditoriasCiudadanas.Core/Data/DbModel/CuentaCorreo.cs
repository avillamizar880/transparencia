namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuentaCorreo")]
    public partial class CuentaCorreo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaCorreo()
        {
            EnvioCorreo = new HashSet<EnvioCorreo>();
        }

        [Key]
        public int IdCuentaCor { get; set; }

        [Required]
        [StringLength(500)]
        public string UsuarioCor { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordCor { get; set; }

        public int? CantidadMax { get; set; }

        [Required]
        [StringLength(10)]
        public string PuertoCor { get; set; }

        [Required]
        [StringLength(255)]
        public string UrlCor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnvioCorreo> EnvioCorreo { get; set; }
    }
}
