using ToDoList.Application.Contracts;
using ToDoList.Domain.Classes;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Tasks.Queries.GetTasks
{
    internal sealed class GetTasksQueryHandler(IUnitOfWork uow) : IQueryHandler<GetTasksQuery, IEnumerable<TaskResponse>>
    {
        public async Task<Result<IEnumerable<TaskResponse>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var repository = uow.Repository<ToDoTask>();

            var tasks = (await repository.FindAsync(orderBy: (list) => list.OrderByDescending(t => t.CreatedAt), cancellationToken: cancellationToken))
                .Select(t => TaskResponse.Map(t));

            return Result.Success(tasks);
        }
    }
}
