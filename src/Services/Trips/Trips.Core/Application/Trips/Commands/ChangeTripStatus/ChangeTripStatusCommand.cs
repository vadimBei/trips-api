using MediatR;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Trips.Commands.ChangeTripStatus
{
    public class ChangeTripStatusCommand : IRequest<TripVM>
    {
        public long Id { get; set; }

        public TripStatus Status { get; set; }
    }
}
