using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Data.Repository;
using AuditoriasCiudadanas.Api.Core.Data.UoW;
using AuditoriasCiudadanas.Api.Core.Entities;

namespace AuditoriasCiudadanas.Api.Core.Services
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