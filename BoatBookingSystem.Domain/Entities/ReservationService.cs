using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Domain.Entities
{
    public class ReservationService
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public int ServiceId { get; set; }
        public AdditionalService Service { get; set; } = null!;
    }
}

