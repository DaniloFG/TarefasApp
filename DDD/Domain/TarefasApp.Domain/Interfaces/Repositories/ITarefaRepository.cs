using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Domain.Entities;

namespace TarefasApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa, Guid>
    {
        
    }
}