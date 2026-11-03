using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<ExamBookingDto>
    {
        public ExamBookingDto Booking { get; set; }
        public CreateBookingCommand(ExamBookingDto booking)
        {
            Booking = booking;
        }
    }
}
