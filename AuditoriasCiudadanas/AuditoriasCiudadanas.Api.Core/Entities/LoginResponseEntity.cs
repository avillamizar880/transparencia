namespace AuditoriasCiudadanas.Api.Core.Entities
{
    public class LoginResponseEntity : BaseResponse
    {
        public int IdUsuario { get; set; }

        public int IdPerfil { get; set; }

        public int IdRol { get; set; }

        public string Nombre { get; set; }

        public int Estado { get; set; }

        public string EstadoEncuesta { get; set; }
    }
}