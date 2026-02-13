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
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AdditionalService service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AdditionalService>> FindAsync(
            Expression<Func<AdditionalService, bool>> predicate)
        {
            return await _context.Services
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<AdditionalService?> GetByIdAsync(int id)
        {
            return await _context.Services
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

