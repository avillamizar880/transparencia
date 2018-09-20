﻿using System;
using System.Data.Entity;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Api.Core.Data.ContextFactory;

namespace AuditoriasCiudadanas.Api.Core.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext DatabaseContext { get; }
        private bool _disposed;

        public UnitOfWork(IDatabaseContextFactory dbContextfactory)
        {
            if (dbContextfactory == null)
            {
                throw new ArgumentNullException(nameof(dbContextfactory));
            }

            var TransparenciaDbContext = dbContextfactory.CreateTransparenciaDbContext();

            DatabaseContext = TransparenciaDbContext ?? throw new ArgumentNullException(nameof(TransparenciaDbContext), @"TransparenciaDbContext cannot be null");
        }
        
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;


            if (disposing)
            {
                DatabaseContext.Dispose();
            }


            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}