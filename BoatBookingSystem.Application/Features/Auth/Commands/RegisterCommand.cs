using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.DTOs.Auth;
using MediatR;

namespace BoatBookingSystem.Application.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<AuthResponseDto>
    {
        public RegisterRequestDto RegisterRequest { get; set; }

        public RegisterCommand(RegisterRequestDto registerRequest)
        {
            RegisterRequest = registerRequest;
        }
    }
}
