using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Core.Data.Repository;
using AuditoriasCiudadanas.Core.Data.UoW;
using AuditoriasCiudadanas.Core.Entities;

namespace AuditoriasCiudadanas.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponseEntity> ValidateLogin(LoginRequestEntity r)
        {
            var result = await _usuarioRepository.ValidateLogin(r);

            return result;
        }
    }
}