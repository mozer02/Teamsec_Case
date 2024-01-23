using Teamsec_Case.Core;
using Teamsec_Case.Domain.models;
using Teamsec_Case.Domain.repositories;
using Teamsec_Case.Persistence.contexts;

namespace Teamsec_Case.Persistence.repositories
{
    public class EFMovieRepository : EFBaseRepository<Movie, AppDbContext>, IMovieRepository
    {
        public EFMovieRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
