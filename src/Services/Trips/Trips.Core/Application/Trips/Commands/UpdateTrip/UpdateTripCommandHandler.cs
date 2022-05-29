using MediatR;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Commands.UpdateTrip
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, TripVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public UpdateTripCommandHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<TripVM> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var updateDto = new TripToUpdateDto()
            {
                Id = request.Id,
                Comment = request.Comment,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                Goal = request.Goal,
                Locations = request.Locations,
                Participants = request.Participants,
                VehicleType = request.VehicleType
            };

            await _tripService
                .UpdateTrip(updateDto, cancellationToken);

            var trip = await _tripService
                .GetTripById(request.Id, cancellationToken);

            var tripVM = _mapperService.MapTripToVM(trip);

            return tripVM;
        }
    }
}
