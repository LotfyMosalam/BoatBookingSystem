using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Admin.Commands;
using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using MediatR;

namespace BoatBookingSystem.Application.Features.Admin.Handlers
{
    public class ApproveBoatCommandHandler : IRequestHandler<ApproveBoatCommand, bool>
    {
        private readonly IRepository<Boat> _boatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveBoatCommandHandler(
            IRepository<Boat> boatRepository,
            IUnitOfWork unitOfWork)
        {
            _boatRepository = boatRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ApproveBoatCommand request, CancellationToken cancellationToken)
        {
            var boat = await _boatRepository.GetByIdAsync(request.BoatId);

            if (boat == null)
                throw new Exception("Boat not found.");

            boat.IsApproved = true;

            _boatRepository.Update(boat);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
