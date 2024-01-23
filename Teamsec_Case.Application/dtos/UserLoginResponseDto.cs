using System;

namespace Teamsec_Case.Application.dtos
{
    public class UserLoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }
    }
}
