using AuditoriasCiudadanas.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Api.Core.Services
{
    public interface IAuthService
    {
        Task<KeyValuePair<bool, int>> IsLoginValid(ValidateLoginRequestEntity r);
    }
}