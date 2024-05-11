using ToDoList.Application.Contracts;
using ToDoList.Domain.Classes;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.DomainErrors;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Tasks.Commands.DeleteTask
{
    internal sealed class DeleteTaskCommandHandler(IUnitOfWork uow) : ICommandHandler<DeleteTaskCommand, bool>
    {
        public async Task<Result<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var repository = uow.Repository<ToDoTask>();

            var taskId = request.TaskId;

            var toDoTask = await repository.FindByIdAsync(taskId, cancellationToken);

            if (toDoTask is null)
                return Result.Failure<bool>(DomainErrors.Tasks.NotFound(taskId));

            await repository.DeleteAsync(toDoTask, cancellationToken);

            if (!await uow.CommitAsync())
                return Result.Failure<bool>(DomainErrors.Application.InternalError);

            return Result.Success(true);
        }
    }
}
