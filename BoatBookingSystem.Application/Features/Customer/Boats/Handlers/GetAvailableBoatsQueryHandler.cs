using BoatBookingSystem.Application.Features.Customer.Boats.DTOs;
using BoatBookingSystem.Application.Features.Customer.Boats.Queries;
using BoatBookingSystem.Application.Interfaces;
using MediatR;

namespace BoatBookingSystem.Application.Features.Customer.Boats.Handelers
{
    public class GetAvailableBoatsQueryHandler
        : IRequestHandler<GetAvailableBoatsQuery, List<BoatDto>>
    {
        private readonly IBoatRepository _boatRepository;

        public GetAvailableBoatsQueryHandler(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        public async Task<List<BoatDto>> Handle(
            GetAvailableBoatsQuery request,
            CancellationToken cancellationToken)
        {
            var boats = await _boatRepository.FindAsync(b => b.IsApproved);

            return boats.Select(b => new BoatDto
            {
                Id = b.Id,
                Name = b.Name,
                PricePerHour = b.PricePerHour,
                Capacity = b.Capacity
            }).ToList();
        }
    }
}
