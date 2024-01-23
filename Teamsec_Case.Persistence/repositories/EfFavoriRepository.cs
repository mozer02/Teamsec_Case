using Teamsec_Case.Core;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;
using Teamsec_Case.Persistence.contexts;

namespace Teamsec_Case.Persistence.repositories
{
    public class EfFavoriRepository : EFBaseRepository<Favorite, AppDbContext>, IFavoriteRepository
    {
        public EfFavoriRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
