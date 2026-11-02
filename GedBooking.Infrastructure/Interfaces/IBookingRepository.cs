using GedBooking.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Infrastructure.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<ExamBookingDto>> GetAllAsync();
        Task<ExamBookingDto?> GetByIdAsync(int id);
        Task<ExamBookingDto> CreateAsync(ExamBookingDto booking);
        Task<bool> UpdateAsync(int id, ExamBookingDto booking);
        Task<bool> DeleteAsync(int id);
    }
}
