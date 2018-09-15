using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Core.Entities
{
    public class LoginResponseEntity : BaseResponse
    {
        public int IdUsuario { get; set; }

        public int IdPerfil { get; set; }

        public int IdRol { get; set; }

        public int Estado { get; set; }

        public int EstadoEncuesta { get; set; }
    }
}