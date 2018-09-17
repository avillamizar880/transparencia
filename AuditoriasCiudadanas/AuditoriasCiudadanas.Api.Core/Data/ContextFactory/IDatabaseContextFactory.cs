using AuditoriasCiudadanas.Api.Core.Data.DbModel;

namespace AuditoriasCiudadanas.Api.Core.Data.ContextFactory
{
    public interface IDatabaseContextFactory
    {
        TransparenciaDbModel CreateTransparenciaDbContext();
    }
}