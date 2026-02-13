using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Reservations.Commands
{
    public record BookTripCommand(
        int TripId,
        int CustomerId,
        int NumberOfPeople,
        List<int>? ServiceIds
    ) : IRequest<int>;
}


