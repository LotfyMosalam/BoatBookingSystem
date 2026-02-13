using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Domain.Entities;
using System.Linq.Expressions;

namespace BoatBookingSystem.Application.Interfaces
{
    public interface IServiceRepository
    {
        Task<AdditionalService?> GetByIdAsync(int id);

        Task<List<AdditionalService>> FindAsync(
            Expression<Func<AdditionalService, bool>> predicate);

        Task AddAsync(AdditionalService service);
    }
}
