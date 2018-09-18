using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Entities;

namespace AuditoriasCiudadanas.Api.Core.Services
{
    public interface IUsuarioService
    {
        Task<GetUserInfoResponseEntity> GetUserInfo(int userId);
    }
}