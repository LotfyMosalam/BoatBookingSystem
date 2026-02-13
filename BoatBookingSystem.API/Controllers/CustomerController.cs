using BoatBookingSystem.Application.Features.Customer.Boats;
using BoatBookingSystem.Application.Features.Customer.Boats.Queries;
using BoatBookingSystem.Application.Features.Customer.Reservations;
using BoatBookingSystem.Application.Features.Customer.Reservations.Commands;
using BoatBookingSystem.Application.Features.Customer.Trips.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoatBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("trips")]
        public async Task<IActionResult> GetTrips()
        {
            var result = await _mediator.Send(new GetAvailableTripsQuery());
            return Ok(result);
        }

        [HttpGet("boats")]
        public async Task<IActionResult> GetBoats()
        {
            var result = await _mediator.Send(new GetAvailableBoatsQuery());
            return Ok(result);
        }

        [HttpPost("book-trip")]
        public async Task<IActionResult> BookTrip(BookTripCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { ReservationId = id });
        }

        [HttpDelete("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id, [FromQuery] int customerId)
        {
            var result = await _mediator.Send(
                new CancelReservationCommand(id, customerId));

            return Ok(result);
        }
    }
}
