using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User"; 
    }
}
