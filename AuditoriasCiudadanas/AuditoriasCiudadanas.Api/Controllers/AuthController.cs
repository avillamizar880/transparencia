using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AuditoriasCiudadanas.Api.Core.Entities;
using AuditoriasCiudadanas.Api.Core.Services;
using AuditoriasCiudadanas.Api.Utils;

namespace AuditoriasCiudadanas.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> ValidateLogin([FromBody]ValidateLoginRequestEntity r)
        {
            var loginInfo = await _authService.IsLoginValid(r);

            if (!loginInfo.Key)
                return Unauthorized();

            var result = new
            {
                Token = JwtManager.GenerateToken(r.Email),
                UserId = loginInfo.Value
            };

            return Ok(result);
        }
    }
}