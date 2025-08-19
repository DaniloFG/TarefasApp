using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasApp.Application.Commands;
using TarefasApp.Application.Dtos;

namespace TarefasApp.Application.Interfaces
{
    public interface ITarefaAppService
    {
        Task<TarefaDto> Create(TarefaCreateCommand command);
        Task<TarefaDto> Update(TarefaUpdateCommand command);
        Task<TarefaDto> Delete(TarefaDeleteCommand command);
        Task<List<TarefaDto>>? GetAll();
        Task<TarefaDto>? GetById(Guid id);
    }
}