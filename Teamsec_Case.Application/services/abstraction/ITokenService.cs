using Teamsec_Case.Application.dtos;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.Application.services.abstraction
{
    public interface ITokenService
    {
        public GenerateTokenResponse GenerateToken(User user);
    }
}
