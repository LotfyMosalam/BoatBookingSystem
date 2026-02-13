using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BoatBookingSystem.Application.Features.Customer.Trips.DTOs;

namespace BoatBookingSystem.Application.Features.Customer.Trips.Queries
{
    public record GetAvailableTripsQuery() : IRequest<List<TripDto>>;

}
