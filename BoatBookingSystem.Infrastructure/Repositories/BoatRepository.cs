using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using BoatBookingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Infrastructure.Repositories
{
    public class BoatRepository : IBoatRepository
    {
        private readonly AppDbContext _context;

        public BoatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Boat boat)
        {
            await _context.Boats.AddAsync(boat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Boat boat)
        {
            _context.Boats.Remove(boat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Boat>> FindAsync(Expression<Func<Boat, bool>> predicate)
        {
            return await _context.Boats
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Boat?> GetByIdAsync(int id)
        {
            return await _context.Boats
                .Include(b => b.Trips)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Boat boat)
        {
            _context.Boats.Update(boat);
            await _context.SaveChangesAsync();
        }
    }
}
