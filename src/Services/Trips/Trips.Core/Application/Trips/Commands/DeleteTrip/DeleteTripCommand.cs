using MediatR;

namespace Trips.Core.Application.Trips.Commands.DeleteTrip
{
    public class DeleteTripCommand : IRequest
    {
        public long Id { get; set; }
    }
}
