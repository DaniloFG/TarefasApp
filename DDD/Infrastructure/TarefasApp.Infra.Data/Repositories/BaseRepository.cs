using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasApp.Domain.Interfaces.Repositories;
using TarefasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace TarefasApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DataContext _context;

        protected BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async virtual Task AddAsync(TEntity entity) => await _context.AddAsync(entity);

        public async virtual Task UpdateAsync(TEntity entity) => _context.Update(entity);

        public async virtual Task DeleteAsync(TEntity entity) => _context.Remove(entity);

        public async virtual Task<List<TEntity>>? GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async virtual Task<TEntity>? GetByIdAsync(TKey id) => await _context.Set<TEntity>().FindAsync(id);

        public void Dispose() => _context.Dispose();
    }
}