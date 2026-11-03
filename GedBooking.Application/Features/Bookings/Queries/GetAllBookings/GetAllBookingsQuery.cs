using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IRequest<List<ExamBookingDto>>
    {

    }
}
