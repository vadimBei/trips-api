using MediatR;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommand: IRequest<TripVM>
    {
        public long Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Comment { get; set; }

        public string Goal { get; set; }

        public List<TripLocationDto> Locations { get; set; }

        public List<TripParticipantDto> Participants { get; set; }

        public TripVehicleType VehicleType { get; set; }
    }
}
