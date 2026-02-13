using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BoatBookingSystem.Infrastructure.Persistence;

namespace BoatBookingSystem.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> FindAsync(
            Expression<Func<Reservation, bool>> predicate)
        {
            return await _context.Reservations
                .Include(r => r.Trip)
                .Include(r => r.ReservationServices)
                .ThenInclude(rs => rs.Service)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Trip)
                .Include(r => r.ReservationServices)
                .ThenInclude(rs => rs.Service)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}

