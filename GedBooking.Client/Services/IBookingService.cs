using GedBooking.Shared.DTOs;

namespace GedBooking.Client.Services
{
    public interface IBookingService
    {
        Task<List<ExamBookingDto>> GetBookingsAsync();
        Task<ExamBookingDto?> GetBookingByIdAsync(int id);
        Task<bool> CreateBookingAsync(ExamBookingDto booking);
        Task<bool> UpdateBookingAsync(int id, ExamBookingDto booking);
        Task<bool> DeleteBookingAsync(int id);
    }
}
