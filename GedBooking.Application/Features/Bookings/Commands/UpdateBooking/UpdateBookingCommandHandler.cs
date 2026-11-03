using AutoMapper;
using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var existingBooking = await _bookingRepository.GetByIdAsync(request.Booking.Id);
            if (existingBooking == null)
            {
                return false;
            }

            _mapper.Map(request.Booking, existingBooking);
            await _bookingRepository.UpdateAsync(existingBooking);
            return true;
        }
    }
}
