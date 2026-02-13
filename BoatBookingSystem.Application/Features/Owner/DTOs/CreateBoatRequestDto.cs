using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Owner.DTOs
{
    public class CreateBoatRequestDto
    {
        public string Name { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerHour { get; set; }

    }
}

