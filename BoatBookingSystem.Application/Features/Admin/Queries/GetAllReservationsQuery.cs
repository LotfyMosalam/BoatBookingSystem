using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Admin.DTOs;
using MediatR;

namespace BoatBookingSystem.Application.Features.Admin.Queries
{
    public class GetAllReservationsQuery : IRequest<List<ReservationDto>>
    {
    }
}
