using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasApp.Domain.Interfaces.Repositories;
using TarefasApp.Domain.Interfaces.Services;

namespace TarefasApp.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey> where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey> _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task Add(TEntity entity)
        {
            await _baseRepository.AddAsync(entity);
        }

        public virtual async Task Delete(TEntity entity)
        {
            await _baseRepository.DeleteAsync(entity);
        }

        public virtual async Task<List<TEntity>>? GetAll()
        {
            return await _baseRepository.GetAllAsync();
        }

        public virtual async Task<TEntity>? GetById(TKey id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _baseRepository.UpdateAsync(entity);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}