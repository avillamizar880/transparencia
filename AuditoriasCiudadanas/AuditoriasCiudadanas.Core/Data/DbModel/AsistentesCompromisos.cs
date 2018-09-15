namespace AuditoriasCiudadanas.Core.Data.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AsistentesCompromisos
    {
        [Key]
        public int idAsistenteComp { get; set; }

        public int? idAudiencia { get; set; }

        public int? idTipoAsistente { get; set; }

        public int? cantidad { get; set; }

        public int? idGac { get; set; }

        public virtual Audiencias Audiencias { get; set; }

        public virtual TiposAsistente TiposAsistente { get; set; }
    }
}
