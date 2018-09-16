using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AuditoriasCiudadanas.Core.Entities;
using AuditoriasCiudadanas.Core.Services;

namespace AuditoriasCiudadanas.Api.Controllers
{
    [Route("api/[controller]")]
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
    }
}