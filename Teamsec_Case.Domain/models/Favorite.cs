using Teamsec_Case.Core;

namespace Teamsec_Case.Domain.models
{
    public class Favorite : Entity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
