using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BoatBookingSystem.Application.Features.Admin.Commands
{
    public class ApproveUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public ApproveUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}

