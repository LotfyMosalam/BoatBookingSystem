using BoatBookingSystem.Application.Features.Owner.Commands;
using BoatBookingSystem.Application.Features.Owner.DTOs;
using BoatBookingSystem.Application.Features.Owner.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoatBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Owner")]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private int GetOwnerId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        [HttpPost("boats")]
        public async Task<IActionResult> CreateBoat(CreateBoatRequestDto dto)
        {
            var ownerId = GetOwnerId();
            var id = await _mediator.Send(new CreateBoatCommand(ownerId, dto));
            return Ok(new { BoatId = id });
        }

        [HttpPost("trips")]
        public async Task<IActionResult> CreateTrip(CreateTripRequestDto dto)
        {
            var ownerId = GetOwnerId();
            var id = await _mediator.Send(new CreateTripCommand(ownerId, dto));
            return Ok(new { TripId = id });
        }

        [HttpPost("services")]
        public async Task<IActionResult> CreateService(CreateServiceRequestDto dto)
        {
            var ownerId = GetOwnerId();
            var id = await _mediator.Send(new CreateServiceCommand(ownerId, dto));
            return Ok(new { ServiceId = id });
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetReservations()
        {
            var ownerId = GetOwnerId();
            var result = await _mediator.Send(new GetOwnerReservationsQuery(ownerId));
            return Ok(result);
        }

    }
}
