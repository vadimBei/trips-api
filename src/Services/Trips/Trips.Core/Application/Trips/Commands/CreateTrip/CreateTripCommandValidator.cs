using FluentValidation;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Trips.Commands.CreateTrip
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public CreateTripCommandValidator()
        {
            RuleFor(c => c.Locations.Count)
                .GreaterThan(0)
                    .WithMessage("Trip must include minimum 1 Location");

            RuleFor(c => c.Locations)
                .Must(CheckLocations)
                    .WithMessage("Every ObjectId into Location mustn't be null");

            RuleFor(c => c.Participants.Count)
                .GreaterThan(0)
                    .WithMessage("Trip must include minimum 1 Participant");

            RuleFor(c => c.Participants)
                .Must(CheckParticipants)
                .WithMessage("Every EmployeeId into Participants mustn't be 0");

            RuleFor(c => c)
                .Must(CompareDates)
                .WithMessage("DateTo must be biger than DateFrom");

            RuleFor(c => c.VehicleType)
                .NotNull()
                .NotEmpty()
                .Must(CheckVehicleType)
                .WithMessage("VehicleType is required");

            RuleFor(c => c.Goal)
               .NotNull()
               .NotEmpty()
               .WithMessage("Goal Id is required");
        }

        private bool CheckLocations(List<TripLocationDto> tripLocations)
        {
            var emptyLocations = tripLocations.Where(location => string.IsNullOrEmpty(location.ObjectID)
                                                              || string.IsNullOrWhiteSpace(location.ObjectID));

            return !emptyLocations.Any();
        }

        private bool CheckParticipants(List<TripParticipantDto> tripParticipants)
        {
            var emptyParticipants = tripParticipants.Where(participant => participant.EmployeeId == Guid.Empty);

            return !emptyParticipants.Any();
        }

        private bool CompareDates(CreateTripCommand command)
        {
            return command.DateFrom.Date <= command.DateTo.Date;
        }

        private bool CheckVehicleType(TripVehicleType vehicleType)
        {
            var valid = false;

            if (vehicleType == TripVehicleType.CompanyCar
                || vehicleType == TripVehicleType.CompanyBus
                || vehicleType == TripVehicleType.Airplane
                || vehicleType == TripVehicleType.Bus
                || vehicleType == TripVehicleType.Train
                || vehicleType == TripVehicleType.OwnCar)
            {
                valid = true;
            }

            return valid;
        }
    }
}
