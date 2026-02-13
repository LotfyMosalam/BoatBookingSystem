using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Common;

namespace BoatBookingSystem.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int CustomerId { get; set; }
        public ApplicationUser Customer { get; set; } = null!;

        public int? TripId { get; set; }
        public Trip? Trip { get; set; }

        public int? BoatId { get; set; }
        public Boat? Boat { get; set; }

        public int Participants { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ReservationDate { get; set; }

        public bool IsCancelled { get; set; } = false;

        public ICollection<ReservationService> ReservationServices { get; set; } = new List<ReservationService>();

    }
}

