using ToDoList.Application.Contracts;
using ToDoList.Domain.Classes;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.DomainErrors;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Tasks.Queries.GetTaskById
{
    internal sealed class GetTaskByIdQueryHandler(IUnitOfWork uow) : IQueryHandler<GetTaskByIdQuery, TaskResponse>
    {
        public async Task<Result<TaskResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = uow.Repository<ToDoTask>();

            var taskId = request.TaskId;

            var toDoTask = await repository.FindByIdAsync(taskId, cancellationToken);

            if (toDoTask is null)
                return Result.Failure<TaskResponse>(DomainErrors.Tasks.NotFound(request.TaskId));

            var toDoTaskResponse = TaskResponse.Map(toDoTask);

            return Result.Success(toDoTaskResponse);
        }
    }
}
