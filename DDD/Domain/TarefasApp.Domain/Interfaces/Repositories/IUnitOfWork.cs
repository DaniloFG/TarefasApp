using System;
using System.Threading.Tasks;

namespace TarefasApp.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITarefaRepository? TarefaRepository { get; }
        Task SaveChanges();
    }
}