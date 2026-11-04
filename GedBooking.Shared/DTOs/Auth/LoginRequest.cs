using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Shared.DTOs.Auth
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
