using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Entities;
using System.Linq.Expressions;

namespace BoatBookingSystem.Application.Interfaces
{
    public interface IBoatRepository
    {
        Task<Boat?> GetByIdAsync(int id);

        Task<List<Boat>> FindAsync(Expression<Func<Boat, bool>> predicate);

        Task AddAsync(Boat boat);

        Task UpdateAsync(Boat boat);

        Task DeleteAsync(Boat boat);
    }
}

