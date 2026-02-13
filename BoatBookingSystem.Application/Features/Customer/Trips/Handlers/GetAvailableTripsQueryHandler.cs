using BoatBookingSystem.Application.Features.Customer.Trips.DTOs;
using BoatBookingSystem.Application.Features.Customer.Trips.Queries;
using BoatBookingSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Trips.Handlers
{
    public class GetAvailableTripsQueryHandler
        : IRequestHandler<GetAvailableTripsQuery, List<TripDto>>
    {
        private readonly ITripRepository _tripRepository;

        public GetAvailableTripsQueryHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<List<TripDto>> Handle(
            GetAvailableTripsQuery request,
            CancellationToken cancellationToken)
        {
            var trips = await _tripRepository.FindAsync(t => t.IsApproved);

            return trips.Select(t => new TripDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                PricePerPerson = t.PricePerPerson,
                Capacity = t.Capacity
            }).ToList();
        }
    }
}
