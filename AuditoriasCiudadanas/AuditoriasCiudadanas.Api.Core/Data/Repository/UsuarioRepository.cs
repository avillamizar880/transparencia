using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Data.DbModel;
using AuditoriasCiudadanas.Api.Core.Data.UoW;
using AuditoriasCiudadanas.Api.Core.Entities;

namespace AuditoriasCiudadanas.Api.Core.Data.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        private readonly TransparenciaDbModel _dbContext;
        private readonly DbSet<Usuario> _usuarioDbSet;

        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException();

            _dbContext = unitOfWork.DatabaseContext as TransparenciaDbModel;
            _usuarioDbSet = unitOfWork.DatabaseContext.Set<Usuario>();
        }

        public async Task<ValidateLoginResponseEntity> ValidateLogin(ValidateLoginRequestEntity r)
        {
            var inParamEmail = new SqlParameter("@email", SqlDbType.VarChar, 100)
            {
                Direction = ParameterDirection.Input,
                Value = r.Email
            };

            var inParamPassword = new SqlParameter("@hash_clave", SqlDbType.VarChar, 100)
            {
                Direction = ParameterDirection.Input,
                Value = r.Password
            };

            var outParamEstado = new SqlParameter("@estado", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var outParamIdUsuario = new SqlParameter("@id_usuario", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var outParamIdPerfil = new SqlParameter("@id_perfil", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var outParamIdRol = new SqlParameter("@id_rol", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var outParamNombre = new SqlParameter("@nombre", SqlDbType.VarChar, 400)
            {
                Direction = ParameterDirection.Output
            };

            var outParamEstadoEncuesta = new SqlParameter("@estadoencuesta", SqlDbType.NVarChar, 1)
            {
                Direction = ParameterDirection.Output
            };

            const string sql = @"EXEC dbo.pa_valida_login @email, @hash_clave, @estado OUT, @id_usuario OUT, @id_perfil OUT, @id_rol OUT, @nombre OUT, @estadoencuesta OUT";

            await _dbContext.Database.ExecuteSqlCommandAsync(sql, inParamEmail, inParamPassword, outParamEstado, outParamIdUsuario, outParamIdPerfil, outParamIdRol, outParamNombre, outParamEstadoEncuesta);

            var result = new ValidateLoginResponseEntity
            {
                IdUsuario = outParamIdUsuario.Value is DBNull ? -1 : Convert.ToInt32(string.IsNullOrEmpty(outParamIdUsuario.Value.ToString()) ? -1 : outParamIdUsuario.Value),
                IdPerfil = outParamIdPerfil.Value is DBNull ? -1 : Convert.ToInt32(string.IsNullOrEmpty(outParamIdPerfil.Value.ToString()) ? -1 : outParamIdPerfil.Value),
                IdRol = outParamIdRol.Value is DBNull ? -1 : Convert.ToInt32(string.IsNullOrEmpty(outParamIdRol.Value.ToString()) ? -1 : outParamIdRol.Value),
                Nombre = outParamNombre.Value is DBNull ? string.Empty : Convert.ToString(string.IsNullOrEmpty(outParamNombre.Value.ToString()) ? -1 : outParamNombre.Value),
                Estado = outParamEstado.Value is DBNull ? -1 : Convert.ToInt32(string.IsNullOrEmpty(outParamEstado.Value.ToString()) ? -1 : outParamEstado.Value),
                EstadoEncuesta = outParamEstadoEncuesta.Value is DBNull ? string.Empty : Convert.ToString(string.IsNullOrEmpty(outParamEstadoEncuesta.Value.ToString()) ? -1 : outParamEstadoEncuesta.Value)
            };

            return result;
        }

        public async Task<GetUserInfoResponseEntity> GetUserInfo(int userId)
        {
            var data = await (from u in _dbContext.Usuario
                join upp in _dbContext.UsuarioXProyecto on u.IdUsuario equals upp.IDUsuario into upprol
                join dau in _dbContext.DatosAdicionalesUsuario on u.IdUsuario equals dau.IdUsuario
                from rol in upprol.DefaultIfEmpty()
                where u.IdUsuario == userId
                select new GetUserInfoResponseEntity
                {
                    IdUsuario = u.IdUsuario,
                    IdPerfil = u.IdPerfil.HasValue ? u.IdPerfil.Value : - 1,
                    IdRol = rol != null ? rol.IDRol : -1,
                    Nombre = u.Nombre,
                    EstadoEncuesta = !string.IsNullOrEmpty(dau.Estado) || u.FechaPregEnc.HasValue,
                    Estado = u.Estado
                }).FirstOrDefaultAsync();

            return data;
        }
    }
}