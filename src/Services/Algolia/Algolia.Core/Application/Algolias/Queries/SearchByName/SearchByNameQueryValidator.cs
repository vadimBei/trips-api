using FluentValidation;

namespace Algolia.Core.Application.Algolias.Queries.SearchByName
{
    public class SearchByNameQueryValidator : AbstractValidator<SearchByNameQuery>
    {
        public SearchByNameQueryValidator()
        {
            RuleFor(с => с.Name)
              .NotEmpty()
              .NotNull()
                   .WithMessage("Name is required");
        }
    }
}
