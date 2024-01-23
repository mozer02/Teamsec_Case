using Teamsec_Case.Application.dtos;

namespace Teamsec_Case.Application.services.abstraction
{
    public interface IAuthService
    {
        public UserLoginResponse LoginUser(UserLoginRequest request);
        public bool UserRegister(UserRegisterRequestDto dto);

    }
}
