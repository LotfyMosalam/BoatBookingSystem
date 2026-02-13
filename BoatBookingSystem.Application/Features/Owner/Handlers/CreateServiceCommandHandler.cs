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
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IRepository<AdditionalService> _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(
            IRepository<AdditionalService> serviceRepository,
            IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new AdditionalService
            {
                Name = request.Service.Name,
                Price = request.Service.Price,
                OwnerId = request.OwnerId
            };

            await _serviceRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();

            return service.Id;
        }
    }
}

