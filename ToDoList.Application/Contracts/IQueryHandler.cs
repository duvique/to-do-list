using MediatR;
using ToDoList.Domain.Classes;

namespace ToDoList.Application.Contracts
{
    internal interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {

    }
}
