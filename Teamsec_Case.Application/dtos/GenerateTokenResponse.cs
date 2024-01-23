using System;

namespace Teamsec_Case.Application.dtos
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
