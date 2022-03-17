using FluentValidation;

namespace Employees.Core.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(c => c.Id)
              .GreaterThan(Guid.Empty)
              .NotNull()
              .NotEmpty()
                  .WithMessage("Id must be set");
        }
    }
}
