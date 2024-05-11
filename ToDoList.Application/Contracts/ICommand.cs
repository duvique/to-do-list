using MediatR;
using ToDoList.Domain.Classes;

namespace ToDoList.Application.Contracts
{
    internal interface ICommand : IRequest<Result>
    {
    }
    internal interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
