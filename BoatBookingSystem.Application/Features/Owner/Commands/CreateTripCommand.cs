using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Owner.DTOs;
using MediatR;

namespace BoatBookingSystem.Application.Features.Owner.Commands
{
    public class CreateTripCommand : IRequest<int>
    {
        public int OwnerId { get; set; }
        public CreateTripRequestDto Trip { get; set; }

        public CreateTripCommand(int ownerId, CreateTripRequestDto trip)
        {
            OwnerId = ownerId;
            Trip = trip;
        }
    }
}

