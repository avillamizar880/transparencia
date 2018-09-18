using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Api.Core.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DatabaseContext { get; }

        void Commit();

        Task CommitAsync();
    }
}