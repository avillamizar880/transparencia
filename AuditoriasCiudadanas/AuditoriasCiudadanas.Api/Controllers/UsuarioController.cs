using System.Threading.Tasks;
using System.Web.Http;
using AuditoriasCiudadanas.Api.Core.Entities;
using AuditoriasCiudadanas.Api.Core.Services;
namespace AuditoriasCiudadanas.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Route("{userId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserInfo(int userId)
        {
            var info = await _usuarioService.GetUserInfo(userId);

            return Ok(info);
        }
    }
}