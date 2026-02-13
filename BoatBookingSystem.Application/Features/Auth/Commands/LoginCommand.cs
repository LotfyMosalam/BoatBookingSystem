using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.DTOs.Auth;
using MediatR;

namespace BoatBookingSystem.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<AuthResponseDto>
    {
        public LoginRequestDto LoginRequest { get; set; }

        public LoginCommand(LoginRequestDto loginRequest)
        {
            LoginRequest = loginRequest;
        }
    }
}

