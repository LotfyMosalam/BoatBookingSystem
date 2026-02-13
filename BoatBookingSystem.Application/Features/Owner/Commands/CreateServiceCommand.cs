using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Owner.DTOs;
using MediatR;

namespace BoatBookingSystem.Application.Features.Owner.Commands
{
    public class CreateServiceCommand : IRequest<int>
    {
        public int OwnerId { get; set; }
        public CreateServiceRequestDto Service { get; set; }

        public CreateServiceCommand(int ownerId, CreateServiceRequestDto service)
        {
            OwnerId = ownerId;
            Service = service;
        }
    }
}

