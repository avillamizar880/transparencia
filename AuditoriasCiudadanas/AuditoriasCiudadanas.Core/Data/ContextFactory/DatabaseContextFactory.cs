using AuditoriasCiudadanas.Core.Data.DbModel;

namespace AuditoriasCiudadanas.Core.Data.ContextFactory
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private static readonly DatabaseContextFactory instance  = new DatabaseContextFactory();
        public static DatabaseContextFactory Instance => instance;

        static DatabaseContextFactory()
        {

        }
        
        private DatabaseContextFactory()
        {
        }

        public TransparenciaDbModel CreateTransparenciaDbContext()
        {
            return new TransparenciaDbModel();
        }
    }
}
