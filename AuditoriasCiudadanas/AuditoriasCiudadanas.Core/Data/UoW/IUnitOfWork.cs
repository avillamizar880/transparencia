using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Core.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DatabaseContext { get; }

        void Commit();

        Task CommitAsync();
    }
}