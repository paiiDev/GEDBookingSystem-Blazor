using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<List<ExamBookingDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _bookingRepository.GetAllAsync();
            return entities.Select(_mapper.Map<ExamBookingDto>).ToList();
        }
    }
}
