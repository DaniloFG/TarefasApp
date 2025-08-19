using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TarefasApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>>? GetAllAsync();
        Task<TEntity>? GetByIdAsync(TKey id);
    }
}