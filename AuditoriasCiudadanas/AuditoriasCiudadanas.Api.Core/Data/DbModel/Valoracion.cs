using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditoriasCiudadanas.Api.Core.Data.DbModel
{
    [Table("Valoracion")]
    public partial class Valoracion
    {
        [Key]
        public int idValoracion { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoBPIN { get; set; }

        [StringLength(2)]
        public string ProyP1 { get; set; }

        [StringLength(2)]
        public string ProyP2 { get; set; }

        [StringLength(2)]
        public string ProyP3 { get; set; }

        [StringLength(2)]
        public string ProyP4 { get; set; }

        [StringLength(2)]
        public string ProyP5 { get; set; }

        [StringLength(2)]
        public string AudP1 { get; set; }

        [StringLength(2)]
        public string AudP2 { get; set; }

        [StringLength(2)]
        public string AudP3GAC { get; set; }

        [StringLength(2)]
        public string AudP3Int { get; set; }

        [StringLength(2)]
        public string AudP3Sup { get; set; }

        [StringLength(2)]
        public string AudP3Con { get; set; }

        [StringLength(2)]
        public string AudP3Eje { get; set; }

        [StringLength(2)]
        public string AudP3Ent { get; set; }

        [StringLength(2)]
        public string AudP4GAC { get; set; }

        [StringLength(2)]
        public string AudP4Int { get; set; }

        [StringLength(2)]
        public string AudP4Sup { get; set; }

        [StringLength(2)]
        public string AudP4Con { get; set; }

        [StringLength(2)]
        public string AudP4Eje { get; set; }

        [StringLength(2)]
        public string AudP4Ent { get; set; }

        [StringLength(2)]
        public string AudP5 { get; set; }

        [StringLength(2)]
        public string AudP6 { get; set; }

        [StringLength(2)]
        public string GacP1 { get; set; }

        [StringLength(2)]
        public string GacP2 { get; set; }

        [StringLength(2)]
        public string GacP3 { get; set; }

        public int? idUsuario { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }

        [StringLength(200)]
        public string ProyP3Cual { get; set; }

        [StringLength(1)]
        public string ProyP3Op { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
