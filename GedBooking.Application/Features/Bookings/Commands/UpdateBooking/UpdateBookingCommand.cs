using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public ExamBookingDto Booking { get; set; }
        public UpdateBookingCommand(int id, ExamBookingDto booking)
        {
            Id = id;
            Booking = booking;
        }
    }
}
