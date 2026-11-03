using AutoMapper;
using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Domain.Entities;
using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ExamBookingDto>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<ExamBookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ExamBooking>(request.Booking);
            var createdEntity = await _bookingRepository.AddAsync(entity);
            return _mapper.Map<ExamBookingDto>(createdEntity);
        }
    }
}
