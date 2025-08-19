using TarefasApp.Application.Dtos;
using MediatR;

namespace TarefasApp.Application.Handlers.Notifications
{
    public class TarefaNotification : INotification
    {
        public TarefaDto? Tarefa { get; set; }
        public TarefaNotificationAction Action { get; set; }
    }

    public enum TarefaNotificationAction
    {
        TarefaCriada = 1,
        TarefaAlterada = 2,
        TarefaExcluida = 3
    }
}