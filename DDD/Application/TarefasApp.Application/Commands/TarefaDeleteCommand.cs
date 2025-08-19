using System;
using MediatR;
using TarefasApp.Application.Dtos;

namespace TarefasApp.Application.Commands
{
    public class TarefaDeleteCommand : IRequest<TarefaDto>
    {
        public Guid? Id { get; set; }
    }
}