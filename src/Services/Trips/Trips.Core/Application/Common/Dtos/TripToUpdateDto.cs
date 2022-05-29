using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Common.Dtos
{
    public class TripToUpdateDto
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
