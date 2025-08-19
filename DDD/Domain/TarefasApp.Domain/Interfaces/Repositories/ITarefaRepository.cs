using System;
using TarefasApp.Domain.Entities;

namespace TarefasApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa, Guid>
    {

    }
}