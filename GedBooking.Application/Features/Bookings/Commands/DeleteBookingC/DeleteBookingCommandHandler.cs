using GedBooking.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.DeleteBookingC
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var existingBooking = await _bookingRepository.GetByIdAsync(request.Id);
            if (existingBooking == null)
            {
                return false; 
            }
            await _bookingRepository.DeleteAsync(existingBooking);
            return true; 
        }
    
    }
}
