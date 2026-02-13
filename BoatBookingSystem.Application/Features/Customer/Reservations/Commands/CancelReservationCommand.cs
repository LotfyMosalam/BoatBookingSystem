using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Reservations.Commands
{
    public record CancelReservationCommand(
        int ReservationId,
        int CustomerId
    ) : IRequest<bool>;
}