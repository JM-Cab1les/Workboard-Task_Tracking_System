using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workboard.Application.DTO;
using Workboard.Application.Helper;
using Workboard.Application.Interfaces;
using Workboard.Domain.DTO;
using Workboard.Domain.SPEntity;

namespace Workboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService_;
        private readonly JwtTokenHelper jwtTokenHelper_;

        public UserController(IAuthService authService, JwtTokenHelper jwtTokenHelper)
        {
            authService_ = authService;
            jwtTokenHelper_ = jwtTokenHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO registerUser)
        {
            try
            {
                var userId = await authService_.RegisterUserAsync(registerUser);
                return Ok(new { Message = "User registered successfully", UserId = userId });
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO loginDTO)
        {
            var user = await authService_.LogInUserAsync(loginDTO.EmailAddress, loginDTO.Password);

            if (user != null)
            {
                var token = await jwtTokenHelper_.GenerateJwtToken(user);

                return Ok(new { message = "Login Successful", token });
            }

            return Unauthorized(new { message = "Invalid Credentials" });
        }

        [HttpGet("MemberType")]
       public async Task<ActionResult<List<MemberTypeDTO>>> GetMemberType()
        {
            return await authService_.GetMemberType();

        }

        [HttpGet("GetUserList")]
        public async Task<ActionResult<List<spRetrieveUserListResult>>> GetUserList()
        {
            return await authService_.GetUserList();

        }
    }
}
