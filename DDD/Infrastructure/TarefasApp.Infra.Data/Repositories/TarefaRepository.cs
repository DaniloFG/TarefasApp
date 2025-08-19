using System;
using TarefasApp.Infra.Data.Contexts;
using TarefasApp.Domain.Entities;
using TarefasApp.Domain.Interfaces.Repositories;

namespace TarefasApp.Infra.Data.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa, Guid>, ITarefaRepository
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}