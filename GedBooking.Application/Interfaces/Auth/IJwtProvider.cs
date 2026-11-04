using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(int userId, string email, string role);
    }
}
