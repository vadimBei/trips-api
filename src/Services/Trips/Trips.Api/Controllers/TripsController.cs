using Common.Kernel.Controllers;
using Microsoft.AspNetCore.Mvc;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Application.Trips.Commands.ChangeTripStatus;
using Trips.Core.Application.Trips.Commands.CreateTrip;
using Trips.Core.Application.Trips.Commands.DeleteTrip;
using Trips.Core.Application.Trips.Commands.UpdateTrip;
using Trips.Core.Application.Trips.Queries.GetApprovedTrips;
using Trips.Core.Application.Trips.Queries.GetTripById;
using Trips.Core.Application.Trips.Queries.GetTrips;

namespace Trips.Api.Controllers
{
    [Route("api/trips")]
    public class TripsController : ApiController
    {
        [HttpPost("create")]
        public async Task<TripVM> CreateTrip(CreateTripCommand command)
            => await Mediator.Send(command);

        [HttpDelete("delete/{id}")]
        public async Task DeleteTrip(long id)
            => await Mediator.Send(
                new DeleteTripCommand()
                {
                    Id = id
                });

        [HttpPost("update")]
        public async Task<TripVM> UpdateTrip(UpdateTripCommand command)
            => await Mediator.Send(command);

        [HttpGet("get/by-id/{id}")]
        public async Task<TripVM> GetTripById(long id)
            => await Mediator.Send(
                new GetTripByIdQuery()
                {
                    Id = id
                });

        [HttpGet("all")]
        public async Task<PaginatedTripsVM> GetTrips([FromQuery] GetTripsQuery query)
            => await Mediator.Send(query);

        [HttpGet("get/approved")]
        public async Task<PaginatedTripsVM> GetApprovedTrips([FromQuery] GetApprovedTripsQuery query)
            => await Mediator.Send(query);

        [HttpPost("change-status")]
        public async Task<TripVM> ChangeTripStatus(ChangeTripStatusCommand command)
            => await Mediator.Send(command);
    }
}
