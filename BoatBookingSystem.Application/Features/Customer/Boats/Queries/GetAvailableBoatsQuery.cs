using BoatBookingSystem.Application.Features.Customer.Boats.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Boats.Queries
{
    public record GetAvailableBoatsQuery() : IRequest<List<BoatDto>>;
}
