using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Common;

namespace BoatBookingSystem.Domain.Entities
{
    public class AdditionalService : BaseEntity
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int OwnerId { get; set; }

        public ApplicationUser Owner { get; set; } = null!;

        public int? TripId { get; set; }

        public Trip? Trip { get; set; }

        public ICollection<ReservationService>? ReservationServices { get; set; }
    }
}

