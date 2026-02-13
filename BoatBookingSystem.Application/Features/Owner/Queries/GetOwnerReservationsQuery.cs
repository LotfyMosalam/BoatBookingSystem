using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Admin.DTOs;
using MediatR;

namespace BoatBookingSystem.Application.Features.Owner.Queries
{
    public class GetOwnerReservationsQuery : IRequest<List<ReservationDto>>
    {
        public int OwnerId { get; set; }

        public GetOwnerReservationsQuery(int ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
