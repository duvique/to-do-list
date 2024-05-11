using MediatR;
using ToDoList.Domain.Classes;

namespace ToDoList.Application.Contracts
{
    internal interface IQuery<TResult> : IRequest<Result<TResult>>
    {
    }
}
