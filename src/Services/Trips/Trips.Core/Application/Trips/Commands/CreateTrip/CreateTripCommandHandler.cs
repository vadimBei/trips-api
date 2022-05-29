using MediatR;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Commands.CreateTrip
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, TripVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public CreateTripCommandHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<TripVM> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var createDto = new TripToCreateDto()
            {
                Comment = request.Comment,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                Goal = request.Goal,
                Locations = request.Locations,
                Participants = request.Participants,
                VehicleType = request.VehicleType
            };

            var newTrip = await _tripService
                .CreateTrip(createDto, cancellationToken);

            var tripVM = _mapperService.MapTripToVM(newTrip);

            return tripVM;
        }
    }
}
