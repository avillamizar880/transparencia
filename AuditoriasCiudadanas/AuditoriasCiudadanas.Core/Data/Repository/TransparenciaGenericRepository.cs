﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuditoriasCiudadanas.Core.Data.UoW;

namespace AuditoriasCiudadanas.Core.Data.Repository
{
    public class TransparenciaGenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public TransparenciaGenericRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork), @"Unit of work cannot be null");
            }

            _dbSet = unitOfWork.DatabaseContext.Set<TEntity>();
        }

        public TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetAsnyc(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();

        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}