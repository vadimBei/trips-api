using MediatR;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Commands.ChangeTripStatus
{
    public class ChangeTripStatusCommandHandler : IRequestHandler<ChangeTripStatusCommand, TripVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public ChangeTripStatusCommandHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<TripVM> Handle(ChangeTripStatusCommand request, CancellationToken cancellationToken)
        {
            await _tripService
                .ChangeTripStatus(request.Id, request.Status, cancellationToken);

            var trip = await _tripService
                .GetTripById(request.Id, cancellationToken);

            var tripVM = _mapperService.MapTripToVM(trip);

            return tripVM;
        }
    }
}
