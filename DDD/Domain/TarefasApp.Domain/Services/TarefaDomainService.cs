using System;
using System.Threading.Tasks;
using TarefasApp.Domain.Entities;
using TarefasApp.Domain.Interfaces.Repositories;
using TarefasApp.Domain.Interfaces.Services;

namespace TarefasApp.Domain.Services
{
    public class TarefaDomainService : BaseDomainService<Tarefa, Guid>, ITarefaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.TarefaRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Add(Tarefa entity)
        {
            await _unitOfWork.TarefaRepository.AddAsync(entity);
            await _unitOfWork.SaveChanges();
        }

        public override async Task Update(Tarefa entity)
        {
            await _unitOfWork.TarefaRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChanges();
        }

        public override async Task Delete(Tarefa entity)
        {
            await _unitOfWork.TarefaRepository.DeleteAsync(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}