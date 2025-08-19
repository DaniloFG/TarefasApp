using System.Threading.Tasks;
using MediatR;
using System.Threading;
using AutoMapper;
using TarefasApp.Infra.Storage.Persistence;
using TarefasApp.Infra.Storage.Collections;

namespace TarefasApp.Application.Handlers.Notifications
{
    public class TarefaNotificationHandler : INotificationHandler<TarefaNotification>
    {
        private readonly TarefaPersistence _tarefaPersistence;
        private readonly IMapper _mapper;

        public TarefaNotificationHandler(TarefaPersistence tarefaPersistence, IMapper mapper)
        {
            _tarefaPersistence = tarefaPersistence;
            _mapper = mapper;
        }

        public async Task Handle(TarefaNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case TarefaNotificationAction.TarefaCriada:
                    _tarefaPersistence.Insert(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaAlterada:
                    _tarefaPersistence.Update(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaExcluida:
                    _tarefaPersistence.Delete(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;
            }

            await Task.CompletedTask;
        }
    }
}