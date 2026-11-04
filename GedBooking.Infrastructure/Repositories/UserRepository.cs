using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Domain.Entities;
using GedBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        }
    }
}
