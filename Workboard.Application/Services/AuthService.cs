using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Application.Helper;
using Workboard.Application.Interfaces;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository_;

        public AuthService(IUserRepository userRepository)
        {
            userRepository_ = userRepository;
        }

        public async Task<List<MemberTypeDTO>> GetMemberType()
        {
            return await userRepository_.GetMemberType();
        }

        public async Task<List<spRetrieveUserListResult>> GetUserList()
        {
           return await userRepository_.GetUserList();
        }

        public async Task<User> LogInUserAsync(string email, string password)
        {
           return await userRepository_.LogInUserAsync(email,password);
        }

        public async Task<int> RegisterUserAsync(RegisterUserDTO userDTO)
        {
            var existing = await userRepository_.GetByEmailAsync(userDTO.EmailAddress);
            if (existing != null)
                throw new Exception("Email already exists");

            var passwordHash = PasswordHashHelper.HashPassword(userDTO.Password);

            var newUser = new User
            {
                FullName = userDTO.FullName,
                EmailAddress = userDTO.EmailAddress,
                Password = passwordHash,
                Role = userDTO.Role,
                CreatedDate = DateTime.Now
            };

            await userRepository_.AddUserAsync(newUser);
            return newUser.Id;
        }
    }
}
