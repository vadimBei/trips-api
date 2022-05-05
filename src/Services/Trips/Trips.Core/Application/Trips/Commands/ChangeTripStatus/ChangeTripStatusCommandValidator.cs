using FluentValidation;

namespace Trips.Core.Application.Trips.Commands.ChangeTripStatus
{
    public class ChangeTripStatusCommandValidator : AbstractValidator<ChangeTripStatusCommand>
    {
        public ChangeTripStatusCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Id is required");

            RuleFor(c => c.Status)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Status is required");
        }
    }
}
