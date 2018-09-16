using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Core.Data.DbModel;
using AuditoriasCiudadanas.Core.Data.UoW;
using AuditoriasCiudadanas.Core.Entities;

namespace AuditoriasCiudadanas.Core.Data.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Usuario> _usuarioDbSet;

        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException();

            _dbContext = unitOfWork.DatabaseContext;
            _usuarioDbSet = unitOfWork.DatabaseContext.Set<Usuario>();
        }

        public async Task<LoginResponseEntity> ValidateLogin(LoginRequestEntity r)
        {
            var inParamEmail = new SqlParameter
            {
                ParameterName = "email",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };

            var inParamPassword = new SqlParameter
            {
                ParameterName = "hash_clave",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Input
            };

            var outParamIdUsuario = new SqlParameter
            {
                ParameterName = "id_usuario",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var outParamIdPerfil = new SqlParameter
            {
                ParameterName = "id_perfil",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var outParamIdRol = new SqlParameter
            {
                ParameterName = "id_rol",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var outParamNombre = new SqlParameter
            {
                ParameterName = "nombre",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Output
            };

            var outParamEstado = new SqlParameter
            {
                ParameterName = "estado",
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.Output
            };

            var outParamEstadoEncuesta = new SqlParameter
            {
                ParameterName = "estadoencuesta",
                DbType = System.Data.DbType.String,
                Direction = System.Data.ParameterDirection.Output
            };

            const string sql = @"EXEC dbo.pa_valida_login @email, @hash_clave, @id_usuario OUT, @id_perfil OUT, @id_rol OUT, @nombre OUT, @estado OUT, @estadoencuesta OUT";

            await _dbContext.Database.ExecuteSqlCommandAsync(sql, inParamEmail, inParamPassword, outParamIdUsuario, outParamIdPerfil, outParamIdRol, outParamNombre, outParamEstado, outParamEstadoEncuesta);

            var result = new LoginResponseEntity
            {
                IdUsuario = (int)outParamIdUsuario.Value,
                IdPerfil = (int)outParamIdPerfil.Value,
                IdRol = (int)outParamIdRol.Value,
                Nombre = (string)outParamNombre.Value,
                Estado = (int)outParamEstado.Value,
                EstadoEncuesta = (string)outParamEstadoEncuesta.Value,
            };

            return result;
        }
    }
}