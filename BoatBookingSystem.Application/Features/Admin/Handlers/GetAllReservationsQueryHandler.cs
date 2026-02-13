using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatBookingSystem.Application.Features.Admin.DTOs;
using BoatBookingSystem.Application.Features.Admin.Queries;
using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using MediatR;

namespace BoatBookingSystem.Application.Features.Admin.Handlers
{
    public class GetAllReservationsQueryHandler
        : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<ApplicationUser> _userRepository;

        public GetAllReservationsQueryHandler(
            IRepository<Reservation> reservationRepository,
            IRepository<ApplicationUser> userRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }

        public async Task<List<ReservationDto>> Handle(
            GetAllReservationsQuery request,
            CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();
            var users = await _userRepository.GetAllAsync();

            var result = reservations.Select(r =>
            {
                var customer = users.FirstOrDefault(u => u.Id == r.CustomerId);

                return new ReservationDto
                {
                    Id = r.Id,
                    CustomerName = customer?.FullName ?? "Unknown",
                    Participants = r.Participants,
                    TotalPrice = r.TotalPrice,
                    ReservationDate = r.ReservationDate,
                    IsCancelled = r.IsCancelled
                };
            }).ToList();

            return result;
        }
    }
}

