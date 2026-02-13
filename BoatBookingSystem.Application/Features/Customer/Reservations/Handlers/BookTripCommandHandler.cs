using BoatBookingSystem.Application.Features.Customer.Reservations.Commands;
using BoatBookingSystem.Application.Interfaces;
using BoatBookingSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Reservations.Handlers
{
    public class BookTripCommandHandler
        : IRequestHandler<BookTripCommand, int>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IServiceRepository _serviceRepository;

        public BookTripCommandHandler(
            ITripRepository tripRepository,
            IReservationRepository reservationRepository,
            IServiceRepository serviceRepository)
        {
            _tripRepository = tripRepository;
            _reservationRepository = reservationRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<int> Handle(
            BookTripCommand request,
            CancellationToken cancellationToken)
        {
            var trip = await _tripRepository.GetByIdAsync(request.TripId);

            if (trip == null || !trip.IsApproved)
                throw new Exception("Trip not available");

            if (request.NumberOfPeople > trip.Capacity)
                throw new Exception("Capacity exceeded");

            decimal total = trip.PricePerPerson * request.NumberOfPeople;

            var reservation = new Reservation
            {
                TripId = trip.Id,
                CustomerId = request.CustomerId,
                TotalPrice = total,
                CreatedAt = DateTime.UtcNow
            };

            // Add services
            if (request.ServiceIds != null && request.ServiceIds.Any())
            {
                var services = await _serviceRepository
                    .FindAsync(s => request.ServiceIds.Contains(s.Id));

                foreach (var service in services)
                {
                    reservation.TotalPrice += service.Price;

                    reservation.ReservationServices ??= new List<ReservationService>();
                    reservation.ReservationServices.Add(new ReservationService
                    {
                        ServiceId = service.Id
                    });
                }
            }

            await _reservationRepository.AddAsync(reservation);

            return reservation.Id;
        }
    }
}
