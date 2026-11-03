using GedBooking.Domain.Entities;

namespace GedBooking.Application.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<List<ExamBooking>> GetAllAsync();
        Task<ExamBooking?> GetByIdAsync(int id);
        Task<ExamBooking> AddAsync(ExamBooking entity);
        Task UpdateAsync(ExamBooking entity);
        Task DeleteAsync(ExamBooking entity);
    }
}