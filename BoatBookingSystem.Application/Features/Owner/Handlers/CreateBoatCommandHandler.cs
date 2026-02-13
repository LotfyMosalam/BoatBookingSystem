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
    public class CreateBoatCommandHandler : IRequestHandler<CreateBoatCommand, int>
    {
        private readonly IRepository<Boat> _boatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBoatCommandHandler(
            IRepository<Boat> boatRepository,
            IUnitOfWork unitOfWork)
        {
            _boatRepository = boatRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBoatCommand request, CancellationToken cancellationToken)
        {
            var boat = new Boat
            {
                Name = request.Boat.Name,
                Capacity = request.Boat.Capacity,
                PricePerHour = request.Boat.PricePerHour,
                Description = "Default description",
                OwnerId = request.OwnerId,
                IsApproved = false
            };

            await _boatRepository.AddAsync(boat);
            await _unitOfWork.SaveChangesAsync();

            return boat.Id;
        }
    }
}
