using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BoatBookingSystem.Application.Features.Admin.Commands
{
    public class ApproveBoatCommand : IRequest<bool>
    {
        public int BoatId { get; set; }

        public ApproveBoatCommand(int boatId)
        {
            BoatId = boatId;
        }
    }
}

