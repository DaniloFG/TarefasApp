using MediatR;
using TarefasApp.Application.Commands;
using TarefasApp.Application.Dtos;
using TarefasApp.Application.Handlers.Notifications;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using TarefasApp.Domain.Interfaces.Services;
using TarefasApp.Domain.Entities;
using TarefasApp.Infra.Messages.Producers;
using TarefasApp.Infra.Messages.Models;
using System;
using Newtonsoft.Json;

namespace TarefasApp.Application.Handlers.Requests
{
    public class TarefaRequestHandler :
        IRequestHandler<TarefaCreateCommand, TarefaDto>,
        IRequestHandler<TarefaUpdateCommand, TarefaDto>,
        IRequestHandler<TarefaDeleteCommand, TarefaDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITarefaDomainService _tarefaDomainService;
        private readonly MessageProducer _messageProducer;

        public TarefaRequestHandler(IMediator mediator, IMapper mapper, ITarefaDomainService tarefaDomainService, MessageProducer messageProducer)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tarefaDomainService = tarefaDomainService;
            _messageProducer = messageProducer;
        }

        public async Task<TarefaDto> Handle(TarefaCreateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = _mapper.Map<Tarefa>(request);
            await _tarefaDomainService.Add(tarefa);

            var tarefaDto = _mapper.Map<TarefaDto>(tarefa);

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDto,
                Action = TarefaNotificationAction.TarefaCriada
            };

            await _mediator.Publish(tarefaNotification);

            _messageProducer.SendMessage(new EmailMessageModel
            {
                To = "danilofgama@gmail.com",
                Subject = $"Nova tarefa criada com sucesso em {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}",
                Body = JsonConvert.SerializeObject(tarefaDto, Formatting.Indented)
            });

            return tarefaDto;
        }

        public async Task<TarefaDto> Handle(TarefaUpdateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = _mapper.Map<Tarefa>(request);
            await _tarefaDomainService.Update(tarefa);

            var tarefaDto = _mapper.Map<TarefaDto>(tarefa);

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDto,
                Action = TarefaNotificationAction.TarefaAlterada
            };

            await _mediator.Publish(tarefaNotification);

            return tarefaDto;
        }

        public async Task<TarefaDto> Handle(TarefaDeleteCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaDomainService.GetById(request.Id.Value);
            await _tarefaDomainService.Delete(tarefa);

            var tarefaDto = _mapper.Map<TarefaDto>(tarefa);

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefaDto,
                Action = TarefaNotificationAction.TarefaExcluida
            };

            await _mediator.Publish(tarefaNotification);

            return tarefaDto;
        }
    }
}