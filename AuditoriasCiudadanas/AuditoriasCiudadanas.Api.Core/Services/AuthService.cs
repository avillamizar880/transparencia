using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Data.Repository;
using AuditoriasCiudadanas.Api.Core.Entities;

namespace AuditoriasCiudadanas.Api.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<KeyValuePair<bool, int>> IsLoginValid(ValidateLoginRequestEntity r)
        {
            var loginInfo = await _usuarioRepository.ValidateLogin(r);

            return new KeyValuePair<bool, int>(loginInfo.IdUsuario != -1, loginInfo.IdUsuario);
        }
    }
}