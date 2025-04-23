using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workboard.Application.DTO;
using Workboard.Domain.DTO;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.Application.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterUserAsync(RegisterUserDTO userDTO);

        Task<User> LogInUserAsync(string email, string password);

        public Task<List<MemberTypeDTO>> GetMemberType();

        Task<List<spRetrieveUserListResult>> GetUserList();
    }
}
