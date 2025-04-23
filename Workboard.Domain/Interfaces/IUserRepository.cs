using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        System.Threading.Tasks.Task AddUserAsync(User user);
        Task<User> LogInUserAsync(string email, string password);
        public Task<List<MemberTypeDTO>> GetMemberType();
        Task<List<spRetrieveUserListResult>> GetUserList();
    }
}
