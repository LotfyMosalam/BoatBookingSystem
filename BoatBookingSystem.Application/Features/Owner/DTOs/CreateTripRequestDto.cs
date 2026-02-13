using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Owner.DTOs
{
    public class CreateTripRequestDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal PricePerPerson { get; set; }

        public int Capacity { get; set; }

        public int BoatId { get; set; }

        public int MaxCancellationHours { get; set; }
    }
}

