using FluentValidation;

namespace Trips.Core.Application.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommandValidator : AbstractValidator<DeleteTripCommand>
    {
        public DeleteTripCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("Id is required");
        }
    }
}
