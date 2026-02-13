using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Common;

namespace BoatBookingSystem.Domain.Entities
{
    public class Boat : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Capacity { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsApproved { get; set; } = false;

        public int OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public ICollection<Trip>? Trips { get; set; }
    }
}

