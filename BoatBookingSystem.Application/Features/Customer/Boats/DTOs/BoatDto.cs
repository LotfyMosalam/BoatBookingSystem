using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Boats.DTOs
{
    public class BoatDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public int Capacity { get; set; }
    }
}
