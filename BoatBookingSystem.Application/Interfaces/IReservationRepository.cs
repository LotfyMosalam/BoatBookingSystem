using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Entities;
using System.Linq.Expressions;

namespace BoatBookingSystem.Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation?> GetByIdAsync(int id);

        Task<List<Reservation>> FindAsync(
            Expression<Func<Reservation, bool>> predicate);

        Task AddAsync(Reservation reservation);

        Task DeleteAsync(Reservation reservation);
    }
}

