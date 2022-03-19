using FluentValidation;

namespace Algolia.Core.Application.Algolias.Queries.SearchByObjectId
{
    public class SearchByObjectIdQueryValidator : AbstractValidator<SearchByObjectIdQuery>
    {
        public SearchByObjectIdQueryValidator()
        {
            RuleFor(с => с.ObjectId)
              .NotEmpty()
              .NotNull()
                   .WithMessage("ObjectId is required");
        }
    }
}
