using FluentValidation;

namespace Trips.Core.Application.Trips.Queries.GetTripById
{
    public class GetTripByIdQueryValidator : AbstractValidator<GetTripByIdQuery>
    {
        public GetTripByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id is reqired");
        }
    }
}
