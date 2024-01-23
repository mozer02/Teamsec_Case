using System.Linq;
using Teamsec_Case.Core;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;
using Teamsec_Case.Persistence.contexts;

namespace Teamsec_Case.Persistence.repositories
{
    public class EFUserRepository : EFBaseRepository<User, AppDbContext>, IUserRepository
    {
        public EFUserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public User GetByEmail(string email)
        {
            return GetQuery(x => x.Email == email).FirstOrDefault();
        }
    }
}
