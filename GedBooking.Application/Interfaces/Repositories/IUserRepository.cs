using GedBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Interfaces.Repositories
{
    public interface IUserRepository 
    {
        Task<User?> GetByEmailAsync(User user);
    }
}
