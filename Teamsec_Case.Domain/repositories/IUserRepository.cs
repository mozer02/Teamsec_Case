using Teamsec_Case.Core;
using Teamsec_Case.Domain.models;

namespace Teamsec_Case.Domain.repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByEmail(string username);
    }
}
