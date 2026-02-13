using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Owner.DTOs
{
    public class BoatDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsApproved { get; set; }
    }
}
