using AutoMapper;
using Common.Data.Helpers;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Application.Common.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(
            IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<TripLocation> MapLocationsDtosToEntities(List<TripLocationDto> dtos)
        {
            var locations = new List<TripLocation>();

            dtos.ForEach(c =>
                locations.Add(new TripLocation()
                {
                    ObjectId = c.ObjectID
                }));

            return locations;
        }

        public List<TripParticipant> MapParticipantsDtosToEntities(List<TripParticipantDto> dtos)
        {
            var participants = new List<TripParticipant>();

            dtos.ForEach(c =>
                participants.Add(new TripParticipant()
                {
                    EmployeeId = c.EmployeeId
                }));

            return participants;
        }

        public PaginatedTripsVM MapTripsToPaginatedTripsVM(PaginatedList<Trip> paginatedTrips)
        {
            var paginatedTripsVM = new PaginatedTripsVM()
            {
                PageIndex = paginatedTrips.PageIndex,
                TotalPages = paginatedTrips.TotalPages,
                HasNextPage = paginatedTrips.HasNextPage,
                HasPreviousPage = paginatedTrips.HasPreviousPage
            };

            paginatedTrips.Items.ForEach(trip =>
                paginatedTripsVM.Items.Add(this.MapTripToVM(trip)));

            return paginatedTripsVM;
        }

        public TripVM MapTripToVM(Trip trip)
        {
            var tripVM = _mapper.Map<TripVM>(trip);

            trip.Participants.ForEach(participant =>
            {
                tripVM.Participants.Add(
                    _mapper.Map<TripParticipantVM>(participant.Employee));
            });

            trip.Locations.ForEach(location =>
            {
                tripVM.Locations.Add(
                    _mapper.Map<TripLocationVM>(location.Location));
            });

            return tripVM;
        }
    }
}
