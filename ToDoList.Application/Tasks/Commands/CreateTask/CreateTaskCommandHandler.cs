using ToDoList.Application.Contracts;
using ToDoList.Domain.Classes;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.DomainErrors;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Tasks.Commands.CreateTask
{
    internal sealed class CreateTaskCommandHandler(IUnitOfWork uow) : ICommandHandler<CreateTaskCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var repository = uow.Repository<ToDoTask>();

            var dueDate = request.DueDate;
            if (dueDate < DateTime.Now)
                return Result.Failure<Guid>(DomainErrors.Tasks.InvalidDueDate);

            var toDoTask = new ToDoTask(
                    Guid.NewGuid(),
                    request.Name,
                    request.Description,
                    request.Visibility,
                    request.DueDate
                );

            await repository.AddAsync(toDoTask, cancellationToken);

            if (!await uow.CommitAsync())
                return Result.Failure<Guid>(DomainErrors.Application.InternalError);

            return Result.Success(toDoTask.Id);
        }
    }
}
