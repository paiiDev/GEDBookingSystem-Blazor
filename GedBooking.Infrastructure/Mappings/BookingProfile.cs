using AutoMapper;
using GedBooking.Infrastructure.Entities;
using GedBooking.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Infrastructure.Mappings
{
    public class BookingProfile : Profile
    {
        public BookingProfile() 
        {
            CreateMap<ExamBooking, ExamBookingDto>().ReverseMap();
        }
    }
}
