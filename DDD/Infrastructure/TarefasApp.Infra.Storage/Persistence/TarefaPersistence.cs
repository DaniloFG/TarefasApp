using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasApp.Infra.Storage.Contexts;
using TarefasApp.Infra.Storage.Collections;
using MongoDB.Driver;

namespace TarefasApp.Infra.Storage.Persistence
{
    public class TarefaPersistence
    {
        private readonly MongoDBContext _mongoDbContext;

        public TarefaPersistence(MongoDBContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task Insert(TarefaCollection tarefa)
        {
            await _mongoDbContext.TarefaCollection.InsertOneAsync(tarefa);
        }

        public async Task Update(TarefaCollection tarefa)
        {
            var filter = Builders<TarefaCollection>.Filter.Eq(t => t.Id, tarefa.Id);
            await _mongoDbContext.TarefaCollection.ReplaceOneAsync(filter, tarefa);
        }

        public async Task Delete(TarefaCollection tarefa)
        {
            var filter = Builders<TarefaCollection>.Filter.Eq(t => t.Id, tarefa.Id);
            await _mongoDbContext.TarefaCollection.DeleteOneAsync(filter);
        }

        public async Task<List<TarefaCollection>> FindAll()
        {
            var filter = Builders<TarefaCollection>.Filter.Where(t => true);
            var result = await _mongoDbContext.TarefaCollection.FindAsync(filter);
            return result.ToList();
        }

        public async Task<TarefaCollection>? Find(Guid id)
        {
            var filter = Builders<TarefaCollection>.Filter.Where(t => t.Id == id);
            var result = await _mongoDbContext.TarefaCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
    }
}