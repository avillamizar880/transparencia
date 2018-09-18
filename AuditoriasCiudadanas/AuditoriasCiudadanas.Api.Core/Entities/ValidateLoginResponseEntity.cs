using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Api.Core.Entities
{
    public class ValidateLoginResponseEntity
    {
        public int IdUsuario { get; set; }

        public int IdPerfil { get; set; }

        public int IdRol { get; set; }

        public string Nombre { get; set; }

        public int Estado { get; set; }

        public string EstadoEncuesta { get; set; }
    }
}