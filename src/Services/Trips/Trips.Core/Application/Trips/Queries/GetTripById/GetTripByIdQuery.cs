using MediatR;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Queries.GetTripById
{
    public class GetTripByIdQuery : IRequest<TripVM>
    {
        public int Id { get; set; }
    }
}
