using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Admin.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public int Participants { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ReservationDate { get; set; }

        public bool IsCancelled { get; set; }
    }
}

