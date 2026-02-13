using BoatBookingSystem.Application.Features.Customer.Reservations.Commands;
using BoatBookingSystem.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatBookingSystem.Application.Features.Customer.Reservations.Handlers
{
    public class CancelReservationCommandHandler
        : IRequestHandler<CancelReservationCommand, bool>
    {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationCommandHandler(
            IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> Handle(
            CancelReservationCommand request,
            CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository
                .GetByIdAsync(request.ReservationId);

            if (reservation == null)
                throw new Exception("Reservation not found");

            if (reservation.CustomerId != request.CustomerId)
                throw new Exception("Unauthorized");

            await _reservationRepository.DeleteAsync(reservation);

            return true;
        }
    }
}

