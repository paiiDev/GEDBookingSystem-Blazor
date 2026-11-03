using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<ExamBookingDto>>
    {
        private readonly IBookingRepository _bookingRepository;
        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<List<ExamBookingDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetAllAsync();
        }
    }
}
