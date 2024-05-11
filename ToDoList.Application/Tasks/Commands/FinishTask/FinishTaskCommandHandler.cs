using ToDoList.Application.Contracts;
using ToDoList.Domain.Classes;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.DomainErrors;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Tasks.Commands.FinishTask
{
    internal class FinishTaskCommandHandler(IUnitOfWork uow) : ICommandHandler<FinishTaskCommand, bool>
    {
        public async Task<Result<bool>> Handle(FinishTaskCommand request, CancellationToken cancellationToken)
        {
            var repository = uow.Repository<ToDoTask>();

            var taskId = request.TaskId;

            var toDoTask = await repository.FindByIdAsync(taskId, cancellationToken);

            if (toDoTask is null)
                return Result.Failure<bool>(DomainErrors.Tasks.NotFound(taskId));

            toDoTask.FinishTask();

            await repository.UpdateAsync(toDoTask, cancellationToken);

            if (!await uow.CommitAsync())
                return Result.Failure<bool>(DomainErrors.Application.InternalError);

            return Result.Success(true);
        }
    }
}
