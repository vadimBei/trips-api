using Common.Data.Helpers;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IMapperService
    {
        List<TripLocation> MapLocationsDtosToEntities(List<TripLocationDto> dtos);

        List<TripParticipant> MapParticipantsDtosToEntities(List<TripParticipantDto> dtos);

        TripVM MapTripToVM(Trip trip);

        PaginatedTripsVM MapTripsToPaginatedTripsVM(PaginatedList<Trip> paginatedTrips);
    }
}
