using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Core.Data.DbModel;
using AuditoriasCiudadanas.Core.Entities;

namespace AuditoriasCiudadanas.Core.Data.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario, int>
    {
        Task<LoginResponseEntity> ValidateLogin(LoginRequestEntity r);
    }
}