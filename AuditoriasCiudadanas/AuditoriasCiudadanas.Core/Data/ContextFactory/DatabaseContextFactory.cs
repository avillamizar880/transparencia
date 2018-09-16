using AuditoriasCiudadanas.Core.Data.DbModel;

namespace AuditoriasCiudadanas.Core.Data.ContextFactory
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        public static DatabaseContextFactory Instance { get; } = new DatabaseContextFactory();

        public DatabaseContextFactory()
        {

        }

        public TransparenciaDbModel CreateTransparenciaDbContext()
        {
            return new TransparenciaDbModel();
        }
    }
}