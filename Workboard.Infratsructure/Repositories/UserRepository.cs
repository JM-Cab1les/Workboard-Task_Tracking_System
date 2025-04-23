using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workboard.Application.Helper;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.Interfaces;
using Workboard.Domain.SPEntity;
using Workboard.Infratsructure.Contexts;

namespace Workboard.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Workboard_DBContext contexts_;

        public UserRepository(Workboard_DBContext contexts)
        {
            contexts_ = contexts;
        }

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            try
            {
                contexts_.Users.Add(user);
                await contexts_.SaveChangesAsync();
            }catch (Exception ex)
            {

            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await contexts_.Users.FirstOrDefaultAsync(e => e.EmailAddress == email);
        }

        public async Task<List<MemberTypeDTO>> GetMemberType()
        {
            return new List<MemberTypeDTO>
            { 
                new MemberTypeDTO{Id = 1, Value = "User" },
                new MemberTypeDTO{Id = 2, Value = "Manager" },
                new MemberTypeDTO{Id = 3, Value = "Admin" },

            };

        }

        public async Task<List<spRetrieveUserListResult>> GetUserList()
        {
            return await contexts_.Procedures.spRetrieveUserListAsync();
        }

        public async Task<User> LogInUserAsync(string email, string password)
        {
            try
            {
                var existingUser = await contexts_.Users.FirstOrDefaultAsync(u => u.EmailAddress == email);

                if (existingUser == null)
                    return null;

                var isValid = PasswordHashHelper.VerifyPassword(existingUser.Password, password);

                return isValid ? existingUser : null;
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
