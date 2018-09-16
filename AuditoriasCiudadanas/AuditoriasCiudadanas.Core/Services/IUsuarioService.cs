using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Core.Entities;

namespace AuditoriasCiudadanas.Core.Services
{
    public interface IUsuarioService
    {
        Task<LoginResponseEntity> ValidateLogin(LoginRequestEntity r);
    }
}