using GedBooking.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<ExamBookingDto>
    {
        public int Id { get; set; }
        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
