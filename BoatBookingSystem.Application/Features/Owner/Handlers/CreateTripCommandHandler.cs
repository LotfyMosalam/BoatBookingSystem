using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Owner.Commands;
using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using MediatR;

namespace BoatBookingSystem.Application.Features.Owner.Handlers
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
    {
        private readonly IRepository<Trip> _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTripCommandHandler(
            IRepository<Trip> tripRepository,
            IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = new Trip
            {
                Name = request.Trip.Name,
                Description = request.Trip.Description,
                PricePerPerson = request.Trip.PricePerPerson,
                Capacity = request.Trip.Capacity,
                BoatId = request.Trip.BoatId,
                OwnerId = request.OwnerId,
                MaxCancellationHours = request.Trip.MaxCancellationHours,
                IsApproved = false
            };

            await _tripRepository.AddAsync(trip);
            await _unitOfWork.SaveChangesAsync();

            return trip.Id;
        }
    }
}
