using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TarefasApp.Application.Commands;
using TarefasApp.Application.Dtos;
using TarefasApp.Application.Interfaces;
using TarefasApp.Infra.Storage.Persistence;

namespace TarefasApp.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de tarefa da aplicação
    /// </summary>
    public class TarefaAppService : ITarefaAppService
    {
        //atributo
        private readonly TarefaPersistence _tarefaPersistence;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TarefaAppService(TarefaPersistence tarefaPersistence, IMediator mediator, IMapper mapper)
        {
            _tarefaPersistence = tarefaPersistence;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TarefaDto> Create(TarefaCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TarefaDto> Update(TarefaUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TarefaDto> Delete(TarefaDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<List<TarefaDto>>? GetAll()
        {
            var result = await _tarefaPersistence.FindAll();
            return _mapper.Map<List<TarefaDto>>(result);
        }

        public async Task<TarefaDto>? GetById(Guid id)
        {
            var result = await _tarefaPersistence.Find(id);
            return _mapper.Map<TarefaDto>(result);
        }
    }
}
