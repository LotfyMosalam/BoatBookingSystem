using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Common;

namespace BoatBookingSystem.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal PricePerPerson { get; set; }

        public int Capacity { get; set; }

        public int MaxCancellationHours { get; set; }

        public int BoatId { get; set; }

        public Boat Boat { get; set; } = null!;

        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; } = null!;

        public bool IsApproved { get; set; } = false;

        public ICollection<AdditionalService>? Services { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}

