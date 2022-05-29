using MediatR;
using Trips.Core.Application.Common.Interfaces;

namespace Trips.Core.Application.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand>
    {
        private readonly ITripService _tripService;

        public DeleteTripCommandHandler(
            ITripService tripService)
        {
            _tripService = tripService;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            await _tripService.DeleteTrip(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
