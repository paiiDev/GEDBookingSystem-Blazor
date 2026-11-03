using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Domain.Entities;
using GedBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GedBooking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamBooking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<ExamBooking?> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<ExamBooking> AddAsync(ExamBooking entity)
        {
            _context.Bookings.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ExamBooking entity)
        {
            _context.Bookings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ExamBooking entity)
        {
            _context.Bookings.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}