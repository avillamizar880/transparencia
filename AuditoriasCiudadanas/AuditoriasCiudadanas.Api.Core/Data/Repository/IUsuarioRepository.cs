using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Data.DbModel;
using AuditoriasCiudadanas.Api.Core.Entities;

namespace AuditoriasCiudadanas.Api.Core.Data.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario, int>
    {
        Task<LoginResponseEntity> ValidateLogin(LoginRequestEntity r);
    }
}