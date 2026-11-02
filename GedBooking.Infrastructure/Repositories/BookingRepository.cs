using AutoMapper;
using GedBooking.Infrastructure.Data;
using GedBooking.Infrastructure.Entities;
using GedBooking.Infrastructure.Interfaces;
using GedBooking.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExamBookingDto>> GetAllAsync()
        {
            var entities = await _context.Bookings.ToListAsync();
            return _mapper.Map<List<ExamBookingDto>>(entities);
        }

        public async Task<ExamBookingDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Bookings.FindAsync(id);
            return entity == null ? null : _mapper.Map<ExamBookingDto>(entity);
        }

        public async Task<ExamBookingDto> CreateAsync(ExamBookingDto booking)
        {
            var entity = _mapper.Map<ExamBooking>(booking);
            _context.Bookings.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamBookingDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, ExamBookingDto updated)
        {
            var existing = await _context.Bookings.FindAsync(id);
            if (existing == null) return false;

            _mapper.Map(updated, existing);
      
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
