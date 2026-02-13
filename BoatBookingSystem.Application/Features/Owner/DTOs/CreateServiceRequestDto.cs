using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Owner.DTOs
{
    public class CreateServiceRequestDto
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

