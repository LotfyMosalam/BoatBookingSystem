using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Owner.DTOs;
using MediatR;

namespace BoatBookingSystem.Application.Features.Owner.Commands
{
    public class CreateBoatCommand : IRequest<int>
    {
        public int OwnerId { get; set; }
        public CreateBoatRequestDto Boat { get; set; }

        public CreateBoatCommand(int ownerId, CreateBoatRequestDto boat)
        {
            OwnerId = ownerId;
            Boat = boat;
        }
    }
}

