using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Commands.DeleteBookingC
{
    public class DeleteBookingCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;
        }
    }
}
