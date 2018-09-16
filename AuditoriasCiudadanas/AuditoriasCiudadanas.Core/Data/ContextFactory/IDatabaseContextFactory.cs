using AuditoriasCiudadanas.Core.Data.DbModel;

namespace AuditoriasCiudadanas.Core.Data.ContextFactory
{
    public interface IDatabaseContextFactory
    {
        TransparenciaDbModel CreateTransparenciaDbContext();
    }
}