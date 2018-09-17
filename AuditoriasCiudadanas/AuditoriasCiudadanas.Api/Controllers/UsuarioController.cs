using System.Threading.Tasks;
using System.Web.Http;
using AuditoriasCiudadanas.Api.Core.Entities;
using AuditoriasCiudadanas.Api.Core.Services;
namespace AuditoriasCiudadanas.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> ValidateLogin([FromBody]LoginRequestEntity r)
        {
            var result = await _usuarioService.ValidateLogin(r);

            return Ok(result);
        }

        //[Route("encrypt/{key}")]
        //[HttpGet]
        //public async Task<IHttpActionResult> Encrypt(string key)
        //{
        //    var result = await Task.FromResult(Cipher.SHA256Encripta(key));

        //    return Ok(result);
        //}
    }
}