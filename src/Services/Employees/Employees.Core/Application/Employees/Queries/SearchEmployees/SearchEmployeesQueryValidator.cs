using FluentValidation;

namespace Employees.Core.Application.Employees.Queries.SearchEmployees
{
    public class SearchEmployeesQueryValidator : AbstractValidator<SearchEmployeesQuery>
    {
        public SearchEmployeesQueryValidator()
        {
            //RuleFor(c => c.Pattern)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("Pattern is required");
        }
    }
}
