using Microsoft.AspNetCore.Mvc;
using Teamsec_Case.Application.dtos;
using Teamsec_Case.Application.services.abstraction;

namespace Teamsec_Case.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]

        public ActionResult<UserLoginResponse> Login([FromBody] UserLoginRequest request)
        {
            var result = _authService.LoginUser(request);

            return result;
        }
        [HttpPost("Register")]
        public ActionResult<bool> Register([FromBody] UserRegisterRequestDto request)
        {
            var result = _authService.UserRegister(request);

            return result;
        }
    }
}
