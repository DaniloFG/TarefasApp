using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Domain.Interfaces.Repositories;
using TarefasApp.Infra.Data.Contexts;

namespace TarefasApp.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly ITarefaRepository _tarefaRepository;

        public UnitOfWork(DataContext context, ITarefaRepository tarefaRepository)
        {
            _context = context;
            _tarefaRepository = new TarefaRepository(_context);
        }

        public ITarefaRepository TarefaRepository => _tarefaRepository;

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}