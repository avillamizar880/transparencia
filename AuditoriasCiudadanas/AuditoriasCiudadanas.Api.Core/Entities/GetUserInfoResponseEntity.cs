namespace AuditoriasCiudadanas.Api.Core.Entities
{
    public class GetUserInfoResponseEntity
    {
        public int IdUsuario { get; set; }

        public int IdPerfil { get; set; }

        public int IdRol { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }

        public bool EstadoEncuesta { get; set; }
    }
}