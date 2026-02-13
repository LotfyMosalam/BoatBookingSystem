using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Common;
using BoatBookingSystem.Domain.Enums;

namespace BoatBookingSystem.Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public UserRole Role { get; set; }

        public bool IsApproved { get; set; } = false;

        public ICollection<Boat>? Boats { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}

