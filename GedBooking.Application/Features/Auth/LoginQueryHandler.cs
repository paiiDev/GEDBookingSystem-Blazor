using GedBooking.Application.Interfaces.Auth;
using GedBooking.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GedBooking.Application.Features.Auth
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string?>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }
        public async Task<string?> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(new GedBooking.Domain.Entities.User { Email = request.Email });
            if (user == null)
            {
                return null; 
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid)
            {
                return null;
            }

            var token = _jwtProvider.GenerateToken(user.Id, user.Email, user.Role); // Assuming role is "User" for simplicity
            return token;
        }
            
    }
}
