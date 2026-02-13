using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Entities;
using System.Linq.Expressions;

namespace BoatBookingSystem.Application.Interfaces
{
    public interface ITripRepository
    {
        Task<Trip?> GetByIdAsync(int id);

        Task<List<Trip>> FindAsync(Expression<Func<Trip, bool>> predicate);

        Task AddAsync(Trip trip);

        Task UpdateAsync(Trip trip);

        Task DeleteAsync(Trip trip);
    }
}

