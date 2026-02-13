using BoatBookingSystem.Application.Features.Admin.Commands;
using BoatBookingSystem.Application.Features.Admin.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoatBookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("approve-user/{id}")]
        public async Task<IActionResult> ApproveUser(int id)
        {
            await _mediator.Send(new ApproveUserCommand(id));
            return Ok("User approved.");
        }

        [HttpPost("approve-boat/{id}")]
        public async Task<IActionResult> ApproveBoat(int id)
        {
            await _mediator.Send(new ApproveBoatCommand(id));
            return Ok("Boat approved.");
        }

        [HttpGet("reservations")]
        public async Task<IActionResult> GetAllReservations()
        {
            var result = await _mediator.Send(new GetAllReservationsQuery());
            return Ok(result);
        }
    }
}
