using FluentValidation;

namespace Employees.Core.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(Guid.Empty)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Id must be set");
        }
    }
}
